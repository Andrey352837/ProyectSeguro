using SeguroDeSalud.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Interfaces
{
    interface IBLLUsuario
    {
        void guardarUsuario(Usuario pUsuario);
        void Guardar(Usuario pUsuario);
        void Eliminar(string Id);
        Usuario TraerPorId(string Id);
        List<Usuario> TraerTodo();
        
    }
}
