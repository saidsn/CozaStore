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

    if (localStorage.getItem("products") != undefined) {
        products = JSON.parse(localStorage.getItem("products"));
    };

    let tableBody = document.querySelector(".card-body .table .table-body");


    let heartCount = document.querySelector(".heart sup");

    let heartCount1 = document.querySelector("#scroll-section .heart sup");


    addProductTable(products);

    showHeartCount();

    let deleteIcons = document.querySelectorAll(".delete-icon");


    deleteIcons.forEach(icon => {
        icon.addEventListener("click", function () {
           
            deleteProducts(this);
            swal.fire({
                title: 'Product deleted!',
                showClass: {
                    popup: 'animate__animated animate__fadeInDown'
                },
                hideClass: {
                    popup: 'animate__animated animate__fadeOutUp'
                }
            })

        })

    });


    function deleteProducts(icon) {

        let id = parseInt(icon.parentNode.parentNode.firstElementChild.getAttribute("data-id"));

        products = products.filter(m => m.id != id);

        localStorage.setItem("products", JSON.stringify(products));

        icon.parentNode.parentNode.remove();

        showHeartCount();
    };


    function addProductTable(products) {
        for (const product of products) {
            tableBody.innerHTML += `<tr>
            <td data-id = "${product.id}"> <img src="${product.image}" width = "200px" height = "150px" alt=""></td>
            <td>${product.brand}</td>
            <td>${product.name}</td>
            <td>${product.price}</td>
            <td>
                <i class="fa-solid fa-trash delete-icon"></i>
            </td>
        </tr>`
        }
    };


    function getHeartCount(hearts) {
        let resultcount = 0;
        for (const heart of hearts) {
            resultcount += heart.count;
        }
        return resultcount;
    };

    function showHeartCount() {
        heartCount.innerText = getHeartCount(products);
        heartCount1.innerText = getHeartCount(products);
    }





});