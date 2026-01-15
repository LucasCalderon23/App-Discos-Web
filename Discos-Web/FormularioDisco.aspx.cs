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
    public partial class FormularioDisco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    EstiloNegocio negocioEstilo = new EstiloNegocio();
                    List<Estilos> listaEstilo = negocioEstilo.Listado();
                    TipoEdicionNegocio negocioEdicion = new TipoEdicionNegocio();
                    List<TipoEdicion> listaEdicion = negocioEdicion.Listado();

                    ddlGenero.DataSource = listaEstilo;
                    ddlGenero.DataValueField = "Id";
                    ddlGenero.DataTextField = "Descripcion";
                    ddlGenero.DataBind();

                    ddlEdicion.DataSource = listaEdicion;
                    ddlEdicion.DataValueField = "Id";
                    ddlEdicion.DataTextField = "Descripcion";
                    ddlEdicion.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgDisco.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Discos nuevo = new Discos();
                DiscosNegocio negocio = new DiscosNegocio();
                nuevo.Titulo = txtTitulo.Text;
                nuevo.Fecha_Lanzamiento = DateTime.Parse(txtFecha.Text);
                nuevo.Cant_Canciones = int.Parse(txtCanciones.Text);
                nuevo.Genero = new Estilos();
                nuevo.Genero.Id = int.Parse(ddlGenero.SelectedValue);
                nuevo.Edicion = new TipoEdicion();
                nuevo.Edicion.Id = int.Parse(ddlEdicion.SelectedValue);
                nuevo.UrlImagenTapa = txtUrlImagen.Text;

                negocio.agregarSP(nuevo);
                Response.Redirect("ListaDiscos.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}