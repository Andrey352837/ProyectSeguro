
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

namespace SeguroDeSalud.UI.Mantenimiento.frmManteminientoSeguro
{
    public partial class frmManteminientoSeguro : Form
    {

        int validar = 1;

        Seguro pro = null;
        int m, mx, my;


        public frmManteminientoSeguro()
        {

            InitializeComponent();
        }
        public void refrescar()
        {
            BLLSeguro nuevo = new BLLSeguro();
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
            cmbPlan.Enabled = false;
            btnSeguros.Enabled = false;
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

                Seguro nuevo = new Seguro();
                if (txtCobertura.Text == "")
                {
                    nuevo.Id = 0;
                }
                else
                {
                    nuevo.Id = int.Parse(txtCobertura.Text);

                }
                nuevo.Monto = float.Parse(txtMontoMaximo.Text);

                nuevo.Descripcion = txtDescripcion.Text;

               
                BLLSeguro nuevoPlan = new BLLSeguro();
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
                    BLLSeguro nuevo = new BLLSeguro();

                    int id = int.Parse(txtCobertura.Text.ToString());
                    BLLPlanesSeguro.EliminarSegurosPlanes(id);
                    nuevo.Eliminar(id);

                    MessageBox.Show("El seguro eliminado con éxito");
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
                    pro = (Seguro)dgvCliente.SelectedRows[0].DataBoundItem;

                    txtCobertura.Text = pro.Id.ToString();
                    txtMontoMaximo.Text = pro.Monto.ToString();
                    txtDescripcion.Text = pro.Descripcion.ToString();
                    cmbPlan.Enabled = true;
                    btnSeguros.Enabled = true;
                    
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                BLLPlanesSeguro nuevo = new BLLPlanesSeguro();
                PlanSeguros nuevoPlan = new PlanSeguros();
                nuevoPlan.Planning = (int)cmbPlan.SelectedValue;
                nuevoPlan.Seguro = int.Parse(txtCobertura.Text);
                nuevo.Guardar(nuevoPlan);
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

