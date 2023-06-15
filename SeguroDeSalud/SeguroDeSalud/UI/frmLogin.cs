using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SeguroDeSalud.Interfaces;
using SeguroDeSalud.BLL;
using SeguroDeSalud.Entities;
using SeguroDeSalud.UI.Registro;
using SeguroDeSalud.UI.Menu;
using System.Data.SqlClient;

namespace SeguroDeSalud.UI.Login
{
    public partial class frmLogin : Form
    {
        static int intentosTotales = 4;
        int m, mx, my;
        public frmLogin()
        {


            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }


        private void Titulo_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;

        }

        private void Titulo_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void Titulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                frmMenu nuevo = null;

                IBLLUsuario nuevoCliente = new BLLUsuario();


                Usuario validar = nuevoCliente.TraerPorId(txtUsuario.Text);

                if (validar == null)
                {
                    MessageBox.Show("El usuario no existe, porfavor registrarse");
                    return;
                }

                else
                {
                    string contrasenna = validar.Contrasenna;

                    if (validar.Identificacion.Equals(txtUsuario.Text))
                    {
                        if (contrasenna.Equals(txtContrasenna.Text))
                        {
                            nuevo = new frmMenu(validar.Identificacion, validar.Nombre, validar.Apellido1, validar.Email,
                             validar.Foto, validar.Sexo, validar.FechaNacimiento, validar.NumeroTelefono, validar.TipoUsuario);
                            nuevo.ShowDialog();



                        }
                        else
                        {

                            intentosTotales--;
                            MessageBox.Show("Le quedan estos intentos:   " + intentosTotales + "\nSi no la acierta la contraseña la aplicacion se va a cerrar");
                        }
                    }
                }


                if (intentosTotales == 0)
                {
                    Application.Exit();

                }
            }
            catch (SqlException sqlError)
            {
                BLLLog4Net.Guardar(Utilitarios.Utilitarios.GetCustomErrorByNumber(sqlError));
                MessageBox.Show($"Ha ocurrido un error en la base de datos: {Utilitarios.Utilitarios.GetCustomErrorByNumber(sqlError)}");

            }
            catch (Exception er)
            {
                BLLLog4Net.Guardar(er.Message);
                MessageBox.Show($"Ha ocurrido un error: {er.Message}");

            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            frmRegistro nuevo = new frmRegistro();
            nuevo.ShowDialog();


        }

        private void Titulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }




    }
}
