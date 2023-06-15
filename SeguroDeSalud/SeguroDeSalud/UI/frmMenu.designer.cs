
namespace SeguroDeSalud.UI.Menu
{
    partial class frmMenu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.gbMantenimientos = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMantenimientoEntrenamiento = new System.Windows.Forms.Button();
            this.btnMantenimientoEjercicio = new System.Windows.Forms.Button();
            this.btnMantenimientoTipoEjercicio = new System.Windows.Forms.Button();
            this.btnMantenimientoCliente = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbReportes = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnReporteMantenimiento = new System.Windows.Forms.Button();
            this.btnReporteGraficoEjecicio = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ntnPagar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSexo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtElectronico = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtmkCedula = new System.Windows.Forms.MaskedTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lblTipoUsuario = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.btnIVA = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.gbMantenimientos.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbReportes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.gbMantenimientos);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 76);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMinimizar.Image = global::SeguroDeSalud.Properties.Resources.Minimize_Icon;
            this.btnMinimizar.Location = new System.Drawing.Point(908, 28);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(18, 18);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMinimizar.TabIndex = 5;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnCerrar.Image = global::SeguroDeSalud.Properties.Resources.Close_Icon;
            this.btnCerrar.Location = new System.Drawing.Point(941, 27);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(18, 18);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // gbMantenimientos
            // 
            this.gbMantenimientos.Controls.Add(this.button1);
            this.gbMantenimientos.Controls.Add(this.btnMantenimientoEntrenamiento);
            this.gbMantenimientos.Controls.Add(this.btnMantenimientoEjercicio);
            this.gbMantenimientos.Controls.Add(this.btnMantenimientoTipoEjercicio);
            this.gbMantenimientos.Controls.Add(this.btnMantenimientoCliente);
            this.gbMantenimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMantenimientos.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gbMantenimientos.Location = new System.Drawing.Point(204, 9);
            this.gbMantenimientos.Name = "gbMantenimientos";
            this.gbMantenimientos.Size = new System.Drawing.Size(698, 56);
            this.gbMantenimientos.TabIndex = 3;
            this.gbMantenimientos.TabStop = false;
            this.gbMantenimientos.Text = "Mantenimientos";
            this.gbMantenimientos.Enter += new System.EventHandler(this.gbMantenimientos_Enter);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(397, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cobertura";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMantenimientoEntrenamiento
            // 
            this.btnMantenimientoEntrenamiento.FlatAppearance.BorderSize = 0;
            this.btnMantenimientoEntrenamiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimientoEntrenamiento.Location = new System.Drawing.Point(145, 16);
            this.btnMantenimientoEntrenamiento.Name = "btnMantenimientoEntrenamiento";
            this.btnMantenimientoEntrenamiento.Size = new System.Drawing.Size(79, 30);
            this.btnMantenimientoEntrenamiento.TabIndex = 4;
            this.btnMantenimientoEntrenamiento.Text = "Plan";
            this.btnMantenimientoEntrenamiento.UseVisualStyleBackColor = true;
            this.btnMantenimientoEntrenamiento.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnMantenimientoEjercicio
            // 
            this.btnMantenimientoEjercicio.FlatAppearance.BorderSize = 0;
            this.btnMantenimientoEjercicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimientoEjercicio.Location = new System.Drawing.Point(524, 13);
            this.btnMantenimientoEjercicio.Name = "btnMantenimientoEjercicio";
            this.btnMantenimientoEjercicio.Size = new System.Drawing.Size(91, 30);
            this.btnMantenimientoEjercicio.TabIndex = 3;
            this.btnMantenimientoEjercicio.Text = "Seguro";
            this.btnMantenimientoEjercicio.UseVisualStyleBackColor = true;
            this.btnMantenimientoEjercicio.Click += new System.EventHandler(this.btnMantenimientoEjercicio_Click);
            // 
            // btnMantenimientoTipoEjercicio
            // 
            this.btnMantenimientoTipoEjercicio.FlatAppearance.BorderSize = 0;
            this.btnMantenimientoTipoEjercicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimientoTipoEjercicio.Location = new System.Drawing.Point(272, 13);
            this.btnMantenimientoTipoEjercicio.Name = "btnMantenimientoTipoEjercicio";
            this.btnMantenimientoTipoEjercicio.Size = new System.Drawing.Size(75, 37);
            this.btnMantenimientoTipoEjercicio.TabIndex = 2;
            this.btnMantenimientoTipoEjercicio.Text = "Poliza";
            this.btnMantenimientoTipoEjercicio.UseVisualStyleBackColor = true;
            this.btnMantenimientoTipoEjercicio.Click += new System.EventHandler(this.btnMantenimientoTipoEjercicio_Click);
            // 
            // btnMantenimientoCliente
            // 
            this.btnMantenimientoCliente.FlatAppearance.BorderSize = 0;
            this.btnMantenimientoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimientoCliente.Location = new System.Drawing.Point(20, 16);
            this.btnMantenimientoCliente.Name = "btnMantenimientoCliente";
            this.btnMantenimientoCliente.Size = new System.Drawing.Size(78, 30);
            this.btnMantenimientoCliente.TabIndex = 0;
            this.btnMantenimientoCliente.Text = "Usuario";
            this.btnMantenimientoCliente.UseVisualStyleBackColor = true;
            this.btnMantenimientoCliente.Click += new System.EventHandler(this.btnMantenimientoCliente_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Crimson;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 75);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(30, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Menu Principal";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Crimson;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.gbReportes);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 448);
            this.panel3.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(32, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // gbReportes
            // 
            this.gbReportes.Controls.Add(this.button4);
            this.gbReportes.Controls.Add(this.btnReporteMantenimiento);
            this.gbReportes.Controls.Add(this.btnReporteGraficoEjecicio);
            this.gbReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReportes.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gbReportes.Location = new System.Drawing.Point(32, 199);
            this.gbReportes.Name = "gbReportes";
            this.gbReportes.Size = new System.Drawing.Size(132, 215);
            this.gbReportes.TabIndex = 5;
            this.gbReportes.TabStop = false;
            this.gbReportes.Text = "Reportes";
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(27, 130);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 55);
            this.button4.TabIndex = 5;
            this.button4.Text = "Ventas por dia";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnReporteMantenimiento
            // 
            this.btnReporteMantenimiento.FlatAppearance.BorderSize = 0;
            this.btnReporteMantenimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteMantenimiento.Location = new System.Drawing.Point(16, 22);
            this.btnReporteMantenimiento.Name = "btnReporteMantenimiento";
            this.btnReporteMantenimiento.Size = new System.Drawing.Size(114, 30);
            this.btnReporteMantenimiento.TabIndex = 4;
            this.btnReporteMantenimiento.Text = "Pólizas";
            this.btnReporteMantenimiento.UseVisualStyleBackColor = true;
            this.btnReporteMantenimiento.Click += new System.EventHandler(this.btnReporteMantenimiento_Click);
            // 
            // btnReporteGraficoEjecicio
            // 
            this.btnReporteGraficoEjecicio.FlatAppearance.BorderSize = 0;
            this.btnReporteGraficoEjecicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteGraficoEjecicio.Location = new System.Drawing.Point(27, 58);
            this.btnReporteGraficoEjecicio.Name = "btnReporteGraficoEjecicio";
            this.btnReporteGraficoEjecicio.Size = new System.Drawing.Size(84, 55);
            this.btnReporteGraficoEjecicio.TabIndex = 1;
            this.btnReporteGraficoEjecicio.Text = "Consulta individual";
            this.btnReporteGraficoEjecicio.UseVisualStyleBackColor = true;
            this.btnReporteGraficoEjecicio.Click += new System.EventHandler(this.btnReporteGraficoEjecicio_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Silver;
            this.groupBox2.CausesValidation = false;
            this.groupBox2.Controls.Add(this.ntnPagar);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSexo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtTelefono);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtFechaNacimiento);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtElectronico);
            this.groupBox2.Controls.Add(this.txtApellido);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.txtmkCedula);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox2.Location = new System.Drawing.Point(213, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(716, 298);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Personales";
            // 
            // ntnPagar
            // 
            this.ntnPagar.FlatAppearance.BorderSize = 2;
            this.ntnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntnPagar.Location = new System.Drawing.Point(559, 213);
            this.ntnPagar.Name = "ntnPagar";
            this.ntnPagar.Size = new System.Drawing.Size(151, 46);
            this.ntnPagar.TabIndex = 31;
            this.ntnPagar.Text = "Pagar Factura";
            this.ntnPagar.UseVisualStyleBackColor = true;
            this.ntnPagar.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(18, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Sexo";
            // 
            // txtSexo
            // 
            this.txtSexo.Location = new System.Drawing.Point(21, 213);
            this.txtSexo.Name = "txtSexo";
            this.txtSexo.Size = new System.Drawing.Size(90, 22);
            this.txtSexo.TabIndex = 29;
            this.txtSexo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(219, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Correo Electronico";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(219, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "Fecha de nacimiento";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(222, 154);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(163, 22);
            this.txtTelefono.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(219, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Telefono";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Cedula";
            // 
            // dtFechaNacimiento
            // 
            this.dtFechaNacimiento.Location = new System.Drawing.Point(222, 103);
            this.dtFechaNacimiento.Name = "dtFechaNacimiento";
            this.dtFechaNacimiento.Size = new System.Drawing.Size(279, 22);
            this.dtFechaNacimiento.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(18, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(18, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Apellidos";
            // 
            // txtElectronico
            // 
            this.txtElectronico.Location = new System.Drawing.Point(222, 47);
            this.txtElectronico.Name = "txtElectronico";
            this.txtElectronico.Size = new System.Drawing.Size(168, 22);
            this.txtElectronico.TabIndex = 25;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(21, 153);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(173, 22);
            this.txtApellido.TabIndex = 24;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(21, 103);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(173, 22);
            this.txtNombre.TabIndex = 23;
            // 
            // txtmkCedula
            // 
            this.txtmkCedula.Location = new System.Drawing.Point(21, 47);
            this.txtmkCedula.Mask = "0-0000-0000";
            this.txtmkCedula.Name = "txtmkCedula";
            this.txtmkCedula.Size = new System.Drawing.Size(173, 22);
            this.txtmkCedula.TabIndex = 21;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gray;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(833, 402);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 36);
            this.button3.TabIndex = 30;
            this.button3.Text = "Cerrar sesion ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblTipoUsuario
            // 
            this.lblTipoUsuario.AutoSize = true;
            this.lblTipoUsuario.BackColor = System.Drawing.Color.Silver;
            this.lblTipoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoUsuario.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTipoUsuario.Location = new System.Drawing.Point(217, 412);
            this.lblTipoUsuario.Name = "lblTipoUsuario";
            this.lblTipoUsuario.Size = new System.Drawing.Size(0, 16);
            this.lblTipoUsuario.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(399, 390);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 32;
            this.label7.Text = "IVA";
            // 
            // txtIVA
            // 
            this.txtIVA.Location = new System.Drawing.Point(368, 408);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(90, 20);
            this.txtIVA.TabIndex = 32;
            this.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnIVA
            // 
            this.btnIVA.BackColor = System.Drawing.Color.Gray;
            this.btnIVA.FlatAppearance.BorderSize = 2;
            this.btnIVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIVA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnIVA.Location = new System.Drawing.Point(464, 399);
            this.btnIVA.Name = "btnIVA";
            this.btnIVA.Size = new System.Drawing.Size(90, 36);
            this.btnIVA.TabIndex = 34;
            this.btnIVA.Text = "Cambiar IVA";
            this.btnIVA.UseVisualStyleBackColor = false;
            this.btnIVA.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(971, 450);
            this.Controls.Add(this.btnIVA);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTipoUsuario);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenu";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMenu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.gbMantenimientos.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbReportes.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbMantenimientos;
        private System.Windows.Forms.Button btnMantenimientoEntrenamiento;
        private System.Windows.Forms.Button btnMantenimientoEjercicio;
        private System.Windows.Forms.Button btnMantenimientoTipoEjercicio;
        private System.Windows.Forms.Button btnMantenimientoCliente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbReportes;
        private System.Windows.Forms.Button btnReporteMantenimiento;
        private System.Windows.Forms.Button btnReporteGraficoEjecicio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSexo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtTelefono;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFechaNacimiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtElectronico;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.MaskedTextBox txtmkCedula;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblTipoUsuario;
        private System.Windows.Forms.Button ntnPagar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Button btnIVA;
    }
}