using practicaFinal.paginas.reporte;
using practicaFinal.paginas.soporte;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practicaFinal.paginas
{
    public partial class impresion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            claseSoporte cl = new claseSoporte();
            /*velidacion para redireccionar si no esta slogeado*/
            if ((Session["usuarioNombre_$"] == null) || (Convert.ToInt32(Session["perfilId_$"].ToString()) == 2))
            {

                Response.Redirect("inicio.aspx");
            }

            string id1 = Request.QueryString["id"];
            string id2 = Request.QueryString["id2"];
            string fecha1 = Request.QueryString["fecha1"];
            string fecha2 = Request.QueryString["fecha2"];
            string estadoId = Request.QueryString["estadoID"];
            DataTable tbl = variablesGlobales.dt;
            rptSoporte rep = new rptSoporte();
            rep.DataSource =  cl.rptSoporte(id1, id2, fecha1, fecha2,estadoId);
            Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();
            instanceReportSource.ReportDocument = rep;


            rpt.ReportSource = instanceReportSource;
            rpt.RefreshReport();
        }
    }
}