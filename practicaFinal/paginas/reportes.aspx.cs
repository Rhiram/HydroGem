using practicaFinal.paginas.reporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practicaFinal.paginas
{
    public partial class reportes : System.Web.UI.Page
    {
        string id;
        string Nreporte;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*velidacion para redireccionar si no esta slogeado*/
            if ((Session["usuarioNombre_$"] == null) || (Convert.ToInt32(Session["perfilId_$"].ToString()) == 2))
            {

                Response.Redirect("inicio.aspx");
            }

           

                rptSoporte rep = new rptSoporte();
                rep.DataSource = variablesGlobales.dt;
                Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();
                instanceReportSource.ReportDocument = rep;


                ReportViewer1.ReportSource = instanceReportSource;
                ReportViewer1.RefreshReport();
          
        }
    }
}