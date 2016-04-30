<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="reportes.aspx.cs" Inherits="practicaFinal.paginas.reportes" %>



<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=9.0.15.225, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="1200px" Width="100%" ViewMode="PrintPreview"></telerik:ReportViewer>
</asp:Content>
