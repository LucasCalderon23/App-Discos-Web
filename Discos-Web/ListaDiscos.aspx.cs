using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Discos_Web
{
    public partial class ListaDiscos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        //cargamos la lista 
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = chkFiltro.Checked;
            if(!IsPostBack)
            {
                DiscosNegocio negocio = new DiscosNegocio();
                Session.Add("listaDiscos", negocio.ListadoConSP());
                dgvListaDiscos.DataSource = Session["listaDiscos"];
                dgvListaDiscos.DataBind();
            }
            
        }
        // mandamos el id por URL cuando seleccionamos un item de la lista y va al formulario
        protected void dgvListaDiscos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvListaDiscos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioDisco.aspx?id=" + id);
        }
        // carga los datos de la lista cuando cambiamos de pagina en el listado
        protected void dgvListaDiscos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaDiscos.PageIndex = e.NewPageIndex;
            dgvListaDiscos.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Discos> lista = (List<Discos>)Session["listaDiscos"];
            List<Discos> listaFiltrada = lista.FindAll(x => x.Titulo.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvListaDiscos.DataSource = listaFiltrada;
            dgvListaDiscos.DataBind();
        }

        protected void chkFiltro_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkFiltro.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if(ddlCampo.SelectedItem.ToString() == "Titulo")
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            } else if (ddlCampo.SelectedItem.ToString() == "Genero")
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            } else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
                
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DiscosNegocio negocio = new DiscosNegocio();
                dgvListaDiscos.DataSource = negocio.Filtrar(ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text,
                    ddlEstado.SelectedItem.ToString());
                dgvListaDiscos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                DiscosNegocio negocio = new DiscosNegocio();
                dgvListaDiscos.DataSource = negocio.ListadoConSP();
                dgvListaDiscos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }
    }
}