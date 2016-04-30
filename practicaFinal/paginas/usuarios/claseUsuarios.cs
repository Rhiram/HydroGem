using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace practicaFinal.paginas
{
    class claseUsuarios
    {

        Conexion con = new Conexion();

        public DataTable buscaUsuario(string usuarioId)
        {
            return con.regresaTabla("EXEC vistaUsuarios '" + usuarioId + "'").Tables[0]; ;
        }

        public DataTable regresaUsuario (string usuarioId)
        {
            return con.regresaTabla("EXEC regresaUsuario '" + usuarioId + "'").Tables[0]; ;
        }
        public DataTable buscaUsuario(string usuario, string email, string nombre)
        {
            DataTable tbl;
            tbl = con.regresaTabla("EXEC buscaUsuarios '" + usuario + "','" + email + "','" + nombre + "'").Tables[0];
            return tbl;
        }

        public bool insertaUsuario(string nombre, string apellidoP, string apellidoM, string email, string pass, string usuario, string perfil, string usuarioId)
        {
            return con.consulta("EXEC insertaUsuario '" + usuario + "','" + pass + "','" + email + "','" + nombre + "','" + apellidoP + "','" + apellidoM + "','" + perfil + "','" + usuarioId + "'");
        }
        public bool modificaUsuario(string nombre, string apellidoP, string apellidoM, string email, string pass, string usuario, string perfil, string usuarioId,string usuarioIdUP)
        {
            return con.consulta("EXEC modificaUsuario '" + usuario + "','" + pass + "','" + email + "','" + nombre + "','" + apellidoP + "','" + apellidoM + "','" + perfil +  "','" + usuarioId + "','"+usuarioIdUP+"'");
        }


        public bool insertaEnlaceEstado(string consulta)
        {
            return con.consulta(consulta);
        }

        public DataTable login( string usuario, string pass)
        {
            return con.regresaTabla("EXEC login '" + usuario + "','" + pass + "'").Tables[0];
        }

        public DataTable estadosAsigandos(string usuario)
        {
            return con.regresaTabla("EXEC estadosAsignados " + usuario).Tables[0];
        }
    }
}
