<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="vistaSoporte.aspx.cs" Inherits="practicaFinal.paginas.soporte.vistaSoporte" %>
<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
      <script>
          function onDoubleClick(iRecordIndex) {
              var proy = dgProyectos.Rows[iRecordIndex].Cells[1].Value;
              //alert(dgProyectos.Rows[iRecordIndex].Cells[0].Value);
              proy = proy.replace(" ", "_");
              window.location.assign("agregarSolicitud.aspx?id=" + dgProyectos.Rows[iRecordIndex].Cells[0].Value);
          }
          $(document).ready(function () {
              var today = new Date();
              var fecha=new Date();
              var month = today.getMonth()+1;
              var day = today.getDate();
              var year = today.getFullYear();
              var fecha2;
              var fecha=new Date(month+'/01/'+year);
              month=month+1
           
              var fecha2 = new Date(month + "/01/" + year);
              fecha2.setMonth(fecha2.getMonth());
              fecha2.setDate(fecha2.getDate() -1);             
              document.getElementById('ContentPlaceHolder1_fecha1x').value = formatDate(fecha);
              document.getElementById('ContentPlaceHolder1_fecha2x').value = formatDate(fecha2);

          });

          function formatDate(value) {
              var day = "";
              var mes = "";
              if (value.getMonth()+1 < 10)
              {
                  mes = "0" + (value.getMonth()+1);
              }
              else {
                  mes = value.getMonth()+1;
              }
              if (value.getDate() < 10) {
                  day = "0" + value.getDate();
              }
              else {
                  day = value.getDate();
              }
              return value.getFullYear()+"-"+mes  + "-" + day  ;
          }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row"> 
        <h1 class="col-xs-12 text-center">Solicitudes de servicio</h1>
    </div>
    <div id="filtros" runat="server">
        <div class="row">         
                <div class = "col-xs-12 col-md-3">
		            <h3>Registró:</h3>
                    <!--validacion para enlace-->
                    <asp:DropDownList ID="cmbUsuarios" runat="server" class="form-control input-lg" required="required"></asp:DropDownList>
	            </div>

                 <div class = "col-xs-12 col-md-3">
		            <h3>Atíende:</h3>
                    <!--validacion para enlace-->
                    <asp:DropDownList ID="cmbUsuariosAtiende" runat="server" class="form-control input-lg" required="required"></asp:DropDownList>
	            </div>

                <div class = "col-xs-12 col-md-3">
		            <h3>Del:</h3>
                    <input  type="date" id="fecha1x" class="form-control input-lg" runat="server"/>
	            </div>           
        
                <div class = "col-xs-12 col-md-3">
		            <h3>Al:</h3>
                    <input id="fecha2x" class="form-control input-lg" type="date" runat="server"/>
	            </div>  
             <div class = "col-xs-12 col-md-3">
		            <h3>Estado:</h3>
                    <!--validacion para enlace-->
                    <asp:DropDownList ID="cmbEstado" runat="server" class="form-control input-lg" required="required"></asp:DropDownList>
	            </div>         
	        </div>
         <div class = "row"> 
            <div class="col-xs-12">
                <asp:Button ID="btnGenerar" runat="server" Text="Generar"  class="btn btn-default btn-lg btn-block" Visible="true" OnClick="btnGenerar_Click"/>
                <div class = "row">
                <div class = "col-xs-12 col-md-3">                  
                 </div>

                    <input id="btnImprimir"  style=" " type="image" src="../../imagenes/logoImp.png" runat="server" onServerClick="btnLogin_Click" />
                <div class = "col-xs-12 col-md-3">
                </div>
                </div>
            </div>
        </div>
        </div>
    <div class="row">
        <div class="col-xs-12">
            <cc1:Grid ID="dgProyectos" runat="server" AutoGenerateColumns="False"  FolderStyle="~/style/premiere_blue" AllowMultiRecordSelection="False" KeepSelectedRecords="True" AllowAddingRecords="False" EnableTypeValidation="False">
                <ScrollingSettings  ScrollHeight="100%" ScrollWidth="100%" />
                <ClientSideEvents OnClientDblClick="onDoubleClick" />        
                <Columns>
                    <cc1:Column DataField="id" HeaderText="id" Index="0" Visible="False" Wrap="True">
                    </cc1:Column>
                    <cc1:Column DataField="Usuario" HeaderText="Usuario" Index="1" ValidateRequestMode="Disabled">
                    </cc1:Column>
                        <cc1:Column DataField="Titulo" HeaderText="Titulo" Index="2" ValidateRequestMode="Disabled">
                    </cc1:Column>
                        <cc1:Column DataField="estadoActual" HeaderText="Estado" Index="3" ValidateRequestMode="Disabled">
                    </cc1:Column>
                </Columns>   
            </cc1:Grid>
        </div>
    </div>
    <br />

    <div class = "row"> 
        <div class="col-xs-12">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"  class="btn btn-default btn-lg btn-block" Visible="false"/>

        </div>
    </div>

</asp:Content>
