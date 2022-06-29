window.addEventListener('load', () => {
    const tungay_format = document.querySelector('#tungay');
    const toingay_format = document.querySelector('#toingay');

    const datepicker_tungay = new TheDatepicker.Datepicker(tungay_format);
    datepicker_tungay.options.setInputFormat('j-n-Y');
    datepicker_tungay.options.setTitle('Từ ngày:')
    datepicker_tungay.options.setShowResetButton(true);
    datepicker_tungay.options.setMinDate('2022-1-1');
    datepicker_tungay.render();

    const datepicker_toingay = new TheDatepicker.Datepicker(toingay_format);
    datepicker_toingay.options.setInputFormat('j-n-Y');
    datepicker_toingay.options.setTitle('Tới ngày:')
    datepicker_toingay.options.setShowResetButton(true);
    datepicker_toingay.options.setMinDate('2022-1-1');
    datepicker_toingay.render();

})