
namespace SeguroDeSalud.UI.Reportes
{
    partial class frmReporteFacturasCedula
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
            this.usp_SELECT_Factura_ByIDCedulaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.segurosFacturaCedula = new SeguroDeSalud.SegurosFacturaCedula();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mtbCedula = new System.Windows.Forms.MaskedTextBox();
            this.uspSELECTFacturaByIDCedulaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usp_SELECT_Factura_ByIDCedulaTableAdapter = new SeguroDeSalud.SegurosFacturaCedulaTableAdapters.usp_SELECT_Factura_ByIDCedulaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.usp_SELECT_Factura_ByIDCedulaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.segurosFacturaCedula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspSELECTFacturaByIDCedulaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // usp_SELECT_Factura_ByIDCedulaBindingSource
            // 
            this.usp_SELECT_Factura_ByIDCedulaBindingSource.DataMember = "usp_SELECT_Factura_ByIDCedula";
            this.usp_SELECT_Factura_ByIDCedulaBindingSource.DataSource = this.segurosFacturaCedula;
            // 
            // segurosFacturaCedula
            // 
            this.segurosFacturaCedula.DataSetName = "SegurosFacturaCedula";
            this.segurosFacturaCedula.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "ReporteFacturasCedula";
            reportDataSource1.Value = this.usp_SELECT_Factura_ByIDCedulaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SeguroDeSalud.UI.Reportes.ReporteCedula.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 54);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(942, 436);
            this.reportViewer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(665, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(324, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cedula";
            // 
            // mtbCedula
            // 
            this.mtbCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbCedula.Location = new System.Drawing.Point(458, 3);
            this.mtbCedula.Mask = "0-0000-0000";
            this.mtbCedula.Name = "mtbCedula";
            this.mtbCedula.Size = new System.Drawing.Size(173, 40);
            this.mtbCedula.TabIndex = 3;
            // 
            // uspSELECTFacturaByIDCedulaBindingSource
            // 
            this.uspSELECTFacturaByIDCedulaBindingSource.DataMember = "usp_SELECT_Factura_ByIDCedula";
            this.uspSELECTFacturaByIDCedulaBindingSource.DataSource = this.segurosFacturaCedula;
            // 
            // usp_SELECT_Factura_ByIDCedulaTableAdapter
            // 
            this.usp_SELECT_Factura_ByIDCedulaTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteFacturasCedula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 502);
            this.Controls.Add(this.mtbCedula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteFacturasCedula";
            this.Text = "frmReporteFacturasCedula";
            this.Load += new System.EventHandler(this.frmReporteFacturasCedula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usp_SELECT_Factura_ByIDCedulaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.segurosFacturaCedula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspSELECTFacturaByIDCedulaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbCedula;
        private System.Windows.Forms.BindingSource usp_SELECT_Factura_ByIDCedulaBindingSource;
        private SegurosFacturaCedula segurosFacturaCedula;
        private System.Windows.Forms.BindingSource uspSELECTFacturaByIDCedulaBindingSource;
        private SegurosFacturaCedulaTableAdapters.usp_SELECT_Factura_ByIDCedulaTableAdapter usp_SELECT_Factura_ByIDCedulaTableAdapter;
    }
}