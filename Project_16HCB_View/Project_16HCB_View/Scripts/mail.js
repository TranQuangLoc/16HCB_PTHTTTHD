
//tranquangloc2906@gmail.com
//$('#mail_nhan').val("tranquangloc2906@gmail.com");

function Mail(userId) {
 
    var imail = {
        //userID: sessionStorage["userid"],
        userID: userId,
        _tieuDe: $('#tieude').val(),
        irecipients: $('#mail_nhan').val(),
        _noiDung: $('#noidungmail').val()      
    };
    console.log(imail);

    //$.post("http://localhost:8080/Project_16HCB_API/rest/atm/getList", JSON.stringify(us), function (data, status) {

    //    console.log(data, status, 1);

    //    if (status == "success") {
    //        var html = "";
    //        for (var i = 0; i < list.length; i++) {
    //            html += "<p>"+list[i].DiaChi+"</p>"
    //        }
    //        $("#hien").html(html);
    //    } else {
    //        alert("Fail");
    //    }
    //});

    $.ajax({

        url: 'http://localhost:8080/Project_16HCB_API/rest/mail/guimail',
        //contentType: 'application/json',
        type: 'POST',
        data: JSON.stringify(imail)
        //headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        //heade: {
        //    "access-control-allow-credentials" :true,
        //    "access-control-allow-methods": "GET, POST, PUT, DELETE, OPTIONS, HEAD",
        //    "access-control-allow-origin":"*"
        //}
        
    }).done(function (data) {
        
        if (data.ketqua === 1) {
            console.log(data.ketqua);
            alert("Gửi thành công")
        }
        else {
            console.log("aa : " + data.ketqua);
            alert("Gửi thất bại")
        }
            
        }).fail(function (a, b, c) {
            console.log("a : "+data.ketqua);
        console.log(a, b, c);
    });

    //$('#fr_login').submit(function (e) {
    //    alert('121221');
    //    e.preventDefault();

    //});

}

