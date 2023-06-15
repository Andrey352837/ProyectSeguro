using SeguroDeSalud.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Interfaces
{
    interface IBLLTipoUsuario
    {
        List<TipoUsuario> TaerTodo();
    }
}
