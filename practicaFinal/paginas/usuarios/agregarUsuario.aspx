<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="agregarUsuario.aspx.cs" Inherits="practicaFinal.paginas.usuarios.agregarUsuario" %>

<%@ Register Assembly="obout_ComboBox" Namespace="Obout.ComboBox" TagPrefix="cc2" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row"> 
        <h1 class="col-xs-12 text-center">Usuarios</h1>
        <div class = "col-xs-12 col-md-4">
            <h3>Nombre:</h3>
            <input id="txtNombre" class = "form-control input-lg" type="text" runat="server" required="required" pattern="[A-Za-z]{1,}.*" title="Debe contener y empezar mínimo con una letra"/>
        </div>
        <div class = "col-xs-12 col-md-4">
            <h3>Apellido Paterno:</h3>
            <input id="txtApellidoP"  class="form-control input-lg" type="text" runat="server" required="required" pattern="[A-Za-z]{1,}.*" title="Debe contener y empezar mínimo con una letra"/>
        </div>
        <div class = "col-xs-12 col-md-4">
            <h3>Apellido Materno:</h3>
            <input id="txtApellidoM"  class="form-control input-lg" type="text" runat="server"/>
        </div>
    </div>

    <div class = "row">
        <div class="col-xs-12">
		    <hr/>
		    <h3 class="text-center">Datos de la cuenta</h3>
		    <hr/>
        </div>	
	</div>
    
    <div class="row">         
        <div class = "col-xs-12 col-md-3">
		    <h3>Correo:</h3>
            <input id="txtCorreo" class="form-control input-lg" type="email" runat="server" required="required"/>
	    </div>
        
        <div class = "col-xs-12 col-md-3">
		    <h3>Usuario:</h3>
            <input id="txtUsuarios" class="form-control input-lg" type="text" runat="server" required="required"  title="Debe contener solo letras sin espacios en blanco"/>
	    </div>
        
        <div class = "col-xs-12 col-md-3">
		    <h3>Contrase&ntilde;a:</h3>
            <input id="txtPass" class="form-control input-lg" type="password" runat="server" required="required" />
	    </div>

        <div class = "col-xs-12 col-md-3">
		    <h3>Perfil:</h3>
            <!--validacion para enlace-->
            <asp:DropDownList ID="cmbPerfil" runat="server" class="form-control input-lg" required="required"></asp:DropDownList>
            <%--<cc2:ComboBox ID="cmbPerfil" runat="server" Height="60px" MenuWidth="10000px"></cc2:ComboBox>--%>
	    </div>
      
    </div>

   <%-- <div class = "row">
        <div class="col-xs-12">
		    <hr/>
		    <h3 class="text-center">Estados</h3>
		    <hr/>
        </div>	
	</div>

    <div class = "row">            
        <div class = "col-xs-12 col-md-6">
	        <!--<h3>Estado:</h3>-->
		    <asp:DropDownList ID="cmbEstados" class="form-control input-lg" runat="server">
            </asp:DropDownList>
        </div>

        <div class = "col-xs-12 col-md-6">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Estado"  class="btn btn-default btn-lg btn-block" OnClick="btnAgregar_Click" />
        </div>
    </div>
    <br />
    <div class = "row">
        <div class="col-xs-12">
            <cc1:grid ID="dgEstados" runat="server" AutoGenerateColumns="False" FolderStyle="~/style/premiere_blue" AllowMultiRecordAdding="True" AllowMultiRecordDeleting="True" AllowMultiRecordEditing="True" AllowMultiRecordSelection="False" AllowRecordSelection="False" KeepSelectedRecords="False" PageSize="32">
                <ScrollingSettings  ScrollHeight="100%" ScrollWidth="100%" />
                <Columns>   
                    <cc1:Column DataField="value" HeaderText="estadoId" Index="0" visible="false" >
                    </cc1:Column>
                    <cc1:Column DataField="text" HeaderText="Estado" Index="1">
                    </cc1:Column>
                    <cc1:CheckBoxSelectColumn ShowHeaderCheckBox="true"  >
                    </cc1:CheckBoxSelectColumn>
                </Columns>
            </cc1:grid>
        </div>
    </div>--%>      
    <br />
    <div class = "row">
        <div class="col-xs-12">
            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-default btn-lg btn-block"/>
		</div> 
    </div>
</asp:Content>
