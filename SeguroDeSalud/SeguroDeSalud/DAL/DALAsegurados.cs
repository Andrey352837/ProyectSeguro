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
    ///La Clase DALAsegurados sirve para la insertacion, actualizacion, eliminacion,
    ///extraccion por Id y la extraccion de todos los datos de una tabla en especifica
    ///de la base de datos
    /// </summary>
    class DALAsegurados
    {
    
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        /// <summary>
        /// Metodo para eliminar en la base de datos 
        /// </summary>
        /// <param name="pUsuario"></param>
        /// Se trae el Id Usuario de para eliminarlo en la base de datos
        /// <param name="pPlanning"></param>
        /// Se trae el Id Planning de para eliminarlo en la base de datos
        public void Eliminar(string pUsuario, int pPlanning)
        {

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_DELETE_Asegurados_ByID"
            };
            comando.Parameters.AddWithValue("@Usuario", pUsuario);
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
        /// <param name="pAsegurados"></param>
        /// Se envia un objeto tipo Asegurados para guardarlo en la base de datos
        public void Insertar(Asegurados pAsegurados)
        {
            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_INSERT_Asegurados"
            };

            comando.Parameters.AddWithValue("@Planning", pAsegurados.Planning);
            comando.Parameters.AddWithValue("@Usuario", pAsegurados.Usuario);
            comando.Parameters.AddWithValue("@FacturaEncabezado", pAsegurados.FacturaEncabezado);

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
        /// Se traer los Asegurados por ID
        /// </summary>
        /// <param name="pUsuario"></param>
        /// Se envia un id Tipo Usuario para buscar los asegurados
        /// <param name="pPlanning"></param>
        /// Se envia un id Tipo Planning para buscar los asegurados
        /// <param name="pEncabezadoFactura"></param>
        /// Se envia un id Tipo Encabezado Factura para buscar los asegurados
        /// <returns></returns>
        public Asegurados TraerPorId(string pUsuario, int pPlanning, int pEncabezadoFactura)
        {
            Asegurados oAsegurados = null;

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,

                CommandText = "usp_SELECT_Asegurados_ByID"
            };

            comando.Parameters.AddWithValue("@Usuario", pUsuario);
            comando.Parameters.AddWithValue("@Planning", pPlanning);
            comando.Parameters.AddWithValue("@FacturaEncabezado", pEncabezadoFactura);

            try
            {

                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    IDataReader reader = db.ExecuteReader(comando);

                    while (reader.Read())
                    {

                        oAsegurados = new Asegurados();

                        oAsegurados.Planning = (int)reader["Planning"];
                        oAsegurados.Usuario = reader["Usuario"].ToString();
                        oAsegurados.FacturaEncabezado = (int)reader["FacturaEncabezado"];

                    }

                }

                return oAsegurados;

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
        public List<Asegurados> TraerTodos()
        {

            List<Asegurados> lista = new List<Asegurados>();

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_SELECT_Asegurados_All"
            };



            try
            {

                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    IDataReader reader = db.ExecuteReader(comando);

                    while (reader.Read())
                    {

                        Asegurados oAsegurados = new Asegurados();

                        oAsegurados.Planning = (int)reader["Planning"];
                        oAsegurados.Usuario = reader["Usuario"].ToString();
                        oAsegurados.FacturaEncabezado = (int)reader["FacturaEncabezado"];
                        lista.Add(oAsegurados);
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