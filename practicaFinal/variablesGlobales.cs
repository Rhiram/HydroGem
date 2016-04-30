using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practicaFinal
{
    class variablesGlobales
    {
        public static string[] parametros;
        public static string[] nombreParametros;
        public static DataSet ds;
        public static DataTable dt;
        public static string mensajeErrorSQL;
        public static string cadena = System.Configuration.ConfigurationSettings.AppSettings.GetValues("conexionLocal")[0];
        public static string correo = System.Configuration.ConfigurationSettings.AppSettings.GetValues("correo")[0];
        public static string contrasena = System.Configuration.ConfigurationSettings.AppSettings.GetValues("contrasena")[0];
        public static Conexion con = new Conexion();
        public static string usuarioId;

        public static DataTable cmbUsuarios()
        {
            Conexion con = new Conexion();

            return con.regresaTabla("EXEC cmbUsuarios").Tables[0];
        }

        public static DataTable cmbUsuariosAtinde()
        {
            Conexion con = new Conexion();

            return con.regresaTabla("EXEC cmbUsuariosAtiende").Tables[0];
        }
         public static DataTable cmbEstados()
        {
            Conexion con = new Conexion();

            return con.regresaTabla("SELECT value=-1,text='TODOS',orden=1 UNION ALL SELECt value=estadoId ,text=nombre,orden=2 FROM estados ORDER BY orden,text").Tables[0];
        }
        public static bool enviaCorreo(string usuarioId, string titulo, string mensaje, string email)
        {
            Conexion con = new Conexion();
            if (email == "")
            {
                email = con.obtenerValorUnico("EXEC regresaCorreo " + usuarioId, 0);
            }
            else
            {
                mensaje = mensaje+"\n Del usuario: " + con.obtenerValorUnico("SELECT nombre+' '+apellidoP+' '+apellidoM FROM usuarios WHERE usuarioId=" + usuarioId, 0);
            }



          

                MailMessage msg = new MailMessage();
                //Quien escribe al correo
                msg.From = new MailAddress(variablesGlobales.correo);
                //A quien va dirigido
                msg.To.Add(new MailAddress(email));
                //Asunto
                msg.Subject = "Respuesta de atencion ciudadana";
                //Contenido del correo
                msg.Body = mensaje;
                //Servidor smtp de gmail
                SmtpClient clienteSmtp = new SmtpClient();
                clienteSmtp.Host = "smtp.gmail.com";
                clienteSmtp.Port = 587;
                clienteSmtp.EnableSsl = false;
                clienteSmtp.UseDefaultCredentials = true;
                //Se envia el correo
                clienteSmtp.Credentials = new NetworkCredential(variablesGlobales.correo, variablesGlobales.contrasena);
                clienteSmtp.EnableSsl = true;
                try
                {
                    clienteSmtp.Send(msg);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                } 

               
        }


    }
}
