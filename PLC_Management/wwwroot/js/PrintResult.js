
document.querySelector('#btn-print').onclick = () => {

    let params = new URLSearchParams(window.location.search);

    let tungay_p = params.get('tungay');
    let toingay_p = params.get('toingay');


    let textOxy = params.get('Oxy') ? 'Oxy,' : '';
    let textNitor = params.get('Nitor') ? 'Nitor,' : '';

    console.log(tungay_p, toingay_p, textOxy, textNitor);


    var printdata = document.getElementById('print_data');
    printdata.style.textAlign = 'center';


    var ngay = '(' + tungay_p + ') - (' + toingay_p + ')';

    var divChildren1 = document.createElement('div');
    divChildren1.textContent = 'BÁO CÁO GIÁ TRỊ ĐO';
    divChildren1.style.fontSize = '20px';
    divChildren1.style.fontWeight = '600';


    var divChildren2 = document.createElement('div');
    if (textOxy || textNitor) {
        var textvalue = `${textOxy + textNitor}`;
        divChildren2.textContent = '(' + textvalue.substr(0, textvalue.lastIndexOf(',')) + ')';
    }


    var divChildren3 = document.createElement('div');
    if (tungay_p && toingay_p) {
        if (tungay_p == toingay_p) {
            divChildren3.textContent = '(' + tungay_p + ')';
        }
        else {
            divChildren3.textContent = ngay;
        }
    }
    divChildren3.style.marginBottom = '20px';
    divChildren3.style.marginTop = '7px';

    var divFather = document.createElement('div');
    divFather.style.marginBottom = '15px';
    divFather.appendChild(divChildren1);
    divFather.appendChild(divChildren2);
    divFather.appendChild(divChildren3);

    printdata.insertAdjacentElement('afterbegin', divFather);
    printdata.style.fontFamily = 'Arial, Helvetica, sans-serif';

    //about: blank
    var newwin = window.open(window.location.host);


    newwin.document.write('<link rel="stylesheet" href="./lib/bootstrap_min.css">');
    newwin.document.write(printdata.outerHTML);

    setTimeout(() => {
        newwin.print();
        newwin.close();

    }, 300);
    divFather.remove();


}