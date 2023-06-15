
namespace SeguroDeSalud.UI.Reportes
{
    partial class frmReporteDias
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.segurosDataSet1 = new SeguroDeSalud.SegurosDataSet1();
            this.uspSELECTFacturaByIDDiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usp_SELECT_Factura_ByIDDiasTableAdapter = new SeguroDeSalud.SegurosDataSet1TableAdapters.usp_SELECT_Factura_ByIDDiasTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.usp_SELECT_Factura_ByIDDiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.segurosDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspSELECTFacturaByIDDiasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usp_SELECT_Factura_ByIDDiasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "SeguroFacturaDia";
            reportDataSource2.Value = this.usp_SELECT_Factura_ByIDDiasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SeguroDeSalud.UI.Reportes.rptFacturaDias.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(29, 114);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(748, 293);
            this.reportViewer1.TabIndex = 0;
            // 
            // segurosDataSet1
            // 
            this.segurosDataSet1.DataSetName = "SegurosDataSet1";
            this.segurosDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uspSELECTFacturaByIDDiasBindingSource
            // 
            this.uspSELECTFacturaByIDDiasBindingSource.DataMember = "usp_SELECT_Factura_ByIDDias";
            this.uspSELECTFacturaByIDDiasBindingSource.DataSource = this.segurosDataSet1;
            // 
            // usp_SELECT_Factura_ByIDDiasTableAdapter
            // 
            this.usp_SELECT_Factura_ByIDDiasTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(362, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 55);
            this.button1.TabIndex = 5;
            this.button1.Text = "Comparar fechas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.Location = new System.Drawing.Point(482, 36);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha2.TabIndex = 4;
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Location = new System.Drawing.Point(124, 36);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha1.TabIndex = 3;
            // 
            // usp_SELECT_Factura_ByIDDiasBindingSource
            // 
            this.usp_SELECT_Factura_ByIDDiasBindingSource.DataMember = "usp_SELECT_Factura_ByIDDias";
            this.usp_SELECT_Factura_ByIDDiasBindingSource.DataSource = this.segurosDataSet1;
            // 
            // frmReporteDias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpFecha2);
            this.Controls.Add(this.dtpFecha1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteDias";
            this.Text = "frmReporteDias";
            this.Load += new System.EventHandler(this.frmReporteDias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.segurosDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspSELECTFacturaByIDDiasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usp_SELECT_Factura_ByIDDiasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uspSELECTFacturaByIDDiasBindingSource;
        private SegurosDataSet1 segurosDataSet1;
        private SegurosDataSet1TableAdapters.usp_SELECT_Factura_ByIDDiasTableAdapter usp_SELECT_Factura_ByIDDiasTableAdapter;
        private System.Windows.Forms.BindingSource usp_SELECT_Factura_ByIDDiasBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
    }
}