using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda_Autopartes_ProyectoFinal
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            if (FrmLogin.RolActual != "Administrador")//Esto desahabilita los botones en caso de que el usuario que ingreso no sea admin
            {
                BtnGestionUsuarios.Enabled = false;//Deshabilita el botón
                BtnGestionUsuarios.Visible = false;//Lo vuelve invisible
            }
        }

        private void BtnGestionUsuarios_Click(object sender, EventArgs e)
        {
            FrmCrudUsuarios ventana = new FrmCrudUsuarios(this); //Declara la ventana de usuarios como un elemento
            ventana.Show();//Muestra la ventana de los usuarios
            this.Hide(); //Esto oculta la ventana
        }

        private void BtnInventario_Click(object sender, EventArgs e)
        {
            FrmInventario ventana = new FrmInventario(this); //Declara la ventana de usuarios como un elemento
            ventana.Show();//Muestra la ventana de inventario
            this.Hide(); //Esto oculta la ventana
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            FrmVentas ventana = new FrmVentas(this); //Declara la ventana de usuarios como un elemento
            ventana.Show();//Muestra la ventana de ventas
            this.Hide(); //Esto oculta la ventana
        }

        private void BtnCorteCaja_Click(object sender, EventArgs e)
        {
            FrmCorteCaja ventana = new FrmCorteCaja(this); //Declara la ventana de usuarios como un elemento
            ventana.Show();//Muestra la ventana del corte de caja
            this.Hide(); //Esto oculta la ventana
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estas seguro de que desea cerrar sesión?", "--ATENCIÓN--", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                FrmLogin.UsuarioActual = null;//Se borra el usuario volviendo el valor null y asi no use el usuario anterior en los procesos futuros sino el nuevo que logie
                FrmLogin.RolActual = null;//Se borra el rol del usuario volviendo el valor null y asi no use el rol del usuario anterior en los procesos futuros sino el nuevo que logie

                this.Close();//Cierra la venta

                FrmLogin PestañaLogin = new FrmLogin();
                PestañaLogin.Show();
            }
        }
    }
}
