using SeguroDeSalud.DAL;
using SeguroDeSalud.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.BLL
{
    /// <summary>
    /// Clase donde se trabaja la logica de PlanesSeguro
    /// </summary>
    class BLLPlanesSeguro
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        private DALSeguroPlanning oPlanSeguros = new DALSeguroPlanning();


        /// <summary>
        /// Se guarda un plan en la DAL
        /// </summary>
        /// <param name="pSeguroPlanning"></param>
        /// Se envia un plan para insertarlo en la base de datos 
        public void Guardar(PlanSeguros pSeguroPlanning)
        {

            try
            {

                if (oPlanSeguros.TraerPorId(pSeguroPlanning.Seguro, pSeguroPlanning.Planning) == null)
                {
                    oPlanSeguros.Insertar(pSeguroPlanning);
                }




            }
            catch (SqlException sqlError)
            {
                throw sqlError;
            }
            catch (Exception er)
            {
                throw er;
            }
        }

        

       
        /// <summary>
        /// Se  trae todos los planes de la base de datos 
        /// </summary>
        /// <returns></returns>
        public List<PlanSeguros> TraerTodo()
        {
            try
            {

                return oPlanSeguros.TraerTodos();

            }
            catch (SqlException sqlError)
            {
                throw sqlError;
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        /// <summary>
        /// Va y busca todos los seguros que estan ligados y los elimina
        /// </summary>
        /// <param name="seguro"></param>
        /// Es el numero de seguro para eliminar datos en la tabla
        public static void EliminarSegurosPlanes(int seguro)
        {
             DALSeguroPlanning oSeguroPlan = new DALSeguroPlanning();
            foreach (var lista in oSeguroPlan.TraerTodos())
            {
                if (lista.Seguro == seguro)
                {
                    oSeguroPlan.Eliminar(lista.Seguro,lista.Planning);

                }
            }

        }
    }
}
