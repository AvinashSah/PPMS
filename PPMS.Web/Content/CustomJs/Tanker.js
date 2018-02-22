//$(document).ready(function () {
//    $('#tankerList').DataTable();
//});

$(document).ready(function () {
    BindTankerList();
    debugger;
    function BindTankerList() {
        debugger;
        var tankerList = [];
        $.ajax({
            type: "POST",
            url: "TankerService.asmx/GetTankerData",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                for (var key in r.d) {
                    if (r.d.hasOwnProperty(key)) {
                        var TankerData = r.d[key];
                        var tanker = {
                            Id: TankerData.Id, Name: TankerData.Name, Size: TankerData.Size, Description: TankerData.Description,
                            FuelType: TankerData.FuelType, DayStartReading: TankerData.DayStartReading, DayEndReading: TankerData.DayEndReading/*, Date: TankerData.Date*/
                        }
                        tankerList.push(tanker);
                    }
                }
                BindTankerListToTankerTable(tankerList);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindTankerListToTankerTable(tankerList) {
        $("#tankerList tbody").html("");
        var htmlContent = "";
        debugger;
        for (var i = 0; i < tankerList.length; i++) {
            htmlContent += "<tr class=\"tankerID\" id=\"" + tankerList[i].Id + "\">";
            htmlContent += "<td scope=\"row\">" + tankerList[i].Name + "</td>";
            htmlContent += "<td scope=\"row\">" + tankerList[i].FuelType + "</td>";
            htmlContent += "<td scope=\"row\">" + tankerList[i].Size + "</td>";
            htmlContent += "<td scope=\"row\">" + tankerList[i].DayStartReading + "</td>";
            htmlContent += "<td scope=\"row\">" + tankerList[i].DayEndReading + "</td>";
            //htmlContent += "<td scope=\"row\">" + tankerList[i].Date + "</td>";
            htmlContent += "<td scope=\"row\">" + tankerList[i].Description + "</td>";
            htmlContent += "<td>" + "<button id=\"" + tankerList[i].Id + "\" class=\"editTanker btn btn-danger nopadding\" style=\"padding:2px\"><i class=\"glyphicon glyphicon-pencil\"></i></button>" + "</td>";
            htmlContent += "</tr>";
        }
        $("#tankerList tbody").append(htmlContent);
        $("#tankerList").DataTable();
    }

    $("#addNewTankerButton").click(function () {
        $("#createTankerModel").modal('show');
        BindFuelTypeListToAddModel();
    });
    function BindFuelTypeListToAddModel() {
        debugger;
        var fuelTypeList = [];
        $.ajax({
            type: "POST",
            url: "TankerService.asmx/GetFuelList",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                for (var key in r.d) {
                    if (r.d.hasOwnProperty(key)) {
                        var DropDownFuelType = r.d[key];
                        var fuelType = { value: DropDownFuelType.Id, text: DropDownFuelType.Type }
                        fuelTypeList.push(fuelType);
                    }
                }
                BindFuelTypeListToAddModelDropDown(fuelTypeList);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindFuelTypeListToAddModelDropDown(fuelTypeList) {
        $("#tankerFuelTypeCreate").empty();
        var selectStatement = "<option Value=\"0\" selected>Select Fuel Type</option>";
        $("#tankerFuelTypeCreate").append(selectStatement);

        for (var i = 0; i < fuelTypeList.length; i++) {
            var fuelTypeListHtml = "<option Value=\"" + fuelTypeList[i].value + "\">" + fuelTypeList[i].text + "</option>";
            $("#tankerFuelTypeCreate").append(fuelTypeListHtml);
        }
        return false;
    }
    $("#createTankerModalButton").click(function () {
        debugger;
        var tankerName = $("#tankerNameCreate").val();
        var tankerFuelTypeID = $("#tankerFuelTypeCreate").val();
        var tankersize = $("#tankerSizeCreate").val();
        var tankerdesc = $("#tankerDescriptionCreate").val();
        var tankerStartReading = $("#tankerSrtRdCreate").val();
        var tankerEndReading = $("#tankerEndRdCreate").val();
        //var tankerDate = $("#tankerDateCreate").val();
        var submitTankerData = {
            Name: tankerName, FuelTypeID: tankerFuelTypeID, Size: tankersize,
            Description: tankerdesc, DayStartReading: tankerStartReading, DayEndReading: tankerEndReading/*, Date: tankerDate*/
        }
        SubmitCreateTankerData(submitTankerData);
    });

    function SubmitCreateTankerData(submitTankerData) {
        var postData = {
            TankerData: submitTankerData
        };

        $.ajax({
            type: "POST",
            url: "TankerService.asmx/SubmitCreateTankerData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(postData),
            success: function (data) {
                var json = data.d;
                BindTankerList();
                alert(json);
                $("#createTankerModel").modal('hide');
            }
        });
    }

    //function GetFuelList(controlName) {
    //    debugger;
    //    $(controlName).html("");
    //    var uel3 = "TankerService.asmx/GetFuelList";
    //    var fuelList = [];
    //    $.ajax({
    //        type: "POST",
    //        url: uel3,
    //        data: "",
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        async: false,
    //        success: function (r) {
    //            for (var key in r.d) {
    //                if (r.d.hasOwnProperty(key)) {
    //                    var FuelData = r.d[key];
    //                    var fuel = {
    //                        Id: FuelData.Id, FuelType: FuelData.Type
    //                    }
    //                    fuelList.push(fuel);
    //                }
    //            }
    //            var markup = "<option value='0'>Select Fuel Type</option>";
    //            for (var i = 0; i < fuelList.length; i++) {
    //                markup += "<option value=" + '"' + fuelList[i].Id + '"' + ">" + fuelList[i].FuelType + "</option>";
    //            }
    //            $(controlName).append(markup);
    //        },
    //        error: function (r) {
    //            alert(r.responseText);
    //        },
    //        failure: function (r) {
    //            alert(r.responseText);
    //        }
    //    });
    //}

    $("#tankerList").on('click', '.editTanker', function () {
        debugger;
        var tankerIDClicked = $(this).attr('id');
        event.preventDefault();
        GetTankerDataByID(tankerIDClicked);
    });

    function GetTankerDataByID(tankerIDClicked) {
        var tankerDataClicked = [];
        $.ajax({
            type: "POST",
            url: "TankerService.asmx/GetTankerDataByID",
            data: JSON.stringify({ tankerID: tankerIDClicked }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                var TankerData = r.d;
                var tanker = {
                    Id: TankerData.Id, Name: TankerData.Name, Size: TankerData.Size, Description: TankerData.Description,
                    FuelTypeID: TankerData.FuelTypeID, FuelTypeName: TankerData.FuelType, DayStartReading: TankerData.DayStartReading, DayEndReading: TankerData.DayEndReading/*, Date: TankerData.Date*/
                }
                tankerDataClicked.push(tanker);
                BindEditedTankerDataToEditModel(tankerDataClicked);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindEditedTankerDataToEditModel(tankerDataClicked) {
        debugger;
        for (var i = 0; i < tankerDataClicked.length; i++) {

            $("#tankerNameEdit").val(tankerDataClicked[i].Name);
            $("#tankerSizeEdit").val(tankerDataClicked[i].Size);
            $("#tankerDescriptionEdit").val(tankerDataClicked[i].Description);
            $("#tankerSrtRdEdit").val(tankerDataClicked[i].DayStartReading);
            $("#tankerEndRdEdit").val(tankerDataClicked[i].DayEndReading);
            $("#tankerID").val(tankerDataClicked[i].Id);
            BindFuelTypeListToEditModel(tankerDataClicked[i].FuelTypeName);
        }
        $("#editTankerModal").modal('show');
    }
    function BindFuelTypeListToEditModel(fuelTypeName) {
        debugger;
        var fuelTypeList = [];
        $.ajax({
            type: "POST",
            url: "TankerService.asmx/GetFuelList",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                for (var key in r.d) {
                    if (r.d.hasOwnProperty(key)) {
                        var DropDownFuelType = r.d[key];
                        var fuelType = { value: DropDownFuelType.Id, text: DropDownFuelType.Type }
                        fuelTypeList.push(fuelType);
                    }
                }
                BindFuelTypeListToEditModelDropDown(fuelTypeList, fuelTypeName);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindFuelTypeListToEditModelDropDown(fuelTypeList, fuelTypeName) {
        $("#tankerFuelTypeEdit").empty();
        var selectStatement = "<option Value=\"0\" selected>Select Fuel Type</option>";
        $("#tankerFuelTypeEdit").append(selectStatement);

        for (var i = 0; i < fuelTypeList.length; i++) {
            var fuelTypeListHtml = "<option Value=\"" + fuelTypeList[i].value + "\">" + fuelTypeList[i].text + "</option>";
            $("#tankerFuelTypeEdit").append(fuelTypeListHtml);
        }
        $("#tankerFuelTypeEdit option:contains(" + fuelTypeName + ")").attr('selected', true);
        //return false;
    }

    $("#editTankerModalButton").click(function () {
        var tankerID = $("#tankerID").val();
        var tankerName = $("#tankerNameEdit").val();
        var tankerFuelTypeID = $("#tankerFuelTypeEdit").val();
        var tankersize = $("#tankerSizeEdit").val();
        var tankerdesc = $("#tankerDescriptionEdit").val();
        var tankerStartReading = $("#tankerSrtRdEdit").val();
        var tankerEndReading = $("#tankerEndRdEdit").val();
        $("#messageEdit").val("");
        var submitTankerData = {
            Id: tankerID, Name: tankerName, FuelTypeID: tankerFuelTypeID, Size: tankersize,
            Description: tankerdesc, DayStartReading: tankerStartReading, DayEndReading: tankerEndReading
        }
        SubmitEditTankerData(submitTankerData);
    });

    function SubmitEditTankerData(submitTankerData) {
        var postData = {
            TankerData: submitTankerData
        };

        $.ajax({
            type: "POST",
            url: "TankerService.asmx/SubmitEditTankerData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(postData),
            success: function (data) {
                var json = data.d;
                BindTankerList();
                alert(json);
                $("#editTankerModal").modal('hide');
            }
        });
    }
});