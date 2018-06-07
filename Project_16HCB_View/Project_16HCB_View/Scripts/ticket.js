
//tranquangloc2906@gmail.com
//$('#mail_nhan').val("tranquangloc2906@gmail.com");

function ObjectToRow(obj) {
    var rowHtml = '<tr>';
    for (var key in obj) {
        rowHtml += '<td>' + obj[key] + '</td>';
    }

    return rowHtml + '</tr>';
}

function CreateTicket() {

    var a = getFormData("#fr_ticket");

    console.log(a);

    
    $.ajax({

        url: 'http://localhost:8080/Project_16HCB_API/rest/phieudiem/layphieudiem',
        //contentType: 'application/json',
        type: 'POST',
        data: JSON.stringify(a)
        //headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        //heade: {
        //    "access-control-allow-credentials" :true,
        //    "access-control-allow-methods": "GET, POST, PUT, DELETE, OPTIONS, HEAD",
        //    "access-control-allow-origin":"*"
        //}
        
    }).done(function (data) {
        if (data.ketqua === 1) {
            swal("Gửi thành công !", "Nhấn để kết thúc!", "success").then((value) => {
                $('#myModal').modal('hide');
                $('#content_diem').html(ObjectToRow(a));
            });
            
        }
        else
            swal("Gửi thất bại !", "Nhấn để kết thúc !", "error");
    }).fail(function (a, b, c) {
        console.log(a, b, c);
    });

   
}

function Traphieudiem(e, masv) {
    e.preventDefault();
    $('#tdtt_' + masv).text("Đang xử lý");
}