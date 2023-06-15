using SeguroDeSalud.Entities;
using SeguroDeSalud.UI;
using SeguroDeSalud.UI.Mantenimiento;
using SeguroDeSalud.UI.Mantenimiento.frmFactura;
using SeguroDeSalud.UI.Mantenimiento.frmManteminientoCobertura;
using SeguroDeSalud.UI.Mantenimiento.frmManteminientoPlan;
using SeguroDeSalud.UI.Mantenimiento.frmManteminientoPoliza;
using SeguroDeSalud.UI.Mantenimiento.frmManteminientoSeguro;
using SeguroDeSalud.UI.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeguroDeSalud.UI.Menu
    {
    public partial class frmMenu : Form
    {
        int m, mx, my;

        string Identificacion;
        string Nombre;
        string Apellido;
        string CorreoElectronico;
        byte[] Fotografia;
        char Genero;
        DateTime FechaNacimiento;
        string Telefono;
        int tipoUsuario;

        public frmMenu(string Identificacion, string Nombre, string Apellido, string CorreoElectronico,
                       byte[] Fotografia, char Genero, DateTime FechaNacimiento, string Telefono, int tipoUsuario)
        {
            this.Identificacion = Identificacion;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.CorreoElectronico = CorreoElectronico;
            this.Fotografia = Fotografia;
            this.Genero = Genero;
            this.FechaNacimiento = FechaNacimiento;
            this.Telefono = Telefono;
            this.tipoUsuario = tipoUsuario;
            InitializeComponent();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            frmManteminientoPlan nuevo = new frmManteminientoPlan();
            nuevo.Show();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        public Image byteArrayToImage(byte[] Fotografia)
        {


            MemoryStream ms = new MemoryStream(Fotografia, 0, Fotografia.Length);
            ms.Write(Fotografia, 0, Fotografia.Length);
            Image image = Image.FromStream(ms, true);
            return image;//Exception occurs here



        }
        public void actualizarIVA()
        {
            txtIVA.Text = BLL.BLLIVA.TraerIVA(1).Porcentaje.ToString();
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            txtIVA.Enabled = false;
            cargarDatos();
            actualizarIVA();




            if (tipoUsuario == 1) {
                lblTipoUsuario.Text = "Administrador";
            }
            else
            {
                if (tipoUsuario == 2)
                {
                    lblTipoUsuario.Text = "Cliente";
                }
                else
                {
                    
                        lblTipoUsuario.Text = "Reportes";
                   
                }
            }
        }
        public void cargarDatos()
        {
            pictureBox1.Image = byteArrayToImage(Fotografia);
            txtApellido.Enabled = false;
            txtElectronico.Enabled = false;
            txtmkCedula.Enabled = false;
            txtNombre.Enabled = false;
            txtSexo.Enabled = false;
            dtFechaNacimiento.Enabled = false;
            txtTelefono.Enabled = false;

            txtApellido.Text = Apellido;
            txtElectronico.Text = CorreoElectronico;
            txtmkCedula.Text = Identificacion;
            txtNombre.Text = Nombre;
            dtFechaNacimiento.Value = FechaNacimiento;
            txtTelefono.Text = Telefono;
            if (Genero.ToString().Equals("M"))
            {
                txtSexo.Text = "Masculino";
            }
            else
            {
                txtSexo.Text = "Femenino";
            }

            if (tipoUsuario == 2)
            {
                gbMantenimientos.Enabled = false;
                gbMantenimientos.Visible = false;
                btnIVA.Visible = false;
                btnIVA.Enabled = false;
                          }
            else
            {
                if (tipoUsuario == 3)
                {
                    gbMantenimientos.Enabled = false;
                    gbMantenimientos.Visible = false;
                    btnIVA.Visible = false;
                    btnIVA.Enabled = false;
                    ntnPagar.Visible = false;
                    ntnPagar.Enabled = false;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gbMantenimientos_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void btnMantenimientoCliente_Click(object sender, EventArgs e)
        {
            frmManteminientoUsuario frm = new frmManteminientoUsuario();
            frm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMantenimientoEjercicio_Click(object sender, EventArgs e)
        {
            frmManteminientoSeguro nuevo = new frmManteminientoSeguro();
            nuevo.Show();
        }

        private void btnMantenimientoTipoEjercicio_Click(object sender, EventArgs e)
        {
            frmManteminientoPoliza nuevo = new frmManteminientoPoliza();
            nuevo.Show();

        }

        private void btnReporteEjercicio_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmManteminientoCobertura nuevo = new frmManteminientoCobertura();
            nuevo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = MessageBox.Show("¿Quiere Cerrar Sesion?", "Pregunta",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            btnAgregarCedula  nuevo = new btnAgregarCedula(Identificacion, Fotografia);
            nuevo.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            IVA nuevo = new IVA();
            nuevo.id = 1;
            nuevo.Porcentaje = float.Parse(txtIVA.Text);
            BLL.BLLIVA.Insertar(nuevo);

            actualizarIVA();
        }

        private void btnReporteGraficoEjecicio_Click(object sender, EventArgs e)
        {
            frmReporteFacturasCedula nuevo = new frmReporteFacturasCedula();
            nuevo.Show();

        }

        private void btnReporteMantenimiento_Click(object sender, EventArgs e)
        {
            frmResporteFacturasFechas nueva = new frmResporteFacturasFechas();
            nueva.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmReporteDias nuevoreport = new frmReporteDias();
            nuevoreport.Show();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
    }
}
