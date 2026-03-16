$(document).ready(function () {
    $('#car').animate({ left: '+=500px' }, {
        duration: 4000,
        step: function (now) {
            $("#xValue").text(now);
        }
    });

});


$(document).ready(function () {
    $('.my-slider').slick({
        dots: true,
        infinite: true,
        speed: 500,
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 2000,
        arrows: true
    });
});


$(document).ready(function () {
    $({ progress: 0 }).animate({
        progress: 1
    }, {
        duration: 4000,
        step: function (now) {
            let currentScale = 0.2 + (0.8 * now);
            let currentRotate = 60 - (60 * now);

            $('#flower').css({
                transform: `scale(${currentScale}) rotate(${currentRotate}deg)`,
            });
        }
    });
});


$(document).ready(function () {
    $("#drag-me").draggable({
        revert: "invalid",
        cursor: "grabbing"
    });

    $("#black-hole").droppable({
        accept: "#drag-me",
        drop: function (event, ui) {
            ui.draggable.fadeOut(500);
        }
    });
})