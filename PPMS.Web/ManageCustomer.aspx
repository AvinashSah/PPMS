<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGeneral.Master" AutoEventWireup="true" CodeBehind="ManageCustomer.aspx.cs" Inherits="PPMS.Web.ManageCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <button type="button" id class="btn btn-primary">Add Customer</button>
        </div>
        <div class="row">
            <table id="customerList" class="table table-striped table-bordered" cellspacing="0" width="100%">
                <thead>
                    <tr>
                        <th scope="col">Name</th>
                        <th scope="col">Customer Type</th>
                        <th scope="col">Contact Number</th>
                        <th scope="col">Email Id</th>
                        <th scope="col">Address</th>
                        <th scope="col">City</th>
                        <th scope="col">District</th>
                        <th scope="col">State</th>
                        <th scope="col">Pin Code</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="customerListBody" runat="server"></asp:PlaceHolder>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
