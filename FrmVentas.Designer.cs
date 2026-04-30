namespace Tienda_Autopartes_ProyectoFinal
{
    partial class FrmVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentas));
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.LvProductos = new System.Windows.Forms.ListView();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.BtnAgregarCarrito = new System.Windows.Forms.Button();
            this.LvCarrito = new System.Windows.Forms.ListView();
            this.LblCarrito = new System.Windows.Forms.Label();
            this.BtnCobrar = new System.Windows.Forms.Button();
            this.BtnRegresar = new System.Windows.Forms.Button();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.NUDCantidad = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.Location = new System.Drawing.Point(19, 100);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(464, 43);
            this.TxtBuscar.TabIndex = 25;
            // 
            // LvProductos
            // 
            this.LvProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvProductos.HideSelection = false;
            this.LvProductos.Location = new System.Drawing.Point(19, 148);
            this.LvProductos.Name = "LvProductos";
            this.LvProductos.Size = new System.Drawing.Size(600, 460);
            this.LvProductos.TabIndex = 24;
            this.LvProductos.UseCompatibleStateImageBehavior = false;
            this.LvProductos.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvProductos_ColumnClick);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.Location = new System.Drawing.Point(489, 100);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnBuscar.Size = new System.Drawing.Size(130, 42);
            this.BtnBuscar.TabIndex = 23;
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // PbLogo
            // 
            this.PbLogo.Image = ((System.Drawing.Image)(resources.GetObject("PbLogo.Image")));
            this.PbLogo.Location = new System.Drawing.Point(12, 12);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(75, 75);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbLogo.TabIndex = 26;
            this.PbLogo.TabStop = false;
            // 
            // BtnAgregarCarrito
            // 
            this.BtnAgregarCarrito.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.BtnAgregarCarrito.Location = new System.Drawing.Point(419, 614);
            this.BtnAgregarCarrito.Name = "BtnAgregarCarrito";
            this.BtnAgregarCarrito.Size = new System.Drawing.Size(200, 40);
            this.BtnAgregarCarrito.TabIndex = 35;
            this.BtnAgregarCarrito.Text = "Agregar al carrito";
            this.BtnAgregarCarrito.UseVisualStyleBackColor = true;
            this.BtnAgregarCarrito.Click += new System.EventHandler(this.BtnAgregarCarrito_Click);
            // 
            // LvCarrito
            // 
            this.LvCarrito.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvCarrito.HideSelection = false;
            this.LvCarrito.Location = new System.Drawing.Point(646, 148);
            this.LvCarrito.Name = "LvCarrito";
            this.LvCarrito.Size = new System.Drawing.Size(600, 460);
            this.LvCarrito.TabIndex = 36;
            this.LvCarrito.UseCompatibleStateImageBehavior = false;
            this.LvCarrito.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvCarrito_ColumnClick);
            // 
            // LblCarrito
            // 
            this.LblCarrito.AutoSize = true;
            this.LblCarrito.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCarrito.Location = new System.Drawing.Point(641, 106);
            this.LblCarrito.Name = "LblCarrito";
            this.LblCarrito.Size = new System.Drawing.Size(95, 32);
            this.LblCarrito.TabIndex = 37;
            this.LblCarrito.Text = "Carrito:";
            // 
            // BtnCobrar
            // 
            this.BtnCobrar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.BtnCobrar.Location = new System.Drawing.Point(1046, 614);
            this.BtnCobrar.Name = "BtnCobrar";
            this.BtnCobrar.Size = new System.Drawing.Size(200, 40);
            this.BtnCobrar.TabIndex = 38;
            this.BtnCobrar.TabStop = false;
            this.BtnCobrar.Text = "Cobrar";
            this.BtnCobrar.UseVisualStyleBackColor = true;
            this.BtnCobrar.Click += new System.EventHandler(this.BtnCobrar_Click);
            // 
            // BtnRegresar
            // 
            this.BtnRegresar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnRegresar.Location = new System.Drawing.Point(1113, 11);
            this.BtnRegresar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnRegresar.Name = "BtnRegresar";
            this.BtnRegresar.Size = new System.Drawing.Size(140, 30);
            this.BtnRegresar.TabIndex = 42;
            this.BtnRegresar.TabStop = false;
            this.BtnRegresar.Text = "Regresar";
            this.BtnRegresar.UseVisualStyleBackColor = true;
            this.BtnRegresar.Click += new System.EventHandler(this.BtnRegresar_Click);
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblCantidad.Location = new System.Drawing.Point(1126, 114);
            this.LblCantidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(79, 21);
            this.LblCantidad.TabIndex = 44;
            this.LblCantidad.Text = "Cantidad: ";
            // 
            // NUDCantidad
            // 
            this.NUDCantidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.NUDCantidad.Location = new System.Drawing.Point(1212, 112);
            this.NUDCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.NUDCantidad.Name = "NUDCantidad";
            this.NUDCantidad.Size = new System.Drawing.Size(34, 29);
            this.NUDCantidad.TabIndex = 43;
            this.NUDCantidad.ValueChanged += new System.EventHandler(this.NUDCantidad_ValueChanged);
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.LblCantidad);
            this.Controls.Add(this.NUDCantidad);
            this.Controls.Add(this.BtnRegresar);
            this.Controls.Add(this.BtnCobrar);
            this.Controls.Add(this.LblCarrito);
            this.Controls.Add(this.LvCarrito);
            this.Controls.Add(this.BtnAgregarCarrito);
            this.Controls.Add(this.PbLogo);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.LvProductos);
            this.Controls.Add(this.BtnBuscar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venta";
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.ListView LvProductos;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.Button BtnAgregarCarrito;
        private System.Windows.Forms.ListView LvCarrito;
        private System.Windows.Forms.Label LblCarrito;
        private System.Windows.Forms.Button BtnCobrar;
        private System.Windows.Forms.Button BtnRegresar;
        private System.Windows.Forms.Label LblCantidad;
        private System.Windows.Forms.NumericUpDown NUDCantidad;
    }
}