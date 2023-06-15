using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
///La Entidad Asegurados sirve para la extraccion de datos de la capaBLL, CapaDAL y UI 
/// </summary>
namespace SeguroDeSalud.Entities
{
    class Asegurados
    {
        public int Planning{ get; set; }
        public string Usuario{ get; set; }
        public int FacturaEncabezado{ get; set; }

    }
}
