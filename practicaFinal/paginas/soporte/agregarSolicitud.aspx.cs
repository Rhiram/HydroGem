using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practicaFinal.paginas.soporte
{
    public partial class agregarSolicitud : System.Web.UI.Page
      {
        claseSoporte cl = new claseSoporte();
         string asuntoId;
         string estadoActual = "-1";
         protected void Page_Load(object sender, EventArgs e)
         {

             asuntoId = Request.QueryString["Id"];
             if (asuntoId != null)
             {
                 btnAgregar.Visible = false;
                 DataTable info = cl.regresaSolicitud(asuntoId);
                 foreach (DataRow row in info.Rows)
                 {

                     if (!IsPostBack)
                     {
                         /*velidacion para redireccionar si no esta slogeado*/
                         if ((Session["usuarioNombre_$"] == null))
                         {
                             Response.Redirect("../inicio.aspx");
                         }
                         else
                         {
                             DataTable dt = new DataTable();
                             dt.Clear();
                             dt.Columns.Add("value");
                             dt.Columns.Add("text");
                             DataRow _ravi = dt.NewRow();
                             _ravi[0] = "1";
                             _ravi[1] = "Regular";
                             dt.Rows.Add(_ravi);
                             DataRow _ravi1 = dt.NewRow();
                             _ravi1[0] = "2";
                             _ravi1[1] = "Bueno";
                             dt.Rows.Add(_ravi1);
                             DataRow _ravi2 = dt.NewRow();
                             _ravi2[0] = "3";
                             _ravi2[1] = "Muy bueno";
                             dt.Rows.Add(_ravi2);
                             DataRow _ravi3 = dt.NewRow();
                             _ravi3[0] = "4";
                             _ravi3[1] = "Excelente";
                             dt.Rows.Add(_ravi3);
                             cmbCalificacion.DataSource = dt;
                             cmbCalificacion.DataValueField = "value";
                             cmbCalificacion.DataTextField = "text";
                             cmbCalificacion.DataBind();
                         }
                         lblcomentario.Visible = true;
                         txtcComentarioBitacora.Visible = true;
                         txtTitulo.Value = row["titulo"].ToString();
                         txtComentario.Value = row["comentario"].ToString();
                         cmbCalificacion.SelectedIndex = cmbCalificacion.Items.IndexOf(cmbCalificacion.Items.FindByValue(row["calificacion"].ToString()));
                         estadoActual = cl.regresaEstado(asuntoId);
                         if (estadoActual == "3" && Convert.ToInt32(Session["perfilId_$"].ToString()) == 2)
                         {
                             btnRechazar.Visible = true;
                             btnSeguimiento.Visible = true;
                             cmbCalificacion.Visible = true;
                             h3.Visible = true;
                         }
                         if ((estadoActual == "5" || estadoActual == "1" || estadoActual == "8") && Convert.ToInt32(Session["perfilId_$"].ToString()) == 1)
                         {
                             btnSeguimiento.Visible = true;
                         }
                         Gridview1.DataSource = cl.vistaBitacora(asuntoId);
                         Gridview1.DataBind();
                         //cmbEstados.SelectedIndex = cmbEstados.Items.IndexOf(cmbEstados.Items.FindByValue(row["estadoId"].ToString()));
                     }
                     if (estadoActual == "5")
                     {
                         btnRechazar.Visible = true;
                         btnSeguimiento.Visible = true;
                         btnRechazar.Text = "Suspender atención";
                     }
                 }
             }
         }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string estado = "";
           if( cl.insertaAsunto( Session["usuarioID_$"].ToString(),txtTitulo.Value,txtComentario.Value)==true)
           {
               estado = "Solicitud_guardado_con_exito";
               variablesGlobales.enviaCorreo(Session["usuarioID_$"].ToString(), "Respuesta de atencion ciudadana", "Su solicitud se agrego correctamente, favor de esperar en respuesta de ella", "");
               variablesGlobales.enviaCorreo(Session["usuarioID_$"].ToString(), "Registro de solicitud de servicio de atencion ciudadana", "Se registro la solicitud:\n " + txtTitulo.Value + "\n con el comentario:\n" + txtComentario.Value, "atencioncsis@gmail.com");
                

           }
           else
           {
               estado = "Error al crear Solicitud: " + variablesGlobales.mensajeErrorSQL;

           }
           Response.Redirect("vistaSoporte.aspx?edo=" + estado);
        }

        protected void btnSeguimiento_Click(object sender, EventArgs e)
        {

            string estado = "";
            string estadoId = variablesGlobales.con.obtenerValorUnico("EXEC siguieneteEstado "+asuntoId,0);
            if (cl.continuaAsunto(asuntoId,Session["usuarioID_$"].ToString(), txtComentario.Value,estadoId,cmbCalificacion.SelectedValue) == true)
            {
                estado = "Seguimiento_guardado_con_exito";
                Response.Redirect("vistaSoporte.aspx?edo=" + estado);

            }
            else
            {
                estado = "Error al rechazar seguimiento: " + variablesGlobales.mensajeErrorSQL;

            }

        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            string estado = "";
            string estadoId = "6";
            if (estadoActual == "5")
            {
                estadoId = "8";
            }

                if (cl.continuaAsunto(asuntoId, Session["usuarioID_$"].ToString(), txtComentario.Value, estadoId,"-1") == true)
                {
                    if (estadoActual == "5")
                    {
                        estado = "Seguimiento_pausado_con_exito";
                    }
                    else
                    {
                        estado = "Seguimiento_rechazado_con_exito";
                    }
                    Response.Redirect("vistaSoporte.aspx?edo=" + estado);


                }
                else
                {
                    estado = "Error al crear seguimiento: " + variablesGlobales.mensajeErrorSQL;

                }
        }
    }
}