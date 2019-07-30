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
        var no = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            no++;
            var pension = data[i];

            var link = "<a href='#' onclick='EditPension(\"" + pension.Code + "\")' title='Edit' ><i class='fa fa-pencil'></i></a>";
            var link2 = "<a href='#' onclick='DeletePension(\"" + pension.Code + "\")' title='Delete'><i class='fa fa-trash red'></i></a>";
            var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + no + "</td><td>" + pension.Description + "</td><td>" + pension.EmployeePer + "</td><td>" + pension.EmployerPer + "</td><td>" + link + space + link2 + "</td></tr>";
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

//======================================Loan========================================================

//New Loan Code
$("#NewLoan").click(function (e) {
    e.preventDefault();
    $("#loading").show();
    $.ajax({
        url: "/Payroll/GetLoanCode",
        type: "GET",
        cache: false
    }).success(function (result) {
        $("#txtcodeLoan").val(result);
        $("#txtdesLoan").val("");
        $("#loading").hide();
    }).fail(function (error) {
        $("#loading").hide();
    })
})

//save Loan
$("#SaveLoan").click(function (evt) {
    evt.preventDefault();
    var code = $("#txtcodeLoan").val();
    var description = $("#txtdesLoan").val();
    var minor = $("#iteminor").val();
    var maxor = $("#itemaxor").val();
    $("#loading").show();
    var loan = {
        Code: code, Description: description, MinPay: minor, MaxPay: maxor
    }
    $.ajax({
        url: "/Payroll/SaveLoanSet",
        type: "POST",
        data: loan
    }).success(function (result) {
        $("#txtcodeLoan").val("");
        $("#txtdesLoan").val("");
        LoadLoan();
        $("#loading").hide();
    }).fail(function (error) {
        $("#loading").hide();
    })
});

function LoadLoan() {
    $.ajax({
        url: "/Payroll/LoadLoans",
        type: "GET",
        cache: false
    }).success(function (data) {
        $("#loanBody").empty();
        var no = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            no++;
            var loan = data[i];

            var link = "<a href='#' onclick='EditLoan(\"" + loan.Code + "\")' title='Edit' ><i class='fa fa-pencil'></i></a>";
            var link2 = "<a href='#' onclick='DeleteLoan(\"" + loan.Code + "\")' title='Delete'><i class='fa fa-trash red'></i></a>";
            var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + no + "</td><td>" + loan.Description + "</td><td>" + loan.MinPay + "</td><td>" + loan.MaxPay + "</td><td>" + link + space + link2 + "</td></tr>";
        }
        $("#loanBody").html(html);
    });
}

//delete Loan
function DeleteLoan(code) {
    $.ajax({
        url: "/Payroll/DeleteLoan",
        data: { Code: code },
        type: "POST"
    }).success(function (result) {
        LoadLoan();
    })
}
//Edit Loan
function EditLoan(code) {
    $.ajax({
        url: "/Payroll/EditLoan",
        type: "GET",
        data: { Code: code },
        cache: false
    }).success(function (result) {
        $("#txtcodeLoan").val(result.Code);
        $("#txtdesLoan").val(result.Description);
        $("#iteminor").val(result.MinPay);
        $("#itemaxor").val(result.MaxPay);
    })
}

//======================================Penalty========================================================

//New Penalty Code
$("#NewPenalty").click(function (e) {
    e.preventDefault();
    $("#loading").show();
    $.ajax({
        url: "/Payroll/GetPenaltyCode",
        type: "GET",
        cache: false
    }).success(function (result) {
        $("#txtcodePenal").val(result);
        $("#txtdesPenal").val("");
        $("#txtpercentPenal").val("");
        $("#loading").hide();
    }).fail(function (error) {
        $("#loading").hide();
    })
})

//save Penalty
$("#SavePenalty").click(function (evt) {
    evt.preventDefault();
    var code = $("#txtcodePenal").val();
    var description = $("#txtdesPenal").val();
    var deduction = "";
    var percentPenal = $("#txtpercentPenal").val();
    if ($("#chkperPen").is(':checked')) {
        deduction = "Percentage";
    }
    else if ($("#chkloopSum").is(':checked')) {
        deduction = "LoopSum";
    }
    $("#loading").show();
    var penalty = {
        Code: code, Description: description, DeductType: deduction, Percentage: percentPenal
    }
    $.ajax({
        url: "/Payroll/SavePenaltySet",
        type: "POST",
        data: penalty
    }).success(function (result) {
        $("#txtcodePenal").val("");
        $("#txtdesPenal").val("");
        $("#txtpercentPenal").val("");
        LoadPenalty();
        $("#loading").hide();
    }).fail(function (error) {
        $("#lblErrorMsg").show("Please Check the fields")
        $("#loading").hide();
    })
})

