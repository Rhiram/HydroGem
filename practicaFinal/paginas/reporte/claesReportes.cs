using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace practicaFinal.paginas.reporte
{
    public class claesReportes
    {
        Conexion con = new Conexion();
        public DataTable rptSemanal(string eventoId)
        {

            return con.regresaTabla("EXEC rptSemanal " + eventoId.ToString()).Tables[0];
        }

        public DataTable tblAsistencias(string eventoId)
        {
            return con.regresaTabla("EXEC personasXevento " + eventoId.ToString()).Tables[0];
        }

        public DataTable rptFichaTecnica(string eventoId)
        {

            return con.regresaTabla("EXEC rptFichaTecnica " + eventoId.ToString()).Tables[0];
        }

        public DataTable rptAsistenca(string eventoid)
        {
            return con.regresaTabla("EXEC rptAsistencia " + eventoid).Tables[0];
        }
    }
}