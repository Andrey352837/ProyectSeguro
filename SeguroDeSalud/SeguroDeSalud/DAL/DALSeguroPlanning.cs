using SeguroDeSalud.BLL;
using SeguroDeSalud.Entities;
using SeguroDeSalud.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.DAL
{
    /// <summary>
    ///La Clase DALSeguroPlanning sirve para la insertacion, actualizacion, eliminacion,
    ///extraccion por Id y la extraccion de todos los datos de una tabla en especifica
    ///de la base de datos
    /// </summary>
    class DALSeguroPlanning
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        public void Eliminar(int pSeguro, int pPlanning)
        {

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_DELETE_PlanSeguros_ByID"
            };
            comando.Parameters.AddWithValue("@Seguro", pSeguro);
            comando.Parameters.AddWithValue("@Planning", pPlanning);

            try
            {

                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    db.ExecuteNonQuery(comando);
                }

            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("{0}\n", Utilitarios.Utilitarios.CreateSQLExceptionsErrorDetails(MethodBase.GetCurrentMethod(), comando, sqlError));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                BLLLog4Net.Guardar(msg.ToString());

                throw sqlError;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                BLLLog4Net.Guardar(msg.ToString());
                throw er;
            }
        }

        /// <summary>
        /// Metodo para insetar un objeto en la base de datos
        /// </summary>
        /// <param name="pSeguroPlanning"></param>
        /// Se envia un objeto tipo PlanSeguros para guardarlo en la base de datos

        public void Insertar(PlanSeguros pSeguroPlanning)
        {
            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_INSERT_PlanSeguros"
            };

            comando.Parameters.AddWithValue("@Seguro", pSeguroPlanning.Seguro);
            comando.Parameters.AddWithValue("@Planning", pSeguroPlanning.Planning);

            try
            {
                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    db.ExecuteNonQuery(comando);
                }

            }


            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("{0}\n", Utilitarios.Utilitarios.CreateSQLExceptionsErrorDetails(MethodBase.GetCurrentMethod(), comando, sqlError));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                BLLLog4Net.Guardar(msg.ToString());
                throw sqlError;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                BLLLog4Net.Guardar(msg.ToString());
                throw er;
            }
        }
        /// <summary>
        /// Se traer los PlanSeguros por ID
        /// </summary>
        /// <param name="pPlanning"></param>
        /// Se envia un id Tipo PlanSeguros para buscar las Cobertura       
        /// <param name="pSeguro "></param>
        ///Se envia el id Tipo seguro
        /// <returns></returns>
        public PlanSeguros TraerPorId(int pSeguro , int pPlanning)
        {
            PlanSeguros oSeguroPlanning = null;

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                
            CommandText = "usp_SELECT_PlanSeguros_ByID"
            };

            comando.Parameters.AddWithValue("@Seguro", pSeguro);
            comando.Parameters.AddWithValue("@Planning", pPlanning);

            try
            {

                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    IDataReader reader = db.ExecuteReader(comando);

                    while (reader.Read())
                    {

                        oSeguroPlanning = new PlanSeguros();

                        oSeguroPlanning.Planning  = (int)reader["Planning"];
                        oSeguroPlanning.Seguro = (int)reader["Seguro"];
               

                    }

                }

                return oSeguroPlanning;

            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("{0}\n", Utilitarios.Utilitarios.CreateSQLExceptionsErrorDetails(MethodBase.GetCurrentMethod(), comando, sqlError));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                BLLLog4Net.Guardar(msg.ToString());
                throw sqlError;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                BLLLog4Net.Guardar(msg.ToString());

                throw er;
            }
        }
        /// <summary>
        /// Se trae todo los asegurados de la tabla
        /// </summary>
        /// <returns></returns>
        public List<PlanSeguros> TraerTodos()
        {

            List<PlanSeguros> lista = new List<PlanSeguros>();

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_SELECT_PlanSeguros_All"
            };



            try
            {

                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    IDataReader reader = db.ExecuteReader(comando);

                    while (reader.Read())
                    {

                        PlanSeguros oSeguroPlanning = new PlanSeguros();

                        oSeguroPlanning.Planning = (int)reader["Planning"];
                        oSeguroPlanning.Seguro = (int)reader["Seguro"];
                        lista.Add(oSeguroPlanning);
                    }

                }

                return lista;

            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("{0}\n", Utilitarios.Utilitarios.CreateSQLExceptionsErrorDetails(MethodBase.GetCurrentMethod(), comando, sqlError));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                BLLLog4Net.Guardar(msg.ToString());
                throw sqlError;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                BLLLog4Net.Guardar(msg.ToString());
                throw er;
            }
        }
    }
}