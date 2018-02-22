<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGeneral.Master" AutoEventWireup="true" CodeBehind="Sale.aspx.cs" Inherits="PPMS.Web.Sale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default height">
                    <div class="panel-body">
                        <div class="wizard" style="margin: 20px !important;">
                            <div class="wizard-inner">
                                <div class="connecting-line"></div>
                                <ul class="nav nav-tabs" role="tablist">

                                    <li role="presentation" class="active">
                                        <a href="#step1" data-toggle="tab" aria-controls="step1" role="tab" title="Step 1">
                                            <span class="round-tab">
                                                <i class="glyphicon glyphicon-folder-open"></i>
                                            </span>
                                        </a>
                                    </li>

                                    <li role="presentation" class="disabled">
                                        <a href="#step2" data-toggle="tab" aria-controls="step2" role="tab" title="Step 2">
                                            <span class="round-tab">
                                                <i class="glyphicon glyphicon-pencil"></i>
                                            </span>
                                        </a>
                                    </li>
                                    <li role="presentation" class="disabled">
                                        <a href="#step3" data-toggle="tab" aria-controls="step3" role="tab" title="Step 3">
                                            <span class="round-tab">
                                                <i class="glyphicon glyphicon-picture"></i>
                                            </span>
                                        </a>
                                    </li>

                                    <li role="presentation" class="disabled">
                                        <a href="#complete" data-toggle="tab" aria-controls="complete" role="tab" title="Complete">
                                            <span class="round-tab">
                                                <i class="glyphicon glyphicon-ok"></i>
                                            </span>
                                        </a>
                                    </li>
                                </ul>
                            </div>

                            <form role="form">
                                <div class="tab-content">
                                    <div class="tab-pane active" role="tabpanel" id="step1">
                                        <div class="row">
                                            <div class="form-group col-lg-6">
                                                <label for="customerSale">Customer</label>
                                                <select class="form-control" id="customerSale">
                                                    <option value="0">--Select Customer--</option>
                                                    <option value="1">Tekriwal Motors</option>
                                                    <option value="1">Honda</option>
                                                </select>
                                            </div>
                                        </div>
                                        <ul class="list-inline pull-right">
                                            <li>
                                                <button type="button" class="btn btn-primary next-step">Save and continue</button></li>
                                        </ul>
                                    </div>
                                    <div class="tab-pane" role="tabpanel" id="step2">
                                        <div class="row">
                                            <div class="form-group col-lg-4">
                                                <label for="customerFuel">Fuel</label>
                                                <select class="form-control" id="customerFuel">
                                                    <option value="0">--Select Fuel Type--</option>
                                                    <option value="1">Petrol XP</option>
                                                    <option value="1">Petrol Normal</option>
                                                    <option value="1">Diesel XP</option>
                                                </select>
                                            </div>
                                            <div class="form-group col-lg-4">
                                                <label for="customerFuelAmount">Qty</label>
                                                <input type="text" class="form-control" id="customerFuelAmount" />
                                            </div>
                                            <div class="form-group col-lg-4">
                                                <label for="customerFuelAmountCost">Total Cost</label>
                                                <input type="text" class="form-control" id="customerFuelAmountCost" />
                                            </div>
                                        </div>
                                        <ul class="list-inline pull-right">
                                            <li>
                                                <button type="button" class="btn btn-default prev-step">Previous</button></li>
                                            <li>
                                                <button type="button" class="btn btn-primary next-step">Save and continue</button></li>
                                        </ul>
                                    </div>
                                    <div class="tab-pane" role="tabpanel" id="step3">
                                        <div class="row table-responsive">
                                            <div class="form-group col-lg-6">
                                                <label for="SaleType">Sale Type</label>
                                                <select class="form-control" id="SaleType">
                                                    <option value="0">--Select Sale Type--</option>
                                                    <option value="1">Credit</option>
                                                    <option value="2">Cash</option>
                                                    <option value="3">Token</option>
                                                </select>
                                            </div>
                                        </div>
                                        <ul class="list-inline pull-right">
                                            <li>
                                                <button type="button" class="btn btn-default prev-step">Previous</button></li>
                                            <li>
                                                <button type="button" class="btn btn-primary btn-info-full next-step">Sale</button></li>
                                        </ul>
                                    </div>
                                    <div class="tab-pane" role="tabpanel" id="complete">
                                        <h3>Complete</h3>
                                        <p>You have successfully made a sale.</p>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </form>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
