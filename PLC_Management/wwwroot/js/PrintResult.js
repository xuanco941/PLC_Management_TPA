
document.querySelector('#btn-print').onclick = () => {

    var Oxi_p = document.querySelector('#Oxi');
    var Nitor_p = document.querySelector('#Nitor');
    var tungay_p = document.querySelector('#tungay');
    var toingay_p = document.querySelector('#toingay');

    var printdata = document.getElementById('print_data');
    printdata.style.textAlign = 'center';

    var textOxi = Oxi_p.checked == true ? 'Oxi,' : '';
    var textNitor = Nitor_p.checked == true ? 'Nitor,' : '';


    var ngay = new Date(tungay_p.value).toLocaleDateString('vi-VI') + ' - ' + new Date(toingay_p.value).toLocaleDateString('vi-VI');

    var divChildren1 = document.createElement('div');
    divChildren1.textContent = 'BÁO CÁO GIÁ TRỊ ĐO';
    divChildren1.style.fontSize = '20px';
    divChildren1.style.fontWeight = '600';


    var divChildren2 = document.createElement('div');
    var textvalue = `${textOxi} ${textNitor}`;
    divChildren2.textContent = '('+ textvalue.substr(0, textvalue.lastIndexOf(',')) +')';

    var divChildren3 = document.createElement('div');
    divChildren3.textContent = ngay;
    divChildren3.style.marginBottom = '20px';
    divChildren3.style.marginTop = '7px';

    var divFather = document.createElement('div');
    divFather.style.marginBottom = '15px';
    divFather.appendChild(divChildren1);
    divFather.appendChild(divChildren2);
    divFather.appendChild(divChildren3);

    printdata.insertAdjacentElement('afterbegin', divFather);
    printdata.style.fontFamily = 'Arial, Helvetica, sans-serif';
    var newwin = window.open("");


    newwin.document.write('<link rel="stylesheet" href="./lib/lib_new_version/bootstrap_min.css">');
    newwin.document.write(printdata.outerHTML);

    setTimeout(() => {
        newwin.print();
        newwin.close();

    }, 300);
    divFather.remove();
 

}