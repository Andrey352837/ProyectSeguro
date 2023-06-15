using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Entities
{
    /// <summary>
    ///La Entidad FacturaEncabezado sirve para la extraccion de datos de la capaBLL, CapaDAL y UI 
    /// </summary>
    class FacturaEncabezado
    {
        public int Id { get; set; }

        public DateTime FechaFactura { get; set; }
        public string Cliente{ get; set; }
        public string TarjetaCredito { get; set; }
        public int planning  { get; set; }
        public float MontoFinal { get; set; }
        public byte[] QR { get; set; }
        public byte[] FirmaDigital { get; set; }
        public byte[] Cedula { get; set; }

        public float MontoBruto { get; set; }
        public float MontoFinalDolares { get; set; }
        public float MontoBrutoDolares { get; set; }



    }
}
