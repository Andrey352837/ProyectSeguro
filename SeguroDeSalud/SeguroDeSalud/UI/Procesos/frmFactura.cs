
using SeguroDeSalud.BLL;
using SeguroDeSalud.DAL;
using SeguroDeSalud.Entities;
using SeguroDeSalud.Interfaces;
using SeguroDeSalud.UI.Procesos;
using SeguroDeSalud.UI.Procesos.frmFacturasClientes;
using SeguroDeSalud.UI.Procesos.frmFirmaDigital;
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

namespace SeguroDeSalud.UI.Mantenimiento.frmFactura
{
    public partial class btnAgregarCedula : Form
    {

        int validar = 1;

        float montoCobertura;
        float montoPoliza;

        Image firma;

        float MontoSeguro;
        float montoTipoPlan;
        float prima;
        float MontoAsegurado;
        OpenFileDialog nuevo = new OpenFileDialog();
        Planning pro = null;
        int m, mx, my;
        byte[] foto;
        string cedula;
        byte[] nuevaFoto = null;
        int plan;
        public btnAgregarCedula(string Identificacion, byte[] Fotografia)
        {
            cedula = Identificacion;
            foto = Fotografia;

            InitializeComponent();
        }
        public void refrescar()
        {
            BLLPlanning nuevo = new BLLPlanning();

            dgvPalanning.Rows.Clear();
            dgvPalanning.ColumnCount = 5;
            dgvPalanning.Columns[0].Name = "Id Plan";
            dgvPalanning.Columns[1].Name = "Prima";
            dgvPalanning.Columns[2].Name = "Monto asegurado del plan";
            dgvPalanning.Columns[3].Name = "Tipo de Plan";
            dgvPalanning.Columns[4].Name = "Precio Tipo plan";

            foreach (var lista in nuevo.TraerTodo())
            {
                var oTipoPlan = BLLTipoPlan.TraerPorId(lista.TipoPlan);
                object[] data = { lista.Id, lista.Prima, lista.MontoAsegurado, oTipoPlan.Descripcion, oTipoPlan.Precio };
                dgvPalanning.Rows.Add(data);
            }

        }


        private void frmRegistro_Load(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
            pckFoto.Image = byteArrayToImage(foto);
            dgvPoliza.ClearSelection();
            dgvCobertura.AutoGenerateColumns = false;
            dgvPoliza.AutoGenerateColumns = false;
            dgvSeguros.AutoGenerateColumns = false;
            dgvPalanning.ClearSelection();
            dgvCobertura.ClearSelection();
            refrescar();

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
                FacturaEncabezado nuevaFactura = new FacturaEncabezado();
                BLLFacturaEncabezado oFactura = new BLLFacturaEncabezado();

                oFactura.MontoAsegurado = MontoAsegurado;
                oFactura.montoCobertura = montoCobertura;
                oFactura.prima = prima;
                oFactura.montoPoliza = montoPoliza;
                oFactura.MontoSeguro = MontoSeguro;

                nuevaFactura.Cedula = nuevaFoto;
                nuevaFactura.Cliente = cedula;
                nuevaFactura.FechaFactura = DateTime.Now;

                ImageConverter _imageConverter = new ImageConverter();

                byte[] multimedia = (byte[])_imageConverter.ConvertTo(firma, typeof(byte[]));

                nuevaFactura.FirmaDigital = multimedia;
                nuevaFactura.MontoBruto = oFactura.SumaTotalBruto();
                nuevaFactura.MontoBrutoDolares = oFactura.CovertidorDolaresBruto();

                nuevaFactura.MontoFinal = oFactura.SumaTotalFinal();
                nuevaFactura.MontoFinalDolares = oFactura.CovertidorDolaresFinal();
                nuevaFactura.planning = plan;

                nuevaFactura.QR = Utilitarios.Utilitarios.CodigoQR(BLLFacturaEncabezado.SiguienteCodigoFactura());
                nuevaFactura.TarjetaCredito = txtNumeroTarjeta.Text;

                oFactura.GuardarFactura(nuevaFactura);

                nuevaFactura.QR = Utilitarios.Utilitarios.CodigoQR(BLLFacturaEncabezado.UltimaFactura(cedula));
               
                nuevaFactura.Id = BLLFacturaEncabezado.UltimaFactura(cedula);
                BLLFacturaEncabezado.ActualizarFactura(nuevaFactura);


                frmReporteFactura nuevoReporte = new frmReporteFactura(BLLFacturaEncabezado.UltimaFactura(cedula),cedula);
                nuevoReporte.Show();
                





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
            

        }

