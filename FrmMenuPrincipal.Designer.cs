namespace Tienda_Autopartes_ProyectoFinal
{
    partial class FrmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.BtnGestionUsuarios = new System.Windows.Forms.Button();
            this.BtnInventario = new System.Windows.Forms.Button();
            this.BtnVentas = new System.Windows.Forms.Button();
            this.BtnCorteCaja = new System.Windows.Forms.Button();
            this.BtnCerrarSesion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PbLogo
            // 
            this.PbLogo.Image = ((System.Drawing.Image)(resources.GetObject("PbLogo.Image")));
            this.PbLogo.Location = new System.Drawing.Point(170, 140);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(400, 400);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbLogo.TabIndex = 1;
            this.PbLogo.TabStop = false;
            // 
            // BtnGestionUsuarios
            // 
            this.BtnGestionUsuarios.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGestionUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("BtnGestionUsuarios.Image")));
            this.BtnGestionUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGestionUsuarios.Location = new System.Drawing.Point(644, 68);
            this.BtnGestionUsuarios.Name = "BtnGestionUsuarios";
            this.BtnGestionUsuarios.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnGestionUsuarios.Size = new System.Drawing.Size(450, 100);
            this.BtnGestionUsuarios.TabIndex = 2;
            this.BtnGestionUsuarios.Text = "Gestión de Usuarios";
            this.BtnGestionUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGestionUsuarios.UseVisualStyleBackColor = true;
            this.BtnGestionUsuarios.Click += new System.EventHandler(this.BtnGestionUsuarios_Click);
            // 
            // BtnInventario
            // 
            this.BtnInventario.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInventario.Image = ((System.Drawing.Image)(resources.GetObject("BtnInventario.Image")));
            this.BtnInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnInventario.Location = new System.Drawing.Point(644, 216);
            this.BtnInventario.Name = "BtnInventario";
            this.BtnInventario.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnInventario.Size = new System.Drawing.Size(450, 100);
            this.BtnInventario.TabIndex = 3;
            this.BtnInventario.Text = "Inventario";
            this.BtnInventario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnInventario.UseVisualStyleBackColor = true;
            this.BtnInventario.Click += new System.EventHandler(this.BtnInventario_Click);
            // 
            // BtnVentas
            // 
            this.BtnVentas.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVentas.Image = ((System.Drawing.Image)(resources.GetObject("BtnVentas.Image")));
            this.BtnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnVentas.Location = new System.Drawing.Point(644, 364);
            this.BtnVentas.Name = "BtnVentas";
            this.BtnVentas.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnVentas.Size = new System.Drawing.Size(450, 100);
            this.BtnVentas.TabIndex = 4;
            this.BtnVentas.Text = "Ventas";
            this.BtnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnVentas.UseVisualStyleBackColor = true;
            this.BtnVentas.Click += new System.EventHandler(this.BtnVentas_Click);
            // 
            // BtnCorteCaja
            // 
            this.BtnCorteCaja.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCorteCaja.Image = ((System.Drawing.Image)(resources.GetObject("BtnCorteCaja.Image")));
            this.BtnCorteCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCorteCaja.Location = new System.Drawing.Point(644, 512);
            this.BtnCorteCaja.Name = "BtnCorteCaja";
            this.BtnCorteCaja.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnCorteCaja.Size = new System.Drawing.Size(450, 100);
            this.BtnCorteCaja.TabIndex = 5;
            this.BtnCorteCaja.Text = "Corte de caja";
            this.BtnCorteCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCorteCaja.UseVisualStyleBackColor = true;
            this.BtnCorteCaja.Click += new System.EventHandler(this.BtnCorteCaja_Click);
            // 
            // BtnCerrarSesion
            // 
            this.BtnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnCerrarSesion.Location = new System.Drawing.Point(12, 12);
            this.BtnCerrarSesion.Name = "BtnCerrarSesion";
            this.BtnCerrarSesion.Size = new System.Drawing.Size(140, 30);
            this.BtnCerrarSesion.TabIndex = 6;
            this.BtnCerrarSesion.Text = "Cerrar Sesión";
            this.BtnCerrarSesion.UseVisualStyleBackColor = true;
            this.BtnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.BtnCerrarSesion);
            this.Controls.Add(this.BtnCorteCaja);
            this.Controls.Add(this.BtnVentas);
            this.Controls.Add(this.BtnInventario);
            this.Controls.Add(this.BtnGestionUsuarios);
            this.Controls.Add(this.PbLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.Button BtnGestionUsuarios;
        private System.Windows.Forms.Button BtnInventario;
        private System.Windows.Forms.Button BtnVentas;
        private System.Windows.Forms.Button BtnCorteCaja;
        private System.Windows.Forms.Button BtnCerrarSesion;
    }
}