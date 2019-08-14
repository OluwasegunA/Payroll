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
    });
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
    });
}

//Sening Messages
$("#SendMessage").click(function () {
    var receiver = $("#cbostaff").val();
    //var sender = $("#UserID").val(); 
    var receivername = $("#txtcontactName").val();
    var subject = $("#txtsubject").val();
    var msgbody = $("#txtmessageBody").val();
    var messageContent = {
        Subject: subject, From_ID: sender, To_ID: receiver, Body: msgbody, RecieverName: receivername, SenderName: sendername
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
        bootbox.alert({
            size: "small",
            title: "Message Operation",
            message: data.Desc,
            callback: function (res) {
                $("html, body").animate({ scrollTop: 0 }, 600);
            }
        });
    }).fail(function (error) {
        $("#lblErrorMsg").html(error.Desc);
        $("#lblErrorMsg").show();
        $("#loading").hide();
    });
});

function LoadInboxs(name) {
    $.ajax({
        url: "/Message/LoadInbox",
        type: "GET",
        data: { myStaffNo: name },
        cache: false
    }).success(function (data) {
        var count = 0;
        var inboxHTML = '<ul>';
        for (i = 0; i <= data.length - 1; i++) {
            count++;
            var msg = data[i];
            var d = msg.Date;
            var resump = new Date(parseInt(d.substr(6)));
            var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
            var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

            var day = days[resump.getDay()];
            var month = months[resump.getMonth()];
            var hours = resump.getHours();
            var minutes = resump.getMinutes();
            var ampm = hours >= 12 ? 'pm' : 'am';
            hours = hours % 12;
            hours = hours ? hours : 12; // the hour '0' should be '12'
            minutes = minutes < 10 ? '0' + minutes : minutes;
            var strTime = hours + ':' + minutes + ' ' + ampm;

            var resumptDate = day + ", " + month + " - " + resump.getFullYear();
            var s = msg.Subject;
            var n = msg.SenderName;
            var r = msg.RecieverName;
            var m = msg.Body;
            inboxHTML += '<li class="message"><input type="checkbox" value="selected" class="check">';
            inboxHTML += '<span id="senderName" class="sender"> ' + n + "  to  You" + '</span>';
            //inboxHTML += '<span id="senderName" class="sender"> ' + r + '</span>';
            inboxHTML += '<span id="msgSubject" class="subject"> ' + s + '</span>';
            inboxHTML += '<span id="msgDate" class="date"> ' + resumptDate + "  at  " + strTime + '</span>';
            inboxHTML += '</li>';
        }
        inboxHTML += '</ul>';
        $(".inbox").html(inboxHTML);
        //msgBdy.text(m);
        $("body").on("click", ".check", function () {
            $(this).parent().toggleClass("selected");
        });
        $("body").on("click", ".message", function () {
            $(".message").removeClass("active");
            $(this).toggleClass("active");
            //Displays the message body when message is clicked. Get the message from the array using its index number.
            var index = $(".message").index(this);
            var f = data[index].Date;
            var resump = new Date(parseInt(f.substr(6)));
            var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
            var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

            var day = days[resump.getDay()];
            var month = months[resump.getMonth()];
            var hours = resump.getHours();
            var minutes = resump.getMinutes();
            var ampm = hours >= 12 ? 'pm' : 'am';
            hours = hours % 12;
            hours = hours ? hours : 12; // the hour '0' should be '12'
            minutes = minutes < 10 ? '0' + minutes : minutes;
            var strTime = hours + ':' + minutes + ' ' + ampm;

            var msDat = day + ", " + month + " - " + resump.getFullYear();
            var msgBody = '<h1>' + data[index].Subject + '</h1>';
            msgBody += '<h3>' + data[index].SenderName + '</h3>';
            msgBody += '<h4>' + msDat + "  at  " + strTime + '</h4><hr>';
            msgBody += '<h6>' + data[index].Body + '</h6>';
            msgBody += "<div class = 'innerIcon'><a href='#' onclick='LoadDeletedMsg(\"" + data[index].ID + "\")' title='Trash Message' ><i class='fa fa-2x fa-trash btn-outline-danger'></i></a></div>";
            $(".inbox-body").html(msgBody);
        });
        //$("#inboxcount").val(count);
    });
}

