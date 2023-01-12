"use strict"
$(function(){

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




    $('input').focus(function(){
        $(this).parents('.form-group').addClass('focused');
      });
      
      $('input').blur(function(){
        var inputValue = $(this).val();
        if ( inputValue == "" ) {
          $(this).removeClass('filled');
          $(this).parents('.form-group').removeClass('focused');  
        } else {
          $(this).addClass('filled');
        }
      }) 
      

      
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
