namespace Tienda_Autopartes_ProyectoFinal
{
    partial class FrmCrudUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCrudUsuarios));
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.LvUsuarios = new System.Windows.Forms.ListView();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.RdBusqExac = new System.Windows.Forms.RadioButton();
            this.RdBusqAprox = new System.Windows.Forms.RadioButton();
            this.LblNumUsuarios = new System.Windows.Forms.Label();
            this.CboCampo = new System.Windows.Forms.ComboBox();
            this.BtnRegresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnModificar
            // 
            this.BtnModificar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnModificar.Location = new System.Drawing.Point(532, 570);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnModificar.Size = new System.Drawing.Size(200, 40);
            this.BtnModificar.TabIndex = 10;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.Location = new System.Drawing.Point(868, 105);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnBuscar.Size = new System.Drawing.Size(217, 42);
            this.BtnBuscar.TabIndex = 9;
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEliminar.Location = new System.Drawing.Point(885, 570);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnEliminar.Size = new System.Drawing.Size(200, 40);
            this.BtnEliminar.TabIndex = 8;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregar.Location = new System.Drawing.Point(179, 570);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnAgregar.Size = new System.Drawing.Size(200, 40);
            this.BtnAgregar.TabIndex = 7;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // PbLogo
            // 
            this.PbLogo.Image = ((System.Drawing.Image)(resources.GetObject("PbLogo.Image")));
            this.PbLogo.Location = new System.Drawing.Point(12, 12);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(75, 75);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbLogo.TabIndex = 6;
            this.PbLogo.TabStop = false;
            // 
            // LvUsuarios
            // 
            this.LvUsuarios.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LvUsuarios.HideSelection = false;
            this.LvUsuarios.Location = new System.Drawing.Point(179, 153);
            this.LvUsuarios.Name = "LvUsuarios";
            this.LvUsuarios.Size = new System.Drawing.Size(906, 411);
            this.LvUsuarios.TabIndex = 11;
            this.LvUsuarios.UseCompatibleStateImageBehavior = false;
            this.LvUsuarios.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvUsuarios_ColumnClick);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.Location = new System.Drawing.Point(179, 105);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(683, 43);
            this.TxtBuscar.TabIndex = 12;
            // 
            // RdBusqExac
            // 
            this.RdBusqExac.AutoSize = true;
            this.RdBusqExac.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.RdBusqExac.Location = new System.Drawing.Point(688, 70);
            this.RdBusqExac.Name = "RdBusqExac";
            this.RdBusqExac.Size = new System.Drawing.Size(172, 29);
            this.RdBusqExac.TabIndex = 13;
            this.RdBusqExac.TabStop = true;
            this.RdBusqExac.Text = "Búsqueda Exacta";
            this.RdBusqExac.UseVisualStyleBackColor = true;
            // 
            // RdBusqAprox
            // 
            this.RdBusqAprox.AutoSize = true;
            this.RdBusqAprox.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.RdBusqAprox.Location = new System.Drawing.Point(462, 70);
            this.RdBusqAprox.Name = "RdBusqAprox";
            this.RdBusqAprox.Size = new System.Drawing.Size(220, 29);
            this.RdBusqAprox.TabIndex = 14;
            this.RdBusqAprox.TabStop = true;
            this.RdBusqAprox.Text = "Búsqueda Aproximada";
            this.RdBusqAprox.UseVisualStyleBackColor = true;
            // 
            // LblNumUsuarios
            // 
            this.LblNumUsuarios.AutoSize = true;
            this.LblNumUsuarios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumUsuarios.Location = new System.Drawing.Point(175, 22);
            this.LblNumUsuarios.Name = "LblNumUsuarios";
            this.LblNumUsuarios.Size = new System.Drawing.Size(149, 21);
            this.LblNumUsuarios.TabIndex = 39;
            this.LblNumUsuarios.Text = "Num. de Usuarios:";
            // 
            // CboCampo
            // 
            this.CboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboCampo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboCampo.FormattingEnabled = true;
            this.CboCampo.Items.AddRange(new object[] {
            "Nombre",
            "Usuario",
            "Rol"});
            this.CboCampo.Location = new System.Drawing.Point(868, 72);
            this.CboCampo.Margin = new System.Windows.Forms.Padding(2);
            this.CboCampo.Name = "CboCampo";
            this.CboCampo.Size = new System.Drawing.Size(217, 29);
            this.CboCampo.TabIndex = 40;
            // 
            // BtnRegresar
            // 
            this.BtnRegresar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRegresar.Location = new System.Drawing.Point(1112, 12);
            this.BtnRegresar.Name = "BtnRegresar";
            this.BtnRegresar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnRegresar.Size = new System.Drawing.Size(140, 30);
            this.BtnRegresar.TabIndex = 41;
            this.BtnRegresar.Text = "Regresar";
            this.BtnRegresar.UseVisualStyleBackColor = true;
            this.BtnRegresar.Click += new System.EventHandler(this.BtnRegresar_Click);
            // 
            // FrmCrudUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.BtnRegresar);
            this.Controls.Add(this.CboCampo);
            this.Controls.Add(this.LblNumUsuarios);
            this.Controls.Add(this.RdBusqAprox);
            this.Controls.Add(this.RdBusqExac);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.LvUsuarios);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.PbLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmCrudUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Usuarios";
            this.Load += new System.EventHandler(this.FrmCrudUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.ListView LvUsuarios;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.RadioButton RdBusqExac;
        private System.Windows.Forms.RadioButton RdBusqAprox;
        private System.Windows.Forms.Label LblNumUsuarios;
        private System.Windows.Forms.ComboBox CboCampo;
        private System.Windows.Forms.Button BtnRegresar;
    }
}