function LoadSentMsg(name) {
    //var msgBdy = $(bod);
    $.ajax({
        url: "/Message/LoadSent",
        type: "GET",
        data: { myStaffNo: name },
        cache: false
    }).success(function (data) {
        var count = 0;
        var inboxHTML = '<ul>';
        for (i = 0; i <= data.length - 1; i++) {
            count++;
            var msg = data[i];
            var d = msg.Date;
            var resump = new Date(parseInt(d.substr(6)));
            var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
            var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

            var day = days[resump.getDay()];
            var month = months[resump.getMonth()];
            var hours = resump.getHours();
            var minutes = resump.getMinutes();
            var ampm = hours >= 12 ? 'pm' : 'am';
            hours = hours % 12;
            hours = hours ? hours : 12; // the hour '0' should be '12'
            minutes = minutes < 10 ? '0' + minutes : minutes;
            var strTime = hours + ':' + minutes + ' ' + ampm;

            var resumptDate = day + ", " + month + " - " + resump.getFullYear();
            var s = msg.Subject;
            var n = msg.RecieverName;
            var r = msg.SenderName;
            var m = msg.Body;
            inboxHTML += '<li class="message"><input type="checkbox" value="selected" class="check">';
            inboxHTML += '<span id="senderName" class="sender"> ' + "You  to  " + n + '</span>';
            //inboxHTML += '<span id="recieverName" class="reciever"> ' + r + '</span>';
            inboxHTML += '<span id="msgSubject" class="subject"> ' + s + '</span>';
            inboxHTML += '<span id="msgDate" class="date"> ' + resumptDate + "  at  " + strTime + '</span>';
            inboxHTML += '</li>';
        }
        inboxHTML += '</ul>';
        $(".inbox").html(inboxHTML);
        //msgBdy.text(m);
        $("body").on("click", ".check", function () {
            $(this).parent().toggleClass("selected");
        });
        $("body").on("click", ".message", function () {
            $(".message").removeClass("active");
            $(this).toggleClass("active");
            //Displays the message body when message is clicked. Get the message from the array using its index number.
            var index = $(".message").index(this);
            var f = data[index].Date;
            var resump = new Date(parseInt(f.substr(6)));
            var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
            var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

            var day = days[resump.getDay()];
            var month = months[resump.getMonth()];
            var hours = resump.getHours();
            var minutes = resump.getMinutes();
            var ampm = hours >= 12 ? 'pm' : 'am';
            hours = hours % 12;
            hours = hours ? hours : 12; // the hour '0' should be '12'
            minutes = minutes < 10 ? '0' + minutes : minutes;
            var strTime = hours + ':' + minutes + ' ' + ampm;

            var msDat = day + ", " + month + " - " + resump.getFullYear();
            var msgBody = '<h1>' + data[index].Subject + '</h1>';
            msgBody += '<h3>' + data[index].RecieverName + '</h3>';
            msgBody += '<h4>' + msDat + "  at  " + strTime + '</h4><hr>';
            msgBody += '<h6>' + data[index].Body + '</h6>';
            msgBody += "<div class = 'innerIcon'><a href='#' onclick='LoadDeletedMsg(\"" + data[index].ID + "\")' title='Trash Message' ><i class='fa fa-2x fa-trash btn-outline-danger'></i></a></div>";
            $(".inbox-body").html(msgBody);
        });
        //$("#sentcount").val(count);
    });
}

