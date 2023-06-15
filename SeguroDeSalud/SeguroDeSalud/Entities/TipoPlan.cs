using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Entities
{
    /// <summary>
    ///La Entidad TipoPlan sirve para la extraccion de datos de la capaBLL, CapaDAL y UI 
    /// </summary>
    class TipoPlan
    {
        public string Descripcion { get; set; }
        public  string Precio { get; set; }
        public int Id { get; set; }

    }
}
