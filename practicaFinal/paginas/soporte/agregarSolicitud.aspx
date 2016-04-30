<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="agregarSolicitud.aspx.cs" Inherits="practicaFinal.paginas.soporte.agregarSolicitud" %>
<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
      <script>
          function cambiaTexto(text) {
              document.getElementById("ContentPlaceHolder1_txtTitulo").value = "Problema con " + text
              return false;
          }
        
      </script>
    <div class="row"> 
        <h1 class="col-xs-12 text-center">Solicitud de servicio</h1>
    </div>
     <div class="row">  
       
         <div class = "col-xs-12 col-md-3">   
            <input id="btn1" type="image" onclick="cambiaTexto('Impresion'); return false;"  src="../../imagenes/logoImp.png" />
             <br />
             Impresora</div>
        <div class = "col-xs-12 col-md-3">                  
            <input type="image"  onclick="cambiaTexto('la Red o Telefono'); return false;" src="../../imagenes/logoRed.jpg" /><br />
            Redes o Telefono</div>
          <div class = "col-xs-12 col-md-3">                  
            <input  type="image"  src="../../imagenes/logoComp.png" onclick="cambiaTexto('la Computadora'); return false;"/>
              <br />
&nbsp;&nbsp;&nbsp;&nbsp; Computadora</div>
         <div class = "col-xs-12 col-md-3">                  
            <input  type="image"  src="../../imagenes/logoOtros.png" onclick="cambiaTexto('Asesoria y Otros'); return false;"/>
             <br />
             Asesoria y Otros</div> 
          
    </div>
    <div class="row">
        <div class="row">
            <div class="col-xs-12">
                <asp:Button ID="btnSeguimiento" runat="server" Text="Dar seguimiento"   class="btn btn-default btn-lg btn-block" OnClick="btnSeguimiento_Click" Visible="False"/>
            </div>
        </div>
           <div class="row">
            <div class="col-xs-12">
                <asp:Button ID="btnRechazar" runat="server" Text="Rechazar"   class="btn btn-default btn-lg btn-block"  Visible="False" OnClick="btnRechazar_Click"/>
            </div>
        </div>
		<div class="col-xs-12 ">
			<h3>Título:</h3>
            <input id="txtTitulo" class="form-control input-lg" type="text" runat="server" title="Debe contener y empezar mínimo con una letra" readonly="true"/>
		</div>
		<div class="col-xs-12 ">	
			<h3>Asunto:</h3> 
            <textarea id="txtComentario" class="form-control input-lg" type="text" runat="server"></textarea>
		</div>
        <div class="col-xs-12 ">	
			<h3 id="h3" runat="server" visible="false">Calificacion:</h3> 
            <asp:DropDownList ID="cmbCalificacion" runat="server" class="form-control input-lg" required="required" Visible="False"></asp:DropDownList>
		</div>
        <div class="col-xs-12 ">	
			<h3 id="lblcomentario" runat="server" visible="false">Comentario:</h3> 
         <textarea id="txtcComentarioBitacora" visible="false" class="form-control input-lg" type="text" runat="server"></textarea>
		</div>
	</div>
    <br />


    <div class="row">
        <div class="col-xs-12">
            <cc2:Grid ID="Gridview1" runat="server" FolderStyle="~/style/premiere_blue" AutoGenerateColumns="False" AllowAddingRecords="False" EnableTypeValidation="False" >
                  <ScrollingSettings  ScrollHeight="100%" ScrollWidth="100%" />
                <Columns>
                    <cc2:Column DataField="Usuario" HeaderText="Usuario" Index="0" Visible="True">
                    </cc2:Column>
                    <cc2:Column DataField="Estado" HeaderText="Estado" Index="1">
                    </cc2:Column>
                    <cc2:Column DataField="Fecha" HeaderText="Fecha" Index="1">
                    </cc2:Column>
                </Columns>
            </cc2:Grid>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-12">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"  class="btn btn-default btn-lg btn-block"/>
        </div>
    </div>

</asp:Content>

