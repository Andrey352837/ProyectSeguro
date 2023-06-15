using SeguroDeSalud.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Interfaces
{
    interface IBLLPlanning
    {
        void Guardar(Planning pPlanning);
        void Eliminar(int Id);
        Planning TraerPorId(int Id);
        List<Planning> TraerTodo();
    }
}
