using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public SqlDataReader Reader
        {
            get {  return reader; }
        }
        public AccesoDatos ()
        {
            this.connection = new SqlConnection("server=LUCAS\\SQLEXPRESS; database=DISCOS_DB; integrated security=true");
            command = new SqlCommand();
        }
        // funcion para pasar la consulta SQL y realizar la accion que corresponda
        public void setQuery(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }
        // funcion para pasar un stored procedure con la consulta ya almacenada 
        public void setProcedure(string sp)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = sp;
        }

        public void setParameters(string nombre, object numero)
        {
            command.Parameters.AddWithValue(nombre, numero);
        }

        public void exRead()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void closeConnection()
        {
            if (reader != null)
                reader.Close();
            connection.Close();
        }

        public void exAccion()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
