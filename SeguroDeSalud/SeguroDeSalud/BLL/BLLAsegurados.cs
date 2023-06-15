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
    /// Clase donde se trabaja la logica de Asegurados
    /// </summary>
    class BLLAsegurados
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        private DALAsegurados oAsegurados = new DALAsegurados();

        /// <summary>
        /// Se envia un objeto para guardar el asegurado con toda la informacion 
        /// </summary>
        /// <param name="pAsegurados"></param>
        /// El tipo de objeto que se le envia

        public void Guardar(Asegurados pAsegurados)
        {
            try
            {
                
                if (oAsegurados.TraerPorId(pAsegurados.Usuario, pAsegurados.Planning, pAsegurados.FacturaEncabezado) == null)
                {
                    oAsegurados.Insertar(pAsegurados);
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
        /// Se elimina el asegurado atravez de la cedula y el tipo de plan que pertenece
        /// </summary>
        /// <param name="pCedula"></param>
        /// <param name="pPlanning"></param>
        public void Eliminar(string pCedula, int pPlanning)
        {

            try
            {
                oAsegurados.Eliminar(pCedula,pPlanning);

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
       /// Se Elimina los asegurados
       /// </summary>
       /// <param name="planning"></param>
       /// Se busca con el id Plannning para encontrar a que plan pertenece 
       /// <param name="idFactura"></param>
       /// se envia el Id factura para buscar en que plan y factura esta ligado y se elimina con esta informacion
        public static void EliminarAsegurados(int planning, int idFactura)
        {
            DALAsegurados oNuevo = new DALAsegurados();
            foreach (var lista in oNuevo.TraerTodos()) {


                if (planning == lista.Planning && idFactura == lista.FacturaEncabezado)
                {
                    oNuevo.Eliminar(lista.Usuario, lista.Planning);
                }
            }

        }

        /// <summary>
        /// Trae Todos los asegurados y utiliza metodos de la capa DAL
        /// </summary>
        /// <param name="idFactura"></param>
        /// Se envia el parametro para buscar la factura
        /// <param name="idPlanning"></param>
        /// se envia el parametro para buscar el tipo de plan que pertenece ese asefurado
        /// <returns></returns>
        public static List<Asegurados> todoAsegurados(int idFactura, int idPlanning)
        {
            List<Asegurados> nuevoAsegurado = new List<Asegurados>();
            DALAsegurados oNuevo = new DALAsegurados();
            foreach (var lista in oNuevo.TraerTodos())
            {
                if (lista.FacturaEncabezado == idFactura && lista.Planning == idPlanning)
                {
                    nuevoAsegurado.Add(lista);
                }

            }
                    return nuevoAsegurado;
        }

    }
}

