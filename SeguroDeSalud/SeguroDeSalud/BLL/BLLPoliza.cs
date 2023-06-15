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
    /// Clase donde se trabaja la logica de Poliza
    /// </summary>
    class BLLPoliza
    
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        private DALPoliza oPoliza = new DALPoliza();


        /// <summary>
        /// Metodo para guardar una poliza en especifico o modificarlo
        /// </summary>
        /// <param name="pPoliza"></param>
        /// Se envia un objeto poliza al dal para guardarlo 
        public void Guardar(Poliza pPoliza)
        {

            try
            {
                if (TraerPorId(pPoliza.Id) == null)
                {
                    oPoliza.Insertar(pPoliza);
                }
                else
                {
                    oPoliza.Actualizar(pPoliza);
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
        /// Metodo para eliminar una poliza en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// Numero de la poliza a eliminar
        public void Eliminar(int Id)
        {

            try
            {

                oPoliza.Eliminar(Id);

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
        /// Se trae una poliza en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// Numero de esa poliza
        /// <returns></returns>
        public Poliza TraerPorId(int Id)
        {
            try
            {

                return oPoliza.TraerPorId(Id);

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
        /// Se trae todas las polizas existentes
        /// </summary>
        /// <returns></returns>
        public List<Poliza> TraerTodo()
        {
            try
            {

                return oPoliza.TraerTodos();

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


    }
}
