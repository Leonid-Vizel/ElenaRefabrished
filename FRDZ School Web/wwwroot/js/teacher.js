var dataTable;

$(document).ready(function () {
    dataTable = $('#teacherTable').DataTable({
        "ajax": { url: '/admin/teacher/getall' },
        "autoWidth": true,
        "columns": [
            { data: 'fullName' },   
            { data: 'post' },
            { data: 'qualification' },
            { data: 'experience' },
            { data: 'birth', "visible": false, "searchable": false },
            { data: 'phoneNumber', "visible": false, "searchable": false },
            {
                data: 'id',
                render: function (data) {
                    return `<div class="w-100 btn-group" role="group">
                    <a href="/admin/teacher/edit?id=${data}" class="btn btn-outline-warning mx-2 w-100"><i class="bi bi-person-gear big-icon2"></i></a>
                    <a onClick=Delete('/admin/teacher/delete?id=${data}') class="btn btn-outline-danger mx-2 w-100"><i class="bi bi-person-x big-icon2"></i></a>
                    </div>`
                }
            }
        ],
        "language": {
            lengthMenu: 'Показать _MENU_ учителей',
            zeroRecords: 'Учитель не найден!',
            info: 'Показаны учителя с _START_ по _END_ из _TOTAL_',
            infoEmpty: 'Никаких записей',
            infoFiltered: '(Выборка из _MAX_ записей)',
            search: "Поиск",
            searchPlaceholder: "Искать учителя...",
            paginate: {
                first: '«',
                previous: '‹',
                next: '›',
                last: '»'
            },
            url: '//cdn.datatables.net/plug-ins/1.13.4/i18n/ru.json',
        },
        "pagingType": 'full_numbers',
        "lengthMenu": [
            [5, 10, 25, -1],
            [5, 10, 25, 'All']
        ],
        "select": true,
        "fixedHeader": true,
        "fixedColumns": {
            right: 1
        }
    });
})

function Delete(url) {
    Swal.fire({
        title: 'Вы уверены?',
        text: "Вы не сможете восстановить данные после удаления!",
        color: '#d9534f',
        icon: 'question',
        iconColor: '#d9534f',
        showCancelButton: true,
        confirmButtonColor: '#d9534f',
        cancelButtonColor: '#1a1a1a',
        cancelButtonText: 'Нет, вернуться',
        confirmButtonText: 'Да, удалить!',
        background: '#1a1a1a',
        showClass: {
            popup: 'animate__animated animate__zoomIn'
        },
        hideClass: {
            popup: 'animate__animated animate__zoomOut'
        }
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    Toast.fire({
                        title: 'Удалено',
                        text: 'Учитель был успешно удалён!',
                        icon: 'success',
                        iconColor: '#4bbf73'
                    })
                }
            })
        }
    })
}

//function Edit(url) {
//    const { value: formValues } = await Swal.fire({
//        title: 'Изменение',
//        color: '#fff',
//        showCancelButton: true,
//        confirmButtonColor: '#f0ad4e',
//        cancelButtonColor: '#1a1a1a',
//        cancelButtonText: 'Отменить',
//        confirmButtonText: 'Принять',
//        background: '#1a1a1a',
//        showClass: {
//            popup: 'animate__animated animate__zoomIn'
//        },
//        hideClass: {
//            popup: 'animate__animated animate__zoomOut'
//        },
//        html:
//            '<input id="swal-input1" class="swal2-input">' +
//            '<input id="swal-input2" class="swal2-input">',
//        focusConfirm: false,
//        preConfirm: () => {
//            return [
//                document.getElementById('swal-input1').value,
//                document.getElementById('swal-input2').value
//            ]
//        }
//    }).then((result) => {
//        if (result.isConfirmed) {
//            $.ajax({
//                url: url,
//                type: 'DELETE',
//                success: function (data) {
//                    dataTable.ajax.reload();
//                    Toast.fire({
//                        title: 'Удалено',
//                        text: 'Учитель был успешно удалён!',
//                        icon: 'success',
//                        iconColor: '#4bbf73'
//                    })
//                }
//            })
//        }
//    })
//    if (formValues) {
//        Swal.fire(JSON.stringify(formValues))
//    }
//}

const Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 2500,
    timerProgressBar: true,
    didOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer)
        toast.addEventListener('mouseleave', Swal.resumeTimer)
    },
    background: '#1a1a1a',
    color: 'white',
    showClass: {
        popup: 'animate__animated animate__slideInDown'
    },
    hideClass: {
        popup: 'animate__animated animate__slideOutUp'
    }
})