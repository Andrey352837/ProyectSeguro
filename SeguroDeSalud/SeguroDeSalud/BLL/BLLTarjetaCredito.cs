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
    /// Clase donde se trabaja la logica de Tarjeta De Creditos
    /// </summary>
    class BLLTarjetaCredito
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        private DALTarjetaCredito oTarjetaCredito = new DALTarjetaCredito();


        /// <summary>
        /// Metodo Donde trae un objeto y se lo envia al DAL para que haga su insertacion en la base de datos
        /// </summary>
        /// <param name="pCobertura"></param>
        public void Guardar(TarjetaCredito pCobertura)
        {

            try
            {
                if (oTarjetaCredito.TraerPorId(pCobertura.Numero) == null)
                {
                    oTarjetaCredito.Insertar(pCobertura);
                }
                else
                {
                    oTarjetaCredito.Actualizar(pCobertura);
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
        /// Metodo donde se trae un objeto tipo tarjeta de credito 
        /// </summary>
        /// <param name="Id"></param>
        /// se trae el numero de tarjeta
        /// <returns></returns>

        public TarjetaCredito TraerPorId(string Id)
        {
            try
            {

                return oTarjetaCredito.TraerPorId(Id);

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
