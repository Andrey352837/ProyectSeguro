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
    ///La Clase DALTipoPlan sirve para la insertacion, actualizacion, eliminacion,
    ///extraccion por Id y la extraccion de todos los datos de una tabla en especifica
    ///de la base de datos
    /// </summary>
    class DALTipoPlan
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        /// <summary>
        /// Se traer los TipoPlan por ID
        /// </summary>
        /// <param name="Id"></param>
        /// Se envia un id Tipo TipoPlan para buscar las Cobertura       
        /// <returns></returns>
        public static TipoPlan TraerPorId(int Id)
        {

            TipoPlan pTipoPlan = null;

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_SELECT_TipoPlan_ByID"
            };
            comando.Parameters.AddWithValue("@Id", Id);


            try
            {

                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    IDataReader reader = db.ExecuteReader(comando);

                    while (reader.Read())
                    {
                        pTipoPlan = new TipoPlan();

                        pTipoPlan.Id = (int)reader["Id"];
                        pTipoPlan.Precio = reader["Precio"].ToString();
                        pTipoPlan.Descripcion = reader["Descripcion"].ToString();

                    }

                }

                return pTipoPlan;

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
        /// Se trae todo los TipoPlan de la tabla
        /// </summary>
        /// <returns></returns>
        public static List<TipoPlan> TraerTodos()
        {


            List<TipoPlan> lista = new List<TipoPlan>();


            SqlCommand comando = new SqlCommand();

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "usp_SELECT_TipoPlan_All";



            try
            {
                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection()))
                {



                    DataSet ds = db.ExecuteDataSet(comando);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        TipoPlan oTipoPlan = new TipoPlan();


                        oTipoPlan.Descripcion = dr["Descripcion"].ToString();
                        oTipoPlan.Id = (int)dr["Id"];
                        oTipoPlan.Precio = dr["Precio"].ToString();

                        lista.Add(oTipoPlan);



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
