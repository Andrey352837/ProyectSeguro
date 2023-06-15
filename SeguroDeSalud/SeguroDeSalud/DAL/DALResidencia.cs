using SeguroDeSalud.BLL;
using SeguroDeSalud.Entities;
using SeguroDeSalud.Interfaces;
using SeguroDeSalud.Persistencia;
using SeguroDeSalud.Utilitarios;
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
    ///La Clase DALRecidencia sirve para la insertacion, actualizacion, eliminacion,
    ///extraccion por Id y la extraccion de todos los datos de una tabla en especifica
    ///de la base de datos
    /// </summary>
    class DALRecidencia 
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        /// <summary>
        /// Se trae todo los Recidencia de la tabla
        /// </summary>
        /// <returns></returns>
        public static List<Recidencia> TraerTodos()
        {


            List<Recidencia> lista = new List<Recidencia>();


            SqlCommand comando = new SqlCommand();

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "usp_SELECT_Recidencia_All";



            try
            {
                using (IDataBase db = FactoryDataBase.CreateDataBase(FactoryConexion.CreateConnection()))
                {

                    

                    DataSet ds = db.ExecuteDataSet(comando);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Recidencia oRecidencia = new Recidencia();

                       
                        oRecidencia.Descripcion = dr["Descripcion"].ToString();
                        oRecidencia.Id = (int)dr["Id"];
                        lista.Add(oRecidencia);



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
