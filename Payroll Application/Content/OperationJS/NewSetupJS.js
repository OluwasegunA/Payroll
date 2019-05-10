function HideAjaxLoad() {
    $("#loading").hide();
    $("#successSave").hide();
}
//get New Branch
$("#NewBranch").click(function (evt) {
    evt.preventDefault();
    $("#loading").show();
    $.ajax({
        url: "/Setup/GetNextBranchCode",
        type: "GET",
        cache: false
    }).done(function (result) {
        $("#code").val(result);
        $("#branchName").val("");
        $("#address").val("");
        $("#PhoneNo").val("");
        $("#Email").val("");
        $("#loading").hide();
        $("#successSave").hide();
    }).error(function (error) {
        $("#loading").hide();
    });
});

//save branch Information
$("#SaveBranch").click(function (evt) {
    evt.preventDefault();
    $("#successSave").hide();
    var code = $("#code").val();
    var Branchname = $("#branchName").val();
    var address = $("#address").val();
    var Phoneno = $("#PhoneNo").val();
    var Email = $("#Email").val();
    if (Branchname.length == 0) {
        $("#successSave").html("Type the Branch Name!");
        $("#successSave").show();
        $("#branchName").focus();
        $("#successSave").addClass("alert-danger");
        return;
    }
    $("#loading").show();
    var Bra = { BranchCode: code, BranchName: Branchname, Address: address, PhoneNo: Phoneno, Email: Email };
    $.ajax({
        url: "/Setup/SaveBranchInfo",
        type: "POST",
        data: Bra
    }).success(function (data) {
        $("#successSave").html(data.Desc);
        $("#successSave").addClass("alert-success");
        $("#successSave").show();
        LoadBranchInfo();
        $("#loading").hide();
        bootbox.alert({
            size: "small",
            title: "Save Operation",
            message: data.Desc,
            callback: function (res) {
                $("html, body").animate({ scrollTop: 0 }, 600);
            }
        });
    }).error(function (error) {
        $("#loading").hide();
    });
});

//load Branch Information
function LoadBranchInfo() {
    $.ajax({
        url: "/Setup/LoadBranchInfo",
        type: "POST"
    }).success(function (data) {
        $("#branchDataList").html(data);
        $("#BranchListTable").DataTable({
            "pageLength": 20

        });
    })
}
//edit branch Information
function EditBranchInfo(Code) {
    $.ajax({
        url: "/Setup/GetBranchData",
        type: "GET",
        data: { BranchCode: Code },
        cache: false
    }).success(function (data) {
        $("#code").val(data.BranchCode);
        $("#branchName").val(data.BranchName);
        $("#address").val(data.Address);
        $("#PhoneNo").val(data.PhoneNo);
        $("#Email").val(data.Email);
    })
}

//edit branch Information
function DeleteBranchInfo(Code) {
    bootbox.confirm({
        size: "small",
        message: "Are you sure you want to delete this record?",
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: "/Setup/DeleteBranch",
                    type: "POST",
                    data: { BranchCode: Code }
                }).success(function (data) {
                    LoadBranchInfo();
                });
            }
        }
    });
}
//==============================================Titles================================================
//Get Title Code
$("#NewTitle").click(function (evt) {
    evt.preventDefault();
    $("#loading").show();
    $.ajax({
        url: "/Setup/GetTitleCode",
        type: "GET",
        cache: false
    }).success(function (result) {
        $("#txtTitleCode").val(result);
        $("#txtTitle").val("");
        $("#loading").hide();
    }).fail(function (error) {
        $("#loading").hide();
    })
})
//save Title
$("#SaveTitle").click(function (evt) {
    evt.preventDefault();
    var code = $("#txtTitleCode").val();
    var title = $("#txtTitle").val();
    if (title.length > 0) {
        $("#loading").show();
        $.ajax({
            url: "/Setup/SaveTitles",
            data: { Code: code, Description: title },
            type: "POST"
        }).success(function (data) {
            if (data.Status == true) {
                $("#txtTitle").val("");
                $("#txtTitleCode").val("");
                loadAllTitles();
                $("#loading").hide();

            }
        }).fail(function (error) {
            $("#txtTitle").focus();
            $("#loading").show();
        });
    }
});
//load the Title
function loadAllTitles() {
    $.ajax({
        url: "/Setup/LoadAllTitles",
        type: "GET",
        cache: false
    }).success(function (data) {
        $("#titlebody").empty();
        var sn = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            sn++;
            var title = data[i];
            var link = "<a href='#' onclick='EditTitleInfo(\"" + title.Code + "\")' title='Edit' ><i class='fa fa-pencil'></i></a>";
            var link2 = "<a href='#' onclick='DeleteTitleInfo(\"" + title.Code + "\")' title='Delete'><i class='fa fa-trash'></i></a>";
            var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + sn + "</td><td>" + title.Description + "</td><td>" + title.Code + "</td><td>" + link + space + link2 + "</td></tr>";

        }
        $("#titlebody").html(html);
    })
}
//delete title
function DeleteTitleInfo(code) {
    $.ajax({
        url: "/Setup/DeleteTitle",
        data: { Code: code },
        type: "POST"
    }).success(function (data) {
        loadAllTitles();
    })
}
//Edit staff Title
function EditTitleInfo(code) {
    $.ajax({
        url: "/Setup/EditTitle",
        type: "GET",
        data: { Code: code },
        cache: false
    }).success(function (result) {
        $("#txtTitle").val(result.Description);
        $("#txtTitleCode").val(result.Code);
    })
}
//=======================================================================================================================

