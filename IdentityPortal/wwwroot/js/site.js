var site = {
    excludedUrlPathForMenuHighlighted : [
        "/",
        "/INDEX",
        "/PRIVACY"
    ]

};

site.highlightMenu = function (selector) {
    $(selector).removeClass("side-navigation-normal").addClass("side-navigation-highlighted");
    $(selector).find(".side-navigation-normal").removeClass("side-navigation-normal").addClass("side-navigation-highlighted");
}


site.sideMenuItemClicked = function (controller, action, moduleAccessId) {
    localStorage.setItem('moduleAccessId', moduleAccessId);
    var redirectTo = action == '' ? `/${controller}` : `/${controller}/${action}`;
    location.href = redirectTo;
}

site.initialize = function (requestPath) {
    var excludedUrlPathForMenuHighlighted = false;
    site.excludedUrlPathForMenuHighlighted.forEach(function (elm) {
        if (requestPath.toUpperCase().localeCompare(elm) == 0) {
            excludedUrlPathForMenuHighlighted = true;
        }
    });

    if (excludedUrlPathForMenuHighlighted == false) {
        var moduleAccessId = localStorage.getItem('moduleAccessId');
        if (moduleAccessId) {
            $(document).find(".c-link").each(function () {
                if (moduleAccessId == $(this).data("moduleaccessid")) {
                    var wrapper = null;
                    if ($(this).hasClass('dropdown-item')) {
                        var dropDownMenu = $(this).closest('.dropdown-menu');
                        if (dropDownMenu.length > 0) {
                            dropDownMenu.removeClass('d-none')
                            dropDownMenu.addClass('stay-open')
                        }

                        wrapper = $(this).closest('.dropdown-item-wrapper');

                    } else {
                        wrapper = $(this).closest('li');
                    }
                    site.highlightMenu(wrapper);
                }
            });
        }
    }
}