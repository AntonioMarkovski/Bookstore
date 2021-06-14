// Wait for the DOM to be ready, analogno na document ready vo book.js
$(function () {
    // Init form validation on book create form
    // by "name" attribute
    $("form[name='bookcreate']").validate({
        success: "valid",
        onkeyup: true, // validation as we type data in the fields
        focusInvalid: true, // focus field when invalid
        errorClass: "error", // adding error class on element -> define error class in css
        highlight: function (element, errorClass) { // highlight fields when error
            $(element).fadeOut(function () { // add fade out and fade in on field + error class
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },

        // Specify validation rules
        rules: {
            BookTitle: {
                required: true,
                minlength: 2
            },
            YearOfIssue: "required",
            NumberOfPages: {
                required: true,
                number: true,
                digits: true,
                min: 10
            },
            Genre: "required",
            PublisherID: {
                required: true,
                min: 1
            },
            CategoryID: {
                required: true,
                min: 1
            },
            AuthorID: {
                required: true,
                min: 1
            },
            Price: {
                required: true,
                number: true,
                digits: true
            },
            BookType: "required",
            BookCoverType: "required",
            Copies: {
                required: true,
                number: true,
                digits: true
            },
            Dimensions: "required",
            Edition: {
                required: true,
                number: true,
                digits: true,
                min: 1
            },
            Language: "required",
            Shipping: "required",
            Weight: {
                required: true,
                number: true,
                digits: true
            },
            Country: "required",
            Description: "required",
            SoldItems: {
                required: true,
                number: true,
                digits: true
            },
            Rating: "required"
        },

        // Specify validation error messages
        messages: {
            BookTitle: {
                required: "Please enter title",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
            YearOfIssue: "Please enter year of issue",
            NumberOfPages: {
                required: "Please enter number of pages",
                number: "Please enter numbers only",
                digits: "Only digits are allowed in this field",
                min: jQuery.validator.format("At least number {0} required")
            },
            Genre: "Please enter genre of the the book",
            PublisherID: {
                required: "Please choose publisher, or create a new one",
                min: "Please select one publihser from the dropdown"
            },
            CategoryID: {
                required: "Please choose category, or create a new one",
                min: "Please select one category from the dropdown"
            },
            AuthorID: {
                required: "Please choose author, or create a new one",
                min: "Please select one author from the dropdown"
            },
            Price: {
                required: "Please enter the price of the book",
                number: "Please enter numbers only",
                digits: "Only digits are allowed in this field",
            },
            BookType: "Please enter book type",
            BookCoverType: "Please enter book cover type",
            Copies: {
                required: "Please enter the copies of the book",
                number: "Please enter numbers only",
                digits: "Only digits are allowed in this field",
            },
            Dimensions: "Please enter dimensions of the book",
            Edition: {
                required: "Please enter the edition of the book",
                number: "Please enter numbers only",
                digits: "Only digits are allowed in this field",
                min: jQuery.validator.format("At least number {0} required")
            },
            Language: "Please enter the language of the book",
            Shipping: "Please enter shipping",
            Weight: {
                required: "Please enter the weight of the book",
                number: "Please enter numbers only",
                digits: "Only digits are allowed in this field",
            },
            Country: "Please enter country of origin",
            Description: "Please enter description of the book",
            SoldItems: {
                required: "Please enter the sold items of the book",
                number: "Please enter numbers only",
                digits: "Only digits are allowed in this field",
            },
            Rating: "Please enter the rating of the book"
        },

        submitHandler: function (form) {
            form.submit();
        }
    });

    // *** author create form

    $("form[name='createauthor']").validate({
        success: "valid",
        onkeyup: true,
        focusInvalid: true,
        errorClass: "error",
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        rules: {
            Name: {
                required: true,
                minlength: 3
            },
            Country: "required",
            DateBirth: "required",
            ShortDescription: "required",
            Language: "required",
            Gender: "required"
        },
        messages: {
            Name: {
                required: "Please enter the name of the category",
                min: jQuery.validator.format("At least number {0} required")
            },
            Country: "Please enter author country",
            DateBirth: "Please enter author date of birth",
            ShortDescription: "Please enter short description about the author",
            Language: "Please enter author language",
            Gender: "Please enter author gender"
        }
    });

    // *** category create form

    $("form[name='createcategory']").validate({
        success: "valid",
        onkeyup: true,
        focusInvalid: true,
        errorClass: "error",
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        rules: {
            Name: {
                required: true,
                minlength: 3
            }
        },
        messages: {
            Name: {
                required: "Please enter the name of the category",
                min: jQuery.validator.format("At least number {0} required")
            }
        }
    });

    // *** publisher create form

    $("form[name='createpublisher']").validate({
        success: "valid",
        onkeyup: true,
        focusInvalid: true,
        errorClass: "error",
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        rules: {
            Name: {
                required: true,
                minlength: 2
            },
            Country: {
                required: true,
                minlength: 2
            },
            Year: "required",
        },
        messages: {
            Name: {
                required: "Please enter the name of the publisher",
                min: jQuery.validator.format("At least number {0} required")
            },
            Country: {
                required: "Please enter the country of the publisher",
                min: jQuery.validator.format("At least number {0} required")
            },
            Year: {
                required: "Please enter the year of the publisher"
            }
        }
    });

});