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

    let products = [];

    if (localStorage.getItem("products") != null) {
        products = JSON.parse(localStorage.getItem("products"))
    }


    let heartCount = document.querySelector(".heart sup");
    let heartCount1 = document.querySelector("#scroll-section .heart sup");

    heartCount.innerText = getHeartCount(products);
    heartCount1.innerText = getHeartCount(products);

    function getHeartCount(hearts) {
        let resultcount = 0;
        for (const heart of hearts) {
            resultcount += heart.count;
        }
        return resultcount;
    }


});


