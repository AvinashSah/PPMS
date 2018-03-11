
$(document).ready(function () {
    BindMeterList();
    function BindMeterList() {
        var meterList = [];
        $.ajax({
            type: "POST",
            url: "MeterService.asmx/GetMeterData",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                for (var key in r.d) {
                    if (r.d.hasOwnProperty(key)) {
                        var MeterData = r.d[key];
                        var meter = {
                            Id: MeterData.Id, Name: MeterData.Name, Description: MeterData.Description,
                            FuelType: MeterData.FuelType, DayStartReading: MeterData.DayStartReading, DayEndReading: MeterData.DayEndReading
                        }
                        meterList.push(meter);
                    }
                }
                BindMeterListToMeterTable(meterList);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindMeterListToMeterTable(meterList) {
        $("#meterList tbody").html("");
        var htmlContent = "";
        for (var i = 0; i < meterList.length; i++) {
            htmlContent += "<tr class=\"meterID\" id=\"" + meterList[i].Id + "\">";
            htmlContent += "<td scope=\"row\">" + meterList[i].Name + "</td>";
            htmlContent += "<td scope=\"row\">" + meterList[i].FuelType + "</td>";
            htmlContent += "<td scope=\"row\">" + meterList[i].Description + "</td>";
            htmlContent += "<td scope=\"row\">" + meterList[i].DayStartReading + "</td>";
            htmlContent += "<td scope=\"row\">" + meterList[i].DayEndReading + "</td>";
            htmlContent += "<td>" + "<button id=\"" + meterList[i].Id + "\" class=\"editMeter btn btn-danger nopadding\" style=\"padding:2px\"><i class=\"glyphicon glyphicon-pencil\"></i></button>" + "</td>";
            htmlContent += "</tr>";
        }
        $("#meterList tbody").append(htmlContent);
        $("#meterList").DataTable();
    }

    $("#addNewMeterButton").click(function () {
        $("#createMeterModel").modal('show');
        BindFuelTypeListToAddModel();
    });
    function BindFuelTypeListToAddModel() {
        var fuelTypeList = [];
        $.ajax({
            type: "POST",
            url: "MeterService.asmx/GetFuelList",
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
        $("#meterFuelTypeCreate").empty();
        var selectStatement = "<option Value=\"0\" selected>Select Fuel Type</option>";
        $("#meterFuelTypeCreate").append(selectStatement);

        for (var i = 0; i < fuelTypeList.length; i++) {
            var fuelTypeListHtml = "<option Value=\"" + fuelTypeList[i].value + "\">" + fuelTypeList[i].text + "</option>";
            $("#meterFuelTypeCreate").append(fuelTypeListHtml);
        }
        return false;
    }
    $("#createMeterModalButton").click(function () {
        var meterName = $("#meterNameCreate").val();
        var meterFuelTypeID = $("#meterFuelTypeCreate").val();
        var meterdesc = $("#meterDescriptionCreate").val();
        var meterStartReading = $("#meterSrtRdCreate").val();
        var meterEndReading = $("#meterEndRdCreate").val();
        var submitMeterData = {
            Name: meterName, FuelTypeID: meterFuelTypeID, 
            Description: meterdesc, DayStartReading: meterStartReading, DayEndReading: meterEndReading
        }
        SubmitCreateMeterData(submitMeterData);
    });

    function SubmitCreateMeterData(submitMeterData) {
        var postData = {
            MeterData: submitMeterData
        };

        $.ajax({
            type: "POST",
            url: "MeterService.asmx/SubmitCreateMeterData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(postData),
            success: function (data) {
                var json = data.d;
                BindMeterList();
                alert(json);
                $("#createMeterModel").modal('hide');
            }
        });
    }

    $("#meterList").on('click', '.editMeter', function () {
        var meterIDClicked = $(this).attr('id');
        event.preventDefault();
        GetMeterDataByID(meterIDClicked);
    });

    function GetMeterDataByID(meterIDClicked) {
        var meterDataClicked = [];
        $.ajax({
            type: "POST",
            url: "MeterService.asmx/GetMeterDataByID",
            data: JSON.stringify({ meterID: meterIDClicked }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                var MeterData = r.d;
                var meter = {
                    Id: MeterData.Id, Name: MeterData.Name, Description: MeterData.Description,
                    FuelTypeID: MeterData.FuelTypeID, FuelTypeName: MeterData.FuelType, DayStartReading: MeterData.DayStartReading, DayEndReading: MeterData.DayEndReading
                }
                meterDataClicked.push(meter);
                BindEditedMeterDataToEditModel(meterDataClicked);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindEditedMeterDataToEditModel(meterDataClicked) {
        for (var i = 0; i < meterDataClicked.length; i++) {

            $("#meterNameEdit").val(meterDataClicked[i].Name);
            $("#meterDescriptionEdit").val(meterDataClicked[i].Description);
            $("#meterSrtRdEdit").val(meterDataClicked[i].DayStartReading);
            $("#meterEndRdEdit").val(meterDataClicked[i].DayEndReading);
            $("#meterID").val(meterDataClicked[i].Id);
            BindFuelTypeListToEditModel(meterDataClicked[i].FuelTypeName);
        }
        $("#editMeterModal").modal('show');
    }
    function BindFuelTypeListToEditModel(fuelTypeName) {
        var fuelTypeList = [];
        $.ajax({
            type: "POST",
            url: "MeterService.asmx/GetFuelList",
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
        $("#meterFuelTypeEdit").empty();
        var selectStatement = "<option Value=\"0\" selected>Select Fuel Type</option>";
        $("#meterFuelTypeEdit").append(selectStatement);

        for (var i = 0; i < fuelTypeList.length; i++) {
            var fuelTypeListHtml = "<option Value=\"" + fuelTypeList[i].value + "\">" + fuelTypeList[i].text + "</option>";
            $("#meterFuelTypeEdit").append(fuelTypeListHtml);
        }
        $("#meterFuelTypeEdit option:contains(" + fuelTypeName + ")").attr('selected', true);
        //return false;
    }

    $("#editMeterModalButton").click(function () {
        var meterID = $("#meterID").val();
        var meterName = $("#meterNameEdit").val();
        var meterFuelTypeID = $("#meterFuelTypeEdit").val();
        var meterdesc = $("#meterDescriptionEdit").val();
        var meterStartReading = $("#meterSrtRdEdit").val();
        var meterEndReading = $("#meterEndRdEdit").val();
        $("#messageEdit").val("");
        var submitMeterData = {
            Id: meterID, Name: meterName, FuelTypeID: meterFuelTypeID,
            Description: meterdesc, DayStartReading: meterStartReading, DayEndReading: meterEndReading
        }
        SubmitEditMeterData(submitMeterData);
    });

    function SubmitEditMeterData(submitMeterData) {
        var postData = {
            MeterData: submitMeterData
        };

        $.ajax({
            type: "POST",
            url: "MeterService.asmx/SubmitEditMeterData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(postData),
            success: function (data) {
                var json = data.d;
                BindMeterList();
                alert(json);
                $("#editMeterModal").modal('hide');
            }
        });
    }
});