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
            imgAvatar.ImageUrl = "https://imgs.search.brave.com/X_N2Y1fS1TO5CbzKSvt1Wsfs7lyyC_oefR6wrHHdPaU/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly91cGxv/YWQud2lraW1lZGlh/Lm9yZy93aWtpcGVk/aWEvY29tbW9ucy84/Lzg5L1BvcnRyYWl0/X1BsYWNlaG9sZGVy/LnBuZw";
            if(!(Page is Login) && !(Page is Default) && !(Page is RegistroUsuario))//hago una excepcion de las paginas que quiero mostrar sin necesidad de loguearme
            {
                if (!Seguridad.sesionActiva(Session["UserActivo"]))//evaluo si NO hay una sesion activa (usuario logueado)
                {
                    Response.Redirect("Login.aspx", false);//los mando a loguearse
                }
                else
                {
                    User user = (User)Session["UserActivo"];//si hay una sesion activa la guardo en 'user'
                    lblUser.Text = user.Nombre;//le pongo el nombre que guarde en mi perfil o el email
                    if(!string.IsNullOrEmpty(user.ImagenPerfil))//verifico que haya una imagen seleccionada y si NO esta nulo o vacio que la cargue
                    {
                        imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    }
                }
                    
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