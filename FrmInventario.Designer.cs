namespace Tienda_Autopartes_ProyectoFinal
{
    partial class FrmInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventario));
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.LvProductos = new System.Windows.Forms.ListView();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.RdBusqAprox = new System.Windows.Forms.RadioButton();
            this.RdBusqExac = new System.Windows.Forms.RadioButton();
            this.PbImgProducto = new System.Windows.Forms.PictureBox();
            this.CboCampo = new System.Windows.Forms.ComboBox();
            this.BtnRegresar = new System.Windows.Forms.Button();
            this.LblNumProductos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbImgProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // PbLogo
            // 
            this.PbLogo.Image = ((System.Drawing.Image)(resources.GetObject("PbLogo.Image")));
            this.PbLogo.Location = new System.Drawing.Point(12, 12);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(75, 75);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbLogo.TabIndex = 19;
            this.PbLogo.TabStop = false;
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.TxtBuscar.Location = new System.Drawing.Point(21, 126);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(684, 43);
            this.TxtBuscar.TabIndex = 22;
            // 
            // LvProductos
            // 
            this.LvProductos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LvProductos.HideSelection = false;
            this.LvProductos.Location = new System.Drawing.Point(21, 174);
            this.LvProductos.Name = "LvProductos";
            this.LvProductos.Size = new System.Drawing.Size(906, 411);
            this.LvProductos.TabIndex = 21;
            this.LvProductos.UseCompatibleStateImageBehavior = false;
            this.LvProductos.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvProductos_ColumnClick);
            this.LvProductos.SelectedIndexChanged += new System.EventHandler(this.LvProductos_SelectedIndexChanged);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscar.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.Location = new System.Drawing.Point(711, 126);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnBuscar.Size = new System.Drawing.Size(217, 42);
            this.BtnBuscar.TabIndex = 20;
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.BtnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnModificar.Location = new System.Drawing.Point(727, 591);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnModificar.Size = new System.Drawing.Size(200, 40);
            this.BtnModificar.TabIndex = 25;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEliminar.Location = new System.Drawing.Point(374, 591);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnEliminar.Size = new System.Drawing.Size(200, 40);
            this.BtnEliminar.TabIndex = 24;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregar.Location = new System.Drawing.Point(21, 591);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnAgregar.Size = new System.Drawing.Size(200, 40);
            this.BtnAgregar.TabIndex = 23;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // RdBusqAprox
            // 
            this.RdBusqAprox.AutoSize = true;
            this.RdBusqAprox.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.RdBusqAprox.Location = new System.Drawing.Point(307, 89);
            this.RdBusqAprox.Name = "RdBusqAprox";
            this.RdBusqAprox.Size = new System.Drawing.Size(220, 29);
            this.RdBusqAprox.TabIndex = 27;
            this.RdBusqAprox.TabStop = true;
            this.RdBusqAprox.Text = "Búsqueda Aproximada";
            this.RdBusqAprox.UseVisualStyleBackColor = true;
            // 
            // RdBusqExac
            // 
            this.RdBusqExac.AutoSize = true;
            this.RdBusqExac.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdBusqExac.Location = new System.Drawing.Point(533, 90);
            this.RdBusqExac.Name = "RdBusqExac";
            this.RdBusqExac.Size = new System.Drawing.Size(172, 29);
            this.RdBusqExac.TabIndex = 26;
            this.RdBusqExac.TabStop = true;
            this.RdBusqExac.Text = "Búsqueda Exacta";
            this.RdBusqExac.UseVisualStyleBackColor = true;
            // 
            // PbImgProducto
            // 
            this.PbImgProducto.Location = new System.Drawing.Point(933, 213);
            this.PbImgProducto.Name = "PbImgProducto";
            this.PbImgProducto.Size = new System.Drawing.Size(311, 321);
            this.PbImgProducto.TabIndex = 28;
            this.PbImgProducto.TabStop = false;
            // 
            // CboCampo
            // 
            this.CboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboCampo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboCampo.FormattingEnabled = true;
            this.CboCampo.Items.AddRange(new object[] {
            "Nombre",
            "Código de inventario",
            "Precio"});
            this.CboCampo.Location = new System.Drawing.Point(711, 92);
            this.CboCampo.Name = "CboCampo";
            this.CboCampo.Size = new System.Drawing.Size(216, 29);
            this.CboCampo.TabIndex = 29;
            this.CboCampo.SelectedIndexChanged += new System.EventHandler(this.CboCampo_SelectedIndexChanged);
            // 
            // BtnRegresar
            // 
            this.BtnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRegresar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnRegresar.Location = new System.Drawing.Point(1112, 12);
            this.BtnRegresar.Name = "BtnRegresar";
            this.BtnRegresar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BtnRegresar.Size = new System.Drawing.Size(140, 30);
            this.BtnRegresar.TabIndex = 30;
            this.BtnRegresar.Text = "Regresar";
            this.BtnRegresar.UseVisualStyleBackColor = true;
            this.BtnRegresar.Click += new System.EventHandler(this.BtnRegresar_Click);
            // 
            // LblNumProductos
            // 
            this.LblNumProductos.AutoSize = true;
            this.LblNumProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.LblNumProductos.Location = new System.Drawing.Point(17, 95);
            this.LblNumProductos.Name = "LblNumProductos";
            this.LblNumProductos.Size = new System.Drawing.Size(160, 21);
            this.LblNumProductos.TabIndex = 40;
            this.LblNumProductos.Text = "Num. de Productos:";
            // 
            // FrmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.LblNumProductos);
            this.Controls.Add(this.BtnRegresar);
            this.Controls.Add(this.CboCampo);
            this.Controls.Add(this.PbImgProducto);
            this.Controls.Add(this.RdBusqAprox);
            this.Controls.Add(this.RdBusqExac);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.LvProductos);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.PbLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmInventario";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInventario";
            this.Load += new System.EventHandler(this.FrmInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbImgProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.ListView LvProductos;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.RadioButton RdBusqAprox;
        private System.Windows.Forms.RadioButton RdBusqExac;
        private System.Windows.Forms.PictureBox PbImgProducto;
        private System.Windows.Forms.ComboBox CboCampo;
        private System.Windows.Forms.Button BtnRegresar;
        private System.Windows.Forms.Label LblNumProductos;
    }
}