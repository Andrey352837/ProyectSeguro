using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Entities
{
    /// <summary>
    ///La Entidad Planning sirve para la extraccion de datos de la capaBLL, CapaDAL y UI 
    /// </summary>
    class Planning
    {
        public int Id { get; set; }
        public int TipoPlan { get; set; }      
        public float Prima { get; set; }
        public float MontoAsegurado { get; set; }
       
    }
}
