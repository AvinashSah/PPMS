$(document).ready(function () {
    BindCustomerListToSalesPage();
    BindFuelListToSalesPage();

    function BindCustomerListToSalesPage() {
        var customerList = [];
        $.ajax({
            type: "POST",
            url: "CustomerService.asmx/GetCustomerList",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                for (var key in r.d) {
                    if (r.d.hasOwnProperty(key)) {
                        var CustomerData = r.d[key];
                        var customer = { Id: CustomerData.Id, Name: CustomerData.Name, ContactNumber: CustomerData.ContactNumber, EmailID: CustomerData.EmailID, Addr1: CustomerData.Addr1, Addr2: CustomerData.Addr2, City: CustomerData.City, State: CustomerData.State, Type: CustomerData.Type }
                        customerList.push(customer);
                    }
                }
                BindCustomerListToSalesPageDropDown(customerList);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindCustomerListToSalesPageDropDown(customerList) {
        $("#customerSale").empty();
        var selectStatement = "<option Value=\"0\" selected>--Select Customer For Sale--</option>";
        $("#customerSale").append(selectStatement);

        for (var i = 0; i < customerList.length; i++) {
            var stateListHtml = "<option Value=\"" + customerList[i].Id + "\">" + customerList[i].Name + "</option>";
            $("#customerSale").append(stateListHtml);
        }
        var slect = "--Select Customer For Sale--";
        $("#customerSale option:contains(" + slect + ")").attr('selected', true);
        return false;
    }

    function BindFuelListToSalesPage() {
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
                BindFuelListToFuelSalePageDropDown(fuelList);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindFuelListToFuelSalePageDropDown(fuelList) {
        $("#customerFuelSale").empty();
        var selectStatement = "<option Value=\"0\" selected>--Select Fuel For Sale--</option>";
        $("#customerFuelSale").append(selectStatement);

        for (var i = 0; i < fuelList.length; i++) {
            var stateListHtml = "<option Value=\"" + fuelList[i].Id + "\">" + fuelList[i].Name + "</option>";
            $("#customerFuelSale").append(stateListHtml);
        }
        var slect = "--Select Fuel For Sale--";
        $("#customerFuelSale option:contains(" + slect + ")").attr('selected', true);
        return false;
    }

    $("#customerFuelSale").change(function () {
        var optionSelected = $(this).find("option:selected");
        var fuelID = optionSelected.val();
        GetFuelDataByID(fuelID);
    });

    $("#SaleType").change(function () {
        var optionSelected = $(this).find("option:selected");
        var saleID = optionSelected.val();
        if (saleID == 3) {
            $("#customerTokenDiv").show();
        }
        else {
            $("#customerTokenDiv").hide();
        }
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
                BindFuelCostToCostInput(fuelDataClicked, fuelIDClicked);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindFuelCostToCostInput(fuelDataClicked, fuelIDClicked) {
        for (var i = 0; i < fuelDataClicked.length; i++) {
            if (fuelIDClicked.trim() == fuelDataClicked[i].Id) {
                $("#customerFuelAmountCost").val(fuelDataClicked[i].CostPerLiter);
                break;
            }
        }
    }
});