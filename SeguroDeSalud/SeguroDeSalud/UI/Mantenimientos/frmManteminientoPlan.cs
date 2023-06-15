
using SeguroDeSalud.BLL;
using SeguroDeSalud.DAL;
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

namespace SeguroDeSalud.UI.Mantenimiento.frmManteminientoPlan
{
    public partial class frmManteminientoPlan : Form
    {

        int validar = 1;

        Planning pro = null;
        int m, mx, my;


        public frmManteminientoPlan()
        {

            InitializeComponent();
        }
        public void refrescar()
        {
            IBLLPlanning nuevo = new BLLPlanning();
            dgvCliente.DataSource= nuevo.TraerTodo();
        }
        public void cargartipoplan()
        {

            cmbTipoPlan.DataSource = BLLTipoPlan.TraerTodo();
            cmbTipoPlan.ValueMember = "Id";
            cmbTipoPlan.DisplayMember = "Descripcion";

        }
        private void frmRegistro_Load(object sender, EventArgs e)
        {

            cargartipoplan();
            refrescar();
            txtCodigoPlan.Enabled = false;

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

                Planning nuevo = new Planning();
                if (txtCodigoPlan.Text == "")
                {
                    nuevo.Id = 0;
                }
                else
                {
                    nuevo.Id = int.Parse(txtCodigoPlan.Text);

                }
                nuevo.MontoAsegurado = float.Parse(txtMontoAsegurado.Text);
                nuevo.Prima = float.Parse(txtPrima.Text);
                nuevo.TipoPlan = (int)cmbTipoPlan.SelectedValue;

                IBLLPlanning nuevoPlan = new BLLPlanning();
                nuevoPlan.Guardar(nuevo);
                refrescar();
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
                    IBLLPlanning nuevo = new BLLPlanning();

                    int id = int.Parse(txtCodigoPlan.Text.ToString());

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
          
        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCliente_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                // Validar si hay un fila selecionada
                if (dgvCliente.SelectedRows.Count > 0)
                {
                    // DataBoundItem retorna el objeto seleccionado en el grid
                    pro = (Planning)dgvCliente.SelectedRows[0].DataBoundItem;

                    txtCodigoPlan.Text = pro.Id.ToString();
                    txtMontoAsegurado.Text = pro.MontoAsegurado.ToString();
                    txtPrima.Text = pro.Prima.ToString();
                    cmbTipoPlan.SelectedIndex = pro.TipoPlan - 1;
                    validar = 0;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

