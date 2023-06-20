$("#home-btn_book_now").click(function () {
    $('html,body').animate({
        scrollTop: $("#container-book_now").offset().top - $('#navbar-scrolled').height()
    },
        'slow');
});