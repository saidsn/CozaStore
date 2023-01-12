"use strict"

$(function () {


    $(document).on("click", ".add-to-cart", function () {

        console.log("ok")
        let productId = parseInt($(this).closest(".basket-product").children(0).val());
        let data = { id: productId }

      

        $.ajax({
            url: "/home/addbasket",
            type: "Post",
            data: data,
            content: "application/x-www-from-urlencoded",
            success: function (res) {

                Swal.fire({
                    icon: 'success',
                    title: 'Product added',
                    showConfirmButton: false,
                    timer: 1200
                })
            }


        });

    });




    let scrollSection = document.getElementById("scroll-section");

    window.onscroll = function() {scrollFunction()};

    function scrollFunction() {
      if (document.body.scrollTop > 150|| document.documentElement.scrollTop > 150) {
         scrollSection.style.top = "0";
      } else {
         scrollSection.style.top = "-86px";
         $("div").removeClass("inActive");
      }
    }



    let imgs = document.querySelectorAll('.img-select a');
    let imgBtns = [...imgs];
    let imgId = 1;

    imgBtns.forEach((imgItem) => {
        imgItem.addEventListener('click', (event) => {
            event.preventDefault();
            imgId = imgItem.dataset.id;
            slideImage();
        });
    });

    function slideImage() {
        let displayWidth = document.querySelector('.img-showcase img:first-child').clientWidth;

        document.querySelector('.img-showcase').style.transform = `translateX(${- (imgId - 1) * displayWidth}px)`;
    }

    window.addEventListener('resize', slideImage);




    
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

