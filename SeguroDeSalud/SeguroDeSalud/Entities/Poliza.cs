using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Entities
{
    /// <summary>
    ///La Entidad Poliza sirve para la extraccion de datos de la capaBLL, CapaDAL y UI 
    /// </summary>
    class Poliza
    {
        public int Id { get; set; }
        public string Descripcion  { get; set; }
        public float Monto { get; set; }
        public int Planes { get; set; }
    }
}
