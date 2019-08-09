function LoadPendingRequest() {
    $.ajax({
        url: "/HumanResource/LoadPendingLea",
        type: "GET",
        cache: false
    }).success(function (data) {
        $("#pendLeaveBody").empty();
        var no = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            no++;
            var staffLeave = data[i];
            var r = staffLeave.ToDate;
            var resump = new Date(parseInt(r.substr(6)));
            var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
            var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

            var day = days[resump.getDay()];
            var month = months[resump.getMonth()];
            var resumptDate = day + "," + month + " - " + resump.getFullYear();

            var f = staffLeave.FromDate;
            var frm = new Date(parseInt(f.substr(6)));
            var Fday = days[frm.getDay()];
            var Fmonth = months[frm.getMonth()];
            var fromDate = Fday + "," + Fmonth + " - " + frm.getFullYear();
            var sta = "";
            if (staffLeave.Status === 1) {
                sta = "Approved";
            }
            else {
                sta = "Pending";
            }
            var link = "<a href='#' onclick='ApproveLeave(\"" + staffLeave.ID + "\")' title='Approve'><i class='fa  fa-check-square-o btn-success'></i></a>";
            var link2 = "<a href='#' onclick='DeclineLeave(\"" + staffLeave.ID + "\")' title='Decline'><i class='fa fa-times btn-danger'></i></a>";
            var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + no + "</td><td>" + staffLeave.StaffName + "</td><td>" + staffLeave.LeaveType + "</td><td>" + staffLeave.NoDays + "</td><td>" + fromDate + "</td><td>" + resumptDate + "</td><td>" + staffLeave.Recall + "</td><td>" + sta + "</td><td>" + staffLeave.Remark + "</td><td>" + link + space + link2 + "</td></tr>";
        }
        $("#pendLeaveBody").html(html);
    })
}

function DeclineLeave(id) {
    $.ajax({
        url: "/HumanResource/DeclineLeave",
        data: { ID: id },
        type: "POST"
    }).success(function (result) {
        LoadPendingRequest();
        LoadApproveRequest();
        LoadDeclineRequest();
    })
}

function DeleteLeave(id) {
    $.ajax({
        url: "/HumanResource/DeleteLeave",
        data: { ID: id },
        type: "POST"
    }).success(function (result) {
        LoadPendingRequest();
        LoadApproveRequest();
        LoadDeclineRequest();
    })
}

function ApproveLeave(id) {
    $.ajax({
        url: "/HumanResource/ApproveLeave",
        data: { ID: id },
        type: "POST"
    }).success(function (result) {
        LoadPendingRequest();
        LoadApproveRequest();
        LoadDeclineRequest();
    })
}

function LoadApproveRequest() {
    $.ajax({
        url: "/HumanResource/LoadApproveLea",
        type: "GET",
        cache: false
    }).success(function (data) {
        $("#approveLeaveBody").empty();
        var no = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            no++;
            var staffLeave = data[i];
            var r = staffLeave.ToDate;
            var resump = new Date(parseInt(r.substr(6)));
            var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
            var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

            var day = days[resump.getDay()];
            var month = months[resump.getMonth()];
            var resumptDate = day + "," + month + " - " + resump.getFullYear();

            var f = staffLeave.FromDate;
            var frm = new Date(parseInt(f.substr(6)));
            var Fday = days[frm.getDay()];
            var Fmonth = months[frm.getMonth()];
            var fromDate = Fday + "," + Fmonth + " - " + frm.getFullYear();
            var sta = "";
            if (staffLeave.Status === true) {
                sta = "Approved";
            }
            else {
                sta = "Pending";
            }
            //var link = "<a href='#' onclick='ApproveLeave(\"" + staffLeave.ID + "\")' title='Approve'><i class='fa  fa-check-square-o btn-success'></i></a>";
            //var link2 = "<a href='#' onclick='DeclineLeave(\"" + staffLeave.ID + "\")' title='Decline'><i class='fa fa-times btn-danger'></i></a>";
            //var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + no + "</td><td>" + staffLeave.StaffName + "</td><td>" + staffLeave.LeaveType + "</td><td>" + fromDate + "</td><td>" + resumptDate + "</td><td>" + staffLeave.Recall + "</td><td>" + sta + "</td></tr>";
        }
        $("#approveLeaveBody").html(html);
    })
}

function LoadDeclineRequest() {
    $.ajax({
        url: "/HumanResource/LoadDeclineLea",
        type: "GET",
        cache: false
    }).success(function (data) {
        $("#declineLeaveBody").empty();
        var no = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            no++;
            var staffLeave = data[i];
            var r = staffLeave.ToDate;
            var resump = new Date(parseInt(r.substr(6)));
            var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
            var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

            var day = days[resump.getDay()];
            var month = months[resump.getMonth()];
            var resumptDate = day + "," + month + " - " + resump.getFullYear();

            var f = staffLeave.FromDate;
            var frm = new Date(parseInt(f.substr(6)));
            var Fday = days[frm.getDay()];
            var Fmonth = months[frm.getMonth()];
            var fromDate = Fday + "," + Fmonth + " - " + frm.getFullYear();
            var decline = "";
            if (staffLeave.IsDeclined === true) {
                decline = "Declined";
            }
            else {
                decline = "Pending";
            }
            var link = "<a href='#' onclick='DeleteLeave(\"" + staffLeave.ID + "\")' title='Delete'><i class='fa  fa-trash btn-success'></i></a>";
            //var link2 = "<a href='#' onclick='DeclineLeave(\"" + staffLeave.ID + "\")' title='Decline'><i class='fa fa-times btn-danger'></i></a>";
            //var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + no + "</td><td>" + staffLeave.StaffName + "</td><td>" + staffLeave.LeaveType + "</td><td>" + staffLeave.NoDays + "</td><td>" + fromDate + "</td><td>" + resumptDate + "</td><td>" + staffLeave.Recall + "</td><td>" + decline + "</td><td>" + link + "</td></tr>";
        }
        $("#declineLeaveBody").html(html);
    })
}

//Loading loan from Message Table
function LoadLoanT() {
    $.ajax({
        url: "/HumanResource/LoadLoan",
        type: "GET",
        cache: false
    }).success(function (data) {
        $("#manLoanBody").empty();
        var no = 0; var html = "";
        for (i = 0; i <= data.length; i++) {
            no++;
            var reqLon = data[i];
            var r = reqLon.Subject;
            var lAmt = PriceFormat(r);
            var link = "<a href='/Payroll/StaffSetup' title='Click to Direct to Loan Setup'><i class='fa  fa-check-square-o btn-success'></i></a>";
            var link2 = "<a href='#' onclick='DeleteLn(\"" + reqLon.ID + "\")' title='Delete Req'><i class='fa fa-trash btn-danger'></i></a>";
            var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + no + "</td><td>" + reqLon.SenderName + "</td><td>" + lAmt + "</td><td>" + reqLon.Body + "</td><td>" + link + space + link2 + "</td></tr>";
        }
        $("#manLoanBody").html(html);
    })
}

function PriceFormat(price) {
    var formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'NGN',
        minimumFractionDigits: 2
    });
    price = formatter.format(price);
    price = price.replace("NGN", "#");
    //price = price.replace(".00", "");
    return price;
}

function DeleteLn(id) {
    $.ajax({
        url: "/HumanResource/DeleteLoan",
        data: { ID: id },
        type: "POST"
    }).success(function (result) {
        LoadLoan();
    })
}