

function HideTranslation() {
    $(".vr-hiden").hide();
}


$(document).ready(function () {

    $(".vr-list-row").click(function () {
        if ($(this).parent().next().is(":visible")) {
            HideTranslation();
        } else {
            HideTranslation();
            $(this).parent().next().show();
        }
    });
    $(".vr-list-row").hover(function() {
        $(this).children(".collapse-img").show();
    },
    function() {
        $(this).children(".collapse-img").hide();
    });

    $(".sound").click(function () {
        var url = $(this).children("img").first().attr("media");
        $("#pronIframe").attr("src", url);
    });
});


