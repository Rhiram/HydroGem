using Obout.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practicaFinal.paginas.usuarios
{
    public partial class eliminarUsuario : System.Web.UI.Page
    {
        claseUsuarios cl = new claseUsuarios();
        DataTable tbl = new DataTable();
        string usuarioId;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioId = Request.QueryString["usuarioId"];
            if (!IsPostBack)
            {
            DataTable dt = new DataTable();
            if (usuarioId == null || usuarioId == "")
            {
                
                //string estadoId = dgEstados.Rows[1].Cells[0].Text;
                //string estado = dgEstados.Rows[1].Cells[1].Text;
                //string activo = dgEstados.Rows[1].Cells[2].Text;

                tbl.Columns.Add("estadoId");
                tbl.Columns.Add("Estado");

                if (!IsPostBack)
                {
                    /*velidacion para redireccionar si no esta slogeado*/
                    if ((Session["usuarioNombre_$"] == null) )
                    {
                        Response.Redirect("../inicio.aspx");
                    }
                    else 
                    {
                        //  DataTable dt = new DataTable();
                        dt.Clear();
                        dt.Columns.Add("value");
                        dt.Columns.Add("text");
                        DataRow _ravi = dt.NewRow();
                        _ravi[0] = "1";
                        _ravi[1] = "Administrador";
                        dt.Rows.Add(_ravi);
                        DataRow _ravi1 = dt.NewRow();

                        _ravi1[0] = "2";
                        _ravi1[1] = "Usuario";
                        dt.Rows.Add(_ravi1);
                      
                    }
                  
                    cmbPerfil.DataSource = dt;
                    cmbPerfil.DataValueField = "value";
                    cmbPerfil.DataTextField = "text";
                    cmbPerfil.DataBind();

                }
            }
            else
            {
                //  DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("value");
                dt.Columns.Add("text");
                DataRow _ravi = dt.NewRow();
                _ravi[0] = "1";
                _ravi[1] = "Administrador";
                dt.Rows.Add(_ravi);
                DataRow _ravi1 = dt.NewRow();
                cmbPerfil.DataSource = dt;
                cmbPerfil.DataValueField = "value";
                cmbPerfil.DataTextField = "text";
                cmbPerfil.DataBind();
                _ravi1[0] = "2";
                _ravi1[1] = "Usuario";
                dt.Rows.Add(_ravi1);
                      
                DataTable tbl = cl.regresaUsuario(usuarioId);
                foreach (DataRow row in tbl.Rows)
                {
                    txtNombre.Value = row["nombre"].ToString();
                    txtApellidoP.Value = row["apellidoP"].ToString();
                    txtApellidoM.Value = row["apellidoM"].ToString();
                    txtCorreo.Value = row["email"].ToString();
                    txtPass.Value = row["pass"].ToString();
                    txtUsuarios.Value = row["usuarioNombre"].ToString();
                    cmbPerfil.SelectedIndex = cmbPerfil.Items.IndexOf(cmbPerfil.Items.FindByValue(row["perfilId"].ToString()));
                    cmbPerfil.DataBind();

                }
            }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string estado;
            string pass = txtPass.Value.ToString();
            if (usuarioId == null || usuarioId == "")
            {
                if (cl.insertaUsuario(txtNombre.Value.ToString(), txtApellidoP.Value.ToString(), txtApellidoM.Value.ToString(), txtCorreo.Value.ToString(), pass, txtUsuarios.Value.ToString(), cmbPerfil.SelectedValue, Session["usuarioID_$"].ToString()) == true)
                {
                    estado = "Usuario_agregado_con_exito";
                }
                else
                {
                    estado = "Error_al_insertar_usuario: " + variablesGlobales.mensajeErrorSQL;

                }

                Response.Redirect("usuariosVista.aspx?edo=" + estado);
            }
            else
            {
                if (cl.modificaUsuario(txtNombre.Value.ToString(), txtApellidoP.Value.ToString(), txtApellidoM.Value.ToString(), txtCorreo.Value.ToString(), pass, txtUsuarios.Value.ToString(), cmbPerfil.SelectedValue, Session["usuarioID_$"].ToString(),usuarioId) == true)
                {
                    estado = "Usuario_modificado_con_exito";
                }
                else
                {
                    estado = "Error_al_modificar_usuario: " + variablesGlobales.mensajeErrorSQL;

                }

                Response.Redirect("usuariosVista.aspx?edo=" + estado);
            }
        }

        protected void cmbEstados_TextChanged(object sender, EventArgs e)
        {
          

        }

        protected void btnEnlaceEstado_Click(object sender, EventArgs e)
        {
            Response.Redirect("estadosAsigndo.aspx?id=" + usuarioId+"&name="+txtUsuarios.Value.ToString());
        }
    }
}