<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGeneral.Master" AutoEventWireup="true" CodeBehind="ManageMeters.aspx.cs" Inherits="PPMS.Web.ManageMeters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default height">
                    <div class="panel-heading">
                        <strong>Meter List</strong>
                        <label id="message"></label>
                        <button type="button" id="addNewMeterButton" tabindex="26" class="btn btn-success" style="float: right"><i class="fa fa-plus-circle">Add Meter</i></button>
                    </div>
                    <div class="panel-body table-responsive">
                        <table id="meterList" class="table table-striped table-bordered" cellspacing="0" cellspacing="0">
                            <thead>
                                <tr>
                                    <th scope="col">Name</th>
                                    <th scope="col">Fuel Type</th>
                                    <th scope="col">Description</th>
                                    <th scope="col">Day Start Reading</th>
                                    <th scope="col">Day End Reading</th>
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
    <div id="createMeterModel" class="modal" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Create New Meter</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="meterNameCreate">Meter Name:</label>
                            <input type="text" class="form-control" id="meterNameCreate" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="meterFuelTypeCreate">Fuel Type:</label>
                            <select tabindex="10" class="form-control" id="meterFuelTypeCreate" tabindex="1">
                                <option value="0">Select Fuel Type</option>
                            </select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="meterSrtRdCreate">Day Start Reading:</label>
                            <input type="text" class="form-control" id="meterSrtRdCreate" tabindex="2" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="meterEndRdCreate">Day End Reading:</label>
                            <input type="text" class="form-control" id="meterEndRdCreate" tabindex="3" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="meterDescriptionCreate">Description:</label>
                            <input type="text" class="form-control" id="meterDescriptionCreate" tabindex="4" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="createMeterModalButton" type="button" class="btn btn-success" data-dismiss="modal" tabindex="6">Create</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <div id="editMeterModal" class="modal" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Edit Meter</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="meterNameEdit">Meter Name:</label>
                            <input type="text" class="form-control" id="meterNameEdit" disabled="disabled" />
                            <input style="display: none" type="text" class="form-control" id="meterID" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="meterFuelTypeEdit">Fuel Type:</label>
                            <select class="form-control" id="meterFuelTypeEdit" tabindex="1">
                                <option value="0">Select Fuel Type</option>
                            </select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="meterSrtRdEdit">Day Start Reading:</label>
                            <input type="text" class="form-control" id="meterSrtRdEdit" tabindex="2" />
                        </div>
                        
                        <div class="form-group col-lg-6">
                            <label for="meterEndRdEdit">Day End Reading:</label>
                            <input type="text" class="form-control" id="meterEndRdEdit" tabindex="3" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="meterDescriptionEdit">Description:</label>
                            <input type="text" class="form-control" id="meterDescriptionEdit" tabindex="4" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="editMeterModalButton" type="button" class="btn btn-success" data-dismiss="modal" tabindex="6">Update</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
