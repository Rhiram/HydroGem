
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practicaFinal.paginas.soporte
{
    public partial class vistaSoporte : System.Web.UI.Page
    {
     
        claseSoporte cl = new claseSoporte();
        DataTable tblG = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            /*velidacion para redireccionar si no esta slogeado*/
            if (!IsPostBack)
            {
                btnAgregar.Visible = true;
               
                string usuarioId = Session["usuarioID_$"].ToString();
                if (Session["perfilId_$"].ToString()=="1")
                {
                    usuarioId = "-1";
                }
                else
                {
                    filtros.Visible = false;
                }
                tblG = cl.rptSoporte(usuarioId, "-1", "01/01/1980", "01/01/2100","-1");
                dgProyectos.DataSource = tblG;
                dgProyectos.DataBind();

                //DataTable tbl = variablesGlobales.cmbUsuarios();
                cmbUsuarios.DataSource = variablesGlobales.cmbUsuarios();
                cmbUsuarios.DataTextField = "text";
                cmbUsuarios.DataValueField = "value";
                cmbUsuarios.DataBind();
                cmbUsuarios.SelectedIndex = 0;

                cmbUsuariosAtiende.DataSource = variablesGlobales.cmbUsuariosAtinde();
                cmbUsuariosAtiende.DataTextField = "text";
                cmbUsuariosAtiende.DataValueField = "value";
                cmbUsuariosAtiende.DataBind();
                cmbUsuariosAtiende.SelectedIndex = 0;

                cmbEstado.DataSource = variablesGlobales.cmbEstados();
                cmbEstado.DataTextField = "text";
                cmbEstado.DataValueField = "value";
                cmbEstado.DataBind();
                cmbEstado.SelectedIndex = 0;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("agregarSolicitud.aspx");
        }

        protected void dgProyectos_Select(object sender, Obout.Grid.GridRecordEventArgs e)
        {
            //Response.Redirect("../inicio.aspx");
//            string id = "";

//            foreach (Hashtable oRecord in dgProyectos.SelectedRecords)
//            {
//                id = oRecord["id"].ToString();
//            }
//            string js = @"var txt;
//                            var r = confirm('¿Desea ver o modificar el Proyecto?');
//                            if (r == true) {
//                           window.location.href = 'agregaProyecto.aspx?id=" + id + @"';
//                            } else {
//                            var r2 = confirm('¿Desea ver o agregar los eventos capturados?');
//                            if(r2==true)
//                            {
//                              window.location.href = 'vistaEventos.aspx?id=" + id + @"';
//                            }
//                            }";
//            ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", js, true);
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
             tblG =cl.rptSoporte(cmbUsuarios.SelectedValue , cmbUsuariosAtiende.SelectedValue, Convert.ToDateTime(fecha1x.Value).ToString("dd/MM/yyyy"), Convert.ToDateTime(fecha2x.Value).ToString("dd/MM/yyyy"), cmbEstado.SelectedValue);
             dgProyectos.DataSource = tblG;
             dgProyectos.DataBind();
        }
        public void btnLogin_Click(object sender, EventArgs e)
        {
            variablesGlobales.dt = tblG;
            Response.Redirect("../impresion.aspx?id=" + cmbUsuarios.SelectedValue + "&id2=" + cmbUsuariosAtiende.SelectedValue + "&fecha1=" + Convert.ToDateTime(fecha1x.Value).ToString("dd/MM/yyyy") + "&fecha2=" + Convert.ToDateTime(fecha2x.Value).ToString("dd/MM/yyyy") + "&estadoId=" + cmbEstado.SelectedValue);
        }
    }
}