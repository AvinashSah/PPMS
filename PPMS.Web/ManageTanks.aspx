<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGeneral.Master" AutoEventWireup="true" CodeBehind="ManageTanks.aspx.cs" Inherits="PPMS.Web.ManageTanks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default height">
                    <div class="panel-heading">
                        <strong>Tanker List</strong>
                        <label id="message"></label>
                        <button type="button" id="addNewTankerButton" tabindex="26" class="btn btn-success" style="float: right"><i class="fa fa-plus-circle">Add Tanker</i></button>
                    </div>
                    <div class="panel-body table-responsive">
                        <table id="tankerList" class="table table-striped table-bordered" cellspacing="0">
                            <thead>
                                <tr>
                                    <th scope="col">Name</th>
                                    <th scope="col">Fuel Type</th>
                                    <th scope="col">Size</th>
                                    <th scope="col">Day Start Reading</th>
                                    <th scope="col">Day End Reading</th>
                                    <th scope="col">Description</th>
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

    <div id="createTankerModel" class="modal" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Create New Tanker</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="tankerNameCreate">Tanker Name:</label>
                            <input type="text" class="form-control" id="tankerNameCreate" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="tankerFuelTypeCreate">Fuel Type:</label>
                            <select tabindex="10" class="form-control" id="tankerFuelTypeCreate" tabindex="1">
                                <option value="0">Select Fuel Type</option>
                            </select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="tankerSizeCreate">Size:</label>
                            <input type="text" class="form-control" id="tankerSizeCreate" tabindex="2" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="tankerSrtRdCreate">Day Start Reading:</label>
                            <input type="text" class="form-control" id="tankerSrtRdCreate" tabindex="3"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="tankerDescriptionCreate">Description:</label>
                            <input type="text" class="form-control" id="tankerDescriptionCreate" tabindex="4" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="tankerEndRdCreate">Day End Reading:</label>
                            <input type="text" class="form-control" id="tankerEndRdCreate" tabindex="5" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="createTankerModalButton" type="button" class="btn btn-success" data-dismiss="modal" tabindex="6">Create</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <div id="editTankerModal" class="modal" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Edit Tanker</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="tankerNameEdit">Tanker Name:</label>
                            <input type="text" class="form-control" id="tankerNameEdit" disabled="disabled" />
                            <input style="display: none" type="text" class="form-control" id="tankerID" />
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="tankerFuelTypeEdit">Fuel Type:</label>
                            <select class="form-control" id="tankerFuelTypeEdit" tabindex="1">
                                <option value="0">Select Fuel Type</option>
                            </select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="tankerSizeEdit">Size:</label>
                            <input type="text" class="form-control" id="tankerSizeEdit" tabindex="2"/>
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="tankerSrtRdEdit">Day Start Reading:</label>
                            <input type="text" class="form-control" id="tankerSrtRdEdit" tabindex="3"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-lg-6">
                            <label for="tankerDescriptionEdit">Description:</label>
                            <input type="text" class="form-control" id="tankerDescriptionEdit" tabindex="4"/>
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="tankerEndRdEdit">Day End Reading:</label>
                            <input type="text" class="form-control" id="tankerEndRdEdit" tabindex="5"/>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="editTankerModalButton" type="button" class="btn btn-success" data-dismiss="modal" tabindex="6">Update</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