function LoadPenalty() {
    $.ajax({
        url: "/Payroll/LoadPenalties",
        type: "GET",
        cache: false
    }).success(function (data) {
        $("#penaltyBody").empty();
        var no = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            no++;
            var penalty = data[i];

            var link = "<a href='#' onclick='EditPenalty(\"" + penalty.Code + "\")' title='Edit' ><i class='fa fa-pencil'></i></a>";
            var link2 = "<a href='#' onclick='DeletePenalty(\"" + penalty.Code + "\")' title='Delete'><i class='fa fa-trash red'></i></a>";
            var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + no + "</td><td>" + penalty.Description + "</td><td>" + penalty.DeductType + "</td><td>" + penalty.Percentage + "</td><td>" + link + space + link2 + "</td></tr>";
        }
        $("#penaltyBody").html(html);
    })
}

//delete Penalty
function DeletePenalty(code) {
    $.ajax({
        url: "/Payroll/DeletePenalty",
        data: { Code: code },
        type: "POST"
    }).success(function (result) {
        LoadPenalty();
    })
}
//Edit Penalty
function EditPenalty(code) {
    $.ajax({
        url: "/Payroll/EditPenalty",
        type: "GET",
        data: { Code: code },
        cache: false
    }).success(function (result) {
        $("#txtcodePenal").val(result.Code);
        $("#txtdesPenal").val(result.Description);
        $("#txtpercentPenal").val(result.Percentage);
    })
}

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

function populateStafName(ddlStaffID, ddlStaffName, txtOthers) {
    var StaffNameID = $(ddlStaffID).val();
    var Name = $(ddlStaffName);
    //$(txtOthers).hide();
    $.ajax({
        url: "/Payroll/GetStaffName",
        type: "GET",
        data: { staff: StaffNameID },
        cache: false
    }).success(function (result) {
        if (result.length === 0) {
            $(ddlStaffName).hide();
            $(txtOthers).show();
        }
        else {
            for (i = 0; i <= result.length; i++) {
                var staffname = result[i];
                var name = staffname.Surname + " " + staffname.FirstName;
                var p = name.toUpperCase();
                Name.val(p);
                Name.show();
                $(txtOthers).hide();
            }
        }
    })
}

function LoadAllowanceType(listID) {
    var cboAllowanceId = $(listID);
    $.ajax({
        url: "/Payroll/LoadAllType",
        type: "GET",
        cache: false
    }).success(function (result) {
        for (i = 0; i <= result.length - 1; i++) {
            var altype = result[i];
            var p = new Option(altype.Description, altype.Description);
            cboAllowanceId.append(p);
        }
    })
}

function populateAllowance(ddlDescript, ddlAllowance, ddlPer) {
    var descriptID = $(ddlDescript).val();
    var allowanceTYPE = $(ddlAllowance);
    var allowancePER = $(ddlPer);
    $.ajax({
        url: "/Payroll/LoadAllowanceType",
        type: "GET",
        data: { descript: descriptID },
        cache: false
    }).success(function (result) {
        for (i = 0; i <= result.length; i++) {
            var allowancDes = result[i];
            var al = allowancDes.AllType.toUpperCase();
            var p = allowancDes.Percentage;
            allowanceTYPE.val(al);
            allowancePER.val(p);
        }
    })
}

