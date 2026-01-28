using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Discos_Web
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            //configuracion de registro de usuario
            try
            {
                User user = new User();
                UserNegocio userNegocio = new UserNegocio();
                EmailService emailService = new EmailService();

                user.Email = txtEmail.Text;
                user.Password = txtPass.Text;
                int id = userNegocio.insertarUser(user);

                // corregir el envio de emails...

                //emailService.armarCorreo(user.Email, "Bienvenido a DiscosApp", "Te damos la bienvenida a la practica de esta App de discos");
                //emailService.enviarEmail();
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }
    }
}