using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Entities
{
    /// <summary>
    ///La Entidad TipoUsuario sirve para la extraccion de datos de la capaBLL, CapaDAL y UI 
    /// </summary>
    class TipoUsuario
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }
    }
}
