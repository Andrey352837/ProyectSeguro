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
    ///La Clase DALCobertura sirve para la insertacion, actualizacion, eliminacion,
    ///extraccion por Id y la extraccion de todos los datos de una tabla en especifica
    ///de la base de datos
    /// </summary>
    class DALCobertura
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        /// <summary>
        /// Se actualiza la tabla Cobertura en la base de datos
        /// </summary>
        /// <param name="pCobertura"></param>
        /// Se le manda un objeto Tipo Cobertura para actualizar la tabla
        public void Actualizar(Cobertura pCobertura)
        {
            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_UPDATE_Cobertura"
            };

            comando.Parameters.AddWithValue("@Id", pCobertura.Id);
            comando.Parameters.AddWithValue("@Descripcion", pCobertura.Descripcion);
            comando.Parameters.AddWithValue("@MontoMaximo   ", pCobertura.MontoMaximo);
            comando.Parameters.AddWithValue("@Planning", pCobertura.Planning);
           

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
            /// <param name="pId"></param>
            /// Se envia un pId para eliminar un dato en la base de datos


        public void Eliminar(int pId)
        {

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_DELETE_Cobertura_ByID"
            };
            comando.Parameters.AddWithValue("@Id", pId);

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
        /// <param name="pCobertura"></param>
        /// Se envia un objeto tipo Cobertura para guardarlo en la base de datos

        public void Insertar(Cobertura pCobertura)
        {
            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_INSERT_Cobertura"
            }; 
           
            comando.Parameters.AddWithValue("@Descripcion", pCobertura.Descripcion);
            comando.Parameters.AddWithValue("@MontoMaximo", pCobertura.MontoMaximo);
            comando.Parameters.AddWithValue("@Planning", pCobertura.Planning);


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
        /// Se traer los Cobertura por ID
        /// </summary>
        /// <param name="pId"></param>
        /// Se envia un id Tipo Cobertura para buscar las Cobertura       
        /// <returns></returns>

        public Cobertura TraerPorId(int pId)
        {
            Cobertura oCobertura = null;

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_SELECT_Cobertura_ByID"
            };
            comando.Parameters.AddWithValue("@Id", pId);


            try
            {

                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    IDataReader reader = db.ExecuteReader(comando);

                    while (reader.Read())
                    {

                        oCobertura = new Cobertura();

                        oCobertura.Id = (int)reader["Id"];
                        oCobertura.Descripcion = reader["Descripcion"].ToString();
                        oCobertura.MontoMaximo = float.Parse(reader["MontoMaximo"].ToString());
                        oCobertura.Planning = (int)reader["Planning"];
                        





                    }

                }

                return oCobertura;

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
        /// Se trae todo las Cobertura de la tabla
        /// </summary>
        /// <returns></returns>
        public List<Cobertura> TraerTodos()
        {

            List<Cobertura> lista = new List<Cobertura>();

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_SELECT_Cobertura_All"
            };



            try
            {

                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    IDataReader reader = db.ExecuteReader(comando);

                    while (reader.Read())
                    {

                        Cobertura oCobertura = new Cobertura();

                        oCobertura.Id = (int)reader["Id"];
                        oCobertura.Descripcion = reader["Descripcion"].ToString();
                        oCobertura.MontoMaximo = float.Parse(reader["MontoMaximo"].ToString());
                        oCobertura.Planning = (int)reader["Planning"];
                        lista.Add(oCobertura);



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