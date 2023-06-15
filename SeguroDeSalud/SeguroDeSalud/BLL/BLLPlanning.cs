using SeguroDeSalud.DAL;
using SeguroDeSalud.Entities;
using SeguroDeSalud.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.BLL
{ /// <summary>
  /// Se trae todas los 
  /// Planning a la parte logica
  /// </summary>
  /// <returns></returns>
    class BLLPlanning : IBLLPlanning
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        private IDALPlanning oPlanning = new DALPlanning();


        /// <summary>
        /// Se guarda el plan en la base de datos o se modifica
        /// </summary>
        /// <param name="pPlanning"></param>
        public void Guardar(Planning pPlanning)
        {

            try
            {
                if (TraerPorId(pPlanning.Id) == null)
                {
                    oPlanning.Insertar(pPlanning);
                }
                else
                {
                    oPlanning.Actualizar(pPlanning);
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
        /// Se elimina el plan de la base de datos 
        /// </summary>
        /// <param name="Id"></param>
        /// Se trae el numero de plan para eliminarlo
        public void Eliminar(int Id)
        {

            try
            {

                oPlanning.Eliminar(Id);

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
        /// Se busca el plan por medio de un id
        /// </summary>
        /// <param name="Id"></param>
        /// se envia un id para buscar un plan en especifico
        /// <returns></returns>
        public Planning TraerPorId(int Id)
        {
            try
            {

                return oPlanning.TraerPorId(Id);

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
        /// Se trae todos los planes existentes
        /// </summary>
        /// <returns></returns>
        public List<Planning> TraerTodo()
        {
            try
            {

                return oPlanning.TraerTodos();

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
        /// Se busca en las coberturas todas las cuales traen un plan en especifico
        /// </summary>
        /// <param name="id"></param>
        /// Se envie el codigo del plan para trae las coberturas
        /// <returns></returns>
        public List<Cobertura> TraerCoberturas(int id)
        {
            BLLCobertura nuevaCobertura = new BLLCobertura();
            List<Cobertura> lista = new List<Cobertura>();
            foreach (var nueva in nuevaCobertura.TraerTodo())
            {
                if (id == nueva.Planning)
                {
                    lista.Add(nueva);
                }
            }
            return lista;
        }
        /// <summary>
        /// Se busca en las Polizas todas las cuales traen un plan en especifico
        /// </summary>
        /// <param name="id"></param>
        /// Se envie el codigo del plan para trae las Polizas
        /// <returns></returns>
        public List<Poliza> TraerPoliza(int id)
        {
            BLLPoliza oPoliza = new BLLPoliza();
            List<Poliza> lista = new List<Poliza>();
            foreach (var nueva in oPoliza.TraerTodo())
            {
                if (id == nueva.Planes)
                {
                    lista.Add(nueva);
                }
            }
            return lista;
        }

        /// <summary>
        /// Se busca en las seguros donde traigan un plan en especifico
        /// </summary>
        /// <param name="id"></param>
        /// Se envie el codigo del plan para trae los seguros 
        /// <returns></returns>
        public List<Seguro> TraerSeguros(int id)
        {
            BLLPlanesSeguro oBLLPlanesSeguro = new BLLPlanesSeguro();
            List<Seguro> lista = new List<Seguro>();
            BLLSeguro nuevoSeguro = new BLLSeguro();
            foreach (var nueva in oBLLPlanesSeguro.TraerTodo())
            {
                if (id == nueva.Planning)
                {
                    lista.Add(nuevoSeguro.TraerPorId(nueva.Seguro));
                }
            }
            return lista;
        }

    }
}
