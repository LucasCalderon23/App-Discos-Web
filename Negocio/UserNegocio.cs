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
        public void ActualizarDatos(User user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("Update USERS set nombre = @nombre, apellido = @apellido, fechaNacimiento = @fechaNacimiento, imagenPerfil = @imagenPerfil where id = @id");
                datos.setParameters("@nombre", user.Nombre);
                datos.setParameters("@apellido", user.Apellido);
                datos.setParameters("@fechaNacimiento", user.FechaNacimiento);
                datos.setParameters("@imagenPerfil", user.ImagenPerfil != null ? user.ImagenPerfil : "");
                datos.setParameters("@id", user.Id);
                datos.exAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

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
                datos.setQuery("select id, nombre, apellido, fechaNacimiento, email, pass, admin, imagenPerfil from USERS where email = @email and pass = @pass");
                datos.setParameters("@email", user.Email);
                datos.setParameters("@pass", user.Password);
                datos.exRead();
                if (datos.Reader.Read())
                {
                    user.Id = (int)datos.Reader["id"];
                    user.Admin = (bool)datos.Reader["admin"];
                    if(!(datos.Reader["nombre"] is DBNull))
                        user.Nombre = (string)datos.Reader["nombre"];
                    if (!(datos.Reader["apellido"] is DBNull))
                        user.Apellido = (string)datos.Reader["apellido"];
                    if (!(datos.Reader["fechaNacimiento"] is DBNull))
                        user.FechaNacimiento = DateTime.Parse(datos.Reader["fechaNacimiento"].ToString());
                    if(!(datos.Reader["imagenPerfil"] is DBNull))
                        user.ImagenPerfil = (string)datos.Reader["imagenPerfil"];
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
