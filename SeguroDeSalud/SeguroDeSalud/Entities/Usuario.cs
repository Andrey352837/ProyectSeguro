using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Entities
{
    /// <summary>
    ///La Entidad Usuario sirve para la extraccion de datos de la capaBLL, CapaDAL y UI 
    /// </summary>
    class Usuario
    {
        public string Identificacion { get; set; }
        public int TipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Nacionalidad{ get; set; }
        public char Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public byte[] Foto { get; set; }
        public string  NumeroTelefono { get; set; }
        public string Direccion { get; set; }
        public int Recidencia { get; set; }
        public string Email { get; set; }
        public string Contrasenna  { get; set; }
    }
}
