using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practicaFinal.paginas
{
    public partial class usuariosVista : System.Web.UI.Page
    {
        claseUsuarios cl = new claseUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*velidacion para redireccionar si no esta slogeado*/
            if ((Session["usuarioNombre_$"] == null) || (Convert.ToInt32(Session["perfilId_$"].ToString()) == 2))
            {

                Response.Redirect("../inicio.aspx");
            }

            dgUsuarios.DataSource = cl.buscaUsuario(Session["usuarioID_$"].ToString());
            dgUsuarios.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("agregarUsuario.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("eliminarUsuario.aspx");
        }
    }
}