//==========================================Levels=======================================================================
//get Next Code for Level
$("#NewLevel").click(function (e) {
    e.preventDefault();
    $("#loading").show();
    $.ajax({
        url: "/Setup/GetLevelCode",
        type: "GET",
        cache: false
    }).success(function (result) {
        $("#txtLevelCode").val(result);
        $("#txtLevel").val("");
        $("#loading").hide();
        }).fail(function (error) {
            $("#loading").hide();
        })
})
//save Level
$("#SaveLevel").click(function (evt) {
    evt.preventDefault();
    var level = $("#txtLevel").val();
    var code = $("#txtLevelCode").val();
    if (level.length > 0) {
        $("#loading").show();
        $.ajax({
            url: "/Setup/SaveLevels",
            data: {Code:code,Description: level },
            type: "POST"
        }).success(function (data) {
            if (data.Status) {
                $("#txtLevel").val("");
                $("#txtLevelCode").val("");
                loadAllLevels();
                $("#loading").hide();

            }
        }).fail(function (error) {
            $("#txtLevel").focus();
            $("#loading").show();
        });
    }
});
//load the Levels
function loadAllLevels() {
    $.ajax({
        url: "/Setup/LoadAllLevels",
        type: "GET",
        cache: false
    }).success(function (data) {
        $("#levelbody").empty();
        var sn = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            sn++;
            var level = data[i];
            var link = "<a href='#' onclick='EditLevelInfo(\"" + level.Code + "\")' title='Edit' ><i class='fa fa-pencil'></i></a>";
            var link2 = "<a href='#' onclick='DeleteLevelInfo(\"" + level.Code + "\")' title='Delete'><i class='fa fa-trash'></i></a>";
            var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + sn + "</td><td>" + level.Description + "</td><td>" + level.Code + "</td><td>" + link + space + link2 + "</td></tr>";

        }
        $("#levelbody").html(html);
    })
}
//edit Level
function DeleteLevelInfo(code) {
    $.ajax({
        url: "/Setup/DeleteLevel",
        data: { Code: code },
        type: "POST"
    }).success(function (data) {
        loadAllLevels();
    })
}
//Edit staff level
function EditLevelInfo(code) {
    $.ajax({
        url: "/Setup/EditLevel",
        type: "GET",
        data: { Code: code },
        cache: false
    }).success(function (result) {
        $("#txtLevel").val(result.Description);
        $("#txtLevelCode").val(result.Code);
    })
}
//===============================================================================================================================================
//==============================================================Employement Types================================================================
//get Next Code for EmpType
$("#NewEmpTypeCode").click(function (e) {
    e.preventDefault();
    $("#loading").show();
    $.ajax({
        url: "/Setup/GetNextEmpTypeCode",
        type: "GET",
        cache: false
    }).success(function (result) {
        $("#txtempCode").val(result);
        $("#txtempType").val("");
        $("#loading").hide();
    }).fail(function (error) {
        $("#loading").hide();
    })
})

