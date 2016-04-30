using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace practicaFinal.clases
{
    public class claseUsuario
    {
        Conexion con = new Conexion();

        public DataTable buscaUsuario(string usuario, string email, string nombre)
        {
            DataTable tbl;
            tbl = con.regresaTabla("EXEC buscaUsuarios '" + usuario + "','" + email + "','" + nombre + "'").Tables[0];
            return tbl;
        }
    }
}