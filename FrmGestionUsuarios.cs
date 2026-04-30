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
    public partial class FrmGestionUsuarios : Form
    {
        private string idRegistroActual = null;
        public FrmGestionUsuarios()
        {
            InitializeComponent();

            //Apartado para AGREGAR
            this.Text = "Usuarios - Agregar Nuevo Usuario";
            //Cambiar "Modificame" a "Agregar Nuevo Usuario"
            label1.Text = "AGREGAR NUEVO USUARIO";
        }
        public FrmGestionUsuarios(string idUsuario)
        {
            InitializeComponent();
            //Modificamos el título y el Label
            label1.Text = "Modificar Usuario: ";
            this.Text = "Usuarios – Modificar Usuario";

            idRegistroActual = idUsuario; //Guarda el ID

            //Llama a la función que busca y llena los TextBox
            CargarDatosUsuario(idUsuario);

        }
        private bool VerificarExistencia(string usuario, string idExcluir = null)
        {
            string sql = "SELECT COUNT(*) FROM Usuarios WHERE [Usuario] = '" + usuario + "'";

            // Si nos pasan un ID para excluir (caso Modificar), lo agregamos a la consulta
            if (idExcluir != null)
            {
                sql += " AND [Id] <> " + idExcluir;
            }

            DataTable resultado = ConexionBD.EjecutarConsulta(sql, null);

            if (resultado != null && resultado.Rows.Count > 0)
            {
                int cantidad = Convert.ToInt32(resultado.Rows[0][0]);
                return cantidad > 0;
            }

            return false;
        }

        private void CargarDatosUsuario(string id)
        {
            //Consulta para obtener todos los campos del usuario basado en el ID
            string consultaSQL = "SELECT [NombreCompleto], [Usuario], [Password], [Rol] FROM [Usuarios] WHERE [Id] = " + id;

            try
            {
                System.Data.DataTable resultado = ConexionBD.EjecutarConsulta(consultaSQL, null);

                if (resultado != null && resultado.Rows.Count > 0)
                {
                    System.Data.DataRow fila = resultado.Rows[0];
                    //Llenar los campos de texto
                    TxtNombre.Text = fila["NombreCompleto"].ToString();
                    TxtUsuario.Text = fila["Usuario"].ToString();
                    TxtPassword.Text = fila["Password"].ToString();
                    CbRol.SelectedItem = fila["Rol"].ToString();

                }
                else
                {
                    MessageBox.Show("No se encontró el usuario con ID: " + id, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = TxtNombre.Text;
            string usuario = TxtUsuario.Text;
            string password = TxtPassword.Text;
            string rol = "";
            if (CbRol.SelectedItem != null)
            {
                rol = CbRol.SelectedItem.ToString();
            }
            string consultaSQL = "";
            string mensajeExito = "";

            if (string.IsNullOrWhiteSpace(nombre) ||
               string.IsNullOrWhiteSpace(usuario) ||
               string.IsNullOrWhiteSpace(password) ||
               string.IsNullOrWhiteSpace(rol))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios (Nombre, Usuario, Password, Rol).",
                                "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idRegistroActual != null)
            {
                if (VerificarExistencia(usuario, idRegistroActual))
                {
                    MessageBox.Show(
                        "El nombre de usuario ya existe, elija otro.",
                        "Usuario Duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                consultaSQL =
                    "UPDATE [Usuarios] SET " +
                    "[NombreCompleto] = '" + nombre + "', " +
                    "[Usuario] = '" + usuario + "', " +
                    "[Password] = '" + password + "', " +
                    "[Rol] = '" + rol + "' " +
                    "WHERE Id = " + idRegistroActual;

                mensajeExito = "Usuario modificado con éxito.";
            }
            else
            {
                if (VerificarExistencia(usuario))
                {
                    MessageBox.Show(
                        "El nombre de usuario ya existe, elija otro.",
                        "Usuario Duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                consultaSQL =
                    "INSERT INTO Usuarios ([NombreCompleto], [Usuario], [Password], [Rol])" +
                    "VALUES ('" + nombre + "', '" + usuario + "', '" + password + "', '" + rol + "')";

                mensajeExito = "Usuario agregado con éxito.";
            }

            try
            {
                ConexionBD.EjecutarConsulta(consultaSQL, null);

                MessageBox.Show(mensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar el registro en la base de datos: " + ex.Message,
                    "Error de BD",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validar que no se introduzcan números ni carácteres especiales.
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;

                //Avisar al usuario con un sonido
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validar que no se introduzcan carácteres especiales.
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;

                //Avisar al usuario con un sonido
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validar que no inntroduzcan espacios
            if(char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;

                //Avisar al usuario con un sonido
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void LblPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