//save Employement
$("#SaveempType").click(function (evt) {
    evt.preventDefault();
    var empType = $("#txtempType").val();
    var code = $("#txtempCode").val();
    if (empType.length > 0) {
        $("#loading").show();
        $.ajax({
            url: "/Setup/SaveEmployementTypes",
            data: {Code:code, Description: empType },
            type: "POST"
        }).success(function (data) {
            if (data.Status) {
                $("#txtempType").val("");
                $("#txtempCode").val("");
                loadAllEmpTypes();
                $("#loading").hide();

            }
        }).fail(function (error) {
            $("#txtempType").focus();
            $("#loading").show();
        });
    }
});
//load the Employment
function loadAllEmpTypes() {
    $.ajax({
        url: "/Setup/LoadAllEmpTypes",
        type: "GET",
        cache: false
    }).success(function (data) {
        $("#empTypebody").empty();
        var sn = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            sn++;
            var emp = data[i];
            var link = "<a href='#' onclick='EditEmpTypeInfo(\"" + emp.Code + "\")' title='Edit' ><i class='fa fa-pencil'></i></a>";
            var link2 = "<a href='#' onclick='DeleteEmpType(\"" + emp.Code + "\")' title='Delete'><i class='fa fa-trash'></i></a>";
            var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + sn + "</td><td>" + emp.Description + "</td><td>" + emp.Code + "</td><td>" + link + space + link2 + "</td></tr>";

        }
        $("#empTypebody").html(html);
    })
}
//Delete Employee Type
function DeleteEmpType(code) {
    $.ajax({
        url: "/Setup/DeleteEmpType",
        data: { Code: code },
        type: "POST"
    }).success(function (data) {
        loadAllEmpTypes();
    })
}
//Edit Employee Type
function EditEmpTypeInfo(code) {
    $.ajax({
        url: "/Setup/EditEmpType",
        type: "GET",
        data: { Code: code },
        cache: false
    }).success(function (result) {
        $("#txtempType").val(result.Description);
        $("#txtempCode").val(result.Code);
    })
}
//==============================================dept======================================================

//get Next Code for Dept
$("#NewDept").click(function (e) {
    e.preventDefault();
    $("#loading").show();
    $.ajax({
        url: "/Setup/GetDeptCode",
        type: "GET",
        cache: false
    }).success(function (result) {
        $("#txtDeptCode").val(result);
        $("#txtdept").val("");
        $("#loading").hide();
    }).fail(function (error) {
        $("#loading").hide();
    })
})

//save Dept 
$("#SaveDept").click(function (evt) {
    evt.preventDefault();
    var dept = $("#txtdept").val();
    var code = $("#txtDeptCode").val();
    $("#loading").show();
    $.ajax({
        url: "/Setup/SaveDepts",
        type: "POST",
        data: { DeptCode: code, Description: dept }
    }).success(function(result) {
        $("#txtdept").val("");
        $("#txtDeptCode").val("");
        LoadAllDepts();
        $("#loading").hide();
    })
});

//load the depts
function LoadAllDepts() {
    $.ajax({
        url: "/Setup/LoadAllDepts",
        type: "GET",
        cache: false
    }).success(function (data) {
        $("#deptbody").empty();
        var sn = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            sn++;
            var dept = data[i];
           
            var link = "<a href='#' onclick='EditDept(\"" + dept.DeptCode + "\")' title='Edit' ><i class='fa fa-pencil'></i></a>";
            var link2 = "<a href='#' onclick='DeleteDept(\"" + dept.DeptCode + "\")' title='Delete'><i class='fa fa-trash'></i></a>";
            var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + sn + "</td><td>" + dept.Description + "</td><td>" + dept.DeptCode + "</td><td>" + link + space + link2 + "</td></tr>";

        }
        $("#deptbody").html(html);
    });
}
//delete Dept
function DeleteDept(code) {
    $.ajax({
        url: "/Setup/DeleteDept",
        data: { Code: code },
        type: "POST"
    }).success(function (result) {
        LoadAllDepts();
    })
}
//Edit Dept
function EditDept(code) {
    $.ajax({
        url: "/Setup/EditDept",
        type: "GET",
        data:{Code:code},
        cache:false
    }).success(function (result) {
        $("#txtdept").val(result.Description);
        $("#txtDeptCode").val(result.DeptCode);
    })
}
//======================================Desgination========================================================


//get Next Code for Designation
$("#NewDes").click(function (e) {
    e.preventDefault();
    $("#loading").show();
    $.ajax({
        url: "/Setup/GetDesignationCode",
        type: "GET",
        cache: false
    }).success(function (result) {
        $("#txtDesCode").val(result);
        $("#txtDes").val("");
        $("#loading").hide();
    }).fail(function (error) {
        $("#loading").hide();
    })
})

