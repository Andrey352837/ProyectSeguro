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
    /// Clase donde se trabaja la logica de Recidencia
    /// </summary>
    class BLLRecidencia : IBLLRecidencia 
    {
        /// <summary>
        /// Metodo que trae todas la Recidencias
        /// </summary>
        /// <returns></returns>
        public List<Recidencia> TraerTodo()
        {
            return DALRecidencia.TraerTodos();

        }
    }
}
