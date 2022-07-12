window.addEventListener('load', () => {
    const input_go_page = document.getElementById('input_go_page');
    const btn_go_page = document.getElementById('btn_go_page');

    btn_go_page.addEventListener('click', () => {
        let link = btn_go_page.getAttribute("data-go-page").toString();
        let countPage = parseInt(input_go_page.getAttribute("data-go-page"));
        let value = parseInt(input_go_page.value);
        if ((0 < value && value <= countPage) && value) {
            window.location.replace(`./${link + value}`);
        }
        else {
            ActiveToast('error', 'Số trang không phù hợp!!!', `Nhập số trang trong khoảng 0 - ${countPage}.`, 5);
        }
    })
})