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
    public partial class frmReporteFacturasCedula : Form
    {
        public frmReporteFacturasCedula()
        {
            InitializeComponent();
        }

        private void frmReporteFacturasCedula_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'segurosFacturaCedula.usp_SELECT_Factura_ByIDCedula' table. You can move, or remove it, as needed.
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.usp_SELECT_Factura_ByIDCedulaTableAdapter.Fill(this.segurosFacturaCedula.usp_SELECT_Factura_ByIDCedula, mtbCedula.Text);

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
