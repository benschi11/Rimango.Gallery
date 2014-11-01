$(".gallery-summary-entry").mouseover(function () {
    $(this).find("img").addClass("selected").removeClass("unselected");
}).mouseout(function () {
    $(this).find("img").removeClass("selected").addClass("unselected");
});