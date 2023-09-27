/*********** Doms Select ********** */
let dropDownListDom = document.querySelectorAll(".nav-menu .dropdown");
let bodyDom = document.querySelector("body");
let collapseDom = document.querySelectorAll("#collapse");
let closeDom = document.querySelectorAll("#closed");
let fullscreenDom = document.querySelectorAll("#fullscreen");
let panelDropdownDom = document.querySelectorAll("#panel-dropdown");
let panelRefreshContentDom = document.querySelectorAll("#panel-refresh-content")

document.addEventListener("DOMContentLoaded",main_function());

function main_function(){
    /********  Collapse Function ***********/
    collapseDom.forEach(item => {
        item.addEventListener("click",function(){
            $(this).closest(".panel-header").next(".panel-container").slideToggle()
        })
    });

    /******** Closed Function ***********/
    closeDom.forEach(item => {
        item.addEventListener("click",function(){
            $(this).closest("#panel").attr('class', 'd-none');
        })
    });

    /******** Fullscreen Function ***********/
    fullscreenDom.forEach(item => {
        item.addEventListener("click",function(){
            if(!document.fullscreenElement){
                item.closest("#panel").requestFullscreen();
                $(this).next("#closed").css("display","none")
                $(this).prev("#collapse").css("display","none")
                $(this).closest(".panel-card").attr("class","panel-card d-flex fullscreen")
            }   
            else{
                document.exitFullscreen();
                $(this).closest(".panel-card").attr("class","panel-card d-flex ")
                $(this).next("#closed").css("display","block")
                $(this).prev("#collapse").css("display","block")
            }
        })
    });

    /******** Panel Dropdown Menu Function ********/
    panelDropdownDom.forEach(item => {
        item.addEventListener("click",function(){
            let height = $(this).closest(".panel-header").css("height");
            $(this).next('.panel-dropdown-menu').css("top",height);
            $(this).next('.panel-dropdown-menu').slideToggle();
            
        });
    });

    /******** Refresh Content Function ***********/
    panelRefreshContentDom.forEach(item => {
        item.addEventListener("click",function(){
            $(this).closest(".panel-dropdown-menu").slideToggle();
            
            let val = $(this).closest(".panel-header").next('.panel-container').children()
            val[0].classList.toggle("d-flex")    
            setTimeout(()=>{
                val[0].classList.toggle("d-flex")
            },1000)
        });
    });
    /******** Vertical Dropdown Menu Function ********/
    dropDownListDom.forEach(item => {
        item.addEventListener("click",function(){
            dropDownListDom.forEach(index => {
                if(index!=item){
                   $(index).next('ul').slideUp();
                }
            })
            $(this).next('ul').slideToggle();
        });
    });
    
    /******** Toggler Button Click Function ********/
    document.querySelector(".toggler").addEventListener("click",function(){
        if(bodyDom.clientWidth<992){
            bodyDom.classList.toggle("mobile-nav-on");
        }
        else{
            bodyDom.classList.toggle("nav-function-hidden");
        }
    });

    
    /******** Click Outside Closing Sidebar Function ********/
    document.addEventListener("click",function(e){
        if(e.target.id!="toggler" && e.target.classList[0]=="page-content-overlay"){
            if(bodyDom.clientWidth<992){
                if(bodyDom.classList=="mobile-nav-on" ){
                    bodyDom.classList.remove("mobile-nav-on")
    
                }   
            }
        }
    });

    /***************Grid Button Function **************/
    $(".grid-button").on("click", function() {
        $(".grid").toggleClass("open close");
        $(".grid").closest(".grid-button").next(".menu-open").slideToggle();
    });

    /***************Shortcut İtem Function *************/
    $("#scrollTop_button").on("click", function() {
        shortcut(1)
    })
    $("#logout_button").on("click", function() {
        shortcut(2)
    })
    $("#fullscreen_button").on("click", function() {
        shortcut(3)
    })
    $("#print_button").on("click", function() {
        shortcut(4)
    })

}

function toastMessage(type, message) {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
    })

    Toast.fire({
        icon: type,
        title: message
    })
}

const shortcut = (type) =>{
    switch(type){
        case 1:
            window.scrollTo(0, 0);
        break;
        case 2:
        break;
        case 3:
            if(!document.fullscreenElement){
                bodyDom.requestFullscreen();
            }
            else{
                document.exitFullscreen();
            }
        break;
    }
}

var color = {
	primary: {
		_50:   '#ccbfdf',
		_100:  '#beaed7',
		_200:  '#b19dce',
		_300:  '#a38cc6',
		_400:  '#967bbd',
		_500:  '#886ab5',
		_600:  '#7a59ad',
		_700:  '#6e4e9e',
		_800:  '#62468d',
		_900:  '#563d7c'
	},
	success: {
		_50:   '#7aece0',
		_100:  '#63e9db',
		_200:  '#4de5d5',
		_300:  '#37e2d0',
		_400:  '#21dfcb',
		_500:  '#1dc9b7',
		_600:  '#1ab3a3',
		_700:  '#179c8e',
		_800:  '#13867a',
		_900:  '#107066'
	},
	info: {
		_50:  '#9acffa',
		_100: '#82c4f8',
		_200: '#6ab8f7',
		_300: '#51adf6',
		_400: '#39a1f4',
		_500: '#2196F3',
		_600: '#0d8aee',
		_700: '#0c7cd5',
		_800: '#0a6ebd',
		_900: '#0960a5'
	},
	warning: {
		_50:  '#ffebc1',
		_100: '#ffe3a7',
		_200: '#ffdb8e',
		_300: '#ffd274',
		_400: '#ffca5b',
		_500: '#ffc241',
		_600: '#ffba28',
		_700: '#ffb20e',
		_800: '#f4a500',
		_900: '#da9400'
	},
	danger: {
		_50:   '#feb7d9',
		_100:  '#fe9ecb',
		_200:  '#fe85be',
		_300:  '#fe6bb0',
		_400:  '#fd52a3',
		_500:  '#fd3995',
		_600:  '#fd2087',
		_700:  '#fc077a',
		_800:  '#e7026e',
		_900:  '#ce0262'
	},
	fusion: {
		_50:   '#909090',
		_100:  '#838383',
		_200:  '#767676',
		_300:  '#696969',
		_400:  '#5d5d5d',
		_500:  '#505050',
		_600:  '#434343',
		_700:  '#363636',
		_800:  '#2a2a2a',
		_900:  '#1d1d1d'
	}
}