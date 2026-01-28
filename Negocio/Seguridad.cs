using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public static class Seguridad
    {
        //Clase para evaluar si hay una sesion activa y reutilizar para otras paginas
        public static bool sesionActiva(object usuario)
        {
            
            User user = usuario != null ? (User)usuario : null;//pregunto si el usuario no es nulo(object) y lo casteo para agregarlo a user y psteriormente evaluarlo en el if 
            if (user != null && user.Id != 0)// si no es nulo y tiene Id retorna true lo que quiere decir que estoy logueado
                return true;
            else
                return false;
        }

        public static bool esAdmin(object usuario)
        {
            User user = usuario != null ? (User)usuario : null;
            return user != null ? user.Admin : false;//es necesario usar el operador ternario ya que si es nulo lanza una excepción
        }
    }
}
