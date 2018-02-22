<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGeneral.Master" AutoEventWireup="true" CodeBehind="ManageCustomer.aspx.cs" Inherits="PPMS.Web.ManageCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default height">
                    <div class="panel-heading">
                        <strong>Customer List</strong>
                        <label id="message"></label>
                        <button type="button" id="addNewCustomerButton" tabindex="26" class="btn btn-success" style="float: right"><i class="fa fa-plus-circle">Add Customer</i></button>
                    </div>
                    <div class="panel-body table-responsive">
                        <table id="customerList" class="table table-striped table-bordered" cellspacing="0">
                            <thead>
                                <tr>
                                    <th scope="col">Name</th>
                                    <th scope="col">Customer Type</th>
                                    <th scope="col">Contact Number</th>
                                    <th scope="col">Email Id</th>
                                    <th scope="col">Address</th>
                                    <th scope="col">City</th>
                                    <th scope="col">State</th>
                                    <th scope="col">Operation</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="editCustomerModal" class="modal" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Edit Customer</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="customerName">Customer Name:</label>
                            <input type="text" class="form-control" id="customerName" disabled="disabled" />
                            <input style="display: none" type="text" class="form-control" id="customerID" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="customerType">Customer Type:</label>
                            <select class="form-control" id="customerType" tabindex="1">
                                <option value="0">--Select Type--</option>
                            </select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="customerMailID">Customer MailID:</label>
                            <input type="text" class="form-control" id="customerMailID" tabindex="2" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="customerContactNumber">Contact Number:</label>
                            <input type="text" class="form-control" id="customerContactNumber" tabindex="3" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="customerAddr1">Customer Address 1:</label>
                            <input type="text" class="form-control" id="customerAddr1" tabindex="4" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="customerAddr2">Contact Address 2:</label>
                            <input type="text" class="form-control" id="customerAddr2" tabindex="5" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="customerState">Customer State:</label>
                            <select class="form-control" id="customerState" tabindex="6">
                            </select>
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="customerCity">Contact City:</label>
                            <select class="form-control" id="customerCity" tabindex="7">
                                <option value="0">--Select City--</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="editCustomerModalButton" type="button" class="btn btn-success" data-dismiss="modal" tabindex="8">Update</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <div id="createCustomerModal" class="modal" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Create Customer</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="customerName">Customer Name:</label>
                            <input type="text" class="form-control" id="customerNameCreate" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="customerType">Customer Type:</label>
                            <select class="form-control" id="customerTypeCreate" tabindex="1">
                                <option value="0">--Select Type--</option>
                            </select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="customerMailID">Customer MailID:</label>
                            <input type="text" class="form-control" id="customerMailIDCreate" tabindex="2" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="customerContactNumber">Contact Number:</label>
                            <input type="text" class="form-control" id="customerContactNumberCreate" tabindex="3" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="customerAddr1">Customer Address 1:</label>
                            <input type="text" class="form-control" id="customerAddr1Create" tabindex="4" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="customerAddr2">Contact Address 2:</label>
                            <input type="text" class="form-control" id="customerAddr2Create" tabindex="5" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="customerState">Customer State:</label>
                            <select class="form-control" id="customerStateCreate" tabindex="6">
                            </select>
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="customerCity">Contact City:</label>
                            <select class="form-control" id="customerCityCreate" tabindex="7">
                                <option value="0">--Select City--</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="createCustomerModalButton" type="button" class="btn btn-success" data-dismiss="modal" tabindex="8">Create</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