$("#SaveSalary").click(function () {
    var staffId = $("#cbostaffId").val();
    var staffName = "";
    var period = $("#cboPeriod").val();
    var allowanceDes1 = $("#cboallowanceDes1").val();
    var allowanceType1 = $("#cboallowanceType1").val();
    var allPercent1 = $("#txtallPercent1").val();
    var allowanceDes2 = $("#cboallowanceDes2").val();
    var allowanceType2 = $("#cboallowanceType2").val();
    var allPercent2 = $("#txtallPercent2").val();
    var allowanceDes3 = $("#cboallowanceDes3").val();
    var allowanceType3 = $("#cboallowanceType3").val();
    var allPercent3 = $("#txtallPercent3").val();
    var allowanceDes4 = $("#cboallowanceDes4").val();
    var allowanceType4 = $("#cboallowanceType4").val();
    var allPercent4 = $("#txtallPercent4").val();
    var allowanceDes5 = $("#cboallowanceDes5").val();
    var allowanceType5 = $("#cboallowanceType5").val();
    var allPercent5 = $("#txtallPercent5").val();
    var allAmt6 = $("#txtallAmount6").val();
    var allowanceDes6 = $("#cboallowanceDes6").val();
    var allowanceType6 = $("#cboallowanceType6").val();
    var allPercent6 = $("#txtallPercent6").val();
    var allAmt1 = $("#txtallAmount1").val();
    var allAmt2 = $("#txtallAmount2").val();
    var allAmt3 = $("#txtallAmount3").val();
    var allAmt4 = $("#txtallAmount4").val();
    var allAmt5 = $("#txtallAmount5").val();
    var amount = $("#txtamount").val();
    if (staffId.length === 0 || staffId === "") {
        $("#lblErrorMsg").val("Staff ID cannot be blank! Select an ID");
        $("#lblErrorMsg").show();
        return;
    }
    else if (amount.length === 0) {
        $("#lblErrorMsg").val("Salary Amount cannot be blank!");
        $("#lblErrorMsg").show();
        $("#txtamount").focus();
        return;
    }
    if ($("#txtstaffNameAdd").is(":visible")) {
        staffName = $("#txtstaffNameAdd").val();
    }
    else {
        staffName = $("#cboStaffName").val();
    }
    //if (allowanceType1 !== "BASIC" || allowanceType1 !== null) {
    //    $("#lblErrorMsg").val("Basic allowance type is Incorrect");
    //    $("#lblErrorMsg").show();
    //    $("#cboallowanceType1").focus();
    //    return;
    //}
    //if (allowanceType2 !== "HOUSING" || allowanceType2 !== null) {
    //    $("#lblErrorMsg").val("Housing allowance type is Incorrect");
    //    $("#lblErrorMsg").show();
    //    $("#cboallowanceType2").focus();
    //    return;
    //}
    //if (allowanceType3 !== "TRANSPORT" || allowanceType3 !== null) {
    //    $("#lblErrorMsg").val("Transport allowance type is Incorrect");
    //    $("#lblErrorMsg").show();
    //    $("#cboallowanceType3").focus();
    //    return;
    //}
    //if (allowanceType4 !== "UTILITY" || allowanceType4 !== null) {
    //    $("#lblErrorMsg").val("Utility allowance type is Incorrect");
    //    $("#lblErrorMsg").show();
    //    $("#cboallowanceType4").focus();
    //    return;
    //}
    //if (allowanceType5 !== "LUNCH" || allowanceType5 !== null) {
    //    $("#lblErrorMsg").val("Lunch allowance type is Incorrect");
    //    $("#lblErrorMsg").show();
    //    $("#cboallowanceType5").focus();
    //    return;
    //}
    //if (allowanceType6 !== "OTHERS" || allowanceType6 !== null) {
    //    $("#lblErrorMsg").val("Other allowance type is Incorrect");
    //    $("#lblErrorMsg").show();
    //    $("#cboallowanceType6").focus();
    //    return;
    //}
    var salary = {
        StaffNo: staffId, StaffName: staffName, Period: period, BasicDescription: allowanceDes1, BasicType: allowanceType1, BasicPer: allPercent1,
        BasicAmt: allAmt1, HousingDescription: allowanceDes2, HousingType: allowanceType2, HousingPer: allPercent2, HousingAmt: allAmt2,
        TransportDescription: allowanceDes3, TransportType: allowanceType3, TransportPer: allPercent3, TransportAmt: allAmt3,
        UtilityDescription: allowanceDes4, UtilityType: allowanceType4, UtilityPer: allPercent4, UtilityAmt: allAmt4,
        LunchDescription: allowanceDes5, LunchType: allowanceType5, LunchPer: allPercent5, LunchAmt: allAmt5,
        OtherDescription: allowanceDes6, OtherType: allowanceType6, OtherPer: allPercent6, OtherAmt: allAmt6, Amount: amount
    }
    $("#loading").show();
    $.ajax({
        url: "/Payroll/SaveSalaryDet",
        data: salary,
        type: "POST"
    }).success(function (result) {
        if (result.status) {
            $("#lblSuccessMsg").html("Salary details saved successfully!");
            $("#lblSuccessMsg").show();
            $("#loading").hide();
        }
    }).fail(function (error) {
        $("#lblErrorMsg").html(error.Desc);
        $("#lblErrorMsg").show();
        $("#loading").hide();
    })
});

