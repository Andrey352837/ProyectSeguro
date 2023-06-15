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
    /// Clase donde se trabaja la logica de Seguro
    /// 
    /// </summary>
    class BLLSeguro
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        private DALSeguro oSeguro = new DALSeguro();



        public void Guardar(Seguro pSeguro)
        {

            try
            {
                if (TraerPorId(pSeguro.Id) == null)
                {
                    oSeguro.Insertar(pSeguro);
                }
                else
                {
                    oSeguro.Actualizar(pSeguro);
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

        public void Eliminar(int Id)
        {

            try
            {

                oSeguro.Eliminar(Id);

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

        public Seguro TraerPorId(int Id)
        {
            try
            {

                return oSeguro.TraerPorId(Id);

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
        public List<Seguro> TraerTodo()
        {
            try
            {

                return oSeguro.TraerTodos();

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