        private void dgvCliente_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void dgvSeguros_SelectionChanged(object sender, EventArgs e)
        {
            BLLPlanning nuevo = new BLLPlanning();
            try
            {
                // Validar si hay un fila selecionada
                if (dgvPalanning.SelectedRows.Count > 0)
                {

                    // DataBoundItem retorna el objeto seleccionado en el grid
                    plan += int.Parse(dgvPalanning.SelectedCells[0].Value.ToString());
                    prima += float.Parse(dgvPalanning.SelectedCells[1].Value.ToString());
                    MontoAsegurado += float.Parse(dgvPalanning.SelectedCells[2].Value.ToString());
                    montoTipoPlan += float.Parse(dgvPalanning.SelectedCells[4].Value.ToString());

                    dgvCobertura.DataSource = nuevo.TraerCoberturas(int.Parse(dgvPalanning.SelectedCells[0].Value.ToString()));
                    dgvPoliza.DataSource = nuevo.TraerPoliza(int.Parse(dgvPalanning.SelectedCells[0].Value.ToString()));
                    dgvSeguros.DataSource = nuevo.TraerSeguros(int.Parse(dgvPalanning.SelectedCells[0].Value.ToString()));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSeguros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCobertura_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Validar si hay un fila selecionada
                if (dgvCobertura.SelectedRows.Count > 0)
                {
                    // DataBoundItem retorna el objeto seleccionado en el grid
                    Cobertura nuevaCobertura = (Cobertura)dgvCobertura.SelectedRows[0].DataBoundItem;

                    montoCobertura += nuevaCobertura.MontoMaximo;

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPoliza_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                // Validar si hay un fila selecionada
                if (dgvPoliza.SelectedRows.Count > 0)
                {
                    // DataBoundItem retorna el objeto seleccionado en el grid
                    Poliza nuevaPoliza = (Poliza)dgvPoliza.SelectedRows[0].DataBoundItem;

                    montoPoliza += nuevaPoliza.Monto;

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSeguros_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFirmaDigital_Click(object sender, EventArgs e)
        {
            

            frmFirmaDigital nuevaFirma = new frmFirmaDigital();
            nuevaFirma.ShowDialog();

            firma = nuevaFirma.firma;
            pckFirmaDigital.Image = firma;
           
            Console.WriteLine(firma);

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BLLTarjetaCredito nuevaTarjeta = new BLLTarjetaCredito();
            try
            {
                if (BLLFacturaEncabezado.ValidarNumeroTarjeta(txtNumeroTarjeta.Text))
                {
                    string[] numero = txtNumeroVencimiento.Text.Split('/');
                    if (int.Parse(numero[1]) > DateTime.Now.Year)
                    {
                        btnAceptar.Enabled = true;
                        MessageBox.Show("La tarjeta es valida");
                        if (nuevaTarjeta.TraerPorId(txtNumeroTarjeta.Text) == null)
                        {
                            TarjetaCredito nueva = new TarjetaCredito();
                            if (rbCredito.Checked)
                            {
                                nueva.Descripcion = "Credito";
                            }
                            else
                            {
                                nueva.Descripcion = "Debito";
                            }
                            nueva.Numero = txtNumeroTarjeta.Text;

                            nuevaTarjeta.Guardar(nueva);
                        }
                        else
                        {
                            TarjetaCredito nueva = nuevaTarjeta.TraerPorId(txtNumeroTarjeta.Text);

                            txtNumeroTarjeta.Text = nueva.Numero;
                            if (nueva.Descripcion.Equals("Credito"))
                            {
                                rbCredito.Checked = true;

                            }
                            else
                            {
                                radioButton2.Checked = true;

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La tarjeta esta caducada");

                    }
                }

                else
                {
                    MessageBox.Show("Coloque una tarjeta valida");
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult rs = nuevo.ShowDialog();

            if (rs == DialogResult.OK)
            {


                nuevaFoto = File.ReadAllBytes(nuevo.FileName);
                pckFoto.Image = (Image)byteArrayToImage(nuevaFoto);

            }

        }

        private void dgvSeguros_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                // Validar si hay un fila selecionada
                if (dgvPoliza.SelectedRows.Count > 0)
                {
                    // DataBoundItem retorna el objeto seleccionado en el grid
                    Seguro nuevoSeguro = (Seguro)dgvPoliza.SelectedRows[0].DataBoundItem;

                    MontoSeguro += nuevoSeguro.Monto;

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            frmFacturasClientes nueva = new frmFacturasClientes(cedula);
            nueva.Show();

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