//save Designation
$("#SaveDes").click(function (evt) {
    evt.preventDefault();
    var desc = $("#txtDes").val();
    var code = $("#txtDesCode").val();
    $("#loading").show();
    $.ajax({
        url: "/Setup/SaveDesignation",
        type: "POST",
        data: { Code: code, Description: desc }
    }).success(function (result) {
        $("#txtDes").val("");
        $("#txtDesCode").val("");
        LoadAllDesignations();
        $("#loading").hide();
    })
});

//load the designation
function LoadAllDesignations() {
    $.ajax({
        url: "/Setup/LoadAllDesignations",
        type: "GET",
        cache: false
    }).success(function (data) {
        $("#descbody").empty();
        var sn = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            sn++;
            var des = data[i];

            var link = "<a href='#' onclick='EditDesignation(\"" + des.Code + "\")' title='Edit' ><i class='fa fa-pencil'></i></a>";
            var link2 = "<a href='#' onclick='DeleteDesignation(\"" + des.Code + "\")' title='Delete'><i class='fa fa-trash'></i></a>";
            var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + sn + "</td><td>" + des.Description + "</td><td>" + des.Code + "</td><td>" + link + space + link2 + "</td></tr>";

        }
        $("#descbody").html(html);
    });
}
//delete Designation
function DeleteDesignation(code) {
    $.ajax({
        url: "/Setup/DeleteDesignation",
        data: { Code: code },
        type: "POST"
    }).success(function (result) {
        LoadAllDesignations();
    })
}
//Edit Designation
function EditDesignation(code) {
    $.ajax({
        url: "/Setup/EditDesignation",
        type: "GET",
        data: { Code: code },
        cache: false
    }).success(function (result) {
        $("#txtDes").val(result.Description);
        $("#txtDesCode").val(result.Code);
    })
}

//====================================Academic Degree===================================
//get Next Code for Degree
$("#NewDeg").click(function (e) {
    e.preventDefault();
    $("#loading").show();
    $.ajax({
        url: "/Setup/GetDegreeCode",
        type: "GET",
        cache: false
    }).success(function (result) {
        $("#txtDegCode").val(result);
        $("#txtDeg").val("");
        $("#loading").hide();
    }).fail(function (error) {
        $("#loading").hide();
    })
})

//save Degree
$("#SaveDeg").click(function (evt) {
    evt.preventDefault();
    var desc = $("#txtDeg").val();
    var code = $("#txtDegCode").val();
    $("#loading").show();
    $.ajax({
        url: "/Setup/SaveDegree",
        type: "POST",
        data: { Code: code, Description: desc }
    }).success(function (result) {
        $("#txtDegCode").val("");
        $("#txtDeg").val("");
        LoadAllDegrees();
        $("#loading").hide();
    })
});

//load the degree
function LoadAllDegrees() {
    $.ajax({
        url: "/Setup/LoadAllDegrees",
        type: "GET",
        cache: false
    }).success(function (data) {
        $("#degbody").empty();
        var sn = 0; var html = "";
        for (i = 0; i <= data.length - 1; i++) {
            sn++;
            var deg = data[i];

            var link = "<a href='#' onclick='EditDegree(\"" + deg.Code + "\")' title='Edit' ><i class='fa fa-pencil'></i></a>";
            var link2 = "<a href='#' onclick='DeleteDegree(\"" + deg.Code + "\")' title='Delete'><i class='fa fa-trash'></i></a>";
            var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            html = html + "<tr><td>" + sn + "</td><td>" + deg.Description + "</td><td>" + deg.Code + "</td><td>" + link + space + link2 + "</td></tr>";

        }
        $("#degbody").html(html);
    });
}
//delete Degree
function DeleteDegree(code) {
    $.ajax({
        url: "/Setup/DeleteDegree",
        data: { Code: code },
        type: "POST"
    }).success(function (result) {
        LoadAllDegrees();
    })
}
//Edit Designation
function EditDegree(code) {
    $.ajax({
        url: "/Setup/EditDegree",
        type: "GET",
        data: { Code: code },
        cache: false
    }).success(function (result) {
        $("#txtDeg").val(result.Description);
        $("#txtDegCode").val(result.Code);
    })
}