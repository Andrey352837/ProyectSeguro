using SeguroDeSalud.Entities;
using SeguroDeSalud.Utilitarios;
using SeguroDeSalud.Interfaces;
using SeguroDeSalud.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using SeguroDeSalud.BLL;

namespace SeguroDeSalud.DAL
{
    /// <summary>
    ///La Clase DALUsuario sirve para la insertacion, actualizacion, eliminacion,
    ///extraccion por Id y la extraccion de todos los datos de una tabla en especifica
    ///de la base de datos
    /// </summary>

    class DALUsuario : IDALUsuario
    {
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        /// <summary>
        /// Se actualiza la tabla Usuario en la base de datos
        /// </summary>
        /// <param name="pUsuario"></param>
        /// Se le manda un objeto Tipo Usuario para actualizar la tabla

        public void Actualizar(Usuario pUsuario)
        {
            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_UPDATE_Usuario"
            };

            comando.Parameters.AddWithValue("@Identificacion", pUsuario.Identificacion);
            comando.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            comando.Parameters.AddWithValue("@Apellido1", pUsuario.Apellido1);
            comando.Parameters.AddWithValue("@Apellido2", pUsuario.Apellido2);
            comando.Parameters.AddWithValue("@Nacionalidad", pUsuario.Nacionalidad);

            comando.Parameters.AddWithValue("@Email", pUsuario.Email);
            comando.Parameters.AddWithValue("@Foto", pUsuario.Foto);
            comando.Parameters.AddWithValue("@Sexo", pUsuario.Sexo);
            comando.Parameters.AddWithValue("@Direccion", pUsuario.Direccion);

            comando.Parameters.AddWithValue("@Recidencia", pUsuario.Recidencia);

            comando.Parameters.AddWithValue("@FechaNacimiento", pUsuario.FechaNacimiento);
            comando.Parameters.AddWithValue("@NumeroTelefono", pUsuario.NumeroTelefono);
            comando.Parameters.AddWithValue("@TipoUsuario", pUsuario.TipoUsuario);
            comando.Parameters.AddWithValue("@Contrasenna", Encriptacion.EncriptarContrasenna(pUsuario.Contrasenna));


            try {
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


        public void Eliminar(string pId)
        {

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_DELETE_Usuario_ByID"
            };
            comando.Parameters.AddWithValue("@Identificacion", pId);

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
        /// <param name="pUsuario"></param>
        /// Se envia un objeto tipo Usuario para guardarlo en la base de datos

        public void Insertar(Usuario pUsuario)
        {
            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_INSERT_Usuario"
            };

            comando.Parameters.AddWithValue("@Identificacion", pUsuario.Identificacion);
            comando.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            comando.Parameters.AddWithValue("@Apellido1", pUsuario.Apellido1);
            comando.Parameters.AddWithValue("@Apellido2", pUsuario.Apellido2);
            comando.Parameters.AddWithValue("@Nacionalidad", pUsuario.Nacionalidad);

            comando.Parameters.AddWithValue("@Email", pUsuario.Email);
            comando.Parameters.AddWithValue("@Foto", pUsuario.Foto);
            comando.Parameters.AddWithValue("@Sexo", pUsuario.Sexo);
            comando.Parameters.AddWithValue("@Direccion", pUsuario.Direccion);
            comando.Parameters.AddWithValue("@Recidencia", pUsuario.Recidencia);
            comando.Parameters.AddWithValue("@FechaNacimiento", pUsuario.FechaNacimiento);
            comando.Parameters.AddWithValue("@NumeroTelefono", pUsuario.NumeroTelefono);
            comando.Parameters.AddWithValue("@TipoUsuario", pUsuario.TipoUsuario);
            comando.Parameters.AddWithValue("@Contrasenna", Encriptacion.EncriptarContrasenna(pUsuario.Contrasenna));


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
        /// Se traer los Usuario por ID
        /// </summary>
        /// <param name="pId"></param>
        /// Se envia un id Tipo Usuario para buscar las Cobertura       
        /// <returns></returns>
        public Usuario TraerPorId(string pId)
        {
            Usuario usuario = null;

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_SELECT_Usuario_ByID"
            };
            comando.Parameters.AddWithValue("@Identificacion", pId);


            try
            {

                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    IDataReader reader = db.ExecuteReader(comando);

                    while (reader.Read())
                    {

                        usuario = new Usuario();

                        usuario.Identificacion = reader["Identificacion"].ToString();  
                        usuario.Nombre = reader["Nombre"].ToString();
                        usuario.Apellido1 = reader["Apellido1"].ToString();
                        usuario.Apellido2 = reader["Apellido2"].ToString();
                        usuario.Foto = (byte[])reader["Foto"];
                        usuario.TipoUsuario = int.Parse(reader["TipoUsuario"].ToString());
                       
                        usuario.Nacionalidad = reader["Nacionalidad"].ToString();
                        usuario.Sexo = char.Parse(reader["Sexo"].ToString());
                        usuario.FechaNacimiento = (DateTime)reader["FechaNacimiento"];

                        usuario.NumeroTelefono = reader["NumeroTelefono"].ToString();
                        usuario.Direccion =  reader["Direccion"].ToString();
                        usuario.Recidencia = (int)reader["Recidencia"];
                        usuario.Email = reader["Email"].ToString();
                        usuario.Contrasenna = Encriptacion.DesencriptarContrasenna((byte[])reader["Contrasenna"]);





                    }

                }

                return usuario;

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
        /// Se trae todo los Usuario de la tabla
        /// </summary>
        /// <returns></returns>
        public List<Usuario> TraerTodos()
        {

            List<Usuario> lista = new List<Usuario>();

            SqlCommand comando = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "usp_SELECT_Usuario_All"
            };
        


            try
            {

                using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
                {
                    IDataReader reader = db.ExecuteReader(comando);

                    while (reader.Read())
                    {

                       Usuario usuario = new Usuario();

                        usuario.Identificacion = reader["Identificacion"].ToString();
                        usuario.Nombre = reader["Nombre"].ToString();
                        usuario.Apellido1 = reader["Apellido1"].ToString();
                        usuario.Apellido2 = reader["Apellido2"].ToString();
                        usuario.Foto = (byte[])reader["Foto"];
                        usuario.TipoUsuario = int.Parse(reader["TipoUsuario"].ToString());
                        byte[] con = (byte[])reader["Contrasenna"];
                        usuario.Contrasenna = Encriptacion.DesencriptarContrasenna(con);
                        usuario.Nacionalidad = reader["Nacionalidad"].ToString();
                        usuario.Sexo = char.Parse(reader["Sexo"].ToString());
                        usuario.FechaNacimiento = (DateTime)reader["FechaNacimiento"];

                        usuario.NumeroTelefono = reader["NumeroTelefono"].ToString();
                        usuario.Direccion = reader["Direccion"].ToString();
                        usuario.Recidencia = (int)reader["Recidencia"];
                        usuario.Email = reader["Email"].ToString();                        
                        lista.Add(usuario);



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
