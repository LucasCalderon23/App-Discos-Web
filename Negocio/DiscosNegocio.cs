using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DiscosNegocio
    {
        public List<Discos> Listado(string id = "")
        {
            List<Discos> lista = new List<Discos>();
            SqlConnection connection = new SqlConnection(); //Objeto creado para la conexion a la DB
            SqlCommand comando = new SqlCommand();//objeto creado para realizar acciones en la conexion que acabamos de declarar
            SqlDataReader reader;
            try
            {
                connection.ConnectionString = "server=LUCAS\\SQLEXPRESS; database=DISCOS_DB; integrated security=true"; //atributo del sqlconnection donde indico a donde me voy a conectar
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select d.Id,Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa,e.Descripcion Genero, t.Descripcion Edicion, d.IdEstilo, d.IdTipoEdicion, d.Activo from DISCOS d, ESTILOS e, TIPOSEDICION t where d.IdEstilo = e.Id and d.IdTipoEdicion = t.Id ";
                if (id != "")
                    comando.CommandText += " and d.Id = " + id;
                comando.Connection = connection;

                connection.Open();
                reader = comando.ExecuteReader(); //Ejecuta los comandos que pedimos a la DB linea por linea

                while (reader.Read())// Este bucle se ejecuta siempre y cuando tenga infromacion para leer
                {
                    Discos aux = new Discos();// creo una instancia de un Disco y abajo le voy cargando la infromacion correspondiente de la DB a ese disco vuelta por vuelta
                    aux.Id = (int)reader["Id"];
                    aux.Titulo = (string)reader["Titulo"];
                    aux.Fecha_Lanzamiento = (DateTime)reader["FechaLanzamiento"];
                    aux.Cant_Canciones = (int)reader["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)reader["UrlImagenTapa"];
                    // Genero una instancia de estilos para poder mostrar la descripcion que contiene en la DB
                    aux.Genero = new Estilos();
                    aux.Genero.Id = (int)reader["IdEstilo"];
                    aux.Genero.Descripcion = (string)reader["Genero"];
                    aux.Edicion = new TipoEdicion();
                    aux.Edicion.Id = (int)reader["IdTipoEdicion"];
                    aux.Edicion.Descripcion = (string)reader["Edicion"];
                    aux.Activo = bool.Parse(reader["Activo"].ToString());

                    lista.Add(aux);// Agrego el disco armado a la lista creada en la linea 14...
                }

                connection.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Discos> ListadoConSP()
        {
            List<Discos> lista = new List<Discos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setProcedure("storedListar");
                datos.exRead();
                while (datos.Reader.Read())// Este bucle se ejecuta siempre y cuando tenga infromacion para leer
                {
                    Discos aux = new Discos();// creo una instancia de un Disco y abajo le voy cargando la infromacion correspondiente de la DB a ese disco vuelta por vuelta
                    aux.Id = (int)datos.Reader["Id"];
                    aux.Titulo = (string)datos.Reader["Titulo"];
                    aux.Fecha_Lanzamiento = (DateTime)datos.Reader["FechaLanzamiento"];
                    aux.Cant_Canciones = (int)datos.Reader["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)datos.Reader["UrlImagenTapa"];
                    // Genero una instancia de estilos para poder mostrar la descripcion que contiene en la DB
                    aux.Genero = new Estilos();
                    aux.Genero.Id = (int)datos.Reader["IdEstilo"];
                    aux.Genero.Descripcion = (string)datos.Reader["Genero"];
                    aux.Edicion = new TipoEdicion();
                    aux.Edicion.Id = (int)datos.Reader["IdTipoEdicion"];
                    aux.Edicion.Descripcion = (string)datos.Reader["Edicion"];
                    aux.Activo = bool.Parse(datos.Reader["Activo"].ToString());

                    lista.Add(aux);// Agrego el disco armado a la lista creada en la linea 14...
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Add(Discos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("insert into DISCOS(Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion)values('" + nuevo.Titulo + "', '" + nuevo.Fecha_Lanzamiento.ToString("yyyy-MM-dd") + "', " + nuevo.Cant_Canciones + ", '" + nuevo.UrlImagenTapa + "', @IdEstilo, @IdTipoEdicion)");
                datos.setParameters("@IdEstilo", nuevo.Genero.Id);
                datos.setParameters("@IdTipoEdicion", nuevo.Edicion.Id);
                datos.exAccion();
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

        public void agregarSP(Discos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setProcedure("storedAltaDisco");
                datos.setParameters("@Titulo", nuevo.Titulo);
                datos.setParameters("@FechaLanzamiento", nuevo.Fecha_Lanzamiento);
                datos.setParameters("@CantidadCanciones", nuevo.Cant_Canciones);
                datos.setParameters("@UrlImagenTapa", nuevo.UrlImagenTapa);
                datos.setParameters("@IdEstilo", nuevo.Genero.Id);
                datos.setParameters("@IdTipoEdicion", nuevo.Edicion.Id);
                datos.exAccion();
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

        public void modify(Discos modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("update DISCOS set Titulo = @titulo, FechaLanzamiento = @fechaLanzamiento, CantidadCanciones = @cantidadCanciones, UrlImagenTapa = @urlImagenTapa, IdEstilo = @idEstilo, IdTipoEdicion = @idTipoEdicion where Id = @id");
                datos.setParameters("@titulo", modificar.Titulo);
                datos.setParameters("@fechaLanzamiento", modificar.Fecha_Lanzamiento);
                datos.setParameters("@cantidadCanciones", modificar.Cant_Canciones);
                datos.setParameters("@urlImagenTapa", modificar.UrlImagenTapa);
                datos.setParameters("@idEstilo", modificar.Genero.Id);
                datos.setParameters("@idTipoEdicion", modificar.Edicion.Id);
                datos.setParameters("@id", modificar.Id);

                datos.exAccion();
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

        public void modificarConSP(Discos modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setProcedure("storedModificarDisco");
                datos.setParameters("@titulo", modificar.Titulo);
                datos.setParameters("@fechaLanzamiento", modificar.Fecha_Lanzamiento);
                datos.setParameters("@cantidadCanciones", modificar.Cant_Canciones);
                datos.setParameters("@urlImagenTapa", modificar.UrlImagenTapa);
                datos.setParameters("@idEstilo", modificar.Genero.Id);
                datos.setParameters("@idTipoEdicion", modificar.Edicion.Id);
                datos.setParameters("@id", modificar.Id);

                datos.exAccion();
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

        public void delete(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setQuery("delete from Discos where Id = @id");
                datos.setParameters("@id", id);
                datos.exAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void deleteLogico(int id, bool activo = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setQuery("update DISCOS set Activo = @activo where Id = @Id");
                datos.setParameters("@Id", id);
                datos.setParameters("@activo", activo);
                datos.exAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Discos> Filtrar(string campo, string criterio, string filtro, string activo)
        {
            List<Discos> lista = new List<Discos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select d.Id,Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa,e.Descripcion Genero, t.Descripcion Edicion, d.IdEstilo, d.IdTipoEdicion, d.Activo from DISCOS d, ESTILOS e, TIPOSEDICION t where d.IdEstilo = e.Id and d.IdTipoEdicion = t.Id and";
                if (campo == "Titulo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " Titulo like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += " Titulo like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += " Titulo like '%" + filtro + "%' ";
                            break;
                    }
                }
                else if (campo == "Genero")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " e.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += " e.Descripcion like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += " e.Descripcion like '%" + filtro + "%' ";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " t.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += " t.Descripcion like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += " t.Descripcion like '%" + filtro + "%' ";
                            break;
                    }
                }

                if(activo == "Activo")
                {
                    consulta += " and d.Activo = 1";
                }else if (activo == "Inactivo")
                {
                    consulta += " and d.Activo = 0";
                }

                    datos.setQuery(consulta);
                datos.exRead();
                while (datos.Reader.Read())// Este bucle se ejecuta siempre y cuando tenga infromacion para leer
                {
                    Discos aux = new Discos();// creo una instancia de un Disco y abajo le voy cargando la infromacion correspondiente de la DB a ese disco vuelta por vuelta
                    aux.Id = (int)datos.Reader["Id"];
                    aux.Titulo = (string)datos.Reader["Titulo"];
                    aux.Fecha_Lanzamiento = (DateTime)datos.Reader["FechaLanzamiento"];
                    aux.Cant_Canciones = (int)datos.Reader["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)datos.Reader["UrlImagenTapa"];
                    // Genero una instancia de estilos para poder mostrar la descripcion que contiene en la DB
                    aux.Genero = new Estilos();
                    aux.Genero.Id = (int)datos.Reader["IdEstilo"];
                    aux.Genero.Descripcion = (string)datos.Reader["Genero"];
                    aux.Edicion = new TipoEdicion();
                    aux.Edicion.Id = (int)datos.Reader["IdTipoEdicion"];
                    aux.Edicion.Descripcion = (string)datos.Reader["Edicion"];
                    aux.Activo = bool.Parse(datos.Reader["Activo"].ToString());
                    lista.Add(aux);// Agrego el disco armado a la lista creada en la linea 14...
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
