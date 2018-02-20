$(document).ready(function () {

    BindCustomerList();

    function BindCustomerList() {
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
                BindCustomerListToCustomerTable(customerList);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindCustomerListToCustomerTable(customerList) {
        $("#customerList tbody").html("");
        var htmlContent = "";

        for (var i = 0; i < customerList.length; i++) {
            htmlContent += "<tr class=\"fuelID\" id=\"" + (customerList[i].Id) + "\">";
            htmlContent += "<td scope=\"row\">" + customerList[i].Name + "</td>";
            htmlContent += "<td scope=\"row\">" + customerList[i].Type + "</td>";
            htmlContent += "<td scope=\"row\">" + customerList[i].ContactNumber + "</td>";
            htmlContent += "<td scope=\"row\">" + customerList[i].EmailID + "</td>";
            htmlContent += "<td scope=\"row\">" + (customerList[i].Addr1 + "," + customerList[i].Addr2) + "</td>";
            htmlContent += "<td scope=\"row\">" + customerList[i].City + "</td>";
            htmlContent += "<td scope=\"row\">" + customerList[i].State + "</td>";
            htmlContent += "<td>" + "<button id=\"" + (customerList[i].Id) + "\" class=\"editCustomer btn btn-danger nopadding\" style=\"padding:2px\"><i class=\"glyphicon glyphicon-pencil\"></i></button>" + "</td>";
            htmlContent += "</tr>";
        }
        $("#customerList tbody").append(htmlContent);
        $("#customerList").DataTable();
    }

    $("#customerList").on('click', '.editCustomer', function () {
        var customerIDClicked = $(this).attr('id');
        GetCustomerDataByID(customerIDClicked);
        event.preventDefault();
    });

    function GetCustomerDataByID(customerIDClicked) {
        var customerDataClicked = [];
        $.ajax({
            type: "POST",
            url: "CustomerService.asmx/GetCustomerDataByID",
            data: JSON.stringify({ customerID: customerIDClicked }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                var CustomerData = r.d;
                var customer = { Id: CustomerData.Id, Name: CustomerData.Name, ContactNumber: CustomerData.ContactNumber, EmailID: CustomerData.EmailID, Addr1: CustomerData.Addr1, Addr2: CustomerData.Addr2, City: CustomerData.City, State: CustomerData.State, Type: CustomerData.Type }
                customerDataClicked.push(customer);
                BindEditedCustomerDataToEditModel(customerDataClicked);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindEditedCustomerDataToEditModel(customerDataClicked) {
        for (var i = 0; i < customerDataClicked.length; i++) {
            $("#customerID").val(customerDataClicked[i].Id);
            $("#customerName").val(customerDataClicked[i].Name);
            $("#customerMailID").val(customerDataClicked[i].EmailID);
            $("#customerContactNumber").val(customerDataClicked[i].ContactNumber);
            $("#customerAddr1").val(customerDataClicked[i].Addr1);
            $("#customerAddr2").val(customerDataClicked[i].Addr2);
            var stateName = customerDataClicked[i].State;
            var cityName = customerDataClicked[i].City;
            var customerTypeName = customerDataClicked[i].Type;
            BindStateListToEditModel(stateName, cityName);
            BindCustomerTypeListToEditModel(customerTypeName);
        }
        $("#editCustomerModal").modal('show');
    }

    function BindCustomerTypeListToEditModel(customerTypeName) {
        var customerTypeList = [];
        $.ajax({
            type: "POST",
            url: "CustomerService.asmx/GetListOfCustomerTypes",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                for (var key in r.d) {
                    if (r.d.hasOwnProperty(key)) {
                        var DropDownCustomerType = r.d[key];
                        var customerType = { value: DropDownCustomerType.Value, text: DropDownCustomerType.text }
                        customerTypeList.push(customerType);
                    }
                }
                BindCustomerTypeListToEditModelDropDown(customerTypeList, customerTypeName);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindCustomerTypeListToEditModelDropDown(customerTypeList, customerTypeName) {
        $("#customerType").empty();
        var selectStatement = "<option Value=\"0\" selected>--Select Customer Type--</option>";
        $("#customerType").append(selectStatement);

        for (var i = 0; i < customerTypeList.length; i++) {
            var customerTypeListHtml = "<option Value=\"" + customerTypeList[i].value + "\">" + customerTypeList[i].text + "</option>";
            $("#customerType").append(customerTypeListHtml);
        }
        $("#customerType option:contains(" + customerTypeName + ")").attr('selected', true);
        return false;
    }

    function BindStateListToEditModel(stateName, cityName) {
        var stateList = [];
        $.ajax({
            type: "POST",
            url: "CommonService.asmx/GetListOfStates",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                for (var key in r.d) {
                    if (r.d.hasOwnProperty(key)) {
                        var DropDownState = r.d[key];
                        var stateOption = { value: DropDownState.Value, text: DropDownState.text }
                        stateList.push(stateOption);
                    }
                }
                BindStateListToEditModelDropDown(stateList, stateName, cityName);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindStateListToEditModelDropDown(stateList, stateName, cityName) {
        $("#customerState").empty();
        var selectStatement = "<option Value=\"0\" selected>--Select State--</option>";
        $("#customerState").append(selectStatement);

        for (var i = 0; i < stateList.length; i++) {
            var stateListHtml = "<option Value=\"" + stateList[i].value + "\">" + stateList[i].text + "</option>";
            $("#customerState").append(stateListHtml);
        }
        $("#customerState option:contains(" + stateName + ")").attr('selected', true);
        var stateID = $("#customerState").val();
        BindCityListForCustomerStateEdtModel(stateID, cityName);
        return false;
    }

    function BindCityListForCustomerStateEdtModel(stateID, cityName) {
        var cityList = [];
        $.ajax({
            type: "POST",
            url: "CommonService.asmx/GetListOfCitiesByStates",
            data: JSON.stringify({ valueSelected: stateID }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                for (var key in r.d) {
                    if (r.d.hasOwnProperty(key)) {
                        var DropDownCity = r.d[key];
                        var cityOption = { value: DropDownCity.Value, text: DropDownCity.text }
                        cityList.push(cityOption);
                    }
                }
                BindCityListForCustomerStateEditModelDropDown(cityList, cityName);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindCityListForCustomerStateEditModelDropDown(cityList, cityName) {
        $("#customerCity").html('');

        var selectStatement = "<option Value=\"0\" selected>--Select City--</option>";
        $("#customerCity").append(selectStatement);

        for (var i = 0; i < cityList.length; i++) {
            var cityListHtml = "<option Value=\"" + cityList[i].value + "\">" + cityList[i].text + "</option>";
            $("#customerCity").append(cityListHtml);
        }
        $("#customerCity option:contains(" + cityName + ")").attr('selected', true);
        return false;
    }

    $("#editCustomerModalButton").click(function () {
        var customerName = $("#customerName").val();
        var customerId = $("#customerID").val();
        var customerType = $('#customerType :selected').val();
        var customerMailID = $("#customerMailID").val();
        var customerContactNumber = $("#customerContactNumber").val();
        var customerAddr1 = $("#customerAddr1").val();
        var customerAddr2 = $("#customerAddr2").val();
        var customerStateName = $('#customerState :selected').text();
        var customerCityName = $('#customerCity :selected').text();

        var submitCustomerUpdateData = { Id: customerId, Name: customerName, ContactNumber: customerContactNumber, EmailID: customerMailID, Addr1: customerAddr1, Addr2: customerAddr2, City: customerCityName, State: customerStateName, Type: customerType }
        SubmitUpdateCustomerData(submitCustomerUpdateData);
    });

    $("#addNewCustomerButton").click(function () {
        BindStateListToCreateModal();
        BindCustomerTypeListToCreateModel();
        $("#createCustomerModal").modal('show');
    });

    $("#createCustomerModalButton").click(function () {
        var customerName = $("#customerNameCreate").val();
        var customerType = $('#customerTypeCreate :selected').val();
        var customerMailID = $("#customerMailIDCreate").val();
        var customerContactNumber = $("#customerContactNumberCreate").val();
        var customerAddr1 = $("#customerAddr1Create").val();
        var customerAddr2 = $("#customerAddr2Create").val();
        var customerStateName = $('#customerStateCreate :selected').text();
        var customerCityName = $('#customerCityCreate :selected').text();

        var submitCustomerCreateData = { Name: customerName, ContactNumber: customerContactNumber, EmailID: customerMailID, Addr1: customerAddr1, Addr2: customerAddr2, City: customerCityName, State: customerStateName, Type: customerType }

        SubmitCreateCustomerData(submitCustomerCreateData);
    });

    function BindStateListToCreateModal() {
        var stateList = [];
        $.ajax({
            type: "POST",
            url: "CommonService.asmx/GetListOfStates",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                for (var key in r.d) {
                    if (r.d.hasOwnProperty(key)) {
                        var DropDownState = r.d[key];
                        var stateOption = { value: DropDownState.Value, text: DropDownState.text }
                        stateList.push(stateOption);
                    }
                }
                BindStateListToCreateModelDropDown(stateList);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindStateListToCreateModelDropDown(stateList) {
        $("#customerStateCreate").empty();
        var selectStatement = "<option Value=\"0\" selected>--Select State--</option>";
        $("#customerStateCreate").append(selectStatement);

        for (var i = 0; i < stateList.length; i++) {
            var stateListHtml = "<option Value=\"" + stateList[i].value + "\">" + stateList[i].text + "</option>";
            $("#customerStateCreate").append(stateListHtml);
        }
        return false;
    }

    function BindCustomerTypeListToCreateModel() {
        var customerTypeList = [];
        $.ajax({
            type: "POST",
            url: "CustomerService.asmx/GetListOfCustomerTypes",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                for (var key in r.d) {
                    if (r.d.hasOwnProperty(key)) {
                        var DropDownCustomerType = r.d[key];
                        var customerType = { value: DropDownCustomerType.Value, text: DropDownCustomerType.text }
                        customerTypeList.push(customerType);
                    }
                }
                BindCustomerTypeListToCreateModelDropDown(customerTypeList);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindCustomerTypeListToCreateModelDropDown(customerTypeList) {
        $("#customerTypeCreate").empty();
        var selectStatement = "<option Value=\"0\" selected>--Select Customer Type--</option>";
        $("#customerTypeCreate").append(selectStatement);

        for (var i = 0; i < customerTypeList.length; i++) {
            var customerTypeListHtml = "<option Value=\"" + customerTypeList[i].value + "\">" + customerTypeList[i].text + "</option>";
            $("#customerTypeCreate").append(customerTypeListHtml);
        }
        return false;
    }

    function SubmitUpdateCustomerData(submitCustomerUpdateData) {
        var postData = {
            CustomerData: submitCustomerUpdateData
        };

        $.ajax({
            type: "POST",
            url: "CustomerService.asmx/SubmitEditCustomerData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(postData),
            success: function (data) {
                var json = data.d;
                BindCustomerList();
                alert(json);
                $("#editCustomerModal").modal('hide');
            }
        });
    }

    function SubmitCreateCustomerData(submitCustomerCreateData) {
        var postData = {
            CustomerData: submitCustomerCreateData
        };

        $.ajax({
            type: "POST",
            url: "CustomerService.asmx/SubmitCreateCustomerData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(postData),
            success: function (data) {
                var json = data.d;
                $("#createCustomerModal").modal('hide');
                BindCustomerList();
                alert(json);
            }
        });
    }


    $("#customerStateCreate").change(function () {
        var optionSelected = $(this).find("option:selected");
        var stateID = optionSelected.val();
        BindCityListForCustomerStateCreateModel(stateID);
    });

    function BindCityListForCustomerStateCreateModel(stateID) {
        var cityList = [];
        $.ajax({
            type: "POST",
            url: "CommonService.asmx/GetListOfCitiesByStates",
            data: JSON.stringify({ valueSelected: stateID }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                for (var key in r.d) {
                    if (r.d.hasOwnProperty(key)) {
                        var DropDownCity = r.d[key];
                        var cityOption = { value: DropDownCity.Value, text: DropDownCity.text }
                        cityList.push(cityOption);
                    }
                }
                BindCityListForCustomerStateCreateModelDropDown(cityList);
            },
            error: function (r) {
                alert(r.responseText);
            },
            failure: function (r) {
                alert(r.responseText);
            }
        });
    }

    function BindCityListForCustomerStateCreateModelDropDown(cityList) {
        $("#customerCityCreate").html('');

        var selectStatement = "<option Value=\"0\" selected>--Select City--</option>";
        $("#customerCityCreate").append(selectStatement);

        for (var i = 0; i < cityList.length; i++) {
            var cityListHtml = "<option Value=\"" + cityList[i].value + "\">" + cityList[i].text + "</option>";
            $("#customerCityCreate").append(cityListHtml);
        }
        $("#customerCity option:contains(" +"--Select City--"+ ")").attr('selected', true);
        return false;
    }
});