// formating currency to naira
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

//Loading Salary for Staff
function LoadSalary(staffID, staffName, netSal) {
    var staffNo = $(staffID).val();
    var Name = $(staffName).val();
    $.ajax({
        url: "/Payroll/LoadNetSalary",
        type: "GET",
        data: { staffName: Name, staffID: staffNo},
        cache: false
    }).success(function (result) {
        if (result.length === 0) {
            $("#lblErrorMsg").html("No record found for this Staff, Please set Salary for Staff");
            $("#lblErrorMsg").show();
            return;
        }
        else {
            for (i = 0; i <= result.length; i++) {
                var netSalary = result[i];
                var p = PriceFormat(netSalary.Amount);
                $(netSal).val(p);
            }
        }
    })
}

//Loading Loan for Staff
function LoadLoanDescription() {
    var cboStaff = $("#cbostaffLoanType");
    $.ajax({
        url: "/Payroll/LoadLoans",
        type: "GET",
        cache: false
    }).success(function (data) {
        for (i = 0; i <= data.length - 1; i++) {
            var loan = data[i];
            var p = new Option(loan.Description.toUpperCase(), loan.Description.toUpperCase());
            cboStaff.append(p);
        }
    });
}

//A simple function to load the total Loan Amount
function LoadTLA(totalAmt) {
    var loanAmt = $("#cbostaffLoanAmt").val();
    var interest = $("#txtinterest").val();
    var t = ((parseFloat(interest) / 100) * parseFloat(loanAmt)) + parseFloat(loanAmt);
    if (!isNaN(t)) {
        var f = PriceFormat(t)
        $(totalAmt).val(f);
    }
}

//Calculating the Repayment for loan
function Repayment(repay) {
    var currency = $("#txttotalLoanAmt").val();
    var totalAmt = Number(currency.replace(/[^0-9.-]+/g, ""));
    var insta = $("#txtinstallment").val();
    var r = parseFloat(totalAmt) / parseFloat(insta);
    if (!isNaN(r)) {
        var d = PriceFormat(r);
        $(repay).val(d);
    }
}

//Saving Loan for Individual
$("#SaveStaffLoan").click(function () {
    var staffIdLoan = $("#cbostaffIdLoan").val();
    var staffLoanAmt = $("#cbostaffLoanAmt").val();
    var interest = $("#txtinterest").val();
    var staffNameLoan = "";
    var staffSalary = $("#cbostaffSalary").val();
    var staffLoan = $("#cbostaffLoanType").val();
    var totalLoa = $("#txttotalLoanAmt").val();
    var totalLoanAmt = Number(totalLoa.replace(/[^0-9.-]+/g, ""));
    var installment = $("#txtinstallment").val();
    var repaymen = $("#txtrepaymentAmt").val();
    var repaymentAmt = Number(repaymen.replace(/[^0-9.-]+/g, ""));
    if (staffIdLoan.length === 0 || staffIdLoan === "") {
        $("#lblErrorMsg").html("Staff ID cannot be blank! Select an ID");
        $("#lblErrorMsg").show();
        $("#cbostaffIdLoan").focus();
        return;
    }
    else if (staffLoanAmt.length === 0) {
        $("#lblErrorMsg").html("Loan Amount cannot be blank!");
        $("#lblErrorMsg").show();
        $("#cbostaffLoanAmt").focus();
        return;
    }
    if ($("#txtstaffNameAddLoan").is(":visible")) {
        staffNameLoan = $("#txtstaffNameAddLoan").val();
    }
    else {
        staffNameLoan = $("#cboStaffNameLoan").val();
    }
    var indiviLoan = {
        StaffNo: staffIdLoan, StaffName: staffNameLoan, NetSalary: staffSalary, LoanType: staffLoan, LoanAmount: staffLoanAmt,
        Interest: interest, TotalLoanAmount: totalLoanAmt, Installment: installment, Repayment: repaymentAmt
    }
    $("#loading").show();
    $.ajax({
        url: "/Payroll/SaveStaffLoan",
        data: indiviLoan,
        type: "POST"
    }).success(function (result) {
        if (result.status) {
            $("#lblSuccessMsg").html("Staff Loan successfully saved!");
            $("#lblSuccessMsg").show();
            $("#loading").hide();
        }
    }).fail(function (error) {
        $("#lblErrorMsg").html(error.Desc);
        $("#lblErrorMsg").show();
        $("#loading").hide();
    });
});

