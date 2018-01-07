<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGeneral.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PPMS.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-4">
            <canvas id="doughnut-chart-Tanker1" width="800" height="450"></canvas>
        </div>
        <div class="col-md-4">
            <canvas id="doughnut-chart-Tanker2" width="800" height="450"></canvas>
        </div>
        <div class="col-md-4">
            <canvas id="doughnut-chart-Tanker3" width="800" height="450"></canvas>
        </div>
    </div>
</asp:Content>
