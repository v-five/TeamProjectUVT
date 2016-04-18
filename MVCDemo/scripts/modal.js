$(document).ready(function () {

    // Plugin options and our code
    $("#modal_trigger").leanModal({
        top: 100,
        overlay: 0.6,
        closeButton: ".modal_close"
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