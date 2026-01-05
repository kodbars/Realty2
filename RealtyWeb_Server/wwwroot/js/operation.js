const notyf = new Notyf({
    duration: 5000,   //задает время показа сообщения.
    position: {       //определение расположения блока с уведомлением
        x: 'right',
        y: 'top'
    },
    dismissible: true //снабжение кнопкой закытия уведомления
});

window.DisplayNotyf = (type, message) => { //функция
    if (type === "success") {
        notyf.success('<b>Успех</b><br />' + message);
    }
    if (type === "error") {
        notyf.error('<b>Неудача</b><br />' + message);
    }
}

window.ShowSweetAlert = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Уведомление об успехе!',
                message,
                'success'
        )
    }
    if (type === "error") {
        Swal.fire(
            'Уведомление об ошибке!',
                message,
                'error'
        )
    }
}

function ShowRemoveConfirmftionModal() {
    $('#removeConfirmationModal').modal('show');
}

function HideRemoveConfirmftionModal() {
    $('#removeConfirmationModal').modal('hide');
}