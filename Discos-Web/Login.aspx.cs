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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserNegocio negocio = new UserNegocio();
            try
            {
                user.Email = txtEmail.Text;//guardo los datos en user.email
                user.Password = txtPass.Text;
                if(negocio.Login(user))
                {
                    Session.Add("UserActivo", user);//guardo el usuario en la session
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("Error", "Email o Password incorrectas");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }
    }
}