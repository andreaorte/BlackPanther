namespace Marker
{
    partial class frmMarcacion
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
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.lblMarcacionEntrada = new System.Windows.Forms.Label();
            this.lblMarcacionSalida = new System.Windows.Forms.Label();
            this.btnMarcarEntrada = new System.Windows.Forms.Button();
            this.btnMarcarSalida = new System.Windows.Forms.Button();
            this.lblDpto = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lstMarcacion = new System.Windows.Forms.ListBox();
            this.lblHorasTrabajadas = new System.Windows.Forms.Label();
            this.txtHorasTrabajadas = new System.Windows.Forms.TextBox();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.txtMarcacionEntrada = new System.Windows.Forms.TextBox();
            this.txtMarcacionSalida = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblHoraActual = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(38, 25);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(57, 13);
            this.lblEmpleado.TabIndex = 0;
            this.lblEmpleado.Text = "Empleado:";
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(138, 17);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(247, 21);
            this.cboEmpleado.TabIndex = 1;
            this.cboEmpleado.SelectedIndexChanged += new System.EventHandler(this.cboEmpleado_SelectedIndexChanged);
            // 
            // lblMarcacionEntrada
            // 
            this.lblMarcacionEntrada.AutoSize = true;
            this.lblMarcacionEntrada.Location = new System.Drawing.Point(38, 104);
            this.lblMarcacionEntrada.Name = "lblMarcacionEntrada";
            this.lblMarcacionEntrada.Size = new System.Drawing.Size(99, 13);
            this.lblMarcacionEntrada.TabIndex = 2;
            this.lblMarcacionEntrada.Text = "Marcación entrada:";
            this.lblMarcacionEntrada.Click += new System.EventHandler(this.lblMarcacionEntrada_Click);
            // 
            // lblMarcacionSalida
            // 
            this.lblMarcacionSalida.AutoSize = true;
            this.lblMarcacionSalida.Location = new System.Drawing.Point(38, 129);
            this.lblMarcacionSalida.Name = "lblMarcacionSalida";
            this.lblMarcacionSalida.Size = new System.Drawing.Size(95, 13);
            this.lblMarcacionSalida.TabIndex = 3;
            this.lblMarcacionSalida.Text = "Marcación  Salida:";
            // 
            // btnMarcarEntrada
            // 
            this.btnMarcarEntrada.Location = new System.Drawing.Point(440, 274);
            this.btnMarcarEntrada.Name = "btnMarcarEntrada";
            this.btnMarcarEntrada.Size = new System.Drawing.Size(114, 23);
            this.btnMarcarEntrada.TabIndex = 4;
            this.btnMarcarEntrada.Text = "&Entrada";
            this.btnMarcarEntrada.UseVisualStyleBackColor = true;
            this.btnMarcarEntrada.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMarcarSalida
            // 
            this.btnMarcarSalida.Location = new System.Drawing.Point(587, 274);
            this.btnMarcarSalida.Name = "btnMarcarSalida";
            this.btnMarcarSalida.Size = new System.Drawing.Size(114, 23);
            this.btnMarcarSalida.TabIndex = 5;
            this.btnMarcarSalida.Text = "&Salida";
            this.btnMarcarSalida.UseVisualStyleBackColor = true;
            this.btnMarcarSalida.Click += new System.EventHandler(this.btnMarcarSalida_Click);
            // 
            // lblDpto
            // 
            this.lblDpto.AutoSize = true;
            this.lblDpto.Location = new System.Drawing.Point(38, 53);
            this.lblDpto.Name = "lblDpto";
            this.lblDpto.Size = new System.Drawing.Size(77, 13);
            this.lblDpto.TabIndex = 6;
            this.lblDpto.Text = "Departamento:";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(38, 80);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(38, 13);
            this.lblCargo.TabIndex = 7;
            this.lblCargo.Text = "Cargo:";
            // 
            // lstMarcacion
            // 
            this.lstMarcacion.FormattingEnabled = true;
            this.lstMarcacion.Location = new System.Drawing.Point(422, 15);
            this.lstMarcacion.Name = "lstMarcacion";
            this.lstMarcacion.Size = new System.Drawing.Size(295, 212);
            this.lstMarcacion.TabIndex = 8;
            this.lstMarcacion.Click += new System.EventHandler(this.lstMarcacion_Click);
            this.lstMarcacion.SelectedIndexChanged += new System.EventHandler(this.lstMarcacion_SelectedIndexChanged);
            // 
            // lblHorasTrabajadas
            // 
            this.lblHorasTrabajadas.AutoSize = true;
            this.lblHorasTrabajadas.Location = new System.Drawing.Point(38, 158);
            this.lblHorasTrabajadas.Name = "lblHorasTrabajadas";
            this.lblHorasTrabajadas.Size = new System.Drawing.Size(94, 13);
            this.lblHorasTrabajadas.TabIndex = 9;
            this.lblHorasTrabajadas.Text = "Horas Trabajadas:";
            // 
            // txtHorasTrabajadas
            // 
            this.txtHorasTrabajadas.Location = new System.Drawing.Point(138, 155);
            this.txtHorasTrabajadas.Name = "txtHorasTrabajadas";
            this.txtHorasTrabajadas.Size = new System.Drawing.Size(135, 20);
            this.txtHorasTrabajadas.TabIndex = 10;
            this.txtHorasTrabajadas.TextChanged += new System.EventHandler(this.txtHorasTrabajadas_TextChanged);
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Location = new System.Drawing.Point(138, 50);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(135, 20);
            this.txtDepartamento.TabIndex = 13;
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(138, 76);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(135, 20);
            this.txtCargo.TabIndex = 14;
            // 
            // txtMarcacionEntrada
            // 
            this.txtMarcacionEntrada.Location = new System.Drawing.Point(138, 101);
            this.txtMarcacionEntrada.Name = "txtMarcacionEntrada";
            this.txtMarcacionEntrada.Size = new System.Drawing.Size(135, 20);
            this.txtMarcacionEntrada.TabIndex = 15;
            // 
            // txtMarcacionSalida
            // 
            this.txtMarcacionSalida.Location = new System.Drawing.Point(138, 126);
            this.txtMarcacionSalida.Name = "txtMarcacionSalida";
            this.txtMarcacionSalida.Size = new System.Drawing.Size(135, 20);
            this.txtMarcacionSalida.TabIndex = 16;
            this.txtMarcacionSalida.TextChanged += new System.EventHandler(this.txtMarcacionSalida_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // lblHoraActual
            // 
            this.lblHoraActual.AutoSize = true;
            this.lblHoraActual.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraActual.Location = new System.Drawing.Point(64, 232);
            this.lblHoraActual.Name = "lblHoraActual";
            this.lblHoraActual.Size = new System.Drawing.Size(0, 31);
            this.lblHoraActual.TabIndex = 17;
            // 
            // frmMarcacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 344);
            this.Controls.Add(this.lblHoraActual);
            this.Controls.Add(this.txtMarcacionSalida);
            this.Controls.Add(this.txtMarcacionEntrada);
            this.Controls.Add(this.txtCargo);
            this.Controls.Add(this.txtDepartamento);
            this.Controls.Add(this.txtHorasTrabajadas);
            this.Controls.Add(this.lblHorasTrabajadas);
            this.Controls.Add(this.lstMarcacion);
            this.Controls.Add(this.lblCargo);
            this.Controls.Add(this.lblDpto);
            this.Controls.Add(this.btnMarcarSalida);
            this.Controls.Add(this.btnMarcarEntrada);
            this.Controls.Add(this.lblMarcacionSalida);
            this.Controls.Add(this.lblMarcacionEntrada);
            this.Controls.Add(this.cboEmpleado);
            this.Controls.Add(this.lblEmpleado);
            this.Name = "frmMarcacion";
            this.Text = "Marcar Entrada y Salida";
            this.Load += new System.EventHandler(this.frmMarcacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.ComboBox cboEmpleado;
        private System.Windows.Forms.Label lblMarcacionEntrada;
        private System.Windows.Forms.Label lblMarcacionSalida;
        private System.Windows.Forms.Button btnMarcarEntrada;
        private System.Windows.Forms.Button btnMarcarSalida;
        private System.Windows.Forms.Label lblDpto;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.ListBox lstMarcacion;
        private System.Windows.Forms.Label lblHorasTrabajadas;
        private System.Windows.Forms.TextBox txtHorasTrabajadas;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.TextBox txtMarcacionEntrada;
        private System.Windows.Forms.TextBox txtMarcacionSalida;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblHoraActual;
    }
}