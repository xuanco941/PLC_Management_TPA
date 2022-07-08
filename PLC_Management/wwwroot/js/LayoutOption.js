
window.addEventListener('load', () => {


    //active text link header
    var str = window.location.pathname.toString();
    var arrlink = Array.from(document.querySelectorAll('.link_header'));
    arrlink.forEach((e) => {

        if (str.toUpperCase().indexOf(e.getAttribute('data-link-name').toUpperCase()) > -1) {
            e.classList.add('active');
        }
    })

    var navbar1 = document.querySelector('#navbar1');
    var navbar2 = document.querySelector('#navbar2');

    setTimeout(() => {
        navbar2.style.width = navbar1.offsetWidth + 'px';
    }, 0);

    window.onresize = () => {
        navbar2.style.width = navbar1.offsetWidth + 'px';
    }








    // swap menu
    const swapToMenuNgang = document.querySelector('#swapToMenuNgang');
    const MenuNgang = document.querySelector('#MenuNgang');
    const MenuDoc = document.querySelector('#sidenav');
    const swapToMenuDoc = Array.from(document.querySelectorAll('.swapToMenuDoc'));

    const menu = localStorage.getItem('menu');
    if (menu && menu == 'MenuDoc') {
        MenuDoc.style.display = 'flex';
    }
    else if (menu && menu == 'MenuNgang') {
        MenuNgang.style.display = 'block';
    }
    else {
        MenuDoc.style.display = 'flex';
    }

    swapToMenuNgang.addEventListener('click', () => {
        MenuNgang.style.display = 'block';
        MenuDoc.style.display = 'none';
        navbar2.style.width = navbar1.offsetWidth + 'px';
        localStorage.setItem('menu', 'MenuNgang');
    })

    swapToMenuDoc.forEach((btn) => {
        btn.addEventListener('click', () => {
            MenuNgang.style.display = 'none';
            MenuDoc.style.display = 'flex';
            localStorage.setItem('menu', 'MenuDoc');
        })
    })


})
