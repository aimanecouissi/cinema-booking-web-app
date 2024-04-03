function navbarTransparency() {
    if (document.body.scrollTop > 0 || document.documentElement.scrollTop > 0) {
        document.querySelector('.navbar').classList.add('bg-white', 'border-bottom');
        document.querySelector('.navbar').classList.remove('navbar-dark');
        document.querySelector('.navbar-brand').style.color = "black";
        document.querySelectorAll('.nav-link').forEach(link => link.style.color = "black");
        /*document.querySelector('#navbarSearch').classList.remove('form-control-clear');*/
    }
    else {
        document.querySelector('.navbar').classList.remove('bg-white', 'border-bottom');
        document.querySelector('.navbar').classList.add('navbar-dark')
        document.querySelector('.navbar-brand').style.color = "white";
        document.querySelectorAll('.nav-link').forEach(link => link.style.color = "white");
        /*document.querySelector('#navbarSearch').classList.add('form-control-clear');*/
    }
}

window.onload = function () {
    navbarTransparency();
}

document.onscroll = function () {
    navbarTransparency();
}

AOS.init({
    offset: 120,
    delay: 0,
    duration: 400,
    easing: 'ease',
    once: true,
    mirror: false,
    anchorPlacement: 'top-bottom',
});

$('.owl-carousel-1').owlCarousel({
    items: 1,
    margin: 10,
    loop: true,
    nav: false,
    dots: true,
    autoplay: true,
    autoplayTimeout: 5000,
    autoplayHoverPause: false,
    smartSpeed: 400,
});

$('.owl-carousel-2').owlCarousel({
    loop: true,
    margin: 16,
    nav: false,
    dots: false,
    autoplay: true,
    autoplayTimeout: 3000,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 2
        },
        768: {
            items: 3
        },
        992: {
            items: 6
        }
    }
});

$('.owl-carousel-2').on('mousewheel', '.owl-stage', function (e) {
    if (e.originalEvent.deltaY > 0) {
        $('.owl-carousel-2').trigger('next.owl');
    } else {
        $('.owl-carousel-2').trigger('prev.owl');
    }
    e.preventDefault();
});

$('#home a.btn-clear').outerWidth($('#home button.btn-clear').outerWidth());