using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practicaFinal.paginas
{
    public partial class inicio : System.Web.UI.Page
    {
        ClaseInicio Cinicio = new ClaseInicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*velidacion para redireccionar si no esta slogeado*/
            if ((Session["usuarioNombre_$"] != null) )
            {
                

                
            }

        }
    }
}