function LoadPenalty() {
    var cboPenalty = $("#cbopenaltyType");
    $.ajax({
        url: "/Payroll/LoadPenalties",
        type: "GET",
        cache: false
    }).success(function (data) {
        for (i = 0; i <= data.length - 1; i++) {
            var pen = data[i];
            var p = new Option(pen.Description.toUpperCase(), pen.Description.toUpperCase());
            cboPenalty.append(p);
        }
    });
}

function LoadDeductionType(description, deductType) {
    var penaltyID = $(description).val();
    $.ajax({
        url: "/Payroll/LoadDeduction",
        type: "GET",
        data: { describe: penaltyID},
        cache: false
    }).success(function (data) {
        for (i = 0; i <= data.length - 1; i++) {
            var pen = data[i];
            var p = pen.DeductType.toUpperCase();
            $(deductType).val(p);
        }
    });
}

//Saving Penalty Deduction for Staff
$("#SaveDeduction").click(function () {
    var staffIdDed = $("#cbostaffIdDed").val();
    var staffNameDed = "";
    var penaltyType = $("#cbopenaltyType").val();
    var deductionType = $("#cbodeductionType").val();
    var staffDedAmt = $("#cbostaffDedAmt").val();

    if ($("#txtstaffNameAddDed").is(":visible")) {
        staffNameDed = $("#txtstaffNameAddDed").val();
    }
    else {
        staffNameDed = $("#cboStaffNameDed").val();
    }
    var staffDeduction = {
        StaffNo: staffIdDed, StaffName: staffNameDed, PenaltyType: penaltyType, DeductionType: deductionType, Amount: staffDedAmt
    }
    $("#loading").show();
    $.ajax({
        url: "/Payroll/SaveStaffDeduction",
        data: staffDeduction,
        type: "POST"
    }).success(function (result) {
        if (result.status) {
            $("#lblSuccessMsg").html("Deduction successfully saved for Staff!");
            $("#lblSuccessMsg").show();
            $("#loading").hide();
        }
    }).fail(function (error) {
        $("#lblErrorMsg").html(error.Desc);
        $("#lblErrorMsg").show();
        $("#loading").hide();
    })
});

//Calculating the Allowance in Amount
function LoadAllowancesAmount(allowanceAmt, allowancePer, salaryAmt) {
    var PersentSalary = $(salaryAmt).val();
    var alPer = $(allowancePer).val();
    var s = ((parseFloat(alPer) / 100) * parseFloat(PersentSalary));
    
    $(allowanceAmt).val(PriceFormat(s));
    return;
}

//PAY E Monthly
function LoadSalaryPAYE(id, income, basic, housing, transport, utility, lunch, others) {
    var Sid = $(id).val();
    $.ajax({
        url: "/Payroll/LoadALL",
        type: "GET",
        data: { sID: Sid},
        cache: false
    }).success(function (data) {
        for (i = 0; i <= data.length - 1; i++) {
            var pen = data[i];
            var inco = pen.Amount;
            var bas = pen.BasicAmt;
            var hou = pen.HousingAmt;
            var tra = pen.TransportAmt;
            var uti = pen.UtilityAmt;
            var lun = pen.LunchAmt;
            var oth = pen.OtherAmt;
            $(income).val(PriceFormat(inco));
            if (bas !== null || bas !==""){
                $(basic).val(bas);
            }
            if (hou !== null || hou !==""){
                $(housing).val(hou);
            }
            if (tra !== null || tra !== "") {
                $(transport).val(tra);
            }
            if (uti !== null || uti !== "") {
                $(utility).val(uti);
            }
            if (lun !== null || lun !== "") {
                $(lunch).val(lun);
            }
            if (oth !== null || oth !== "") {
                $(others).val(oth)
            }
        }
    });
}


