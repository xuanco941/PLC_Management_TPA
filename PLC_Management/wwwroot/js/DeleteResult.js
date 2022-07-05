
window.addEventListener('load', () => {

    const btnDeleteDataCurrentPage = document.querySelector('#btnDeleteDataCurrentPage');


    btnDeleteDataCurrentPage.addEventListener('click', () => {

        //lay data-id cua tat ca cac phan tu tren bang 
        var Results = Array.from(document.getElementsByClassName('ID_Result'));
        var arrID = Results.map((IDs) => {
            return parseInt(IDs.getAttribute("data-id-result"));
        });

        //id lon nhat
        var end_id = arrID.reduce(function (accumulator, element) {
            return (accumulator > element) ? accumulator : element
        });

        //id nho nhat
        var start_id = arrID.reduce(function (accumulator, element) {
            return (accumulator < element) ? accumulator : element
        });

        //lay ten cac loai khi co trong bang
        var arrParameter = Array.from(document.querySelectorAll('.Parameter_ID')).map((parameter_ids) => {
            return parameter_ids.textContent.toString().trim();
        });

        //neu co oxy thi gan oxy, neu co nitor thi gan voi nitor
        var Oxy = arrParameter.indexOf('Oxy') > -1 ? 'Oxy' : 'null';
        var Nitor = arrParameter.indexOf('Nitor') > -1 ? 'Nitor' : 'null';

        //gui len back-end
        fetch('./result/deleteresult', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ start_id, end_id, Oxy, Nitor })
        }).then(res => res.json()).then((data) => {
            Results.forEach((elm) => {
                elm.remove();
            });
            //Toast
            ActiveToast('success', 'Trạng thái', 'Xóa thành công', 5);
        });


    })


    //var xoa_tat_ca = document.getElementById('xoa_tat_ca');
    //xoa_tat_ca.onsubmit = (e) => {
    //    if (confirm("Bạn có chắc chắn muốn xóa tất cả dữ liệu?")) {

    //    }
    //    else {
    //        e.preventDefault();
    //    }
    //}




})