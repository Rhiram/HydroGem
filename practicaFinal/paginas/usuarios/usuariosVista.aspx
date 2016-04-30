<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="usuariosVista.aspx.cs" Inherits="practicaFinal.paginas.usuariosVista" %>

<%@ Register Assembly="obout_Interface" Namespace="Obout.Interface" TagPrefix="cc2" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>--%>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
         
         function onDoubleClick(iRecordIndex) {
             //alert('hola');
             window.location.assign("agregarUsuario.aspx?usuarioid=" + dgUsuarios.Rows[iRecordIndex].Cells[0].Value)
         }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"  onload ="asignaFecha()">
    
    <div class="row" > 
        <h1 class="col-xs-12 text-center">Usuarios</h1>
    </div>
        
      
    <div class="row">
        <div class="col-xs-12">
           <cc1:Grid ID="dgUsuarios" runat="server"  FolderStyle="~/style/premiere_blue" AutoGenerateColumns="False" AllowMultiRecordSelection="False" KeepSelectedRecords="True">
                <ClientSideEvents OnClientDblClick="onDoubleClick" />         
               <ScrollingSettings  ScrollHeight="100%" ScrollWidth="100%" />
               <Columns>
                   <cc1:Column DataField="usuarioId" HeaderText="usuarioId" Index="0" Visible="False">
                   </cc1:Column>
                   <cc1:Column DataField="Usuario" HeaderText="Usuario" Index="1">
                   </cc1:Column>
                   <cc1:Column DataField="Correo" HeaderText="Correo" Index="2">
                   </cc1:Column>
                   <cc1:Column DataField="Nombre" HeaderText="Nombre" Index="3">
                   </cc1:Column>
                   <cc1:Column DataField="Perfil" HeaderText="Perfil" Index="4">
                   </cc1:Column>
                   <%--<cc1:Column DataField="" HeaderText="Bid" Width="80" Index="13" TemplateId="BtnTemplate">
                   <TemplateSettings TemplateId="BtnTemplate" />
                </cc1:Column>--%>
               </Columns>
               

           </cc1:Grid>
        </div>
    </div>
    <br />
    <div class = "row">
        <div class="col-xs-12">
            <asp:Button ID="Button1" runat="server" Text="Agregar" OnClick="Button1_Click" class="btn btn-default btn-lg btn-block"/>
            <asp:Button ID="Button2" runat="server" Text="Eliminar" OnClick="Button2_Click" class="btn btn-default btn-lg btn-block"/>
        </div>
    </div>
</asp:Content>
