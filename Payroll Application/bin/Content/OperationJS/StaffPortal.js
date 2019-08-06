
function HideAjaxLoad() {
    $("#lblErrorMsg").hide();
    $("#lblSuccessMsg").hide();
}

$("#SubmitLeave").click(function (evt) {
    evt.preventDefault();
    //var id = $("#IDLoanee").val();
    //var name = $("#staffNameL").data();
    var type = $("#txtType").val();
    var from = $("#txtFrom").val();
    var leaveTo = $("#txtTo").val();
    var noDays = $("#txtnoDays").val();
    var recall = "";
    var balance = $("#txtBalance").val();
    var remark = $("#txtremarks").val();
        if ($("#chkRecall").is(":checked")) {
            recall = "Yes";
        }
        else {
            recall = "No";
        }
    var leave = {
        StaffId: id, StaffName: name, LeaveType: type, FromDate: from, ToDate: leaveTo, NoDays: noDays, Recall: recall, Balance: balance,
        Remark: remark
    }
    $.ajax({
        url: "/StaffPortal/SaveLeave",
        type: "POST",
        data: leave,
        cache: false
    }).success(function (result) {
        $("#lblSuccessMsg").html("Leave Request Submmitted");
        $("#lblSuccessMsg").show();
    }).fail(function (error) {
        $("#lblErrorMsg").html(error.Desc);
        $("#lblErrorMsg").show();
    })
})

function LoadAllRequest(staff) {
    //var SID = $(staff).val();
    $.ajax({
        url: "/StaffPortal/LoadLeave",
        type: "GET",
        data: { staffID: staff },
        cache: false
    }).success(function (data) {
        $("#LeaveBody").empty();
        var no = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            no++;
            var staffLeave = data[i];
            var sta = "";
            var r = staffLeave.ToDate;
            var resump = new Date(parseInt(r.substr(6)));
            var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
            var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

            var day = days[resump.getDay()];
            var month = months[resump.getMonth()];
            var resumptDate = day + "," + month + " - " + resump.getFullYear();
            if (staffLeave.Status === 1) {
                sta = "Approved";
            }
            else {
                sta = "Pending";
            }
            var link = "<a href='#' onclick='DeleteLeav(\"" + staffLeave.ID + "\")' title='Delete'><i class='fa fa-trash red'></i></a>";
            html = html + "<tr><td>" + no + "</td><td>" + staffLeave.LeaveType + "</td><td>" + staffLeave.NoDays + "</td><td>" + resumptDate + "</td><td>" + sta + "</td><td>" + link + "</td></tr>";
        }
        $("#LeaveBody").html(html);
    })
}

function DeleteLeav(id) {
    $.ajax({
        url: "/StaffPortal/DeleteLeave",
        data: { ID: id },
        type: "POST"
    }).success(function (result) {
        LoadAllRequest(id);
    })
}

function LoadAdmin(HRid, HRname) {
    var hrID = $(HRid);
    var hrName = $(HRname);
    $.ajax({
        url: "/StaffPortal/LoadAdmin",
        cache: false,
        type: "GET"
    }).success(function (result) {
        if (result.Length !== 0){
            var c = result[i];
            var p = c.OtherID;
            var r = c.FullName;
            hrID.val(p);
            hrName.val(r);
        }
    })
}

$("#SendReq").click(function () {
    var receiver = $("#adminID").val();
    var reName = $("#txtadminName").val();
    var lAmount = $("#txtlAmount").val();
    var reasonBody = $("#txtreasonBody").val();
    var reqContent = {
        Subject: lAmount, From_ID: sender, To_ID: receiver, Body: reasonBody, SenderName: sendername, RecieverName: reName
    }
    $.ajax({
        url: "/StaffPortal/SendLoanReq",
        data: reqContent,
        type: "POST"
    }).success(function (result) {
        if (result.status) {
            $("#lblSuccessMsg").html("Request sent!");
            $("#lblSuccessMsg").show();
        }
        $("#loading").hide();
    }).fail(function (error) {
        $("#lblErrorMsg").html(error.Desc);
        $("#lblErrorMsg").show();
        $("#loading").hide();
    });
})