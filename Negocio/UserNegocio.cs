using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UserNegocio
    {
        public int insertarUser(User user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setProcedure("insertarNuevo");
                datos.setParameters("@email", user.Email);
                datos.setParameters("@pass", user.Password);
                // retorna el entero desde el stored procedure donde contiene el email y la password que registre...
                return datos.ejecutarAccionScalar();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Login(User user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("select id, email, pass, admin from USERS where email = @email and pass = @pass");
                datos.setParameters("@email", user.Email);
                datos.setParameters("@pass", user.Password);
                datos.exRead();
                if (datos.Reader.Read())
                {
                    user.Id = (int)datos.Reader["id"];
                    user.Admin = (bool)datos.Reader["admin"];
                    return true;
                }
                return false;
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
