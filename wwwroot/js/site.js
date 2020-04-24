// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#loginButton").click(function () {
    var userName = $("#userNameInput").val();
    var userPassword = $("#userPasswordInput").val();
    var loginMessageResult = $("#loginMessageResult");

    $.ajax({
        type: "GET",
        url:location.origin +"/Home/UserLogin",
        data: {
            userName: userName,
            userPassword: userPassword
        },
        contentType: "application/json",
        dataType: "json"
    }).done(function (response) {
        if (typeof response.ResultCode === 'undefined') { // successfully login
            loginMessageResult.removeClass("alert-danger").addClass("alert-success");
            loginMessageResult.text("Entity details: " + JSON.stringify(response));
        } else { // login failed
            loginMessageResult.removeClass("alert-success").addClass("alert-danger");
            loginMessageResult.text("Code: " + response.ResultCode + ",  Details: " + response.ResultMessage);
        }
    }).fail(function (response) {
        loginMessageResult.removeClass("alert-success").addClass("alert-danger");
        loginMessageResult.text("Server error [" + response.status + "]");
    }).always(function () {
        loginMessageResult.removeClass("d-none");
    });
});