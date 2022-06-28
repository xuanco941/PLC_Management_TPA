﻿const toast_success = document.querySelector('#toast_success');
const toast_danger = document.querySelector('#toast_danger');
const toast_container = document.querySelector('#toast_container');


const ActiveToast = (type, title, content) => {
    let toast_clone = type == 'success' ? toast_success.cloneNode(true) : toast_danger.cloneNode(true);
    toast_clone.style.display = 'block';
    toast_clone.querySelector(':scope > .toast-header > .me-auto').textContent = title;
    toast_clone.querySelector(':scope > .toast-body').textContent = content;
    toast_clone.querySelector(':scope > .toast-header > .btn_toast_close').addEventListener('click', () => {
        toast_container.removeChild(toast_clone);
        console.log('12321')
    });
    toast_container.insertAdjacentElement('afterbegin', toast_clone);

    setTimeout(() => {
        try {
            toast_container.removeChild(toast_clone);
        }
        catch {

        }
    }, 5000);


}
