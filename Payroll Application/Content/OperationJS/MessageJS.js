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