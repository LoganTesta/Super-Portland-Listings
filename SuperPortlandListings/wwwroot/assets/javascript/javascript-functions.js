
$(".mobile-nav__menu").eq(0).on("click", function () {
    $(".mobile-nav__menu").eq("0").toggleClass("show");
    $(".mobile-nav").eq("0").toggleClass("show");
    $(".body-wrapper").toggleClass("hide");
});

$(window).resize(function () {
    if ($(window).width() >= 1200) {
        $(".mobile-nav__menu").eq("0").removeClass("show");
        $(".mobile-nav").eq("0").removeClass("show");
        $(".body-wrapper").removeClass("hide");
    }
});

$(".nav__dropdown-arrow").on("click", function () {
    $(this).parents(".nav__nav-item").find(".nav__dropdown-menu").toggleClass("show");
});