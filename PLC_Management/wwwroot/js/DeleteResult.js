
window.addEventListener('load', () => {

    var btn_xoa_ban_ghi = document.querySelector('#btn_xoa_ban_ghi');


    btn_xoa_ban_ghi.addEventListener('click', () => {
        if (confirm('Bạn có chắc muốn xóa bản ghi ở trang hiện tại?')) {


            var Results = Array.from(document.getElementsByClassName('ID_Result'));
            var arrID = Results.map((IDs) => {
                return parseInt(IDs.getAttribute("data-id-result"));
            });

            var end_id = arrID.reduce(function (accumulator, element) {
                return (accumulator > element) ? accumulator : element
            });

            var start_id = arrID.reduce(function (accumulator, element) {
                return (accumulator < element) ? accumulator : element
            });


            var arrParameter = Array.from(document.querySelectorAll('.Parameter_ID')).map((parameter_ids) => {
                return parameter_ids.textContent.toString().trim();
            });

            var Oxi = arrParameter.indexOf('Oxi') > -1 ? 'Oxi' : 'null';
            var Nitor = arrParameter.indexOf('Nitor') > -1 ? 'Nitor' : 'null';
         

            fetch('./result/deleteresult', {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ start_id, end_id, Oxi, Nitor })
            }).then(res => res.json()).then((data) => {
                Results.forEach((elm) => {
                    elm.remove();
                })
            });

        } else {
            console.log('no elm has deleted.');
        }
    })


    var xoa_tat_ca = document.getElementById('xoa_tat_ca');
    xoa_tat_ca.onsubmit = (e) => {
        if (confirm("Bạn có chắc muốn xóa tất cả bản ghi?")) {

        }
        else {
            e.preventDefault();
        }
    }




})