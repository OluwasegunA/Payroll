function LoadStaffs(dropdownlistID) {
    var cbostaffId = $(dropdownlistID);
    $.ajax({
        url: "/Payroll/LoadAllStaff",
        type: "GET",
        cache: false
    }).success(function (result) {
        for (i = 0; i <= result.length - 1; i++) {
            var staffID = result[i];
            var p = new Option(staffID.StaffNo, staffID.StaffNo);
            cbostaffId.append(p);
        }
    })
}

function populateStafName(ddlStaffID, ddlStaffName) {
    var StaffNameID = $(ddlStaffID).val();
    var Name = $(ddlStaffName);
    //$(txtOthers).hide();
    $.ajax({
        url: "/Payroll/GetStaffName",
        type: "GET",
        data: { staff: StaffNameID },
        cache: false
    }).success(function (result) {
        for (i = 0; i <= result.length; i++) {
            var staffname = result[i];
            var name = staffname.Surname + " " + staffname.FirstName;
            var p = name.toUpperCase();
            Name.val(p);
            Name.show();
        }
    })
}

//Sening Messages
$("#SendMessage").click(function () {
    var receiver = $("#cbostaff").val();
    var sender = $("#UserID").val();
    var subject = $("#txtsubject").val();
    var msgbody = $("#txtmessageBody").val();
    var messageContent = {
        Subject: subject, From_ID: sender, To_ID: receiver, Body: msgbody
    }
    $.ajax({
        url: "/Message/SendMsg",
        data: messageContent,
        type: "POST"
    }).success(function (result) {
        if (result.status) {
            $("#lblSuccessMsg").html("Message sent!");
            $("#lblSuccessMsg").show();
        }
        $("#loading").hide();
    }).fail(function (error) {
        $("#lblErrorMsg").html(error.Desc);
        $("#lblErrorMsg").show();
        $("#loading").hide();
    });
})