

let navbar=document.querySelector(".navbar")
let navbar_btn=document.querySelector(".navbar_btn")

window.addEventListener("scroll", function(e){
    e.preventDefault();
    var top = this.scrollY
    if(top>5){
        navbar.style.padding="4px";
        console.log("slam")
    }else{
        navbar.style.padding="8px";
    }
    console.log(top)
});


let navbar_collapse =document.querySelector(".navbar-collapse ")

navbar_btn.addEventListener("click" , function (params) {
    params.preventDefault();
    navbar_collapse.classList.add("active_nav")
});