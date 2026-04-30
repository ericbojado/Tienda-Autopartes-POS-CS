namespace Tienda_Autopartes_ProyectoFinal
{
    partial class FrmGestionUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionUsuarios));
            this.LblNombre = new System.Windows.Forms.Label();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.LblPassword = new System.Windows.Forms.Label();
            this.LblRol = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.CbRol = new System.Windows.Forms.ComboBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.LblNombre.Location = new System.Drawing.Point(220, 122);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(85, 25);
            this.LblNombre.TabIndex = 13;
            this.LblNombre.Text = "Nombre:";
            // 
            // PbLogo
            // 
            this.PbLogo.Image = ((System.Drawing.Image)(resources.GetObject("PbLogo.Image")));
            this.PbLogo.Location = new System.Drawing.Point(12, 12);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(75, 75);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbLogo.TabIndex = 12;
            this.PbLogo.TabStop = false;
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.LblUsuario.Location = new System.Drawing.Point(220, 190);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(81, 25);
            this.LblUsuario.TabIndex = 14;
            this.LblUsuario.Text = "Usuario:";
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.LblPassword.Location = new System.Drawing.Point(220, 258);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(112, 25);
            this.LblPassword.TabIndex = 15;
            this.LblPassword.Text = "Contraseña:";
            this.LblPassword.Click += new System.EventHandler(this.LblPassword_Click);
            // 
            // LblRol
            // 
            this.LblRol.AutoSize = true;
            this.LblRol.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.LblRol.Location = new System.Drawing.Point(220, 326);
            this.LblRol.Name = "LblRol";
            this.LblRol.Size = new System.Drawing.Size(42, 25);
            this.LblRol.TabIndex = 16;
            this.LblRol.Text = "Rol:";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.TxtNombre.Location = new System.Drawing.Point(224, 149);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(479, 39);
            this.TxtNombre.TabIndex = 17;
            this.TxtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNombre_KeyPress);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.TxtUsuario.Location = new System.Drawing.Point(224, 217);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(479, 39);
            this.TxtUsuario.TabIndex = 18;
            this.TxtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUsuario_KeyPress);
            // 
            // TxtPassword
            // 
            this.TxtPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.TxtPassword.Location = new System.Drawing.Point(224, 285);
            this.TxtPassword.MaxLength = 10;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(479, 39);
            this.TxtPassword.TabIndex = 19;
            this.TxtPassword.UseSystemPasswordChar = true;
            this.TxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPassword_KeyPress);
            // 
            // CbRol
            // 
            this.CbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbRol.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.CbRol.FormattingEnabled = true;
            this.CbRol.Items.AddRange(new object[] {
            "Administrador",
            "Operativo"});
            this.CbRol.Location = new System.Drawing.Point(224, 353);
            this.CbRol.Name = "CbRol";
            this.CbRol.Size = new System.Drawing.Size(479, 40);
            this.CbRol.TabIndex = 20;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(224, 436);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(479, 42);
            this.BtnGuardar.TabIndex = 21;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 45);
            this.label1.TabIndex = 22;
            this.label1.Text = "Modificame";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnCancelar.Location = new System.Drawing.Point(519, 484);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(184, 42);
            this.BtnCancelar.TabIndex = 35;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // FrmGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 572);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.CbRol);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.LblRol);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.LblNombre);
            this.Controls.Add(this.PbLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmGestionUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Usuario";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.Label LblRol;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.ComboBox CbRol;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCancelar;
    }
}