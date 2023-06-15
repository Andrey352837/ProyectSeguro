using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Entities
{
    /// <summary>
    ///La Entidad TarjetaCredito  sirve para la extraccion de datos de la capaBLL, CapaDAL y UI 
    /// </summary>
    class TarjetaCredito
    {
        public string Numero { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaExpiracion { get; set; }
    }
}
