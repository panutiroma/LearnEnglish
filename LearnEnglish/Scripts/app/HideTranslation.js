

function HideTranslation() {
    $(".vr-hiden").hide();
}


$(document).ready(function () {

    $(".vr-list-row").click(function () {
        if ($(this).next().is(":visible")) {
            HideTranslation();
        } else {
            HideTranslation();
            $(this).next().show();
        }
    });
});


