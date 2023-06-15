using SeguroDeSalud.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Interfaces
{
    interface IDALUsuario
    {
        
        void Insertar(Usuario pUsuario);
        void Actualizar(Usuario pUsuario );
        void Eliminar(string pId);
        Usuario TraerPorId(string pId);
        List<Usuario> TraerTodos();
    }
}
