var site = {
    showed: false
};

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
}