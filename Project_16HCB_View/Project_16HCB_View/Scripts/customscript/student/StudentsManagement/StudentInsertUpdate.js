$(document).ready(function () {
    var IndexCurImgClick = 0;

    if ($('#hdFormType').val() === "Insert") {
        //Khoi tao su kien sau khi insert
        $('#frmStudentInsert').ajaxForm(function (data) {
            ajaxInsertSuccess(data);
        });
    } else {
        //Load data
        LoadData();

        //Khoi tao su kien sau khi update
        $('#frmStudentUpdate').ajaxForm(function (data) {
            ajaxUpdateSuccess(data);
        });
    }

    $(".datepicker").datepicker({
        autoclose: true,
        todayHighlight: true
    }).datepicker('update', new Date());

    $('[data-name="imgChooseFile"]').click(function () {
        $('#modalVanTay').modal('show');
        IndexCurImgClick = parseInt($(this).attr('data-index'));
    });

    var timeOut = 0, CountEnd = 0, img = 1;
    $('#imgGet').on('mousedown touchstart', function (e) {
        timeOut = setInterval(function () {
            CountEnd++;

            if (CountEnd < 10) {
                if (img == 1)
                    img = 2;
                else
                    img = 1;

                $('#imgGet').attr('src', '../../../../Content/image/VT0' + img + '.jpg');
            }
        }, 1000);
    }).bind('mouseup mouseleave touchend', function () {
        clearInterval(timeOut);
        img = 1;
        CountEnd = 0;
    });

    $('#btnCloseVT').click(function () {
        $('#modalVanTay').modal('hide');
        $('#imgGet').attr('src', '../../../../Content/image/no-picture.png');
        IndexCurImgClick = 0;
    });

    $('#btnOKVT').click(function () {
        $('#imgChooseFile0' + IndexCurImgClick).attr('src', $('#imgGet').attr('src'));
        $('#modalVanTay').modal('hide');
        $('#imgGet').attr('src', '../../../../Content/image/no-picture.png');
        IndexCurImgClick = 0;
    });

    $('[data-name="btnRemoveImg"]').click(function () {
        $('#imgChooseFile0' + $(this).attr('data-index')).attr('src', '../Content/image/no-picture.png');
    });
});

function BackManage() {
    setTimeout(function () {
        window.location.href = "/quan-ly-sinh-vien";
    }, 500);
}

function InsertStudent() {
    var arrVanTay = [];
    showLoading("btnInsert");

    for (var i = 1; i < 6; i++) {
        var objVanTay = {
            _url: $('#imgChooseFile0' + i).attr('src')
        };

        arrVanTay.push(objVanTay);
    }
    $('#hdListVanTay').val(JSON.stringify(arrVanTay));

    $('#frmStudentInsert').submit();
    return false;
}

//Ham thuc hien sau khi insert
function ajaxInsertSuccess(data) {
    hideLoading("btnInsert");

    if (data.iserror == false) {
        $.notify("Thêm sinh viên thành công.", "success");
        setTimeout(function () {
            window.location.href = "/quan-ly-sinh-vien";
        }, 500);
    }
    else {
        $.notify("Đã có lỗi xảy ra! Vui lòng nhấn F5 để thử lại.", "error");
    }
}

///////////////UPDATE///////////////////////////
function LoadData() {
    //Load combo hệ đào tạo
    $('#cboHDT option').each(function () {
        if ($(this).attr('value') === objStudent._hedaotao) {
            $(this).attr('selected', 'selected');
        }
    });

    //Load combo trạng thái
    $('#cboTrangThai option').each(function () {
        if ($(this).attr('value') === objStudent._trangthai) {
            $(this).attr('selected', 'selected');
        }
    });
}

function UpdateStudent() {
    var arrVanTay = [];
    showLoading("btnUpdate");

    for (var i = 1; i < 6; i++) {
        var objVanTay = {
            _url: $('#imgChooseFile0' + i).attr('src')
        };

        arrVanTay.push(objVanTay);
    }
    $('#hdListVanTay').val(JSON.stringify(arrVanTay));

    $('#frmStudentUpdate').submit();
    return false;
}

//Ham thuc hien sau khi update
function ajaxUpdateSuccess(data) {
    hideLoading("btnUpdate");

    if (data.iserror == false) {
        $.notify("Cập nhật sinh viên thành công.", "success");
        setTimeout(function () {
            window.location.href = "/quan-ly-sinh-vien";
        }, 500);
    }
    else {
        $.notify("Đã có lỗi xảy ra! Vui lòng nhấn F5 để thử lại.", "error");
    }
}