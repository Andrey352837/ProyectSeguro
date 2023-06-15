
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
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeguroDeSalud.UI.Procesos.frmFirmaDigital
{
    public partial class frmFirmaDigital : Form
    {

        float PointX= 0;
        float PointY= 0;

        float LastX= 0;
        float LastY = 0;


        int m, mx, my;

        public Image firma { get; }


        public frmFirmaDigital()
        {

            InitializeComponent();

            firma = new Bitmap(panel.Width, panel.Height);
        }
        
       
        private void frmRegistro_Load(object sender, EventArgs e)
        {

          

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
            try { 
            var gg = Graphics.FromImage(firma);
            var rect = panel.RectangleToScreen(panel.ClientRectangle);
            gg.CopyFromScreen(rect.Location, Point.Empty, panel.Size);
                MessageBox.Show("Frima Guardada");
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
            MessageBox.Show("Ya guardo la Firma?");
            this.Close();
        }



        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Graphics g = panel.CreateGraphics();
                g.Clear(Color.White);
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
            
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = panel.CreateGraphics();
            G.DrawLine(Pens.Black, PointX, PointY, LastX, LastY);
            LastX = PointX;
            LastY = PointY;

        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            LastX = e.X;
            LastY = e.Y;
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PointX = e.X;
                PointY = e.Y;
                panel_Paint(this, null);

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

