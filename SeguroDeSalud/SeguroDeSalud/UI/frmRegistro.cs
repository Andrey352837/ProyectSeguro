
using SeguroDeSalud.BLL;
using SeguroDeSalud.Entities;
using SeguroDeSalud.Interfaces;
using SeguroDeSalud.UI.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeguroDeSalud.UI.Registro
{
    public partial class frmRegistro : Form
    {
        frmLogin nuevoFrame = new frmLogin();

        OpenFileDialog nuevo = new OpenFileDialog();

        int m, mx, my;
        byte[] nuevaFoto = null;
        public frmRegistro()
        {

            InitializeComponent();
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            IBLLRecidencia nuevaRecidecia = new BLLRecidencia();
            cmbPaisResidencia.DataSource = nuevaRecidecia.TraerTodo();
            cmbPaisResidencia.DisplayMember = "descripcion";
            cmbPaisResidencia.ValueMember = "Id";

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContrasenna.Text.Equals(txtContrasennaSegunda.Text))
                {
                    IBLLUsuario nuevo = new BLLUsuario();

                    Usuario oUsuario = new Usuario();

                    oUsuario.Identificacion = mktxtCedula.Text;
                    oUsuario.Nombre = txtNombre.Text;
                    string[] Apellidos = txtApellidos.Text.Split(' ');
                    oUsuario.Apellido1 = Apellidos[0];
                    oUsuario.Apellido2 = Apellidos[1];
                    oUsuario.TipoUsuario = 2;
                    oUsuario.Nacionalidad = txtNacionalidad.Text;
                    if (rbtnFemenino.Checked)
                    {
                        oUsuario.Sexo = 'F';
                    }
                    else
                    {
                        oUsuario.Sexo = 'M';
                    }
                    oUsuario.FechaNacimiento = dpFechaNacimiento.Value;
                    oUsuario.Foto = nuevaFoto;
                    oUsuario.Email = txtCorreo.Text;
                    oUsuario.Contrasenna = txtContrasenna.Text;
                    oUsuario.NumeroTelefono = mtbtxtTelefono.Text;
                    oUsuario.Direccion = TxtDireccion.Text;
                    oUsuario.Recidencia = (int)cmbPaisResidencia.SelectedValue;
                    ;

                    nuevo.guardarUsuario(oUsuario);

                }
                else
                {
                    MessageBox.Show("La segunda contraseña no calza con la  primera");
                    return;
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


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void rbtnFemenino_CheckedChanged(object sender, EventArgs e)
        {

        }

        public Image byteArrayToImage(byte[] nuevaFoto)
        {


            MemoryStream ms = new MemoryStream(nuevaFoto, 0, nuevaFoto.Length);
            ms.Write(nuevaFoto, 0, nuevaFoto.Length);
            Image image = Image.FromStream(ms, true);
            return image;//Exception occurs here



        }



     

        private void Titulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Titulo_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarFoto_Click(object sender, EventArgs e)
        {
            DialogResult rs = nuevo.ShowDialog();
            try
            {

                if (rs == DialogResult.OK)
                {


                    nuevaFoto = File.ReadAllBytes(nuevo.FileName);
                    pictureBox1.Image = (Image)byteArrayToImage(nuevaFoto);

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

        private void Titulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }

        }

        private void Titulo_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
    }
}

