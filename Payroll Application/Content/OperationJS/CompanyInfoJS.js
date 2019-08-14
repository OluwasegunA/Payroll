function loadCompanyInfo() {
   
}
$(document).ready(function (e) {
    $("#loading").hide();
    $("#errormsg").hide();
    $("#uploadImg").click(function (evt) {
        evt.preventDefault();
        var frmdata = new FormData();
        var files = $("#logo").get(0).files;
        if (files.length > 0) {
            frmdata.append("MyImages", files[0]);
        }
        else {
            return;
        }
        $("#loading").show();
        $.ajax({
            url: "/Setup/UploadCompanyLogo",
            type: "POST",
            data: frmdata,
            processData: false,
            contentType: false,
            cache: false
        }).success(function (result) {
            var imgurl = "/Images/" + result
            $("#companyLogo").attr("src", imgurl);
            $("#comgImgUrl").val(imgurl);
            $("#loading").hide();
        }).fail(function (error) {
            $("#lblError").val(error);
            $("#lblError").show();
            $("#loading").hide();
        })


    });
    $("#SaveComp").click(function (evt) {
        evt.preventDefault();
        var companyName = $("#companyName").val();
        var CompAddress = $("#CompAddress").val();
        var phoneNo = $("#PhoneNo").val();
        var Email = $("#Email").val();
        var fileName = $("#comgImgUrl").val();
        var data = { CompanyName: companyName, Address: CompAddress, PhoneNo: phoneNo, ImageUrl:fileName,Email:Email }
        $.ajax({
            url: "/Setup/CompanyInfo_saving",
            type:"POST",
            data: data,
            cache: false
        }).success(function (result) {
            $("#sucMsg").show();
            $("#sucMsg").html(result.Desc);
            bootbox.alert({
                size: "small",
                title: "Save Operation",
                message: result.Desc,
                callback: function (res) {
                    $("html, body").animate({ scrollTop: 0 }, 600);
                }
            });
        })
    });
    $("#sucMsg").hide();
    $.ajax({
        url: "/Setup/GetCompanyInfo",
        type: "GET",
        cache: false
    }).success(function (data) {
        if (data.CompanyName.length > 0) {
            $("#companyName").val(data.CompanyName);
            $("#CompAddress").val(data.Address);
            if (data.ImageUrl.length > 0) {
                $("#comgImgUrl").val(data.ImageUrl);
            }
            $("#companyLogo").attr("src", data.ImageUrl);
            $("#PhoneNo").val(data.PhoneNo);
            $("#Email").val(data.Email);
        }

    })
});

function LoadEmpCount() {
    $.ajax({
        url: "/AdminPortal/GetEmpCount",
        type: "GET",
        cache: false
    }).success(function (result) {
        $("#EmployeeCount").text(result);
    })
}
function LoadUserCount() {
    $.ajax({
        url: "/AdminPortal/GetUserCount",
        type: "GET",
        cache: false
    }).success(function (result) {
        $(".UserCount").text(result);
    })
}
function LoadLeaveCount() {
    $.ajax({
        url: "/AdminPortal/GetStaffLeaveCount",
        type: "GET",
        cache: false
    }).success(function (result) {
        $(".LeaveCount").text(result);
    })
}
function LoadUnapproveCount() {
    $.ajax({
        url: "/AdminPortal/GetUnapproveCount",
        type: "GET",
        cache: false
    }).success(function (result) {
        $(".UnapproveCount").text(result);
    })
}
