
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

namespace SeguroDeSalud.UI.Mantenimiento.frmManteminientoCobertura
{
    public partial class frmManteminientoCobertura : Form
    {

        int validar = 1;

        Cobertura pro = null;
        int m, mx, my;


        public frmManteminientoCobertura()
        {

            InitializeComponent();
        }
        public void refrescar()
        {
            BLLCobertura nuevo = new BLLCobertura();
            dgvCliente.DataSource= nuevo.TraerTodo();
        }
        public void cargartipoplan()
        {
            BLLPlanning nuevo = new BLLPlanning();
            cmbPlan.DataSource = nuevo.TraerTodo();
            cmbPlan.ValueMember = "Id";
            cmbPlan.DisplayMember = "Descripcion";

        }
        private void frmRegistro_Load(object sender, EventArgs e)
        {

            cargartipoplan();
            refrescar();
            txtCobertura.Enabled = false;

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

                Cobertura nuevo = new Cobertura();
                if (txtCobertura.Text == "")
                {
                    nuevo.Id = 0;
                }
                else
                {
                    nuevo.Id = int.Parse(txtCobertura.Text);

                }
                nuevo.MontoMaximo = float.Parse(txtMontoMaximo.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Planning = (int)cmbPlan.SelectedValue;

                BLLCobertura nuevoPlan = new BLLCobertura();
                nuevoPlan.Guardar(nuevo);
                refrescar();
            }


            catch (SqlException sqlError)
            {
                MessageBox.Show($"Ha ocurrido un error en la base de datos: {Utilitarios.Utilitarios.GetCustomErrorByNumber(sqlError)}");
                BLLLog4Net.Guardar(Utilitarios.Utilitarios.GetCustomErrorByNumber(sqlError));
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ha ocurrido un error: {er.Message}");
                BLLLog4Net.Guardar(er.Message);
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
                    BLLCobertura nuevo = new BLLCobertura();

                    int id = int.Parse(txtCobertura.Text.ToString());

                    nuevo.Eliminar(id);

                    MessageBox.Show("La cobertura eliminado con éxito");
                    refrescar();
                }
            }
            catch (SqlException sqlError)
            {
                MessageBox.Show($"Ha ocurrido un error en la base de datos: {Utilitarios.Utilitarios.GetCustomErrorByNumber(sqlError)}");
                BLLLog4Net.Guardar(Utilitarios.Utilitarios.GetCustomErrorByNumber(sqlError));
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ha ocurrido un error: {er.Message}");
                BLLLog4Net.Guardar(er.Message);
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
                    pro = (Cobertura)dgvCliente.SelectedRows[0].DataBoundItem;

                    txtCobertura.Text = pro.Id.ToString();
                    txtMontoMaximo.Text = pro.MontoMaximo.ToString();
                    txtDescripcion.Text = pro.Descripcion.ToString();                   
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

