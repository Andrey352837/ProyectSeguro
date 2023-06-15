using SeguroDeSalud.DAL;
using SeguroDeSalud.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.BLL
{/// <summary>
 /// Clase donde se trabaja la logica de tipo Plan
 /// </summary>
    class BLLTipoPlan
    {
        /// <summary>
        /// metodo el cual se trae un tipo plan en especifico
        /// </summary>
        /// <param name="id"></param>
        /// El numero del id del tipo de plan
        /// <returns></returns>
        public static TipoPlan TraerPorId(int id)
        {
            return DALTipoPlan.TraerPorId(id);
        }
        /// <summary>
        /// Se trae todos los tipo de planes
        /// </summary>
        /// <returns></returns>
        public static List<TipoPlan> TraerTodo()
        {
            return DALTipoPlan.TraerTodos();
        }
    }
}
