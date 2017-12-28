$(document).ready(function (e) {
    $(".LogInLink").on("click", function () {
        debugger;
        $("#LoginModal").modal('show');
    });


    $("#LogInButton").on("click", function () {
        debugger;
        $.ajax({
            type: "post",
            url: "/Home/LogIn",
            ajaxasync: true,
            dataType: 'json',
            data: {
                Username: $("#UserName").val(),
                Password: $("#Password").val()
            },
            success: function (data) {
                $('#LoginModal').modal('hide');
                window.location.href = data.redirecturl;

            },
            error: function (data) {

                $("#showErrorMessage1").text("Login failed, check details");
              
            }
        });
    });

    $("#CancelButton").on("click", function () {

        $("#LogInBtnModal").modal("hide");
        window.location.reload();

    });
});