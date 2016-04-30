using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practicaFinal.paginas.usuarios
{
    public partial class login : System.Web.UI.Page
    {
        claseUsuarios cl = new claseUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            DataTable tbl = cl.login(txtUsuario.Value.ToString(), txtPAss.Value.ToString());
            if (tbl.Rows.Count > 0)
            {
                foreach (DataRow row in tbl.Rows)
                {


                    Session["usuarioNombre_$"] = row["usuarioNombre"].ToString();
                    Session["perfilId_$"] = row["perfilId"].ToString();
                    Session["usuarioID_$"] = row["usuarioId"].ToString();
                }
                Response.Redirect("../inicio.aspx?edo=Bienvenido_" + Session["usuarioNombre_$"]);
                //Response.Redirect("../inicio.aspx");
            }
            else
            {
                Response.Redirect("login.aspx?edo=usuario_o_contraseña_incorrecta");
            }
        }
       
    }
}