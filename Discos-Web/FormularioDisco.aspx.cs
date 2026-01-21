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
        public bool Confirmacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            Confirmacion = false;
            try
            {
                // configuracion inicial de del formulario
                // si no es la primera vez que va al servidor
                if (!IsPostBack)
                {
                    EstiloNegocio negocioEstilo = new EstiloNegocio();
                    List<Estilos> listaEstilo = negocioEstilo.Listado();
                    TipoEdicionNegocio negocioEdicion = new TipoEdicionNegocio();
                    List<TipoEdicion> listaEdicion = negocioEdicion.Listado();
                    //cargamos los DropDownsList 
                    ddlGenero.DataSource = listaEstilo;
                    // tomamos el Id como valor del dato a precargar en la lista
                    ddlGenero.DataValueField = "Id";
                    // muestra la descripcion que le corresponde al Id seleccionado
                    ddlGenero.DataTextField = "Descripcion";
                    ddlGenero.DataBind();

                    ddlEdicion.DataSource = listaEdicion;
                    ddlEdicion.DataValueField = "Id";
                    ddlEdicion.DataTextField = "Descripcion";
                    ddlEdicion.DataBind();

                    
                    
                }
                //configuracion si estamos modificando
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    DiscosNegocio negocio = new DiscosNegocio();
                    Discos seleccionado = (negocio.Listado(id))[0];

                    //guardamos el disco seleccionado en session para su posterior uso cuando querramos desactivar/reactivar
                    Session.Add("discoSeleccionado", seleccionado);
                    // pre cargamos los datos del objeto seleccionado
                    txtId.Text = id;
                    txtTitulo.Text = seleccionado.Titulo;
                    txtFecha.Text = seleccionado.Fecha_Lanzamiento.ToString("dd--MM--yyyy");
                    txtCanciones.Text = seleccionado.Cant_Canciones.ToString();
                    txtUrlImagen.Text = seleccionado.UrlImagenTapa;
                    txtUrlImagen_TextChanged(sender, e);
                    ddlGenero.SelectedValue = seleccionado.Genero.Id.ToString();
                    ddlEdicion.SelectedValue = seleccionado.Edicion.Id.ToString();

                    //configuracion del boton para activar o desactivar
                    if (!seleccionado.Activo)
                        btnDesactivar.Text = "Activar";
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
        // cuando le damos aceptar se cargan todos los datos a la variable de tipo DISCO y se agrega a la lista
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

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modify(nuevo);
                }
                else
                    negocio.agregarSP(nuevo);

                Response.Redirect("ListaDiscos.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Confirmacion = true;
        }

        protected void btnConfirmacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmacion.Checked)
                {
                    DiscosNegocio negocio = new DiscosNegocio();
                    negocio.delete(int.Parse(txtId.Text));
                    Response.Redirect("ListaDiscos.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }

        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DiscosNegocio negocio = new DiscosNegocio();
                Discos seleccionado = (Discos)Session["discoSeleccionado"];
                negocio.deleteLogico(seleccionado.Id, !seleccionado.Activo);
                Response.Redirect("ListaDiscos.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
            
        }
    }
}