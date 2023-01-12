"use strict"

$(function () {



    let scrollSection = document.getElementById("scroll-section");

    window.onscroll = function () { scrollFunction() };

    function scrollFunction() {
        if (document.body.scrollTop > 150 || document.documentElement.scrollTop > 150) {
            scrollSection.style.top = "0";
        } else {
            scrollSection.style.top = "-86px";
            $("div").removeClass("inActive");
        }
    }

});