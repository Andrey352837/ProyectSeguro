using SeguroDeSalud.BLL;
using SeguroDeSalud.Entities;
using SeguroDeSalud.Interfaces;
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
    ///La Clase DALPlanning sirve para la insertacion, actualizacion, eliminacion,
    ///extraccion por Id y la extraccion de todos los datos de una tabla en especifica
    ///de la base de datos
    /// </summary>
    class DALPlanning : IDALPlanning
    {
        int validar = 1;
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        /// <summary>
        /// Se actualiza la tabla Planning en la base de datos
        /// </summary>
        /// <param name="pPlanning"></param>
        /// Se le manda un objeto Tipo Planning para actualizar la tabla


        public void Actualizar(Planning pPlanning)
        {
            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_UPDATE_Planning"
            };

            comando.Parameters.AddWithValue("@Id", pPlanning.Id);
            comando.Parameters.AddWithValue("@TipoPlan", pPlanning.TipoPlan);
            comando.Parameters.AddWithValue("@Prima", pPlanning.Prima);       
            comando.Parameters.AddWithValue("@MontoAsegurado", pPlanning.MontoAsegurado);
           


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
        /// Metodo para eliminar en la base de datos 
        /// </summary>
        /// <param name="Id"></param>
        /// Se envia un pId para eliminar un dato en la base de datos

        public void Eliminar(int Id)
        {

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_DELETE_Planning_ByID"
            };
            comando.Parameters.AddWithValue("@Id", Id);

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
        /// <param name="pPlanning"></param>
        /// Se envia un objeto tipo Planning para guardarlo en la base de datos


        public void Insertar(Planning pPlanning)
        {
            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_INSERT_Planning"
            };

           
            comando.Parameters.AddWithValue("@TipoPlan", pPlanning.TipoPlan);
            comando.Parameters.AddWithValue("@Prima", pPlanning.Prima);
            comando.Parameters.AddWithValue("@MontoAsegurado", pPlanning.MontoAsegurado);


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
        /// Se traer los Planning  por ID
        /// </summary>
        /// <param name="Id"></param>
        /// Se envia un id Tipo Planning para buscar las Cobertura       
        /// <returns></returns>
        public Planning TraerPorId(int Id)
        {
            Planning planning = null;

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_SELECT_Planning_ByID"
            };
            comando.Parameters.AddWithValue("@Id", Id);


            try
            {

                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    IDataReader reader = db.ExecuteReader(comando);

                    while (reader.Read())
                    {

                        planning = new Planning();
                       

                        planning.Id = (int)reader["Id"];
                        planning.MontoAsegurado = float.Parse(reader["MontoAsegurado"].ToString());
                        planning.Prima = float.Parse(reader["Prima"].ToString());

                        planning.TipoPlan = (int)reader["TipoPlan"];

                        






                    }

                }

                return planning;

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
        /// Se trae todo los Planning de la tabla
        /// </summary>
        /// <returns></returns>
        public List<Planning> TraerTodos()
        {

            List<Planning> lista = new List<Planning>();

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_SELECT_Planning_All"
            };



            try
            {

                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    IDataReader reader = db.ExecuteReader(comando);

                    while (reader.Read())
                    {

                        Planning planning = new Planning();

                        planning.Id = (int)reader["Id"];
                        planning.MontoAsegurado = float.Parse(reader["MontoAsegurado"].ToString());
                        planning.Prima = float.Parse(reader["Prima"].ToString());

                        planning.TipoPlan = (int)reader["TipoPlan"];
                     
                        lista.Add(planning);



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
