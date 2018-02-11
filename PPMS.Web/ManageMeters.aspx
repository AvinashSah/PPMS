<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGeneral.Master" AutoEventWireup="true" CodeBehind="ManageMeters.aspx.cs" Inherits="PPMS.Web.ManageMeters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <table id="meterList" class="table table-striped table-bordered" cellspacing="0" width="100%">
                <thead>
                    <tr>
                        <th scope="col">Name</th>
                        <th scope="col">Fuel Type</th>
                        <th scope="col">Day Start Reading</th>
                        <th scope="col">Day End Reading</th>
                        <th scope="col">Date</th>
                        <th scope="col">Description</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="MeterListBody" runat="server"></asp:PlaceHolder>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
