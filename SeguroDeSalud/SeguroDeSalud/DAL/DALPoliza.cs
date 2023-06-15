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
    ///La Clase DALPoliza sirve para la insertacion, actualizacion, eliminacion,
    ///extraccion por Id y la extraccion de todos los datos de una tabla en especifica
    ///de la base de datos
    /// </summary>
    class DALPoliza
    { 
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        /// <summary>
        /// Se actualiza la tabla Poliza en la base de datos
        /// </summary>
        /// <param name="pPoliza"></param>
        /// Se le manda un objeto Tipo Poliza para actualizar la tabla


        public void Actualizar(Poliza pPoliza)
    {

        SqlCommand comando = new SqlCommand
        {
            CommandType = System.Data.CommandType.StoredProcedure,
            CommandText = "usp_UPDATE_Poliza"
        };

        comando.Parameters.AddWithValue("@Id", pPoliza.Id);
        comando.Parameters.AddWithValue("@Descripcion", pPoliza.Descripcion);
        comando.Parameters.AddWithValue("@Monto", pPoliza.Monto);
        comando.Parameters.AddWithValue("@Planes", pPoliza.Planes);


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
            CommandText = "usp_DELETE_Poliza_ByID"
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
        /// <param name="pPoliza"></param>
        /// Se envia un objeto tipo Poliza para guardarlo en la base de datos

        public void Insertar(Poliza pPoliza)
    {
        SqlCommand comando = new SqlCommand
        {
            CommandType = System.Data.CommandType.StoredProcedure,
            CommandText = "usp_INSERT_Poliza"
        };

          
            comando.Parameters.AddWithValue("@Descripcion", pPoliza.Descripcion);
            comando.Parameters.AddWithValue("@Monto", pPoliza.Monto);
            comando.Parameters.AddWithValue("@Planes", pPoliza.Planes);


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
        /// Se traer los Poliza por ID
        /// </summary>
        /// <param name="pId"></param>
        /// Se envia un id Tipo Poliza para buscar las Cobertura       
        /// <returns></returns>
        public Poliza TraerPorId(int pId)
    {
            Poliza oPoliza = null;

        SqlCommand comando = new SqlCommand
        {
            CommandType = System.Data.CommandType.StoredProcedure,
            CommandText = "usp_SELECT_Poliza_ByID"
        };
        comando.Parameters.AddWithValue("@Id", pId);


        try
        {

            using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
            {
                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {

                    oPoliza = new Poliza();

                    oPoliza.Id = (int)reader["Id"];
                    oPoliza.Descripcion = reader["Descripcion"].ToString();
                    oPoliza.Monto = float.Parse(reader["Monto"].ToString());
                    oPoliza.Planes = (int)reader["Planes"];






                }

            }

            return oPoliza;

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
        /// Se trae todo los Poliza de la tabla
        /// </summary>
        /// <returns></returns>

        public List<Poliza> TraerTodos()
    {

        List<Poliza> lista = new List<Poliza>();

        SqlCommand comando = new SqlCommand
        {
            CommandType = System.Data.CommandType.StoredProcedure,
            CommandText = "usp_SELECT_Poliza_All"
        };



        try
        {

            using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
            {
                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {

                        Poliza oPoliza = new Poliza();

                        oPoliza.Id = (int)reader["Id"];
                        oPoliza.Descripcion = reader["Descripcion"].ToString();
                        oPoliza.Monto = float.Parse(reader["Monto"].ToString());
                        oPoliza.Planes = (int)reader["Planes"];
                        lista.Add(oPoliza);
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