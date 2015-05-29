$(document).ready(function() {

    var hoverActive;

    $("#i-incheck").hover(function() {
        hoverActive = "incheck";
        //$(".sub-navbar").css('display', 'block');
    }, function() {
        //$(".sub-navbar").css('display', 'none');
    });


    $("#i-account").hover(function() {
        hoverActive = "account";
        $(".sub-navbar").css('display', 'block');
        removeSub();
        $(".sub-account").css('display', 'flex');

    }, function() {
        $(".sub-navbar").css('display', 'none');
        removeSub();

    });

    $("#i-reserveren").hover(function() {
        hoverActive = "reserveren";
        $(".sub-navbar").css('display', 'block');
        removeSub();
        $(".sub-resereven").css('display', 'flex');
    }, function() {
        $(".sub-navbar").css('display', 'none');
        removeSub();
    });

    $("#i-admin").hover(function() {
        hoverActive = "admin";
        $(".sub-navbar").css('display', 'block');
        removeSub();
        $(".sub-admin").css('display', 'flex');
    }, function() {
        $(".sub-navbar").css('display', 'none');
        removeSub();
    });

    $("#i-opties").hover(function() {
        hoverActive = "opties";
        $(".sub-navbar").css('display', 'block');
        removeSub();
        $(".sub-opties").css('display', 'flex');
    }, function() {
        $(".sub-navbar").css('display', 'none');
        removeSub();
    });

    $(".sub-navbar").hover(function() {
        $(".sub-navbar").css('display', 'block');

        if (hoverActive == "incheck") {

        } 

        else if(hoverActive == "account"){
        	$(".sub-account").css('display', 'flex');
        }

        else if(hoverActive == "reserveren"){
        	$(".sub-resereven").css('display', 'flex');
        }

        else if(hoverActive == "admin"){
        	$(".sub-admin").css('display', 'flex');
        }

        else if(hoverActive == "opties"){
        	$(".i-opties").css('background-color', '#313131');
        	$(".sub-opties").css('display', 'flex');
        }

        else{
        	alert("WUt?");
        };
        
    }, function() {
        $(".sub-navbar").css('display', 'none');
        removeSub();
        hoverActive = "";
    });
});

function removeSub() {
    $(".sub-account").css('display', 'none');
    $(".sub-resereven").css('display', 'none');
    $(".sub-admin").css('display', 'none');
    $(".sub-opties").css('display', 'none');
};
