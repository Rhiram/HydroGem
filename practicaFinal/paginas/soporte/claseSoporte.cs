using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace practicaFinal.paginas.soporte
{
    public class claseSoporte
    {
          Conexion con = new Conexion();
          public bool insertaAsunto(string usuarioId, string titulo, string comentario)
        {
            return con.consulta("EXEC [insertaAsunto] '" + usuarioId + "','" + titulo + "','" + comentario + "'");
        }

          public bool continuaAsunto(string asuntoId, string usuarioId, string comentario, string estadoId,string calificacion)
          {
              return con.consulta("EXEC [actualizaEstado] '" + asuntoId + "','" +estadoId+ "','" + comentario + "','"+usuarioId+"','"+calificacion+"'");
          }

        public DataTable vistaSoporte(string usuarioId)
        {
            return con.regresaTabla("EXEC vistaSoporte " + usuarioId).Tables[0];
        }

        public DataTable vistaSoporteAsignados(string usuarioId)
        {
            return con.regresaTabla("EXEC vistaSoporteAsignados " + usuarioId).Tables[0];
        }

        public DataTable vistaBitacora(string usuarioId)
        {
            return con.regresaTabla("EXEC vistaBitacora " + usuarioId).Tables[0];
        }


        public DataTable regresaSolicitud(string asuntoId)
        {
            return con.regresaTabla("EXEC vistaSoporte " + asuntoId).Tables[0];

        }
        public DataTable rptSoporte(string usuarioId, string usuarioIdAtiende, string fecha1, string fecha2,string estadoId)
        {
            if(fecha1=="")
            {
                DateTime fecha = DateTime.Now;

                fecha1="01/"+fecha.ToString("MM/yyyy");
                fecha2 = Convert.ToDateTime(fecha1).AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy");
            }
            return con.regresaTabla("SET DATEFORMAT DMY; EXEC [rptSoporte] '" + usuarioId + "','" + usuarioIdAtiende + "','" + fecha1 + "','" + fecha2 + "',"+estadoId).Tables[0];


        }
        public string regresaEstado(string asuntoId)
        {
            return con.obtenerValorUnico("SELECT * FROM ultimoEstado("+asuntoId+")",4);
        }
    }
}