//PAY E Annually
function LoadSalaryPAYEAnnual(id, income, basic, housing, transport, utility, lunch, others) {
    var Sid = $(id).val();
    $.ajax({
        url: "/Payroll/LoadALLAnnual",
        type: "GET",
        data: { sID: Sid },
        cache: false
    }).success(function (data) {
        for (i = 0; i <= data.length - 1; i++) {
            var pen = data[i];
            var inco = pen.Amount;
            var bas = pen.BasicAmt;
            var hou = pen.HousingAmt;
            var tra = pen.TransportAmt;
            var uti = pen.UtilityAmt;
            var lun = pen.LunchAmt;
            var oth = pen.OtherAmt;
            $(income).val(PriceFormat(inco));
            if (bas !== null || bas !== "") {
                $(basic).val(bas);
            }
            if (hou !== null || hou !== "") {
                $(housing).val(hou);
            }
            if (tra !== null || tra !== "") {
                $(transport).val(tra);
            }
            if (uti !== null || uti !== "") {
                $(utility).val(uti);
            }
            if (lun !== null || lun !== "") {
                $(lunch).val(lun);
            }
            if (oth !== null || oth !== "") {
                $(others).val(oth)
            }
        }
    });
}

//Calculating Deductions
function Deduction(sal, loanDe, penaltyDe, period) {
    var Gross = $(sal).val();
    var GI = Number(Gross.replace(/[^0-9.-]+/g, ""));
    var loDed = $(loanDe).val();
    var loanDeduct = Number(loDed.replace(/[^0-9.-]+/g, ""));
    var penDed = $(penaltyDe).val();
    var penaltyDed = Number(penDed.replace(/[^0-9.-]+/g, ""));
    var pensionDeduction = parseFloat(GI) * 0.075;
    var NHF = parseFloat(GI) * 0.025;
    var CF = "";
    if ($(period).val() === "Monthly") {
        CF = "# 16,666.67";
    }
    else if ($(period).val() === "Annually") {
        CF = "# 200,000";
    }
    var calCF = Number(CF.replace(/[^0-9.-]+/g, ""));
    var GIR = parseFloat(GI) * 0.2;
    var totNoneTaxDed = pensionDeduction + NHF + parseFloat(calCF) + GIR;
    var totalDed = totNoneTaxDed + parseInt(loanDeduct) + parseInt(penaltyDed);
    var netTaxable = parseFloat(GI) - parseFloat(totNoneTaxDed);
    var pe = PriceFormat(pensionDeduction);
    var nf = PriceFormat(NHF);
    var r = PriceFormat(GIR);
    var TND = PriceFormat(totNoneTaxDed);
    var TD = PriceFormat(totalDed);
    var NT = PriceFormat(netTaxable);
    $("#showPension").val(pe);
    $("#showNHF").val(nf);
    $("#showCF").val(CF);
    $("#showGIF").val(r);
    $("#showTotT").val(TND);
    $("#showTotDed").val(TD);
    $("#showNetTax").val(NT);
    return;
}

function LoadParticulatStaffLoan(sid, LD) {
    var emp = $(sid).val();
    $.ajax({
        url: "/Payroll/PStaffLoan",
        type: "GET",
        data: { sID: emp },
        cache: false
    }).success(function (data) {
        for (i = 0; i <= data.length - 1; i++) {
            if (data.length === 0 || data === 0.00) {
                $("#lblErrorMsg").html("This Staff does not have a running Loan");
                $("#lblErrorMsg").show();
            }
            else{
                var pen = data[i];
                var p = PriceFormat(pen.Repayment);
                $(LD).val(p);
            }
        }
    });
}

function LoadParticulatStaffPen(sid, PD) {
    var empid = $(sid).val();
    $.ajax({
        url: "/Payroll/PStaffDeduction",
        type: "GET",
        data: { sID: empid },
        cache: false
    }).success(function (data) {
        for (i = 0; i <= data.length - 1; i++) {
            if (data.length === 0 || data === 0.00) {
                $("#lblErrorMsg").html("This Staff does not have any Penalty to Pay");
                $("#lblErrorMsg").show();
            }
            else {
                var pen = data[i];
                var p = PriceFormat(pen.Amount);
                $(PD).val(p);
            }
        }
    });
}

