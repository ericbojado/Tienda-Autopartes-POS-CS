namespace Tienda_Autopartes_ProyectoFinal
{
    partial class FrmGestionInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionInventario));
            this.label1 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblRol = new System.Windows.Forms.Label();
            this.LblPassword = new System.Windows.Forms.Label();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.LblNombre = new System.Windows.Forms.Label();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.TxtCodInventario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtStock = new System.Windows.Forms.TextBox();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.LblPrecio = new System.Windows.Forms.Label();
            this.CboCategoria = new System.Windows.Forms.ComboBox();
            this.BtnAgCategoria = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(176, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 45);
            this.label1.TabIndex = 33;
            this.label1.Text = "Modificame";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.BtnGuardar.Location = new System.Drawing.Point(224, 553);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(479, 42);
            this.BtnGuardar.TabIndex = 32;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.TxtDescripcion.Location = new System.Drawing.Point(224, 271);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(479, 39);
            this.TxtDescripcion.TabIndex = 29;
            this.TxtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDescripcion_KeyPress);
            // 
            // TxtNombre
            // 
            this.TxtNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.TxtNombre.Location = new System.Drawing.Point(224, 203);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(479, 39);
            this.TxtNombre.TabIndex = 28;
            this.TxtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
            this.TxtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNombre_KeyPress);
            // 
            // LblRol
            // 
            this.LblRol.AutoSize = true;
            this.LblRol.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.LblRol.Location = new System.Drawing.Point(220, 380);
            this.LblRol.Name = "LblRol";
            this.LblRol.Size = new System.Drawing.Size(60, 25);
            this.LblRol.TabIndex = 27;
            this.LblRol.Text = "Stock:";
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.LblPassword.Location = new System.Drawing.Point(220, 312);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(98, 25);
            this.LblPassword.TabIndex = 26;
            this.LblPassword.Text = "Categoría:";
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.LblUsuario.Location = new System.Drawing.Point(220, 244);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(115, 25);
            this.LblUsuario.TabIndex = 25;
            this.LblUsuario.Text = "Descripción:";
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.LblNombre.Location = new System.Drawing.Point(220, 176);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(85, 25);
            this.LblNombre.TabIndex = 24;
            this.LblNombre.Text = "Nombre:";
            // 
            // PbLogo
            // 
            this.PbLogo.Image = ((System.Drawing.Image)(resources.GetObject("PbLogo.Image")));
            this.PbLogo.Location = new System.Drawing.Point(12, 12);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(75, 75);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbLogo.TabIndex = 23;
            this.PbLogo.TabStop = false;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnCancelar.Location = new System.Drawing.Point(519, 601);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(184, 42);
            this.BtnCancelar.TabIndex = 34;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click_1);
            // 
            // TxtCodInventario
            // 
            this.TxtCodInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.TxtCodInventario.Location = new System.Drawing.Point(224, 135);
            this.TxtCodInventario.Name = "TxtCodInventario";
            this.TxtCodInventario.Size = new System.Drawing.Size(479, 39);
            this.TxtCodInventario.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label2.Location = new System.Drawing.Point(220, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 35;
            this.label2.Text = "Cod. Inventario:";
            // 
            // TxtStock
            // 
            this.TxtStock.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.TxtStock.Location = new System.Drawing.Point(224, 407);
            this.TxtStock.Name = "TxtStock";
            this.TxtStock.Size = new System.Drawing.Size(479, 39);
            this.TxtStock.TabIndex = 37;
            this.TxtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtStock_KeyPress);
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.TxtPrecio.Location = new System.Drawing.Point(224, 475);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(479, 39);
            this.TxtPrecio.TabIndex = 39;
            this.TxtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecio_KeyPress);
            // 
            // LblPrecio
            // 
            this.LblPrecio.AutoSize = true;
            this.LblPrecio.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.LblPrecio.Location = new System.Drawing.Point(220, 448);
            this.LblPrecio.Name = "LblPrecio";
            this.LblPrecio.Size = new System.Drawing.Size(69, 25);
            this.LblPrecio.TabIndex = 38;
            this.LblPrecio.Text = "Precio:";
            // 
            // CboCategoria
            // 
            this.CboCategoria.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.CboCategoria.FormattingEnabled = true;
            this.CboCategoria.Location = new System.Drawing.Point(224, 339);
            this.CboCategoria.Name = "CboCategoria";
            this.CboCategoria.Size = new System.Drawing.Size(390, 40);
            this.CboCategoria.TabIndex = 40;
            // 
            // BtnAgCategoria
            // 
            this.BtnAgCategoria.Font = new System.Drawing.Font("Segoe UI", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgCategoria.Location = new System.Drawing.Point(620, 339);
            this.BtnAgCategoria.Name = "BtnAgCategoria";
            this.BtnAgCategoria.Size = new System.Drawing.Size(83, 38);
            this.BtnAgCategoria.TabIndex = 41;
            this.BtnAgCategoria.Text = "Agregar";
            this.BtnAgCategoria.UseVisualStyleBackColor = true;
            this.BtnAgCategoria.Click += new System.EventHandler(this.BtnAgCategoria_Click);
            // 
            // FrmGestionInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 676);
            this.Controls.Add(this.BtnAgCategoria);
            this.Controls.Add(this.CboCategoria);
            this.Controls.Add(this.TxtPrecio);
            this.Controls.Add(this.LblPrecio);
            this.Controls.Add(this.TxtStock);
            this.Controls.Add(this.TxtCodInventario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.LblRol);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.LblNombre);
            this.Controls.Add(this.PbLogo);
            this.MaximizeBox = false;
            this.Name = "FrmGestionInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGestionInventario";
            this.Load += new System.EventHandler(this.FrmGestionInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label LblRol;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox TxtCodInventario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtStock;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.Label LblPrecio;
        private System.Windows.Forms.ComboBox CboCategoria;
        private System.Windows.Forms.Button BtnAgCategoria;
    }
}