
namespace SeguroDeSalud.UI.Procesos
{
    partial class frmReporteFactura
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsSegurosFactura = new SeguroDeSalud.dsSegurosFactura();
            this.uspSELECTFacturaByIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usp_SELECT_Factura_ByIDTableAdapter = new SeguroDeSalud.dsSegurosFacturaTableAdapters.usp_SELECT_Factura_ByIDTableAdapter();
            this.usp_SELECT_Factura_ByIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsSegurosFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspSELECTFacturaByIDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usp_SELECT_Factura_ByIDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ReporteFactura";
            reportDataSource1.Value = this.usp_SELECT_Factura_ByIDBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SeguroDeSalud.UI.Procesos.reporteFactura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsSegurosFactura
            // 
            this.dsSegurosFactura.DataSetName = "dsSegurosFactura";
            this.dsSegurosFactura.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uspSELECTFacturaByIDBindingSource
            // 
            this.uspSELECTFacturaByIDBindingSource.DataMember = "usp_SELECT_Factura_ByID";
            this.uspSELECTFacturaByIDBindingSource.DataSource = this.dsSegurosFactura;
            // 
            // usp_SELECT_Factura_ByIDTableAdapter
            // 
            this.usp_SELECT_Factura_ByIDTableAdapter.ClearBeforeFill = true;
            // 
            // usp_SELECT_Factura_ByIDBindingSource
            // 
            this.usp_SELECT_Factura_ByIDBindingSource.DataMember = "usp_SELECT_Factura_ByID";
            this.usp_SELECT_Factura_ByIDBindingSource.DataSource = this.dsSegurosFactura;
            // 
            // frmReporteFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteFactura";
            this.Text = "frmReporteFactura";
            this.Load += new System.EventHandler(this.frmReporteFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsSegurosFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspSELECTFacturaByIDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usp_SELECT_Factura_ByIDBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource usp_SELECT_Factura_ByIDBindingSource;
        private dsSegurosFactura dsSegurosFactura;
        private System.Windows.Forms.BindingSource uspSELECTFacturaByIDBindingSource;
        private dsSegurosFacturaTableAdapters.usp_SELECT_Factura_ByIDTableAdapter usp_SELECT_Factura_ByIDTableAdapter;
    }
}