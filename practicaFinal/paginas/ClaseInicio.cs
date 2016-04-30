using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace practicaFinal.paginas
{
    public class ClaseInicio
    {
        Conexion con = new Conexion();
        public DataTable consultaMisEventos(int usuarioId, int EdoEvento)
        {
            return con.regresaTabla("EXEC eventosAsignados " + usuarioId + "," + EdoEvento).Tables[0];
        }

    }
}