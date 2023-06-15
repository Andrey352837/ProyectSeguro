using Microsoft.Reporting.WinForms;
using SeguroDeSalud.BLL;
using SeguroDeSalud.Entities;
using SeguroDeSalud.Interfaces;
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

namespace SeguroDeSalud.UI.Procesos
{
    public partial class frmReporteFactura : Form
    {

        int numero;
        string cedula;
        private string Ruta = @"C:\Windows\Temp\Factura.pdf";
        public frmReporteFactura(int numero1, string Cedula)
        {
            numero = numero1;
            cedula = Cedula;
            InitializeComponent();
        }

        private void frmReporteFactura_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSegurosFactura.usp_SELECT_Factura_ByID' table. You can move, or remove it, as needed.
            this.usp_SELECT_Factura_ByIDTableAdapter.Fill(this.dsSegurosFactura.usp_SELECT_Factura_ByID, numero);

            this.reportViewer1.RefreshReport();

            try
            {
                ExportarYGuardarReporteAPDF();
                IBLLUsuario nuevo = new BLLUsuario();
                Usuario oUsuario = nuevo.TraerPorId(cedula);

                string receptor = oUsuario.Email;
                string tema = "Sistema de Seguros JP";
                string mensaje = $"Se ha creado una nueva factura para usted {oUsuario.Nombre + oUsuario.Apellido1 + oUsuario.Apellido2}, descarga el PDF para poder verla!";

                Utilitarios.Utilitarios.EnviarCorreo(receptor, tema, mensaje, Ruta);

                MessageBox.Show("Factura Enviado!!");



            }
            catch (Exception er)
            {
                MessageBox.Show($"Ha ocurrido un error: {er.Message}");

            }
        }
        private void ExportarYGuardarReporteAPDF()
        {



            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = reportViewer1.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

            using (FileStream fs = new FileStream(Ruta, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

        }


    }
}
