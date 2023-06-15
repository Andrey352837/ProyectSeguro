using SeguroDeSalud.DAL;
using SeguroDeSalud.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.BLL
{/// <summary>
 /// Clase donde se trabaja la logica de IVA
 /// </summary>
    class BLLIVA
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
       
        /// <summary>
        /// Se actualiza el IVA
        /// </summary>
        /// <param name="pIVA"></param>
        /// el id del IVA
        public static void Insertar(IVA pIVA)
        {
            DALIVA nuevo = new DALIVA();
            nuevo.Actualizar(pIVA);

        }
        /// <summary>
        /// Se trae el IVA por el ID
        /// </summary>
        /// <param name="id"></param>
        /// El Id del Iva 
        /// <returns></returns>
        public static IVA TraerIVA(int id)
        {
            DALIVA nuevo = new DALIVA();
            return nuevo.TraerPorId(id);
        }
    }
}
