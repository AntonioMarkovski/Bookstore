$(document).ready(function () {
    console.log("Document Ready from included JS Script | book.js");
});

$("#AuthorID").change(function () {
    var optionSelected = $("option:selected", this);
    //console.log(optionSelected);
    // javascript -> var getVal = document.getElementById("AuthorName").value;
    // jquery -> $("#AuthorName").val();
    // *** 1st case for getting the name
    var optionName1 = optionSelected[0].innerHTML;
    //console.log("OptionName 1: " + optionName1);

    // *** 2nd case for getting the name
    var optionName2 = optionSelected.text();
    //console.log("OptionName 2: " + optionName2);

    $("#AuthorName").val(optionName2);
    //console.log("AuthorName: " + $("#AuthorName").val());
});

$("#PublisherID").change(function () {
    var optionSelected = $("option:selected", this);
    var optionName = optionSelected.text();
    $("#PublisherName").val(optionName);
});

$("#CategoryID").change(function () {
    var optionSelected = $("option:selected", this);
    var optionName = optionSelected.text();
    $("#CategoryName").val(optionName);
});

$("#addNewAuthor").click(function () {

    var data = {
        Name: $("#AuthorNameDTO").val(),
        Country: $("#AuthorCountryDTO").val(),
        DateBirth: $("#AuthorDateBirthDTO").val(),
        ShortDescription: $("#AuthorShortDescriptionDTO").val(),
        Language: $("#AuthorLanguageDTO").val(),
        Gender: $("#AuthorGenderDTO").val()
    };

    $.ajax({
        type: "POST",
        url: "/Author/CreateAuthorAJAX",
        data: data,
        dataType: "json",
        success: function (data) {
            if (data.data == '') {
                $('#authorModal').modal('toggle');
                setTimeout(() => {
                    alert("Error: Author has NOT been added! Please enter data in all the fields!");
                }, 500);
            } else {
                $("#AuthorID").append("<option value=" + data.data.id + ">" + data.data.name + "</option>");
                $("#AuthorID").val(data.data.id);
                var newOptionSelected = $("#AuthorID option:selected").text();
                $("#AuthorName").val(newOptionSelected);
                $('#authorModal').modal('toggle');
            }
        },
        error: function () { alert("Error Adding New Author!"); }
    });
});

$("#addNewPublisher").click(function () {

    var data = {
        Name: $("#PublisherNameDTO").val(),
        Country: $("#PublisherCountryDTO").val(),
        Year: $("#PublisherYearDTO").val()
    };

    $.ajax({
        type: "POST",
        url: "/Publisher/CreatePublisherAJAX",
        data: data,
        dataType: "json",
        success: function (data) {
            if (data.data == '') {
                $('#publisherModal').modal('toggle');
                setTimeout(() => {
                    alert("Error: Publisher has NOT been added! Please enter data in all the fields!");
                }, 500);
            } else {
                $("#PublisherID").append("<option value=" + data.data.id + ">" + data.data.name + "</option>");
                $("#PublisherID").val(data.data.id);
                var newOptionSelected = $("#PublisherID option:selected").text();
                $("#PublisherName").val(newOptionSelected);
                $('#publisherModal').modal('toggle');
            }
        },
        error: function () { alert("Error Adding New Publisher!"); }
    });
});

$("#addNewCategory").click(function () {

    var data = { Name: $("#CategoryNameDTO").val() };

    $.ajax({
        type: "POST",
        url: "/Category/CreateCategoryAJAX",
        data: data,
        dataType: "json",
        success: function (data) {
            if (data.data == '') {
                $('#categoryModal').modal('toggle');
                setTimeout(() => {
                    alert("Error: Category has NOT been added! Please enter data in all the fields!");
                }, 500);
            } else {
                $("#CategoryID").append("<option value=" + data.data.id + ">" + data.data.name + "</option>");
                $("#CategoryID").val(data.data.id);
                var newOptionSelected = $("#CategoryID option:selected").text();
                $("#CategoryName").val(newOptionSelected);
                $('#categoryModal').modal('toggle');
            }
        },
        error: function () { alert("Error Adding New Category!"); }
    });
});

$("#uploadPhoto").click(function () {
    var data = new FormData();
    var files = $("#photoUpload").get(0).files;

    if (files.length > 0) { data.append("UploadedImage", files[0]); }

    $.ajax({
        type: "POST",
        url: "/Book/UploadPhoto",
        data: data,
        contentType: false,
        processData: false,
        success: function (data) {
            $("#PhotoURL").val(data.dbPath);
        },
        error: function () {
            alert("Error Uploading Photo!");
        }
    });
});