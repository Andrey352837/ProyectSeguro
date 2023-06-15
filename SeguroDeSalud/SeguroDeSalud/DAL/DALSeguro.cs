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
    ///La Clase DALSeguro sirve para la insertacion, actualizacion, eliminacion,
    ///extraccion por Id y la extraccion de todos los datos de una tabla en especifica
    ///de la base de datos
    /// </summary>
    class DALSeguro
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        /// <summary>
        /// Se actualiza la tabla Seguro en la base de datos
        /// </summary>
        /// <param name="pSeguro"></param>
        /// Se le manda un objeto Tipo Seguro para actualizar la tabla

        public void Actualizar(Seguro pSeguro)
    {
        SqlCommand comando = new SqlCommand
        {
            CommandType = System.Data.CommandType.StoredProcedure,
            CommandText = "usp_UPDATE_Seguro"
        };

        comando.Parameters.AddWithValue("@Id", pSeguro.Id);
        comando.Parameters.AddWithValue("@Descripcion", pSeguro.Descripcion);
        comando.Parameters.AddWithValue("@Monto   ", pSeguro.Monto);

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
            CommandText = "usp_DELETE_Seguro_ByID"
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
        /// <param name="pSeguro"></param>
        /// Se envia un objeto tipo Seguro para guardarlo en la base de datos

        public void Insertar(Seguro pSeguro)
    {
        SqlCommand comando = new SqlCommand
        {
            CommandType = System.Data.CommandType.StoredProcedure,
            CommandText = "usp_INSERT_Seguro"
        };

            comando.Parameters.AddWithValue("@Descripcion", pSeguro.Descripcion);
            comando.Parameters.AddWithValue("@Monto   ", pSeguro.Monto);

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
        /// Se traer los Seguro por ID
        /// </summary>
        /// <param name="pId"></param>
        /// Se envia un id Tipo Seguro para buscar las Cobertura       
        /// <returns></returns>

        public Seguro TraerPorId(int pId)
    {
            Seguro oSeguro = null;

        SqlCommand comando = new SqlCommand
        {
            CommandType = System.Data.CommandType.StoredProcedure,
            CommandText = "usp_SELECT_Seguro_ByID"
        };
        comando.Parameters.AddWithValue("@Id", pId);


        try
        {

            using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
            {
                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {

                    oSeguro = new Seguro();

                    oSeguro.Id = (int)reader["Id"];
                    oSeguro.Descripcion = reader["Descripcion"].ToString();
                    oSeguro.Monto = float.Parse(reader["Monto"].ToString());


                }

            }

            return oSeguro;

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
        /// Se trae todo los Seguro de la tabla
        /// </summary>
        /// <returns></returns>
        public List<Seguro> TraerTodos()
    {

        List<Seguro> lista = new List<Seguro>();

        SqlCommand comando = new SqlCommand
        {
            CommandType = System.Data.CommandType.StoredProcedure,
            CommandText = "usp_SELECT_Seguro_All"
        };



        try
        {

            using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
            {
                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {

                        Seguro oSeguro = new Seguro();

                        oSeguro.Id = (int)reader["Id"];
                        oSeguro.Descripcion = reader["Descripcion"].ToString();
                        oSeguro.Monto = float.Parse(reader["Monto"].ToString());

                        lista.Add(oSeguro);


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