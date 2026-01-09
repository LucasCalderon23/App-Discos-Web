using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dominio;

namespace Negocio
{
    public class EstiloNegocio
    {
        public List<Estilos> Listado()
        {
            List<Estilos> lista = new List<Estilos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("select Id, Descripcion from ESTILOS");
                datos.exRead();

                while (datos.Reader.Read())
                {
                    Estilos aux = new Estilos();
                    aux.Id = (int)datos.Reader["Id"];
                    aux.Descripcion = (string)datos.Reader["Descripcion"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.closeConnection();
            }
        }

    }
}
