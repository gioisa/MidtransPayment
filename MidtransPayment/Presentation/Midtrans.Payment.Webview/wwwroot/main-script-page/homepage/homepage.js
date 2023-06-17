$(document).ready(function () {
    var owl = $('#owl-carousel');
    owl.owlCarousel({
        items: 1,
        loop: true,
        nav: true, autoHeight: true,
        navText: ['<i class="las la-angle-left"></i>', '<i class="las la-angle-right"></i>'], 
    });
    owl.on('mousewheel', '.owl-stage', function (e, delta) {
        console.log(delta)
        if (delta > 0) {
            owl.trigger('next.owl');
        } else {
            owl.trigger('prev.owl');
        }
        e.preventDefault();
    });

});

//SCRIPT FOR SCROLLED PAGE CHANGE BACKGROUN NAVBAR
const myNav = $('#navbar-scrolled');
window.onscroll = function () {
    if (window.pageYOffset >= 100) {
        myNav.addClass("scrolled");
        myNav.removeClass("bg-transparent");
    }
    else {
        myNav.addClass("bg-transparent");
        myNav.removeClass("scrolled");
    }
};