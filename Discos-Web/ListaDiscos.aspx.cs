using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Discos_Web
{
    public partial class ListaDiscos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            dgvListaDiscos.DataSource = negocio.ListadoConSP();
            dgvListaDiscos.DataBind();
        }

        protected void dgvListaDiscos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvListaDiscos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioDisco.aspx?id=" + id);
        }

        protected void dgvListaDiscos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaDiscos.PageIndex = e.NewPageIndex;
            dgvListaDiscos.DataBind();
        }
    }
}