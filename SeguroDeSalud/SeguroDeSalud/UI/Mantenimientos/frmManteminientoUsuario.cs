
using SeguroDeSalud.BLL;
using SeguroDeSalud.Entities;
using SeguroDeSalud.Interfaces;

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

namespace SeguroDeSalud.UI.Mantenimiento
{
    public partial class frmManteminientoUsuario : Form
    {
       

        OpenFileDialog nuevo = new OpenFileDialog();
        Usuario pro = null;
        int m, mx, my;
        Boolean validar = false;
        byte[] nuevaFoto = null;
        public frmManteminientoUsuario()
        {

            InitializeComponent();
        }
        public void refrescar()
        {
            IBLLUsuario nuevo = new BLLUsuario();
            dgvCliente.DataSource = nuevo.TraerTodo();
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            IBLLRecidencia nuevaRecidecia = new BLLRecidencia();

            dgvCliente.AutoGenerateColumns = false;
            CargaRecidencia();
            CargarTipoUsuario();
            refrescar();

        }
        private void CargaRecidencia()
        {
            IBLLRecidencia nuevaRecidecia = new BLLRecidencia();
            cmbPaisResidencia.DataSource = nuevaRecidecia.TraerTodo();
            cmbPaisResidencia.DisplayMember = "Descripcion";
            cmbPaisResidencia.ValueMember = "Id";
            
        }
            private void CargarTipoUsuario()
        {
            IBLLTipoUsuario nuevaTipoUsuario = new BLLTipoUsuario();
            cmbTipoUsuario.DataSource = nuevaTipoUsuario.TaerTodo();
            cmbTipoUsuario.DisplayMember = "Descripcion";
            cmbTipoUsuario.ValueMember = "Id";
          
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
                    oUsuario.TipoUsuario = (int)cmbTipoUsuario.SelectedValue;
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

                    if (validar == false)
                    {
                        oUsuario.Foto = pro.Foto;

                    }
                    else
                    {
                        oUsuario.Foto = nuevaFoto;
                    }
                    oUsuario.Email = txtCorreo.Text;
                    oUsuario.Contrasenna = txtContrasenna.Text;
                    oUsuario.NumeroTelefono = mtbtxtTelefono.Text;
                    oUsuario.Direccion = TxtDireccion.Text;
                    oUsuario.Recidencia = (int)cmbPaisResidencia.SelectedValue;
                    ;

                    nuevo.Guardar(oUsuario);
                    refrescar();
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
                    pictureBox1.Image.Dispose();

                    nuevaFoto = File.ReadAllBytes(nuevo.FileName);
                    pictureBox1.Image = (Image)byteArrayToImage(nuevaFoto);
                    validar = true;
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = MessageBox.Show("¿Esta seguro?", "Pregunta",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    IBLLUsuario nuevo = new BLLUsuario();

                    string id = mktxtCedula.Text;

                    nuevo.Eliminar(id);

                    MessageBox.Show("Usuario eliminado con éxito");
                    refrescar();
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

        private void dgvCliente_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Validar si hay un fila selecionada
                if (dgvCliente.SelectedRows.Count > 0)
                {
                    // DataBoundItem retorna el objeto seleccionado en el grid
                    pro = (Usuario)dgvCliente.SelectedRows[0].DataBoundItem;
                    mktxtCedula.Enabled = false;
                    mktxtCedula.Text = pro.Identificacion;
                    txtNombre.Text = pro.Nombre;
                    txtApellidos.Text = pro.Apellido1 +" "+pro.Apellido2;
                    mtbtxtTelefono.Text = pro.NumeroTelefono;
                    txtCorreo.Text = pro.Email;
                    dpFechaNacimiento.Value = pro.FechaNacimiento;
                    pictureBox1.Image = byteArrayToImage(pro.Foto);
                    txtNacionalidad.Text = pro.Nacionalidad;
                    TxtDireccion.Text = pro.Direccion;
                    cmbPaisResidencia.SelectedIndex = pro.Recidencia - 1;
                    cmbTipoUsuario.SelectedIndex = pro.TipoUsuario - 1;

                    if (pro.Sexo == 'M')
                    {
                        rbtnMasculino.Checked = true;
                    }
                    else if (pro.Sexo == 'F')
                    {
                        rbtnFemenino.Checked = true;
                    }

                    txtContrasenna.Text = pro.Contrasenna; ;

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

