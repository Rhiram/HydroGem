using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace practicaFinal
{
    // Agregamos un nuevo Using a la clase.
    // El código de la clase es:
    class Correos
    {
        /*
         * Cliente SMTP
         * Gmail:  smtp.gmail.com  puerto:587
         * Hotmail: smtp.liva.com  puerto:25
         */
        SmtpClient server = new SmtpClient("smtp.gmail.com", 587);

        public Correos()
        {

            server.Credentials = new System.Net.NetworkCredential("1osvaldoz@gmail.com", "papalote");
            server.EnableSsl = true;
        }

        public void MandarCorreo(MailMessage mensaje)
        {
            server.Send(mensaje);
        }
    }
}