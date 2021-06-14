$(document).ready(function () {
    //$.ajax({
    //    type: "GET",
    //    url: "/Book/GetAllBooksAJAX/",
    //    success: function (data) {
    //        console.log(data);
    //        /*console.log(data.booksData[4].title);*/
    //       /* $("#bookTitleFromJSON").val(data.booksData[4].title);*/
    //    },
    //    error: function () {
    //        alert("Error getting all books!");
    //    }
    //})

    GetQuotes();

    //GetRandomBook(); // uncomment this to ping the internal API for random book

    setInterval(() => {
        GetQuotes();
    }, 5000);

    //setInterval(() => {  // uncomment this function to ping API every 7 sec
    //    GetRandomBook();
    //}, 7000);

});

function GetQuotes() {
    $.ajax({
        type: "GET",
        url: "/Home/GetQuotes/",
         //url: "https://type.fit/api/quotes",
        success: function (data) {
            $("#quote").text("\" " + data.quotes[0].quote + "\"");
            $("#quote_author").text(data.quotes[0].author);

            var quoteTags = data.quotes[0].tags;
            var tagsString = "";

            quoteTags.forEach(item => {
                var lastItem = quoteTags[quoteTags.length - 1];
                tagsString += item == lastItem ? item + "" : item + ","
            });

            $("#quote_tags").text(tagsString);         
        },
        error: function () {
            console.log("error");

            // ******** error handling -> in case of external API stops, ping in our DB

            //$.ajax({
            //    type: "GET",
            //    url: "https://localhost:6001/api/quote/randomquote",
            //    success: function (data) {
            //        $("#quote").text("\" " + data.quotes[0].quote + "\"");
            //        $("#quote_author").text(data.quotes[0].author);

            //        var quoteTags = data.quotes[0].tags;
            //        var tagsString = "";

            //        quoteTags.forEach(item => {
            //            var lastItem = quoteTags[quoteTags.length - 1];
            //            tagsString += item == lastItem ? item + "" : item + ","
            //        });

            //        $("#quote_tags").text(tagsString);         
            //    },
            //    error: function () {
            //        alert("Error");
            //    }
            //})
        }
    })
}

function GetRandomBook() {
    $.ajax({
        type: "GET",
        url: "https://localhost:6001/api/book/randombook",
        success: function (data) {
            console.log(data); 
        },
        error: function () {
            //alert("Error");
            console.log("Error");
        }
    })
}

function AddToWishlist(id) {
    $.ajax({
        type: "POST",
        url: "/Home/AddToWishlist/" + id,
        success: function (data) {
            //console.log(data);
            if (data.data != "") {
                new Noty({
                    type: 'alert',
                    layout: 'bottomLeft',
                    timeout: 3000,
                    text: 'Successfully Added To Wishlist',
                    theme: 'sunset'
                }).show();
            } else {
                new Noty({
                    type: 'error',
                    layout: 'bottomLeft',
                    timeout: 3000,
                    progressBar: true,
                    text: 'Book Already Exists In The Wishlist',
                    theme: 'sunset'
                }).show();
            }
        },
        error: function () {
            alert("error");
        }
    });
};

function AddToCart(id) {
    $.ajax({
        type: "POST",
        url: "/ShoppingCart/AddToCart/" + id,
        success: function (data) {
            console.log("Success");
            console.log(data);
            new Noty({
                type: 'success',
                layout: 'bottomLeft',
                timeout: 3000,
                text: 'Added To Cart',
                theme: 'sunset'
            }).show();
        },
        error: function () {
            alert("error");
        }
    });
}
