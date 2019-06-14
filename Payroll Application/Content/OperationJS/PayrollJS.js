function HideAjaxLoad() {
    $("#lblErrorMsg").hide();
    $("#lblSuccessMsg").hide();
    $("#loading").hide();
}
//======================================Allowance========================================================

//New Allowance Code
$("#NewAllowance").click(function (e) {
    e.preventDefault();
    $("#loading").show();
    $.ajax({
        url: "/Payroll/GetAllowanceCode",
        type: "GET",
        cache: false
    }).success(function (result) {
        $("#txtcodeAll").val(result);
        $("#txtdesAll").val("");
        $("#txtallowType").val("");
        $("#txtpercent").val("");
        $("#txtgrade").val("");
        $("#loading").hide();
    }).fail(function (error) {
        $("#loading").hide();
    })
})

//save Allowance
$("#SaveAllowance").click(function (evt) {
    evt.preventDefault();
    var code = $("#txtcodeAll").val();
    var description = $("#txtdesAll").val();
    var alltype = $("#txtallowType").val();
    var percent = $("#txtpercent").val();
    var grade = $("#txtgrade").val();
    var period = "";
    if ($("#chkmonthly").is(':checked')) {
        period = "monthly";
    }
    else if ($("#chkyearly").is(':checked')){
        period = "yearly";
    }
    $("#loading").show();
    var allowance = {
        Code: code, Description: description, AllType: alltype, Percentage: percent, Grade: grade, Period: period
    }
    alert(allowance);
    $.ajax({
        url: "/Payroll/SaveAllowancesSet",
        type: "POST",
        data: allowance
    }).success(function (result) {
        $("#txtcodeAll").val("");
        $("#txtdesAll").val("");
        $("#txtallowType").val("");
        $("#txtpercent").val("");
        $("#txtgrade").val("");
        LoadAllowance();
        $("#loading").hide();
    }).fail(function (error) {
        $("#loading").hide();
    })
});

function LoadAllowance() {
    $.ajax({
        url: "/Payroll/LoadAllowances",
        type: "GET",
        cache: false
    }).success(function (data) {
        $("#allowanceBody").empty();
        var sn = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            sn++;
            var allowance = data[i];

            var link = "<a href='#' onclick='EditAllowance(\"" + allowance.Code + "\")' title='Edit' ><i class='fa fa-pencil'></i></a>";
            var link2 = "<a href='#' onclick='DeleteAllowance(\"" + allowance.Code + "\")' title='Delete'><i class='fa fa-trash'></i></a>";
            var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + sn + "</td><td>" + allowance.Description + "</td><td>" + allowance.AllType + "</td><td>" + allowance.Percentage + "</td><td>" + link + space + link2 + "</td></tr>";
        }
        $("#allowanceBody").html(html);
    });
}

//delete Allowance
function DeleteAllowance(code) {
    $.ajax({
        url: "/Payroll/DeleteAllowance",
        data: { Code: code },
        type: "POST"
    }).success(function (result) {
        LoadAllowance();
    })
}
//Edit Allowance
function EditAllowance(code) {
    $.ajax({
        url: "/Payroll/EditAllowance",
        type: "GET",
        data: { Code: code },
        cache: false
    }).success(function (result) {
        $("#txtcodeAll").val(result.Code);
        $("#txtdesAll").val(result.Description);
        $("#txtallowType").val(result.AllType);
        $("#txtpercent").val(result.Percentage);
        $("#txtgrade").val(result.Grade);
    })
}
//======================================Pension========================================================

//New Pension Code
$("#NewPension").click(function (e) {
    e.preventDefault();
    $("#loading").show();
    $.ajax({
        url: "/Payroll/GetPensionCode",
        type: "GET",
        cache: false
    }).success(function (result) {
        $("#txtcodePen").val(result);
        $("#txtdesPen").val("");
        $("#txtempeePer").val("");
        $("#txtempPer").val("");
        $("#loading").hide();
    }).fail(function (error) {
        $("#loading").hide();
    })
})

//save Pension
$("#SavePension").click(function (evt) {
    evt.preventDefault();
    var code = $("#txtcodePen").val();
    var description = $("#txtdesPen").val();
    var EmpeePercent = $("#txtempeePer").val();
    var EmpPercent = $("#txtempPer").val();
    $("#loading").show();
    var pension = {
        Code: code, Description: description, EmployeePer: EmpeePercent, EmployerPer: EmpPercent
    }
    $.ajax({
        url: "/Payroll/SavePensionSet",
        type: "POST",
        data: pension
    }).success(function (result) {
        $("#txtcodePen").val("");
        $("#txtdesPen").val("");
        $("#txtempeePer").val("");
        $("#txtempPer").val("");
        LoadPension();
        $("#loading").hide();
    }).fail(function (error) {
        $("#loading").hide();
    })
});

function LoadPension() {
    $.ajax({
        url: "/Payroll/LoadPensions",
        type: "GET",
        cache: false
    }).success(function (data) {
        $("#pensionBody").empty();
        var sn = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            sn++;
            var pension = data[i];

            var link = "<a href='#' onclick='EditPension(\"" + pension.Code + "\")' title='Edit' ><i class='fa fa-pencil'></i></a>";
            var link2 = "<a href='#' onclick='DeletePension(\"" + pension.Code + "\")' title='Delete'><i class='fa fa-trash'></i></a>";
            var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + sn + "</td><td>" + pension.Description + "</td><td>" + pension.EmployeePer + "</td><td>" + pension.EmployerPer + "</td><td>" + link + space + link2 + "</td></tr>";
        }
        $("#pensionBody").html(html);
    });
}

//delete Pension
function DeletePension(code) {
    $.ajax({
        url: "/Payroll/DeletePension",
        data: { Code: code },
        type: "POST"
    }).success(function (result) {
        LoadPension();
    })
}
//Edit Pension
function EditPension(code) {
    $.ajax({
        url: "/Payroll/EditPension",
        type: "GET",
        data: { Code: code },
        cache: false
    }).success(function (result) {
        $("#txtcodePen").val(result.Code);
        $("#txtdesPen").val(result.Description);
        $("#txtempeePer").val(result.EmployeePer);
        $("#txtempPer").val(result.EmployerPer);
    })
}