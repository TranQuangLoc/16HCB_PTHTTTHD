var IsLoadServer = false;
var visiblepages = 2;

$(document).ready(function () {

});

function GetStudentsList() {
    //Nạp tham số
    var param = {};
    param.strKeyWord = $('#txtKeyWord').val().trim();
    param.intSchoolClassID = parseInt($('#cboSchoolClass').val());
    param.intDivisionID = parseInt($('#cboDivision').val());
    param.intIsGet = parseInt($('#cboIsGet').val());

    $.ajax({
        url: "/Student/SearchStudent",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(param),
        dataType: 'json',
        beforeSend: function () {
            $("#btnSearch").button('loading');
        },
        success: function (data) {
            if (data.iserror === false) {
                $('#ContentStudents').html(data.content);
                Paging(data.totalpages, data.totalrows, 1);
                InitProcessInTable();
                //Gán data để xóa có data load lại trang
                $('#txtKeyWord').attr('data-value', $('#txtKeyWord').val().trim());
                $('#cboSchoolClass').attr('data-value', $('#cboSchoolClass').val());
                $('#cboDivision').attr('data-value', $('#cboDivision').val());
                $('#cboIsGet').attr('data-value', $('#cboIsGet').val());
            } else {
                $.notify("Đã có lỗi xảy ra! Vui lòng nhấn F5 để thử lại.", "error");
            }

            $("#btnSearch").button('reset');
        },
        error: function (xhr, status, error) {
            $.notify("Đã có lỗi xảy ra! Vui lòng nhấn F5 để thử lại.", "error");
            $("#btnSearch").button('reset');
        }
    });
}

function Paging(totalPages, totalRows, startpage) {
    if (totalRows > parseInt(visiblepages)) {
        $('#paging').remove();
        $('#divPagingIndex').html("<ul id='paging' class='pagination'></ul>");
        $('#paging').twbsPagination({
            startPage: startpage,
            totalPages: totalPages,
            visiblePages: visiblepages,
            onPageClick: function (event, page) {
                //Ghi nhận chỉ số trang hiện tại
                $('#hdCurrentPage').val(page); //Vì store bắt đầu từ 0 nên -1

                //Load data ứng với chỉ số page từ server
                if (IsLoadServer == true)
                    SearchAjaxPaging();

                ////Thể hiện chỉ số record đang hiển thị trên giao diện
                //var visiblePages = parseInt(visiblepages);
                //var ToIndextemp = page * visiblePages;
                //var FromIndex = (page - 1) * visiblePages + 1;
                ////Lấy chỉ số đến trang (Nếu không là trang cuối)
                //if (ToIndextemp < totalRows)
                //    ToIndex = ToIndextemp;
                //else
                //    ToIndex = totalRows;

                //$('#page-from-index').text(FromIndex);
                //$('#page-to-index').text(ToIndex);
                //$('#total-record').text(totalRows);

                IsLoadServer = true;
            }
        });
        $('#divPaging').css('display', 'block');
    } else {
        $('#divPaging').css('display', 'none');
    }
}

function SearchAjaxPaging() {
    //Nạp tham số
    var param = {};
    param.strKeyWord = $('#txtKeyWord').attr('data-value').trim();
    param.intSchoolClassID = parseInt($('#cboSchoolClass').attr('data-value'));
    param.intDivisionID = parseInt($('#cboDivision').attr('data-value'));
    param.intIsGet = parseInt($('#cboIsGet').attr('data-value'));
    param.intPageIndex = parseInt($('#hdCurrentPage').val().trim());

    $.ajax({
        url: "/Student/SearchStudent",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(param),
        dataType: 'json',
        beforeSend: function () {
        },
        success: function (data) {
            if (data.iserror == false) {
                $('#ContentStudents').html(data.content);
                InitProcessInTable();
            } else {
                $.notify("Đã có lỗi xảy ra! Vui lòng nhấn F5 để thử lại.", "error");
            }
        },
        error: function (xhr, status, error) {
            $.notify("Đã có lỗi xảy ra! Vui lòng nhấn F5 để thử lại.", "error");
        }
    });
}

function InitProcessInTable() {
    $('#ContentStudents tr').each(function () {
        $(this).find('td span[data-name="Detail"]').click(function () {
            var strStudentID = $(this).closest('td').attr('data-studentid');

            setTimeout(function () { window.location.href = "/quan-ly-sinh-vien/cap-nhat/" + strStudentID }, 500);
        });

        $(this).find('td span[data-name="Delete"]').click(function () {
            var strStudentID = $(this).closest('td').attr('data-studentid');
            var strMessage = "Bạn có muốn xóa sinh viên " + strStudentID + "?"

            $('#divMessage').html(strMessage);
            $('#ModalConfirmDelete').modal('toggle');
            $('#divMessage').attr('data-id', strStudentID);
        });
    });
}

function InsertStudent() {
    setTimeout(function () { window.location.href = "/quan-ly-sinh-vien/them/" }, 500);
}

function DeleleStudent() {
    $('#hdCurRowBeforeDelOnScreen').val($('#ContentStudents tr').length);
    param = {};
    param.strStudentID = $('#divMessage').attr('data-id');

    $.ajax({
        url: "/Student/StudentDelete",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(param),
        dataType: 'json',
        beforeSend: function () {
        },
        success: function (data) {
            if (data.iserror == false) {
                SearchStudentAfterDelete(parseInt($('#hdCurRowBeforeDelOnScreen').val()) - 1);
            } else {
                if (data.message != "") {
                    $.notify(data.message, "error");
                } else {
                    $.notify("Đã có lỗi xảy ra! Vui lòng nhấn F5 để thử lại.", "error");
                }
            }
        },
        error: function (xhr, status, error) {
            $.notify("Đã có lỗi xảy ra! Vui lòng nhấn F5 để thử lại.", "error");
        }
    });
}

function SearchStudentAfterDelete(CurRowAfterDelOnScreen) {
    //Nạp tham số
    if (CurRowAfterDelOnScreen == 0)
        $('#hdCurrentPage').val(parseInt($('#hdCurrentPage').val()) - 1);
    else
        $('#hdCurrentPage').val(parseInt($('#hdCurrentPage').val()));

    var param = {};
    param.strKeyWord = $('#txtKeyWord').attr('data-value').trim();
    param.intSchoolClassID = parseInt($('#cboSchoolClass').attr('data-value'));
    param.intDivisionID = parseInt($('#cboDivision').attr('data-value'));
    param.intIsGet = parseInt($('#cboIsGet').attr('data-value'));
    param.intPageIndex = $('#hdCurrentPage').val();

    $.ajax({
        url: "/Student/SearchStudent",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(param),
        dataType: 'json',
        beforeSend: function () {
        },
        success: function (data) {
            if (data.iserror == false) {
                $('#ContentStudents').html(data.content);
                Paging(data.totalpages, data.totalrows, parseInt($('#hdCurrentPage').val()) + 1);
                InitProcessInTable();
            } else {
                $.notify("Đã có lỗi xảy ra! Vui lòng nhấn F5 để thử lại.", "error");
            }
        },
        error: function (xhr, status, error) {
            $.notify("Đã có lỗi xảy ra! Vui lòng nhấn F5 để thử lại.", "error");
        }
    });
}