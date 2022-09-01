var site = {};

site.initialize = function () {
    $(document).on('click', "main .dropdown-menu a", function (e) {
        console.log("1")
        e.preventDefault();
    });

}