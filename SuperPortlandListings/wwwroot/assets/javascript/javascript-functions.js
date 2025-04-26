
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

$("#navDropdownListingsMobile").on("click", function () {
    $(this).parents(".nav__nav-item").find(".nav__dropdown-menu").toggleClass("show");
    checkMenuItemShowStatus("#navDropdownListingsMenuMobile");
});

$("#navDropdownListings").on("click", function () {
    $(this).parents(".nav__nav-item").find(".nav__dropdown-menu").toggleClass("show");
    checkMenuItemShowStatus("#navDropdownListingsMenu");
});

function checkMenuItemShowStatus(menuItem) {
    if ($(menuItem).hasClass("show")) {
        $(menuItem).attr("aria-expanded", true);
    } else {
        $(menuItem).attr("aria-expanded", false);
    }
}
