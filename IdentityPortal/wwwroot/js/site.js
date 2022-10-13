var site = {
    showed: false
};

site.highlightMenu = function (selector) {
    $(selector).removeClass("side-navigation-normal").addClass("side-navigation-highlighted");
    $(selector).find(".side-navigation-normal").removeClass("side-navigation-normal").addClass("side-navigation-highlighted");
}

site.unHighlightSiblingMenus = function (selector) {
    $(selector).siblings().each(function () {
        $(this).removeClass("side-navigation-highlighted").addClass("side-navigation-normal");
        $(this).find(".side-navigation-highlighted").removeClass("side-navigation-highlighted").addClass("side-navigation-normal");
    });
}

site.initialize = function () {
    $(document).on('click', "main #navbarDropdownMenuLink", function (e) {
        var dropdownMenuPointer = $(this).siblings(".dropdown-menu");
        if (site.showed) {
            dropdownMenuPointer.removeClass('stay-open')
            dropdownMenuPointer.addClass('d-none')
        } else {
            dropdownMenuPointer.removeClass('d-none')
            dropdownMenuPointer.addClass('stay-open')
        }

        site.showed = !(site.showed);
    });

    $(document).on('click', "#side-navigation li:not('.dropdown')", function (e) {
        site.highlightMenu(this);
        site.unHighlightSiblingMenus(this);
    });

    $(document).on('click', "#side-navigation .dropdown-item-wrapper", function (e) {
        site.highlightMenu(this);
        site.unHighlightSiblingMenus(this);

        $("#side-navigation li.dropdown").each(function () {
            site.unHighlightSiblingMenus(this);
        });
    });
}