$(".h-ham").click(function(){
    $(".fade-overlay").addClass("active");
    $(".toggle-widget").addClass("active");
})


$(".toggle-close").click(function(){
    $(".fade-overlay").removeClass("active");
    $(".toggle-widget").removeClass("active");
})

$(".service-click").click(function(){
    $(".fade-overlay").removeClass("active");
    $(".toggle-widget").removeClass("active");
})

$(".service-click").click(function(){
    $(".drop-sub").addClass("d-block");
    $(".owl-carousel").addClass("z-index-0");
})
$(".drop-close").click(function(){
    $(".drop-sub").removeClass("d-block");
    $(".owl-carousel").removeClass("z-index-0");
})




$(window).scroll(function() {    
    var scroll = $(window).scrollTop();

    if (scroll >= 100) {
        $("header").addClass("darkHeader");
    } else {
        $("header").removeClass("darkHeader");
    }
});





$('.owl-carousel').owlCarousel({
    loop:false,
    autoplay:true,
    margin:20,
    autoplayHoverPause:true,
    navText: ["<i><img src='images/left-arrow.svg'></i>","<i><img src='images/left-arrow.svg'></i>"],
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:2
        }
    }
})

$(".hover-sub").click(function(){
    $(".drop-sub").toggleClass("d-block");
})

   




