"use strict"

$(function () {



    let scrollSection = document.getElementById("scroll-section");

    window.onscroll = function () { scrollFunction() };

    function scrollFunction() {
        if (document.body.scrollTop > 350 || document.documentElement.scrollTop > 350) {
            scrollSection.style.top = "0";
          
        } else {
            scrollSection.style.top = "-86px";
            $("div").removeClass("inActive");
        }
    }





    $(document).on('click', '#deleteBtn', function () {
        var id = $(this).data('id')
        var basketCount = $('#basketCount')
        var basketCurrentCount = $('#basketCount').html()
        var id = $(this).data('id');
        var quantity = $(this).data('quantity')
        var sum = basketCurrentCount - quantity


        $.ajax({
            method: 'POST',
            url: "/basket/delete",
            data: {
                id: id
            },
            success: function (res) {

                Swal.fire({
                    icon: 'success',
                    title: 'Product deleted',
                    showConfirmButton: false,
                    timer: 1500
                })

                $(`.basket-product[id=${id}]`).remove();
                basketCount.html("")
                basketCount.append(sum)

            }
        })

    })


});




