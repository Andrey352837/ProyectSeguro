using SeguroDeSalud.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeguroDeSalud.UI.Reportes
{
    public partial class frmResporteFacturasFechas : Form
    {
        public frmResporteFacturasFechas()
        {
            InitializeComponent();
        }

        private void frmResporteFacturasFechas_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'segurosDataSet.usp_SELECT_Factura_ByIDFechas' table. You can move, or remove it, as needed.
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.usp_SELECT_Factura_ByIDFechasTableAdapter.Fill(this.segurosDataSet.usp_SELECT_Factura_ByIDFechas, dtpFecha1.Value, dtpFecha2.Value);

                this.reportViewer1.RefreshReport();
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

        private void dtpFecha2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFecha1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
