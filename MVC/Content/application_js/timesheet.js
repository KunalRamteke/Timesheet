$(document).ready(function () {
    $('.navbar').css('background-color', 'skyblue');

    var arrData;
    var userId = $('#userId').val();

    var link = "http://localhost/MVC/api/system/gettimesheet?id=" + userId;

    
    //function to call api to get all timesheet records
    getRecords = function () {
        var hourscount = 0;
        $.ajax({
            url: link,
            type: "GET",
            success: function (data) {
                //console.log(data);
                arrData = data;
                $("#tbtimesheet").html("");
                for (var i = 0; i < data.length; i++) {
                    $("<tr><td>" + (i + 1) + "</td><td>" + data[i].ProjectName + "</td><td>" + data[i].Description + "</td><td>" + data[i].Hour + "</td><td><a href=\"#\" data-id=" + data[i].Id + " class=\"edit\">Edit</a> | <a href=\"#\" data-id=" + data[i].Id + " class=\"delete\">Delete</a></td></tr>").appendTo("#tbtimesheet");
                    hourscount = hourscount + data[i].Hour;
                }
                $('#hourscount').text(hourscount);
            },
            error: function (msg) {
                //alert("In Get records");
                console.log(msg);
            }
        });
    }

    getRecords();

    //Dailog box for timesheet
    $('#divnewtimesheet').hide();
    $("#divnewtimesheet").dialog({
        autoOpen: false,
         fluid: true, //new option
        resizable: false,
        modal: true,
    });

    //dailog box for delete confermation
    $('#dialog').hide();
    $("#dialog").dialog({
        modal: true,
        bgiframe: true,
        width: 500,
        height: 200,
        autoOpen: false
    });

    // open dialog to create new timesheet
    $("#btnnewtimesheet").click(function () {
        $('#projectname').val("");
        $('#description').val("");
        $('#hour').val("");
        $("#divnewtimesheet").dialog("open");
        $("#save").css("color", "green");

    });

    // save new timesheet
    $("#save").click(function () {
        console.log("Create button clicked");
        var objTimesheet = {};
        objTimesheet.Id = $('#timesheetid').val();
        objTimesheet.ProjectName = $.trim($('#projectname').val());
        objTimesheet.Description = $.trim($('#description').val());
        objTimesheet.Hour = $.trim($('#hour').val());
        objTimesheet.UserId = userId;
        var timesheetObjJSON = JSON.stringify(objTimesheet);
        console.log(" stringify object " + timesheetObjJSON);     
       
    $('#dailog-new').validate({
        rules: {
            ProjectName: {
                required: true
            },
            Description: { required: true },
            Hour: { required: true, maxlength: 8 },
            messages: {
                    Hour: {
                        required: "What is your password?",
                        maxlength: "Please enter hours less than or equal to 8"
                       }
            }
        }
    });
        
        if ($('#projectname').val() == "" | $('#description').val() == "" | $('#hour').val() == "")
        {
            alert("Fields can not be blank");
        }
        else {
            if (objTimesheet.Id == "") {
                $.ajax({
                    url: "http://localhost/MVC/api/system/CreateTimesheet",
                    type: "Post",
                    data: timesheetObjJSON,
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        alert("Record Inserted");
                        getRecords();
                    },
                    error: function (error) {
                        alert('error; ' + eval(error));
                    }
                });
                $("#divnewtimesheet").dialog("close");
                alert("Record inserted successfulyy");
            }
            else {
                $.ajax({
                    url: "http://localhost/MVC/api/system/Edit",
                    type: "Put",
                    data: timesheetObjJSON,
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        $("#divnewtimesheet").dialog("close");
                        console.log("In edit call");
                        alert("Record Edited successfully");
                        getRecords();
                    },
                    error: function (error) {
                        //alert('error; ' + eval(error));
                    }
                });
                $("#divnewtimesheet").dialog("close");
                alert("Record Edited Succesfully");
            }
        }
    });

    //On Edit Click
    $(document).on('click', 'td a.edit', function () {

        $("#divnewtimesheet").dialog("open");
        $("#save").css("color", "green");
        var id = $(this).attr('data-id');
        for (var iIndex = 0; iIndex < arrData.length; iIndex++) {
            if (arrData[iIndex].Id == id) {
                $('#timesheetid').val(arrData[iIndex].Id);
                $('#projectname').val(arrData[iIndex].ProjectName);
                $('#description').val(arrData[iIndex].Description);
                $('#hour').val(arrData[iIndex].Hour);
            }
        }
    });

    $(document).on('click', 'td a.delete', function (data) {
        var id = $(this).attr('data-id');
        $("#dialog").dialog("open");
        $("#dialog").dialog({
            buttons: {
                "Confirm": function () {
                    console.log("In confirm");
                    $(this).dialog("close");
                    for (var iIndex = 0; iIndex < arrData.length; iIndex++) {
                        if (arrData[iIndex].Id == id) {
                            timesheetId = arrData[iIndex].Id;
                            console.log(timesheetId);
                            console.log(arrData[iIndex]);
                            $.ajax({
                                url: "http://localhost/MVC/api/system?id=" + id,
                                type: "Delete",
                                //data: timesheetObjJSON,
                                contentType: 'application/json; charset=utf-8',
                                success: function (data) {
                                    console.log(id);
                                    getRecords();
                                },
                                error: function (error) {
                                    //alert('error ' + eval(error));
                                },
                            });
                        }
                    }
                },
                "Cancel": function () {
                    console.log("in cancel");
                    $(this).dialog("close");
                }
            }
        })
    });

});//document close
