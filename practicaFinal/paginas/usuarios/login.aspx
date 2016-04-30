<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="practicaFinal.paginas.usuarios.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-12 col-md-6">
            <h3>Usuarios</h3>
            <input id="txtUsuario" type="text" runat="server" class="form-control input-lg" />
        </div>
        <div class="col-xs-12 col-md-6">
            <h3>Contrase&ntilde;a</h3>
            <input id="txtPAss" type="password" runat="server" class="form-control input-lg" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-3">
            <asp:Button ID="btnValidar" runat="server" Text="Entrar" OnClick="btnValidar_Click" class="btn btn-default btn-lg btn-block"/>
        </div>
    </div>
</asp:Content>


