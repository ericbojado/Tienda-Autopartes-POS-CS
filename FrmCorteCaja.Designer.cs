namespace Tienda_Autopartes_ProyectoFinal
{
    partial class FrmCorteCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCorteCaja));
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.LvVentas = new System.Windows.Forms.ListView();
            this.LblVentas = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            this.LblEmpleado = new System.Windows.Forms.Label();
            this.CmbEmpleados = new System.Windows.Forms.ComboBox();
            this.BtnCargar = new System.Windows.Forms.Button();
            this.BTcerrar = new System.Windows.Forms.Button();
            this.BTregresar = new System.Windows.Forms.Button();
            this.McFecha = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PbLogo
            // 
            this.PbLogo.Image = ((System.Drawing.Image)(resources.GetObject("PbLogo.Image")));
            this.PbLogo.Location = new System.Drawing.Point(12, 12);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(75, 75);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbLogo.TabIndex = 27;
            this.PbLogo.TabStop = false;
            // 
            // LvVentas
            // 
            this.LvVentas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvVentas.HideSelection = false;
            this.LvVentas.Location = new System.Drawing.Point(52, 154);
            this.LvVentas.Name = "LvVentas";
            this.LvVentas.Size = new System.Drawing.Size(906, 411);
            this.LvVentas.TabIndex = 28;
            this.LvVentas.UseCompatibleStateImageBehavior = false;
            this.LvVentas.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvVentas_ColumnClick);
            // 
            // LblVentas
            // 
            this.LblVentas.AutoSize = true;
            this.LblVentas.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVentas.Location = new System.Drawing.Point(47, 119);
            this.LblVentas.Name = "LblVentas";
            this.LblVentas.Size = new System.Drawing.Size(96, 32);
            this.LblVentas.TabIndex = 38;
            this.LblVentas.Text = "Ventas: ";
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.Location = new System.Drawing.Point(708, 114);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(112, 37);
            this.LblTotal.TabIndex = 39;
            this.LblTotal.Text = "Total: $";
            // 
            // LblEmpleado
            // 
            this.LblEmpleado.AutoSize = true;
            this.LblEmpleado.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.LblEmpleado.Location = new System.Drawing.Point(966, 245);
            this.LblEmpleado.Name = "LblEmpleado";
            this.LblEmpleado.Size = new System.Drawing.Size(100, 25);
            this.LblEmpleado.TabIndex = 40;
            this.LblEmpleado.Text = "Empleado:";
            // 
            // CmbEmpleados
            // 
            this.CmbEmpleados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEmpleados.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEmpleados.FormattingEnabled = true;
            this.CmbEmpleados.Location = new System.Drawing.Point(970, 272);
            this.CmbEmpleados.Name = "CmbEmpleados";
            this.CmbEmpleados.Size = new System.Drawing.Size(248, 33);
            this.CmbEmpleados.TabIndex = 41;
            // 
            // BtnCargar
            // 
            this.BtnCargar.Font = new System.Drawing.Font("Segoe UI", 9.749999F);
            this.BtnCargar.Location = new System.Drawing.Point(1131, 245);
            this.BtnCargar.Name = "BtnCargar";
            this.BtnCargar.Size = new System.Drawing.Size(87, 26);
            this.BtnCargar.TabIndex = 42;
            this.BtnCargar.Text = "Cargar";
            this.BtnCargar.UseVisualStyleBackColor = true;
            this.BtnCargar.Click += new System.EventHandler(this.BtnCargar_Click);
            // 
            // BTcerrar
            // 
            this.BTcerrar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BTcerrar.Location = new System.Drawing.Point(1113, 638);
            this.BTcerrar.Margin = new System.Windows.Forms.Padding(2);
            this.BTcerrar.Name = "BTcerrar";
            this.BTcerrar.Size = new System.Drawing.Size(140, 32);
            this.BTcerrar.TabIndex = 46;
            this.BTcerrar.Text = "Cerrar";
            this.BTcerrar.UseVisualStyleBackColor = true;
            this.BTcerrar.Click += new System.EventHandler(this.BTcerrar_Click);
            // 
            // BTregresar
            // 
            this.BTregresar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BTregresar.Location = new System.Drawing.Point(1113, 11);
            this.BTregresar.Margin = new System.Windows.Forms.Padding(2);
            this.BTregresar.Name = "BTregresar";
            this.BTregresar.Size = new System.Drawing.Size(140, 30);
            this.BTregresar.TabIndex = 45;
            this.BTregresar.Text = "Regresar";
            this.BTregresar.UseVisualStyleBackColor = true;
            this.BTregresar.Click += new System.EventHandler(this.BTregresar_Click);
            // 
            // McFecha
            // 
            this.McFecha.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.McFecha.Location = new System.Drawing.Point(970, 322);
            this.McFecha.Name = "McFecha";
            this.McFecha.TabIndex = 50;
            // 
            // FrmCorteCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.McFecha);
            this.Controls.Add(this.BTcerrar);
            this.Controls.Add(this.BTregresar);
            this.Controls.Add(this.BtnCargar);
            this.Controls.Add(this.CmbEmpleados);
            this.Controls.Add(this.LblEmpleado);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.LblVentas);
            this.Controls.Add(this.LvVentas);
            this.Controls.Add(this.PbLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmCorteCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Corte de Caja";
            this.Load += new System.EventHandler(this.FrmCorteCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.ListView LvVentas;
        private System.Windows.Forms.Label LblVentas;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Label LblEmpleado;
        private System.Windows.Forms.ComboBox CmbEmpleados;
        private System.Windows.Forms.Button BtnCargar;
        private System.Windows.Forms.Button BTcerrar;
        private System.Windows.Forms.Button BTregresar;
        private System.Windows.Forms.MonthCalendar McFecha;
    }
}