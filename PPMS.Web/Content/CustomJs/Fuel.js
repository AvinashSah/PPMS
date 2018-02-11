$(document).ready(function () {
    BindFuelList();

    function BindFuelList() {
        var fuelList = [];
        $.ajax({
            type: "POST",
            url: "FuelService.asmx/GetFuelData",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                for (var key in r.d) {
                    if (r.d.hasOwnProperty(key)) {
                        var FuelData = r.d[key];
                        var fuel = { Id: FuelData.Id, Name: FuelData.Name, Description: FuelData.Description, Type: FuelData.Type, CostPerLiter: FuelData.CostPerLiter }
                        fuelList.push(fuel);
                    }
                }
                BindFuelListToFuelTable(fuelList);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindFuelListToFuelTable(fuelList) {
        $("#fuelList tbody").html("");
        var htmlContent = "";

        for (var i = 0; i < fuelList.length; i++) {
            htmlContent += "<tr class=\"fuelID\" id=\"" + (i + 1) + "\">";
            htmlContent += "<td scope=\"row\">" + fuelList[i].Name + "</td>";
            htmlContent += "<td scope=\"row\">" + fuelList[i].Type + "</td>";
            htmlContent += "<td scope=\"row\">" + fuelList[i].Description + "</td>";
            htmlContent += "<td scope=\"row\">" + fuelList[i].CostPerLiter + "</td>";
            htmlContent += "<td>" + "<button id=\"" + (i + 1) + "\" class=\"editFuel btn btn-danger nopadding\" style=\"padding:2px\"><i class=\"glyphicon glyphicon-pencil\"></i></button>" + "</td>";
            htmlContent += "</tr>";
        }
        $("#fuelList tbody").append(htmlContent);
        $("#fuelList").DataTable();
    }

    $("#fuelList").on('click', '.editFuel', function () {
        var fuelIDClicked = $(this).attr('id');
        event.preventDefault();
        GetFuelDataByID(fuelIDClicked);
    });

    $("#addNewFuelButton").click(function () {
        $("#createFuelModel").modal('show');
    });

    function GetFuelDataByID(fuelIDClicked) {
        var fuelDataClicked = [];
        $.ajax({
            type: "POST",
            url: "FuelService.asmx/GetFuelDataByID",
            data: JSON.stringify({ fuelID: fuelIDClicked }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                var FuelData = r.d;
                var fuel = { Id: FuelData.Id, Name: FuelData.Name, Description: FuelData.Description, Type: FuelData.Type, CostPerLiter: FuelData.CostPerLiter }
                fuelDataClicked.push(fuel);
                BindEditedFuelDataToEditModel(fuelDataClicked);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindEditedFuelDataToEditModel(fuelDataClicked) {
        for (var i = 0; i < fuelDataClicked.length; i++) {
            $("#fuelName").val(fuelDataClicked[i].Name);
            $("#fuelType").val(fuelDataClicked[i].Type);
            $("#description").val(fuelDataClicked[i].Description);
            $("#CostLtr").val(fuelDataClicked[i].CostPerLiter);
            $("#fuelID").val(fuelDataClicked[i].Id);
        }
        $("#editFuelModal").modal('show');
    }

    $("#editFuelModalButton").click(function () {
        var fuelName = $("#fuelName").val();
        var fuelType = $("#fuelType").val();
        var desc = $("#description").val();
        var costperliter = $("#CostLtr").val();
        var fuelID = $("#fuelID").val();
        $("#messageEdit").val("");
        var submitFuelData = { Id: fuelID, Name: fuelName, Description: desc, Type: fuelType, CostPerLiter: costperliter }
        SubmitEditFuelData(submitFuelData);
    });

    function SubmitEditFuelData(submitFuelData) {
        var postData = {
            FuelData: submitFuelData
        };

        $.ajax({
            type: "POST",
            url: "FuelService.asmx/SubmitEditFuelData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(postData),
            success: function (data) {
                var json = data.d;
                BindFuelList();
                alert(json);
                //$("#message").html = json;
                //setTimeout(function () { $("#message").fadeOut(); }, 10000);
                $("#editFuelModal").modal('hide');
            }
        });
    }

    $("#createFuelModalButton").click(function () {
        var fuelName = $("#fuelNameCreate").val();
        var fuelType = $("#fuelTypeCreate").val();
        var desc = $("#descriptionCreate").val();
        var costperliter = $("#CostLtrCreate").val();
        var submitFuelData = { Id: fuelID, Name: fuelName, Description: desc, Type: fuelType, CostPerLiter: costperliter }
        SubmitCreateFuelData(submitFuelData);
    });

    function SubmitCreateFuelData(submitFuelData) {
        var postData = {
            FuelData: submitFuelData
        };

        $.ajax({
            type: "POST",
            url: "FuelService.asmx/SubmitCreateFuelData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(postData),
            success: function (data) {
                var json = data.d;
                BindFuelList();
                alert(json);
                $//("#message").html = json;
                //setTimeout(function () { $("#message").fadeOut(); }, 10000);
                $("#createFuelModel").modal('hide');
            }
        });
    }
});