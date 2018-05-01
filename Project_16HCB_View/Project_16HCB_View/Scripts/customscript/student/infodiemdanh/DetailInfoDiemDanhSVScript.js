function Search() {
    //Nạp tham số
    var cboHocPhan = $('#cboHocPhan').val();
    if (cboHocPhan == null) {
        $.notify("Xin chọn học phần", "info");
    }
    else {
        var vmssv = $('#hdmssvvalue').val();
        var info = {
            mssv: vmssv,
            matkb: cboHocPhan
        };


        $.ajax({
            url: "http://localhost:52740/Student/GetInfoDiemDanh",
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(info),
            dataType: 'json',
            beforeSend: function () {
                showLoading("btnSearch");
            },
            success: function (data) {
                var obj = JSON.parse(data);
                if (obj.length > 0) {
                    var shtml = "";
                    for (i in obj) {
                        shtml = shtml + "<tr>";
                        shtml = shtml + "<td>" + obj[i]._mssv + "</td>";
                        shtml = shtml + "<td>" + obj[i]._tenLop + "</td>";
                        shtml = shtml + "<td>" + obj[i]._maPhong + "</td>";
                        shtml = shtml + "<td>" + obj[i]._ngayHoc + "</td>";
                        shtml = shtml + "</tr>";
                    }
                    $('#tblContentRow').html(shtml);
                } else {
                    var shtml = "";
                    $('#tblContentRow').html(shtml);
                    $.notify("Chưa được điểm danh buổi nào.", "info");
                }

                hideLoading("btnSearch");
            },
            error: function (xhr, status, error) {
                $.notify("Đã có lỗi xảy ra! Vui lòng thử lại.", "error");
                hideLoading("btnSearch");
            }
        });
    }
    
}