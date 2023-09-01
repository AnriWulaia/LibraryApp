function Contains(text_one, text_two) {
    if (text_one.indexOf(text_two) !== -1) {
        return true;
    }
    return false;
}

$(document).ready(function () {
    $("#Search").keyup(function () {
        var searchText = $("#Search").val().toLowerCase();

        $(".card").each(function () {
            if (!Contains($(this).find(".book-title").text().toLowerCase(), searchText)) {
                $(this).hide();
            } else {
                $(this).show();
            }
        });
    });
});
