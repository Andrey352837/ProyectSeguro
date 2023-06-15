using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Entities
{
    /// <summary>
    ///La Cobertura Asegurados sirve para la extraccion de datos de la capaBLL, CapaDAL y UI 
    /// </summary>
    class Cobertura
    {
        public int Id { get; set; }
        public string Descripcion  { get; set; }
        public float MontoMaximo { get; set; }
        public int Planning { get; set; }
    }
}
