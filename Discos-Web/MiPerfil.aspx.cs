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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    if(Seguridad.sesionActiva(Session["UserActivo"]))
                    {
                        User user = (User)Session["UserActivo"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtFechaNacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
                        if(!string.IsNullOrEmpty(user.ImagenPerfil))
                            imgPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Erros.aspx", false);
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            
            Session.Remove("UserActivo");//remuevo al usuario de la sesion...
            Response.Redirect("Default.aspx", false);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UserNegocio negocio = new UserNegocio();
                User user = (User)Session["UserActivo"];
                //valido que cargue una imagen y no mande a la base de datos datos vacios
                if(txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                }
                //cargo los datos
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                //guarda los datos del perfil
                negocio.ActualizarDatos(user);
                //leer img
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + user.ImagenPerfil;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}