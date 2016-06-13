var toggleActive = function (type) {
    console.log(type);
    if (type == "login") {
        $("#loginHeader").addClass("active");
        $(".content-wrapper.login").addClass("active");
        $("#registerHeader").removeClass("active");
        $(".content-wrapper.register").removeClass("active");
    } else {
        $("#loginHeader").removeClass("active");
        $(".content-wrapper.login").removeClass("active");
        $("#registerHeader").addClass("active");
        $(".content-wrapper.register").addClass("active");
    }
}

$(document).ready(function () {
    //trigger popup open
    $(".user_trigger").leanModal(
    {
        top: 100,
        overlay: 0.6,
        closeButton: ".modal_close"
    });

    //Set Right View
    $(".user_trigger").on("click", function () { toggleActive(this.innerText.toLowerCase()); });
    $(".header_title").on("click", function () { toggleActive(this.innerText.toLowerCase()); });
    

    $(function ()
    {
        // clear inputs
        $(".clear").click(function ()
        {
            $("#emailUser").val("");
            $("#passwordUser").val("");
            $("#confirmPassword").val("");
            return false;
        });
    });

    $(function () {
        var isOpen = false;
        // clear inputs
        $(".clear").click(function () {
            $("#username").val("");
            $("#password").val("");
            return false;
        });

        //forgot Password Toggle
        $(".forgot_password").click(function () {
            if (!isOpen) {
                $(".forgot_password_section").show();
                isOpen = !isOpen;
            }
            else {
                $(".forgot_password_section").hide();
                isOpen = !isOpen;
            }

            $(".last button").on("click", function () {
                debugger;
            });

            return false;
        });
    });

});