function Search() {
    //Nạp tham số

    var vmssv = $('#txtMSSV').val();
    if (vmssv == "" || vmssv < 0) {
        $('#lbvalidateMSSV').html("*Nhập mssv không hợp lệ!");
        vmssv = 0;
    } else {
        vmssv = parseInt(vmssv);
    }

    var info = {
        mssv: vmssv
    };

    $.ajax({
        url: "http://localhost:52740/Student/kiemtraSVTonTai",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(info),
        dataType: 'json',
        beforeSend: function () {
            showLoading("btnSearch");
        },
        success: function (data) {
            var obj = JSON.parse(data);
            if (obj.confirm == true) {
                $.notify("Kiểm tra đúng", "success");
                $('#frmCheckMSSV').submit();
            } else {
                $.notify("MSSV không tồn tại", "error");
            }

            hideLoading("btnSearch");
        },
        error: function (xhr, status, error) {
            $.notify("Đã có lỗi xảy ra! Vui lòng nhấn F5 để thử lại.", "error");
            hideLoading("btnSearch");
        }
    });
}