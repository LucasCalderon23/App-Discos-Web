using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio

{
    public class Discos
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha_Lanzamiento { get; set; }
        public int Cant_Canciones { get; set; }
        public string UrlImagenTapa { get; set; }
        public Estilos Genero { get; set; }
        public TipoEdicion Edicion { get; set; }
        public bool Activo { get; set; }

    }
}
