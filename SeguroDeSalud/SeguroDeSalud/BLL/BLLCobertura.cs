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
 /// Clase donde se trabaja la logica de Cobertura
 /// </summary>
    class BLLCobertura
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        private DALCobertura oCobertura = new DALCobertura();


        /// <summary>
        /// Se guarda la Cobertura
        /// </summary>
        /// <param name="pCobertura"></param>
        /// Se guarda el tipo Cobertura en la DAL
        public void Guardar(Cobertura pCobertura)
        {

            try
            {
                if (TraerPorId(pCobertura.Id) == null)
                {
                    oCobertura.Insertar(pCobertura);
                }
                else
                {
                    oCobertura.Actualizar(pCobertura);
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
        /// Se elimina la factura
        /// </summary>
        /// <param name="Id">
        /// Se le Envia el id de la factura
        /// </param>
        public void Eliminar(int Id)
        {

            try
            {

                oCobertura.Eliminar(Id);

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
        /// Se busca busca en la cobertura por ID
        /// </summary>
        /// <param name="Id"></param>
        /// El ID de la factura 
        /// <returns></returns>
        public Cobertura TraerPorId(int Id)
        {
            try
            {

                return oCobertura.TraerPorId(Id);

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
        /// Se trae todas las coberturas a la parte logica
        /// </summary>
        /// <returns></returns>
        public List<Cobertura> TraerTodo()
        {
            try
            {

                return oCobertura.TraerTodos();

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
