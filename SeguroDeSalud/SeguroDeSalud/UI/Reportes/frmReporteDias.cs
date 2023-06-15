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
    public partial class frmReporteDias : Form
    {
        public frmReporteDias()
        {
            InitializeComponent();
        }

        private void frmReporteDias_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'segurosDataSet1.usp_SELECT_Factura_ByIDDias' table. You can move, or remove it, as needed.
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.usp_SELECT_Factura_ByIDDiasTableAdapter.Fill(this.segurosDataSet1.usp_SELECT_Factura_ByIDDias, dtpFecha1.Value, dtpFecha2.Value);

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
    }
}
