

$(document).ready(function (e) {

    //$( "#CreateModal" ).dialog({
    //    autoOpen: false,
    //    height: 400,
    //    width: 350,
    //    modal: true
    //})


            $(".deleteLink").on("click", function (id) {

                var deleteLinkId = $(this).prop("id")
                $("#deletebookId").val(deleteLinkId)
                $("#deleteModal").modal("show");

            });

            $("#YesButton").on("click", function () {
              
                //e.preventDefault();
                var bookId = $("#deletebookId").val()

                $.ajax({
                    type: "post",
                    url: "/Book/Delete?id=" + bookId,
                    ajaxasync: true,

                    success: function (data) {

                        // alert("successfully deleted");
                        $('#deleteModal').modal('hide');
                        window.location.reload();

                    },
                    error: function (data) {
                        alert(data.x);
                    }
                });
            });

            $(".UpdateLink").on("click", function (id) {
               
                var BookId = $(this).prop("id")
                UpdateBookDetails(BookId);
            });


            $("#SaveButton").on("click", function () {

                var bookId = $("#BookId").val()

                $.ajax({
                    type: "post",
                    url: "/Book/AddBook",
                    ajaxasync: true,
                    dataType: 'json',
                    data: {
                        Id: bookId,
                        Isbn: $("#BookIsbn").val() ,
                        Title: $("#BookTitle").val(),
                        Author: $("#BookAuthor").val(),
                        Price: $("#BookPrice").val()
                    },

                    success: function (data) {

                        $('#UpdateModal').modal('hide');
                        window.location.reload();

                    },
                    error: function (data) {
                        alert("Error in Updating Book");

                    }
                });
            });


            $(".CreateLink").on("click", function () {

                  $('#CreateModal').modal('show');
                //$("#CreateModal").dialog("open");

            });

            $("#AddButton").on("click", function (){

                if(ValidateBookData() == false) 
                {

                    $("#showErrorMessage").text("Please insert all book details");
                    $("#CreateBookTitle").addClass("is-invalid");
                    $("#CreateBookAuthor").addClass("is-invalid");
                    $("#CreateBookPublish").addClass("is-invalid");
                    $("#CreateBookPrice").addClass("is-invalid");
                    $("#CreateBookIsbn").addClass("is-invalid");
                }

                else {

                    $.ajax({
                        type: "post",
                        url: "/Book/AddBook",
                        ajaxasync: true,
                        dataType: 'json',
                        data: {
                            Isbn: $("#CreateBookIsbn").val(),
                            Title: $("#CreateBookTitle").val(),
                            Author: $("#CreateBookAuthor").val(),
                            Publish: $("#CreateBookPublish").val(),
                            Price: $("#CreateBookPrice").val()
                        },
                        success: function (data) {

                            $('#UpdateModal').modal('hide');
                            window.location.reload();

                        },
                        error: function (data) {
                            alert(data.x);
                        }
                    });
                }

                });
            

        });

function UpdateBookDetails(id) {

    var BookId = id;

    
    $.ajax({
        type: 'GET',
        url: "/Book/Update?id=" + BookId,
        dataType: 'json',

        success: function (data) {

            var newDate = new Date(parseInt(data.Publish.substr(6)));
            //var PublishDate = newDate.format("dd/mm/yyyy")

            var day = ("0" + newDate.getDate()).slice(-2);
            var month = ("0" + (newDate.getMonth() + 1)).slice(-2);
            var PublishDate = newDate.getFullYear() + "-" + (month) + "-" + (day)

            $("#BookId").val(BookId)
            $("#BookIsbn").val(data.Isbn)
            $("#BookTitle").val(data.Title)
            $("#BookAuthor").val(data.Author)
            $("#BookPrice").val(data.Price)
            $("#BookPublish").val(PublishDate)
            $('#UpdateModal').modal('show');

        },
        error: function (data) {
            alert('error');
        }
    });
}

function ValidateBookData() {

    debugger;

    var BookTitle = $("#CreateBookTitle").val()
    var BookAuthor = $("#CreateBookAuthor").val()
    var BookPublish = $("#CreateBookPublish").val()
    var BookPrice = $("#CreateBookPrice").val()

    if (BookTitle == "" || BookAuthor == "" || BookPublish == "" || BookPrice == "") {

        return false;
    }
}

