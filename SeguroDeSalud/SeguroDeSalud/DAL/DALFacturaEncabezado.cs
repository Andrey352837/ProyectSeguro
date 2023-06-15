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
    ///La Clase DALFacturaEncabezado sirve para la insertacion, actualizacion, eliminacion,
    ///extraccion por Id y la extraccion de todos los datos de una tabla en especifica
    ///de la base de datos
    /// </summary>
    class DALFacturaEncabezado
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        
        public void Actualizar(FacturaEncabezado  pFacturaEncabezado)
        {
            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_UPDATE_FacturaEncabezado"
            };

            comando.Parameters.AddWithValue("@Id", pFacturaEncabezado.Id);
            comando.Parameters.AddWithValue("@Cliente", pFacturaEncabezado.Cliente);
            comando.Parameters.AddWithValue("@FechaFactura", pFacturaEncabezado.FechaFactura);
            comando.Parameters.AddWithValue("@MontoFinal", pFacturaEncabezado.MontoFinal);
            comando.Parameters.AddWithValue("@MontoFinalDolares", pFacturaEncabezado.MontoFinalDolares);
            comando.Parameters.AddWithValue("@MontoBrutoDolares", pFacturaEncabezado.MontoBrutoDolares);
            comando.Parameters.AddWithValue("@MontoBruto", pFacturaEncabezado.MontoBruto);
            comando.Parameters.AddWithValue("@planning", pFacturaEncabezado.planning);
            comando.Parameters.AddWithValue("@QR", pFacturaEncabezado.QR);
            comando.Parameters.AddWithValue("@FirmaDigital", pFacturaEncabezado.FirmaDigital);
            comando.Parameters.AddWithValue("@Cedula", pFacturaEncabezado.Cedula);
            comando.Parameters.AddWithValue("@TarjetaCredito", pFacturaEncabezado.TarjetaCredito);
            
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
                CommandText = "usp_DELETE_FacturaEncabezado_ByID"
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
        /// <param name="pFacturaEncabezado"></param>
        /// Se envia un objeto tipo FacturaEncabezado para guardarlo en la base de datos



        public void Insertar(FacturaEncabezado pFacturaEncabezado)
        {
            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_INSERT_FacturaEncabezado"
            };
            comando.Parameters.AddWithValue("@Cliente", pFacturaEncabezado.Cliente);
            comando.Parameters.AddWithValue("@FechaFactura", pFacturaEncabezado.FechaFactura);
            comando.Parameters.AddWithValue("@MontoFinal", pFacturaEncabezado.MontoFinal);

            comando.Parameters.AddWithValue("@MontoFinalDolares", pFacturaEncabezado.MontoFinalDolares);
            comando.Parameters.AddWithValue("@MontoBrutoDolares", pFacturaEncabezado.MontoBrutoDolares);
            comando.Parameters.AddWithValue("@MontoBruto", pFacturaEncabezado.MontoBruto);

            comando.Parameters.AddWithValue("@Planning", pFacturaEncabezado.planning);
            comando.Parameters.AddWithValue("@QR", pFacturaEncabezado.QR);
            comando.Parameters.AddWithValue("@FirmaDigital", pFacturaEncabezado.FirmaDigital);

            comando.Parameters.AddWithValue("@Cedula", pFacturaEncabezado.Cedula);
            comando.Parameters.AddWithValue("@TarjetaCredito", pFacturaEncabezado.TarjetaCredito);


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
        /// Se traer las FacturaEncabezado por ID
        /// </summary>
        /// <param name="pId"></param>
        /// Se envia un id Tipo FacturaEncabezado para buscar las Cobertura       
        /// <returns></returns>


        public FacturaEncabezado TraerPorId(int pId)
        {
            FacturaEncabezado oFacturaEncabezado = null;
            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_SELECT_FacturaEncabezado_ByID"
            };
            comando.Parameters.AddWithValue("@Id", pId);
            try
            {
                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    IDataReader reader = db.ExecuteReader(comando);
                    while (reader.Read())
                    {
                        oFacturaEncabezado = new FacturaEncabezado();
                        oFacturaEncabezado.Id = (int)reader["Id"];
                        oFacturaEncabezado.Cliente = reader["Cliente"].ToString();
                        oFacturaEncabezado.MontoFinal = float.Parse(reader["MontoFinal"].ToString());

                        oFacturaEncabezado.MontoFinalDolares = float.Parse(reader["MontoFinalDolares"].ToString());
                        oFacturaEncabezado.MontoBruto = float.Parse(reader["MontoBruto"].ToString());
                        oFacturaEncabezado.MontoBrutoDolares = float.Parse(reader["MontoBrutoDolares"].ToString());

                        oFacturaEncabezado.planning = (int)reader["Planning"];
                        oFacturaEncabezado.QR = (byte[])reader["QR"];
                        oFacturaEncabezado.FirmaDigital = (byte[])reader["FirmaDigital"];

                        oFacturaEncabezado.Cedula = (byte[])reader["Cedula"];
                        oFacturaEncabezado.TarjetaCredito = reader["TarjetaCredito"].ToString();
                        oFacturaEncabezado.FechaFactura = (DateTime)reader["FechaFactura"];
                    }
                }
                return oFacturaEncabezado;
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
        /// Se trae todo los FacturaEncabezado de la tabla
        /// </summary>
        /// <returns></returns>

        public List<FacturaEncabezado> TraerTodos()
        {

            List<FacturaEncabezado> lista = new List<FacturaEncabezado>();

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_SELECT_FacturaEncabezado_All"
            };



            try
            {

                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    IDataReader reader = db.ExecuteReader(comando);

                    while (reader.Read())
                    {


                        FacturaEncabezado  oFacturaEncabezado = new FacturaEncabezado();

                        oFacturaEncabezado.Id = (int)reader["Id"];
                        oFacturaEncabezado.Cliente = reader["Cliente"].ToString();
                        oFacturaEncabezado.MontoFinal = float.Parse(reader["MontoFinal"].ToString());

                        oFacturaEncabezado.MontoFinalDolares = float.Parse(reader["MontoFinalDolares"].ToString());
                        oFacturaEncabezado.MontoBruto = float.Parse(reader["MontoBruto"].ToString());
                        oFacturaEncabezado.MontoBrutoDolares = float.Parse(reader["MontoBrutoDolares"].ToString());

                        oFacturaEncabezado.planning = (int)reader["Planning"];
                        oFacturaEncabezado.QR = (byte[])reader["QR"];
                        oFacturaEncabezado.FirmaDigital = (byte[])reader["FirmaDigital"];

                        oFacturaEncabezado.Cedula = (byte[])reader["Cedula"];
                        oFacturaEncabezado.TarjetaCredito = reader["TarjetaCredito"].ToString();
                        oFacturaEncabezado.FechaFactura = (DateTime)reader["FechaFactura"];
                        lista.Add(oFacturaEncabezado);



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
        public int SiguienteCodigoFactura()
        {            
                int codigo = 0;
                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.CommandText = "PA_SiguienteCodigoEncabezadoFactura";

                    IDataReader reader = db.ExecuteReader(comando);

                    while (reader.Read())
                    {
                        codigo = int.Parse(reader["SiguienteCodigo"].ToString());
                    }
                }
                return codigo; 

        }
    }
}
