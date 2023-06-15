
namespace SeguroDeSalud.UI.Reportes
{
    partial class frmResporteFacturasFechas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.usp_SELECT_Factura_ByIDFechasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.segurosDataSet = new SeguroDeSalud.SegurosDataSet();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uspSELECTFacturaByIDFechasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usp_SELECT_Factura_ByIDFechasTableAdapter = new SeguroDeSalud.SegurosDataSetTableAdapters.usp_SELECT_Factura_ByIDFechasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.usp_SELECT_Factura_ByIDFechasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.segurosDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspSELECTFacturaByIDFechasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // usp_SELECT_Factura_ByIDFechasBindingSource
            // 
            this.usp_SELECT_Factura_ByIDFechasBindingSource.DataMember = "usp_SELECT_Factura_ByIDFechas";
            this.usp_SELECT_Factura_ByIDFechasBindingSource.DataSource = this.segurosDataSet;
            // 
            // segurosDataSet
            // 
            this.segurosDataSet.DataSetName = "SegurosDataSet";
            this.segurosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Location = new System.Drawing.Point(228, 27);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha1.TabIndex = 0;
            this.dtpFecha1.ValueChanged += new System.EventHandler(this.dtpFecha1_ValueChanged);
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.Location = new System.Drawing.Point(586, 27);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha2.TabIndex = 1;
            this.dtpFecha2.ValueChanged += new System.EventHandler(this.dtpFecha2_ValueChanged);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(466, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 55);
            this.button1.TabIndex = 2;
            this.button1.Text = "Comparar fechas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.usp_SELECT_Factura_ByIDFechasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SeguroDeSalud.UI.Reportes.ReporteFacturaFechas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-2, 85);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(999, 367);
            this.reportViewer1.TabIndex = 3;
            // 
            // uspSELECTFacturaByIDFechasBindingSource
            // 
            this.uspSELECTFacturaByIDFechasBindingSource.DataMember = "usp_SELECT_Factura_ByIDFechas";
            this.uspSELECTFacturaByIDFechasBindingSource.DataSource = this.segurosDataSet;
            // 
            // usp_SELECT_Factura_ByIDFechasTableAdapter
            // 
            this.usp_SELECT_Factura_ByIDFechasTableAdapter.ClearBeforeFill = true;
            // 
            // frmResporteFacturasFechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(1001, 464);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpFecha2);
            this.Controls.Add(this.dtpFecha1);
            this.ForeColor = System.Drawing.Color.Turquoise;
            this.Name = "frmResporteFacturasFechas";
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmResporteFacturasFechas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usp_SELECT_Factura_ByIDFechasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.segurosDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspSELECTFacturaByIDFechasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource usp_SELECT_Factura_ByIDFechasBindingSource;
        private SegurosDataSet segurosDataSet;
        private System.Windows.Forms.BindingSource uspSELECTFacturaByIDFechasBindingSource;
        private SegurosDataSetTableAdapters.usp_SELECT_Factura_ByIDFechasTableAdapter usp_SELECT_Factura_ByIDFechasTableAdapter;
    }
}