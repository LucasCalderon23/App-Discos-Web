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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(Page is Login) && !(Page is Default))//hago una excepcion de las paginas que quiero mostrar sin necesidad de loguearme
            {
                if (!Seguridad.sesionActiva(Session["UserActivo"]))//evaluo si NO hay una sesion activa (usuario logueado)
                    Response.Redirect("Login.aspx", false);//los mando a loguearse
            }
            
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroUsuario.aspx", false);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnMiPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiPerfil.aspx", false);
        }
    }
}