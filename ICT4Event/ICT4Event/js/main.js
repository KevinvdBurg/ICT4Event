$(document).ready(function () {

    var hoverActive;

    $("#i-incheck").hover(function () {
        hoverActive = "incheck";
        //$(".sub-navbar").css('display', 'block');
    }, function () {
        //$(".sub-navbar").css('display', 'none');
    });


    $("#i-account").hover(function () {
        hoverActive = "account";
        $(".sub-navbar").css('display', 'block');
        removeSub();
        $(".sub-account").css('display', 'block');

    }, function () {
        $(".sub-navbar").css('display', 'none');
        removeSub();
    });

    $("#i-reververingen").hover(function () {
        hoverActive = "reververingen";
        $(".sub-navbar").css('display', 'block');
        removeSub();
        $(".sub-reververingen").css('display', 'block');
    }, function () {
        $(".sub-navbar").css('display', 'none');
        removeSub();
    });

    $("#i-event").hover(function () {
        hoverActive = "event";
        $(".sub-navbar").css('display', 'block');
        removeSub();
        $(".sub-event").css('display', 'block');
    }, function () {
        $(".sub-navbar").css('display', 'none');
        removeSub();
    });

    $("#i-post").hover(function () {
        hoverActive = "post";
        $(".sub-navbar").css('display', 'block');
        removeSub();
        $(".sub-post").css('display', 'block');
    }, function () {
        $(".sub-navbar").css('display', 'none');
        removeSub();
    });

    $("#i-opties").hover(function () {
        hoverActive = "opties";
        $(".sub-navbar").css('display', 'block');
        removeSub();
        $(".sub-opties").css('display', 'block');
    }, function () {
        $(".sub-navbar").css('display', 'none');
        removeSub();
    });

    $(".sub-navbar").hover(function () {
        $(".sub-navbar").css('display', 'block');

        if (hoverActive == "incheck") {

        }

        else if (hoverActive == "account") {
            $(".sub-account").css('display', 'block');
        }

        else if (hoverActive == "reververingen") {
            $(".sub-reververingen").css('display', 'block');
        }

        else if (hoverActive == "event") {
            $(".sub-event").css('display', 'block');
        }

        else if (hoverActive == "post") {
            $(".sub-post").css('display', 'block');
        }


        else if (hoverActive == "opties") {
            $(".i-opties").css('background-color', '#313131');
            $(".sub-opties").css('display', 'block');
        }

        else {
            alert("WUt?");
        };

    }, function () {
        $(".sub-navbar").css('display', 'none');
        removeSub();
        hoverActive = "";
    });
});

function removeSub() {
    $(".sub-account").css('display', 'none');
    $(".sub-reververingen").css('display', 'none');
    $(".sub-event").css('display', 'none');
    $(".sub-opties").css('display', 'none');
    $(".sub-post").css('display', 'none');
};
