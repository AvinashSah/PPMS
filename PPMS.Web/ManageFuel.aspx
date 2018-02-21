<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGeneral.Master" AutoEventWireup="true" CodeBehind="ManageFuel.aspx.cs" Inherits="PPMS.Web.ManageFuel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default height">
                    <div class="panel-heading">
                        <strong>Fuel List</strong>
                        <label id="message"></label>
                        <button type="button" id="addNewFuelButton" tabindex="26" class="btn btn-success" style="float: right"><i class="fa fa-plus-circle">Add Fuel</i></button>
                    </div>
                    <div class="panel-body table-responsive">
                        <table id="fuelList" class="table table-striped table-bordered" cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th scope="col">Name</th>
                                    <th scope="col">Type</th>
                                    <th scope="col">Description</th>
                                    <th scope="col">Cost/Ltr</th>
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

    <div id="editFuelModal" class="modal" role="dialog">
        <div class="modal-dialog">

            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Edit Fuel</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="usr">Fuel Name:</label>
                            <input type="text" class="form-control" id="fuelName" disabled="disabled" />
                            <input style="display: none" type="text" class="form-control" id="fuelID" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="pwd">Fuel Type:</label>
                            <input type="text" class="form-control" id="fuelType" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="usr">Description:</label>
                            <input type="text" class="form-control" id="description" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="pwd">Fuel Cost:</label>
                            <input type="text" class="form-control" id="CostLtr" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="editFuelModalButton" type="button" class="btn btn-success" data-dismiss="modal">Update</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>

    <div id="createFuelModel" class="modal" role="dialog">
        <div class="modal-dialog">

            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Create New Fuel</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="fuelNameCreate">Fuel Name:</label>
                            <input type="text" class="form-control" id="fuelNameCreate" />
                            <input style="display: none" type="text" class="form-control" id="fuelID" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="fuelTypeCreate">Fuel Type:</label>
                            <input type="text" class="form-control" id="fuelTypeCreate" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="descriptionCreate">Description:</label>
                            <input type="text" class="form-control" id="descriptionCreate" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="CostLtrCreate">Fuel Cost:</label>
                            <input type="text" class="form-control" id="CostLtrCreate" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="createFuelModalButton" type="button" class="btn btn-success" data-dismiss="modal">Create</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
