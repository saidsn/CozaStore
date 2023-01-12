"use strict"
$(function () {


  let scrollSection = document.getElementById("scroll-section");


  window.onscroll = function () { scrollFunction() };

  function scrollFunction() {
    if (document.body.scrollTop > 195 || document.documentElement.scrollTop > 195) {
      scrollSection.style.top = "0";
    } else {
      scrollSection.style.top = "-200px";
      $("div").removeClass("inActive");
    }
  }


  let swiper = new Swiper(".mySwiper", {
    loop: true,
    speed: 1000,
    autoplay: {
      delay: 4000
    }
  })

  var swiper1 = new Swiper(".mySwiper1", {
    slidesPerView: 4,
    loop: true,
    spaceBetween: 30,
    speed: 1500,
    autoplay: {
      delay: 3000,
      disableOnInteraction: false,
    },
    breakpoints: {
      0: {
        slidesPerView: 1,
      },
      550: {
        slidesPerView: 2,
      },
      800: {
        slidesPerView: 2,
      },
      1000: {
        slidesPerView: 4,
      },
    }
  });

  var swiper2 = new Swiper(".mySwiper2", {
    slidesPerView: 5,
    speed: 1500,
    autoplay: {
      delay: 2000
    },
    loop: true,
    spaceBetween: 100,
    breakpoints: {
      0: {
        slidesPerView: 1,
      },
      550: {
        slidesPerView: 2,
      },
      800: {
        slidesPerView: 3,
      },
      1000: {
        slidesPerView: 4,
      },
      1200: {
        slidesPerView: 5,
      },
    }

  });




  let hearts = document.querySelectorAll("#product-areas .card .imgBox .my-heart");

  let products = [];

  if (localStorage.getItem("products")) {
    products = JSON.parse(localStorage.getItem("products"))
  }



  document.querySelector(".heart sup").innerText = getProductsCount(products);
  document.querySelector("#scroll-section .heart sup").innerHTML = getProductsCount(products);

  hearts.forEach(heart => {

    let productId = parseInt(heart.parentNode.parentNode.getAttribute("card-id"));

    let existProduct = products.find(m => m.id == productId);
    if (existProduct && products.includes(existProduct)) {
      heart.classList.add('my-active')
    }
    heart.addEventListener("click", function (e) {

      if (!heart.classList.contains("my-active")) {

        heart.classList.add("my-active")

        let productImage = this.previousElementSibling.firstElementChild.getAttribute("src");
        let productBrand = this.parentNode.nextElementSibling.firstElementChild.innerText;
        let productName = this.parentNode.nextElementSibling.firstElementChild.nextElementSibling.innerText;
        let productPrice = this.parentNode.nextElementSibling.lastElementChild.previousElementSibling.innerText;
        let productId = parseInt(this.parentNode.parentNode.getAttribute("card-id"));

        let existProduct = products.find(m => m.id == productId);
        if (existProduct != undefined) {
          existProduct.count += 0;
        }
        else {
          products.push({

            id: productId,
            image: productImage,
            brand: productBrand,
            name: productName,
            price: productPrice,
            count: 1
          })
          document.querySelector(".heart sup").innerText = getProductsCount(products);
          document.querySelector("#scroll-section .heart sup").innerHTML = getProductsCount(products);

        }


        localStorage.setItem("products", JSON.stringify(products));
        document.querySelector(".heart sup").innerText = getProductsCount(products);
        document.querySelector("#scroll-section .heart sup").innerHTML = getProductsCount(products);
      }
      else {

        heart.classList.remove("my-active");


        let productId = parseInt(this.parentNode.parentNode.getAttribute("card-id"));

        let existProduct = products.find(m => m.id == productId);
        if (existProduct) {

          const newProducts = products.filter(m => m !== existProduct);
          localStorage.setItem('products', JSON.stringify(newProducts));
          document.querySelector(".heart sup").innerText = getProductsCount(newProducts);
          document.querySelector("#scroll-section  .heart sup").innerHTML = getProductsCount(newProducts);
          window.location.reload(e)
          e.preventDefault();
        }

      }
    })
  });

  function getProductsCount(items) {
    return items.length;
  }

});




