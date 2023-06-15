using SeguroDeSalud.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Interfaces
{
    interface  IDALPlanning
    {
        void Insertar(Planning pPlanning);
        void Actualizar(Planning pPlanning);
        void Eliminar(int Id);
        Planning TraerPorId(int Id);
        List<Planning> TraerTodos();
    }
}