function LoadTrashMsg(name) {
    $.ajax({
        url: "/Message/LoadTrash",
        type: "GET",
        data: { myStaffNo: name },
        cache: false
    }).success(function (data) {
        var count = 0;
        var inboxHTML = '<ul>';
        for (i = 0; i <= data.length - 1; i++) {
            count++;
            var msg = data[i];
            var d = msg.Date;
            var resump = new Date(parseInt(d.substr(6)));
            var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
            var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

            var day = days[resump.getDay()];
            var month = months[resump.getMonth()];
            var hours = resump.getHours();
            var minutes = resump.getMinutes();
            var ampm = hours >= 12 ? 'pm' : 'am';
            hours = hours % 12;
            hours = hours ? hours : 12; // the hour '0' should be '12'
            minutes = minutes < 10 ? '0' + minutes : minutes;
            var strTime = hours + ':' + minutes + ' ' + ampm;

            var resumptDate = day + ", " + month + " - " + resump.getFullYear();
            var s = msg.Subject;
            var n = msg.RecieverName;
            var r = msg.SenderName;
            var m = msg.Body;
            inboxHTML += '<li class="message"><input type="checkbox" value="selected" class="check">';
            inboxHTML += '<span id="senderName" class="sender"> ' + "You  to  " + n + '</span>';
            //inboxHTML += '<span id="recieverName" class="reciever"> ' + r + '</span>';
            inboxHTML += '<span id="msgSubject" class="subject"> ' + s + '</span>';
            inboxHTML += '<span id="msgDate" class="date"> ' + resumptDate + "  at  " + strTime + '</span>';
            inboxHTML += '</li>';
        }
        inboxHTML += '</ul>';
        $(".inbox").html(inboxHTML);
        //msgBdy.text(m);
        $("body").on("click", ".check", function () {
            $(this).parent().toggleClass("selected");
        });
        $("body").on("click", ".message", function () {
            $(".message").removeClass("active");
            $(this).toggleClass("active");
            //Displays the message body when message is clicked. Get the message from the array using its index number.
            var index = $(".message").index(this);
            var f = data[index].Date;
            var resump = new Date(parseInt(f.substr(6)));
            var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
            var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

            var day = days[resump.getDay()];
            var month = months[resump.getMonth()];
            var hours = resump.getHours();
            var minutes = resump.getMinutes();
            var ampm = hours >= 12 ? 'pm' : 'am';
            hours = hours % 12;
            hours = hours ? hours : 12; // the hour '0' should be '12'
            minutes = minutes < 10 ? '0' + minutes : minutes;
            var strTime = hours + ':' + minutes + ' ' + ampm;

            var msDat = day + ", " + month + " - " + resump.getFullYear();
            var msgBody = '<h1>' + data[index].Subject + '</h1>';
            msgBody += '<h3>' + data[index].RecieverName + '</h3>';
            msgBody += '<h4>' + msDat + "  at  " + strTime + '</h4><hr>';
            msgBody += '<h6>' + data[index].Body + '</h6>';
            msgBody += "<div class = 'col-md-1 innerIcon'><a href='#' onclick='DeletedMsg(\"" + data[index].ID + "\")' title='Trash Message' ><i class='fa fa-trash btn-outline-danger fa-2x'></i></a></div>";
            msgBody += "<div class = 'col-md-1 innerIcon'><a href='#' onclick='RecoverDeletedMsg(\"" + data[index].ID + "\")' title='Recover Message' ><i class='fa fa-recycle fa-2x btn-outline-info'></i></a></div>";
            $(".inbox-body").html(msgBody);
        });
        //$("#trashcount").val(count);
    });
}

function LoadDeletedMsg(Id) {
    $.ajax({
        url: "/Message/MsgStatus",
        data: { id: Id },
        type: "POST"
    }).success(function (result) {
        LoadTrashMsg(sender);
        LoadInboxs(sender);
        LoadSentMsg(sender);
    });
}

function DeletedMsg(Id) {
    $.ajax({
        url: "/Message/MsgStatus",
        data: { id: Id },
        type: "POST"
    }).success(function (result) {
        LoadTrashMsg(sender);
        LoadInboxs(sender);
        LoadSentMsg(sender);
    });
}

function RecoverDeletedMsg(Id) {
    $.ajax({
        url: "/Message/RecoverMsg",
        data: { id: Id },
        type: "POST"
    }).success(function (result) {
        LoadTrashMsg(sender);
        LoadInboxs(sender);
        LoadSentMsg(sender);
    });
}

function countIn(no) {
    $.ajax({
        url: "/Message/CountInbox",
        data: { myStaffNo: no },
        type: "GET"
    }).success(function (result) {
        $("#inboxcount").text(result);
    });
}

function countSe(no) {
    $.ajax({
        url: "/Message/CountSent",
        data: { myStaffNo: no },
        type: "GET"
    }).success(function (result) {
        $("#sentcount").text(result);
    });
}

function countTra(no) {
    $.ajax({
        url: "/Message/CountTrash",
        data: { myStaffNo: no },
        type: "GET"
    }).success(function (result) {
        $("#trashcount").text(result);
    });
}