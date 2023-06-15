using SeguroDeSalud.DAL;
using SeguroDeSalud.Entities;
using SeguroDeSalud.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.BLL
{
    /// <summary>
    /// Clase donde se trabaja la logica de TipoUsuario
    /// </summary>
    class BLLTipoUsuario : IBLLTipoUsuario
    {
        /// <summary>
        /// Se trae todos los tipos de usuario
        /// </summary>
        /// <returns> </returns>
        public List<TipoUsuario> TaerTodo()
        {
            return DALTipoUsuario.TraerTodo();
        }
    }
}
