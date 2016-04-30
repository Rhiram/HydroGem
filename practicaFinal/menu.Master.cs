using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practicaFinal
{
    public partial class menu : System.Web.UI.MasterPage
    {
        Conexion con = new Conexion();
        DataTable tbl = new DataTable();
        variablesGlobales var = new variablesGlobales();
        MenuItem item;
        string a;
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioNombre_$"] != null)
            {
                nombre_usuario.Text = Session["usuarioNombre_$"].ToString().Replace("_"," ");
                if (Convert.ToInt32(Session["perfilId_$"].ToString()) == 1)
                {
                    /*menu administrador*/
                    menu_dinamico.Text = "<li class='active'><a href='/paginas/soporte/vistaSoport.aspx'><font size=\"4\"><b>Catalogo</b></font></a></li>" +
                                         "<li class='dropdown'>" + "<li class='active'><a href='/paginas/soporte/vistaSoport.aspx'><font size=\"4\"><b>Renta</b></font></a></li>" +
                                         "<li class='dropdown'>" + "<li class='active'><a href='/paginas/soporte/vistaSoport.aspx'><font size=\"4\"><b>Servicios</b></font></a></li>" +
                                         "<li class='dropdown'>" + "<li class='active'><a href='/paginas/soporte/vistaSoport.aspx'><font size=\"4\"><b>Proveedores</b></font></a></li>" +
                                         "<li class='dropdown'>" +
                                         "<li class='active'><a href='/paginas/usuarios/usuariosVista.aspx'><font size=\"4\"><b>Usuarios</b></font></a></a></li>" +
                                          "<li class='dropdown'>"
                                         /*+
                                            "<a class='dropdown-toggle' data-toggle='dropdown' href='#'>Catálogos <span class='caret'></span></a>" +
                                            "<ul class='dropdown-menu'>" +
                                            "<li><a href='/paginas/Ciudades/vistaCiudades.aspx'>Ciudades</a></li>" +
                                            "<li><a href='/paginas/Parques/vistaParque.aspx'>Parques</a></li>" +
                                            "<li><a href='/paginas/usuarios/usuariosVista.aspx'>Usuarios</a></li>" +
                                            "</ul>" +
                                        "</li>"*/;

                }
                else
                {
                    menu_dinamico.Text = "<li class='active'><a href='/paginas/soporte/vistaSoport.aspx'>Catalogo</a></li>" +
                                       "<li class='dropdown'>";
                                        
                }

                log_dinamico.Text = "<li><a href='/paginas/usuarios/logout.aspx'><span class='glyphicon glyphicon-log-out'></span> Salir </a></li>";

            }
            else
            {
                nombre_usuario.Text = "Sin identificar";
                log_dinamico.Text = "<li><a href='/paginas/usuarios/login.aspx'><span class='glyphicon glyphicon-log-in'></span> Identificarse </a></li>";
            }
        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnOff_Click(object sender, EventArgs e)
        {
         
        }

        protected void MenuAdmin_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
          
        }
    }
}