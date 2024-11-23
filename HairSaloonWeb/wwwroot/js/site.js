const toggleResponsiveSidebar = () => {
    if ($(".sidebar-custom").hasClass("responsive-active")) {
        $(".sidebar-custom").removeClass("responsive-active");
        $(".sidebar-toggle-btn").removeClass("responsive-active");
    }
    else {
        $(".sidebar-custom").addClass("responsive-active");
        $(".sidebar-toggle-btn").addClass("responsive-active");
    }
}