using SeguroDeSalud.DAL;
using SeguroDeSalud.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.BLL
{
    class BLLLog4Net
    {
        
        public static void Guardar(string Descripcion)
        {
            DALLog4Net.Insertar( Descripcion);
        }
    }
}
