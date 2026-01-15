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
    public partial class Default : System.Web.UI.Page
    {
        public List<Discos> listaDiscos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            listaDiscos = negocio.ListadoConSP();
        }
    }
}