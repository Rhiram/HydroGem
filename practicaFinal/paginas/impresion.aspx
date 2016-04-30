<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="impresion.aspx.cs" Inherits="practicaFinal.paginas.impresion" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=9.0.15.225, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:ReportViewer ID="rpt" runat="server" Height="1200px" Width="100%" ViewMode="PrintPreview"></telerik:ReportViewer>
    <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>--%>
</asp:Content>
