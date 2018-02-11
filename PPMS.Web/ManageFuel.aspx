<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGeneral.Master" AutoEventWireup="true" CodeBehind="ManageFuel.aspx.cs" Inherits="PPMS.Web.ManageFuel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
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
                    <asp:PlaceHolder ID="fuelListBody" runat="server"></asp:PlaceHolder>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