$("#chkDeduction").click(function () {
    LoadParticulatStaffLoan(cbostaffIdPay, txtloanDeduct);
    LoadParticulatStaffPen(cbostaffIdPay, txtpenaDeduct);
    $("#ShowDeduction").removeClass("hide-txt");
    $("#ShowDeduction").show();
})

$("#ShowDeduction").click(function () {
    Deduction(txtIncome, txtloanDeduct, txtpenaDeduct, cbopayPeriod);
})

$("#calculPAYE").click(function () {
    var netInc = $("#showNetTax").val();
    var netIncome = Number(netInc.replace(/[^0-9.-]+/g, ""));
    var netIn = parseFloat(netIncome);
    var GrossI = $("#txtIncome").val();
    var GrossIncome = Number(GrossI.replace(/[^0-9.-]+/g, ""));
    var GrossIn = parseFloat(GrossIncome);
    if (netIn.length === 0) {
        $("#lblErrorMsg").html("The field for the Net Taxable Income is Empty./n Please Click the Right button in the right format");
        $("#lblErrorMsg").show();
        return;
    }
    else {
        var payE = $("#showPayE");
        let first, remIn1, second, remIn2, third, remIn3, fourth, remIn4, fifth;
        if ((netIn - 25000) > 0) {
            first = 25000 * 0.07;
            if ((netIn - 25000) < 25000) {
                remIn1 = (netIn - 25000) * 0.11;
                var t = parseFloat(first) + parseFloat(remIn1);
                var t1 = PriceFormat(t);
                payE.val(t1);
            }
            else if ((netIn - 25000) > 25000) {
                second = 25000 * 0.11;
                var s = parseFloat(first) + parseFloat(second);
                var s1 = PriceFormat(s);
                payE.val(s1);
                if ((netIn - 50000) < 41666) {
                    remIn2 = (netIn - 50000) * 0.15;
                    var r = parseFloat(first) + parseFloat(second) + parseFloat(remIn2);
                    var r1 = PriceFormat(r);
                    payE.val(r1);
                }
                else if ((netIn - 50000) > 41666) {
                    third = 41666 * 0.15;
                    var q = parseFloat(first) + parseFloat(second) + parseFloat(third);
                    var q1 = PriceFormat(q);
                    payE.val(q1);
                    if ((netIn - 91666) < 133333) {
                        remIn3 = (netIn - 91666) * 0.21;
                        var p = parseFloat(first) + parseFloat(second) + parseFloat(third) + parseFloat(remIn3);
                        var p1 = PriceFormat(p);
                        payE.val(p1);
                    }
                    else if ((netIn - 91666) > 133333) {
                        fourth = 133333 * 0.21;
                        var m = parseFloat(first) + parseFloat(second) + parseFloat(third) + parseFloat(fourth);
                        var m1 = PriceFormat(m);
                        payE.val(m1);
                        if ((netIn - 224999) < 491665) {
                            remIn4 = (netIn - 224999) * 0.24;
                            var o = parseFloat(first) + parseFloat(second) + parseFloat(third) + parseFloat(remIn4);
                            var o1 = PriceFormat(o);
                            payE.val(o1);
                        }
                        else if ((netIn - 224999) > 491665) {
                            fifth = 266666 * 0.24;
                            var l = parseFloat(first) + parseFloat(second) + parseFloat(third) + parseFloat(fourth) + parseFloat(fifth);
                            var l1 = PriceFormat(l);
                            payE.val(l1);
                        }
                    }
                }
            }
            $("#payEBody").removeClass("hide-txt");
            $("#payEBody").show();
            var payE = $("#payEBody").val();
            var RPayE = Number(payE.replace(/[^0-9.-]+/g, ""));
            var CRPayE = parseFloat(RPayE);
            var net = GrossIn - CRPayE;
            var n = PriceFormat(net);
            $("#showNetSalary").val(n);
            return;
        }
        else {
            $("#lblErrorMsg").html("This Staff Earn less than # 25,000.00");
            $("#lblErrorMsg").show();
            return;
        }
    }
})