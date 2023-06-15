using SeguroDeSalud.DAL;
using SeguroDeSalud.Entities;
using SeguroDeSalud.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.BLL
{
    /// <summary>
    /// Clase donde se trabaja la logica el Usuario
    /// </summary>
    class BLLUsuario : IBLLUsuario
    {

        //Log4net
        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

      
        private IDALUsuario oUsuarioDAL = new DALUsuario();
        /// <summary>
        /// Metodo para guardar solamente los Usuarios en el de registrar
        /// </summary>
        /// <param name="pUsuario"></param>
        /// Objeto que se va a guardar en la base de datos
        public void guardarUsuario(Usuario pUsuario)
        {
            try
            {
              
                    oUsuarioDAL.Insertar(pUsuario);
              


            }
            catch (SqlException sqlError)
            {
                throw sqlError;
            }
            catch (Exception er)
            {
                throw er;
            }

        }
        /// <summary>
        /// Metodo el cual guarda el usuario o lo modifica
        /// </summary>
        /// <param name="pUsuario"></param>
        /// Se trae un objeto Usuario para guardarlo en DAL 

        public void Guardar(Usuario pUsuario)
        {

            try
            {
                if (TraerPorId(pUsuario.Identificacion) == null)
                {
                    oUsuarioDAL.Insertar(pUsuario);
                }
                else
                {
                    oUsuarioDAL.Actualizar(pUsuario);
                }
              

            }
            catch (SqlException sqlError)
            {
                throw sqlError;
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        /// <summary>
        /// Metodo para eliminar un usuario
        /// </summary>
        /// <param name="Id"></param>
        /// El numero de cedula para eliminar un usuario
        public void Eliminar(string Id)
        {

            try
            {
               
                    oUsuarioDAL.Eliminar(Id);
                
            }
            catch (SqlException sqlError)
            {
                throw sqlError;
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        /// <summary>
        /// Se trae un usuario por su cedula 
        /// </summary>
        /// <param name="Id"></param>
        /// Se envia un numero de cedula par que los busque en la base de datos
        /// <returns></returns>
        public Usuario TraerPorId(string Id)
        {
            try
            {

                return oUsuarioDAL.TraerPorId(Id);

            }
            catch (SqlException sqlError)
            {
                throw sqlError;
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        /// <summary>
        /// Se trae todos los Usuarios que hay en la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Usuario> TraerTodo()
        {
            try
            {

                return oUsuarioDAL.TraerTodos(); 

            }
            catch (SqlException sqlError)
            {
                throw sqlError;
            }
            catch (Exception er)
            {
                throw er;
            }
        }


    }
}
