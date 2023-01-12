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



$(function () {

    let headers = document.querySelectorAll("#product-area .category .my-btn");
    let contents = document.querySelectorAll(".card")

    headers.forEach(header => {
        header.addEventListener("click", function () {
            let activeElem = document.querySelector(".tab-active");
            activeElem.classList.remove("tab-active");
            this.classList.add("tab-active");

            contents.forEach(content => {
                if (this.getAttribute("data-id") == content.getAttribute("data-id")) {
                    content.parentNode.classList.remove("d-none")
                } else {
                    content.parentNode.classList.add("d-none")
                }
                if (this.getAttribute("data-id") == undefined) {
                    content.parentNode.classList.remove("d-none")
                }
            });
        })
    });


    var outputMin = document.getElementById("min-value");
    var outputMax = document.getElementById("max-value");

    let minSlider = document.getElementById("min");
    let maxSlider = document.getElementById("max");



    outputMin.value = minSlider.value;
    outputMax.value = maxSlider.value;

    minSlider.oninput = function () {
        outputMin.value = this.value;
    };

    maxSlider.oninput = function () {
        outputMax.value = this.value;
    };

    outputMin.oninput = function () {
        minSlider.value = this.value;
    };
    outputMax.oninput = function () {
        maxSlider.value = this.value;
    };


    let hearts = document.querySelectorAll("#product-area .card .imgBox  .my-heart");

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
            e.preventDefault();

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

                    Swal.fire({
                        icon: 'success',
                        title: 'Selected',
                        showConfirmButton: false,
                        timer: 1000

                    })

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






