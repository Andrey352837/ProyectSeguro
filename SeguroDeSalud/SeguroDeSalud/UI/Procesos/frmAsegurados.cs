
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

namespace SeguroDeSalud.UI.Procesos.frmManteminientoPlan
{
    public partial class frmAsegurados : Form
    {

        int validar = 1;

        Usuario pro = null;

        Asegurados pro1 = null;
        int m, mx, my;
        int numeroPlanning;
        int numeroFactura;

        int numeroPlanningSelect;
       
        string numeroCedula;


       

        public frmAsegurados(int NumeroFactura, int NumeroPlanning)
        {
            numeroFactura = NumeroFactura;
            numeroPlanning = NumeroPlanning;


            InitializeComponent();
        }
       
       
        private void frmRegistro_Load(object sender, EventArgs e)
        {
            dgvAsegurados.AutoGenerateColumns = false;
            dgvCliente.AutoGenerateColumns = false;
            cargarPersonas();
            refrescarFacturasClientes();


        }
        public void cargarPersonas()
        {
            IBLLUsuario nuevoUsuario = new BLLUsuario();
            dgvCliente.DataSource = nuevoUsuario.TraerTodo();

        }
        public void refrescarFacturasClientes()
        {
            BLLAsegurados nuevo = new BLLAsegurados();
            IBLLUsuario nuevoUsuario = new BLLUsuario();
            dgvAsegurados.Rows.Clear();
            dgvAsegurados.ColumnCount = 8;
            dgvAsegurados.Columns[0].Name = "Id Factura";
            dgvAsegurados.Columns[1].Name = "Id Plan";
            dgvAsegurados.Columns[2].Name = "Cedula";
            dgvAsegurados.Columns[3].Name = "Primer Apellido";
            dgvAsegurados.Columns[4].Name = "Segundo Apellido";
            dgvAsegurados.Columns[5].Name = "Nombre";
            dgvAsegurados.Columns[6].Name = "Telefono";
            dgvAsegurados.Columns[7].Name = "Correo Electronico";


            foreach (var lista in BLLAsegurados.todoAsegurados(numeroFactura, numeroPlanning))
            {
                var oAsegurado = nuevoUsuario.TraerPorId(lista.Usuario);
                object[] data = {lista.FacturaEncabezado, lista.Planning, lista.Usuario, oAsegurado.Apellido1,
                    oAsegurado.Apellido2, oAsegurado.Nombre, oAsegurado.NumeroTelefono, oAsegurado.Email};
                dgvAsegurados.Rows.Add(data);
            }

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
                Asegurados nuevoAsegurado = new Asegurados();
                BLLAsegurados nuevo = new BLLAsegurados();
                nuevoAsegurado.Planning = numeroPlanning;
                nuevoAsegurado.FacturaEncabezado = numeroFactura;
                nuevoAsegurado.Usuario = pro.Identificacion;

                nuevo.Guardar(nuevoAsegurado);

                refrescarFacturasClientes();
                
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = MessageBox.Show("¿Esta seguro?", "Pregunta",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    BLLAsegurados nuevo = new BLLAsegurados();

                   

                    nuevo.Eliminar(numeroCedula, numeroPlanningSelect);


                    MessageBox.Show("Asegurado eliminado con exito de la factura");
                    
                    refrescarFacturasClientes();
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

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCliente_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                
                if (dgvCliente.SelectedRows.Count > 0)
               {
                  
                   pro = (Usuario)dgvCliente.SelectedRows[0].DataBoundItem;

                   
               
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAsegurados_SelectionChanged(object sender, EventArgs e)
        {
            BLLPlanning nuevo = new BLLPlanning();
            try
            {
                // Validar si hay un fila selecionada
                if (dgvAsegurados.SelectedRows.Count > 0)
                {

                    // DataBoundItem retorna el objeto seleccionado en el grid
                    numeroPlanningSelect = int.Parse(dgvAsegurados.SelectedCells[1].Value.ToString());
                    numeroCedula = dgvAsegurados.SelectedCells[2].Value.ToString();


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

