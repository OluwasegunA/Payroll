function HideAjaxLoad() {
    $("#lblErrorMsg").hide();
    $("#lblSuccessMsg").hide();
}

$("#SubmitLeave").click(function (evt) {
    evt.preventDefault();
    var id = $("#staffIDL").val();
    var name = $("#staffNameL").val();
    var type = $("#txtType").val();
    var from = $("#txtFrom").val();
    var leaveTo = $("#txtTo").val();
    var noDays = $("#txtnoDays").val();
    var recall = "";
    var balance = $("#txtBalance").val();
    var remark = $("#txtremarks").val();
    $('#chkRecall').click(function () {
        if ($(this).is(':checked')) {
            recall = "Yes";
        }
        else {
            recall = "No";
        }
    });
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
        if (result.status) {
            $("#lblSuccessMsg").html("Leave Request Submmitted and waiting for response");
            $("#lblSuccessMsg").show();
        }
    }).fail(function (error) {
        $("#lblErrorMsg").html(error.Desc);
        $("#lblErrorMsg").show();
    })
})

function LoadAllRequest(staff) {
    var SID = $(staff).val();
    $.ajax({
        url: "/StaffPortal/LoadLeave",
        type: "GET",
        data: { staffID: SID },
        cache: false
    }).success(function (data) {
        $("#LeaveBody").empty();
        var no = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            no++;
            var staffLeave = data[i];
            var sta = "";
            if (staffLeave.Status === 1) {
                sta = "Approved";
            }
            else {
                sta = "Pending";
            }
            var link = "<a href='#' onclick='DeleteLeav(\"" + staffLeave.ID + "\")' title='Delete'><i class='fa fa-trash red'></i></a>";
            html = html + "<tr><td>" + no + "</td><td>" + staffLeave.LeaveType + "</td><td>" + staffLeave.NoDays + "</td><td>" + staffLeave.ToDate + "</td><td>" + sta + "</td><td>" + link + "</td></tr>";
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
        LoadPenalty();
    })
}