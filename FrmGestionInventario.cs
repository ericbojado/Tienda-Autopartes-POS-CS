using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda_Autopartes_ProyectoFinal
{
    public partial class FrmGestionInventario : Form
    {
        private string rutaImagenActual = "imgdefault.jpg";
        private string idProductoActual = null;
        public FrmGestionInventario()
        {
            InitializeComponent();

            //Apartado para AGREGAR
            this.Text = "Inventario - Agregar Nuevo Producto";
            //Cambiar "Modificame" a "Agregar Nuevo Artículo"
            label1.Text = "AGREGAR NUEVO PRODUCTO";
        }
        public FrmGestionInventario(string idProducto, string nombreProducto) //Pasamos id y nombre para actualizar el label
        {
            InitializeComponent();
            //Modificamos el título y el Label
            label1.Text = "Modificar Producto: " + nombreProducto; //Pasamos nombre del producto para el titulo
            this.Text = "Inventario – Modificar Producto";

            idProductoActual = idProducto; // Guarda el ID

            //Llama a la función que busca y llena los TextBox
            CargarDatosProducto(idProducto);

        }
        private void CargarDatosProducto(string id)
        {
            //Consulta para obtener todos los campos del producto basado en el ID
            string consultaSQL = "SELECT [id], [Codigoinventario], [Nombre], [Descripcion], [Categoria], [Stock], [Precio], [RutaImagen] " +
                                 "FROM [Productos] WHERE [Id] = " + id;

            try
            {
                System.Data.DataTable resultado = ConexionBD.EjecutarConsulta(consultaSQL, null);

                if (resultado != null && resultado.Rows.Count > 0)
                {
                    System.Data.DataRow fila = resultado.Rows[0];

                    //Llenar los campos de texto
                    TxtCodInventario.Text = fila["Codigoinventario"].ToString();
                    TxtNombre.Text = fila["Nombre"].ToString();
                    TxtDescripcion.Text = fila["Descripcion"].ToString();
                    TxtStock.Text = fila["Stock"].ToString();
                    TxtPrecio.Text = fila["Precio"].ToString();
                    rutaImagenActual = fila["RutaImagen"].ToString();
                    string catBd = fila["Categoria"].ToString();//variable para guardar la categoria de la BD
                    if (!CboCategoria.Items.Contains(catBd))//si la categoria no se encuentra se agrega como nueva al combo box.
                    {
                        CboCategoria.Items.Add(catBd);
                    }
                    CboCategoria.SelectedItem = catBd;//se selecciona la categoria de la BD en el Cbo.
                }
                else
                {
                    MessageBox.Show("No se encontró el producto con ID: " + id, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void FrmGestionInventario_Load(object sender, EventArgs e)
        {
            // Establecer el campo como solo lectura
            TxtCodInventario.ReadOnly = true;
            //Cambiar el color para indicar visualmente que no se puede editar
            TxtCodInventario.BackColor = System.Drawing.SystemColors.Control;

            TxtNombre.Focus();

            CargarCategoriasExistentes();
            
            //Detectar si estamos modificando o agregndo
            if (!string.IsNullOrEmpty(idProductoActual))
            {
                //Cargar los datos del producto (se llama aquí, en lugar de en el constructor)
                CargarDatosProducto(idProductoActual);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //Recolectar Datos y validar entrada numerica

            string nombre = TxtNombre.Text;
            string descripcion = TxtDescripcion.Text;
            string consultaSQL = "";
            string mensajeExito = "";
            string rutaImagen = "imgdefault.jpg";
            string categoria = "";
            if (CboCategoria.SelectedItem != null)
            {
                categoria = CboCategoria.SelectedItem.ToString();
            }
            int stock = 0;
            decimal precio = 0;

            //Validar todos los textBox
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(descripcion) ||
                string.IsNullOrWhiteSpace(categoria))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios (Código de Inventario, Nombre, Descripción y Categoría).",
                                "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //Detiene la ejecución
            }
            //Validar Stock
            if (!int.TryParse(TxtStock.Text, out stock))
            {
                MessageBox.Show("El Stock debe ser un número entero válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar Precio
            if (!decimal.TryParse(TxtPrecio.Text, out precio))
            {
                MessageBox.Show("El Precio debe ser un valor monetario válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Forzar el uso de punto (.) en lugar de coma (,)
            string precioSQL = precio.ToString(System.Globalization.CultureInfo.InvariantCulture);

            //Variable final para el código
            string codigoFinalGuardar = "";

            //Si idProductoActual tiene un valor, estamos MODIFICANDO (UPDATE)
            if (idProductoActual != null)
            {
                // Si modificamos, mantenemos el código que ya tenía en el TextBox (no lo regeneramos)
                codigoFinalGuardar = TxtCodInventario.Text;
                //Consulta UPDATE: Actualiza los campos donde el ID coincida
                consultaSQL = "UPDATE Productos SET " +
                              "Codigoinventario = '" + codigoFinalGuardar + "', " +
                              "Nombre = '" + nombre + "', " +
                              "Descripcion = '" + descripcion + "', " +
                              "Categoria = '" + categoria + "', " +
                              "Stock = " + stock.ToString() + ", " +
                              "Precio = " + precioSQL + ", " +
                              "RutaImagen = '" + rutaImagen + "' " +
                              "WHERE id = " + idProductoActual;

                mensajeExito = "Producto modificado con éxito.";
            }
            else //Si idProductoActual es null, estamos AGREGANDO (INSERT)
            {
                //Generamos el código automático
                codigoFinalGuardar = GenerarNuevoCodigo(categoria, nombre);

                //Lo mostramos en el TextBox antes de guardar para que el usuario lo vea
                TxtCodInventario.Text = codigoFinalGuardar;

                //Consulta INSERT SQL
                consultaSQL = "INSERT INTO Productos (Codigoinventario, Nombre, Descripcion, Categoria, Stock, Precio, RutaImagen) " +
                              "VALUES ('" + codigoFinalGuardar + "', '" + nombre + "', '" + descripcion + "', '" + categoria + "', " +
                               stock.ToString() + ", " + precioSQL + ", '" + rutaImagen + "')";

                mensajeExito = "Producto agregado al inventario con éxito.";
            }

            try
            {
                ConexionBD.EjecutarConsulta(consultaSQL, null);

                MessageBox.Show(mensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Cerrar el formulario.
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto en la base de datos: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarCategoriasExistentes()
        {
            CboCategoria.Items.Clear();
            // Usamos DISTINCT para no repetir categorías
            string sql = "SELECT DISTINCT [Categoria] FROM [Productos] WHERE [Categoria] IS NOT NULL ORDER BY [Categoria]";

            try
            {
                DataTable dt = ConexionBD.EjecutarConsulta(sql, null);
                foreach (DataRow row in dt.Rows)
                {
                    CboCategoria.Items.Add(row["Categoria"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }
        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validar que no se introduzcan carácteres especiales.
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;

                //Avisar al usuario con un sonido
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void TxtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validar que no se introduzcan carácteres especiales.
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',' && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;

                //Avisar al usuario con un sonido
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validar que no se introduzcan letras ni carácteres especiales.
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                //Avisar al usuario con un sonido
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validar que no se introduzcan letras ni carácteres especiales a exepción de "," y "." para los decimales
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;

                //Avisar al usuario con un sonido
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void BtnAgCategoria_Click(object sender, EventArgs e)
        {
            // Usamos nuestra nueva clase InputBox creada abajo
            string nuevaCat = InputBox.Show("Nueva Categoría", "Escriba el nombre de la nueva categoría:");

            if (!string.IsNullOrWhiteSpace(nuevaCat))
            {
                nuevaCat = nuevaCat.Trim(); // Limpiamos espacios vacíos

                // Verificamos si ya existe en el combo para no duplicar
                if (!CboCategoria.Items.Contains(nuevaCat))
                {
                    CboCategoria.Items.Add(nuevaCat);
                    CboCategoria.SelectedItem = nuevaCat; // La seleccionamos automáticamente
                }
                else
                {
                    MessageBox.Show("Esa categoría ya existe en la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CboCategoria.SelectedItem = nuevaCat;
                }
            }
        }
        private string GenerarNuevoCodigo(string categoria, string nombre)
        {
            //Validaciones de seguridad
            if (string.IsNullOrEmpty(categoria) || string.IsNullOrEmpty(nombre)) return "GEN-ERR-000";

            //Obtener las siglas (3 letras categoría - 3 letras nombre)
            string catPart = categoria;
            if (categoria.Length >= 3)
            {
                catPart = categoria.Substring(0, 3);
            }

            string nomPart = nombre;
            if (nombre.Length >= 3)
            {
                nomPart = nombre.Substring(0, 3);
            }

            //Convertimos a Mayúsculas y armamos el prefijo (ej: "FR-BAL-")
            string prefijo = $"{catPart.ToUpper()}-{nomPart.ToUpper()}-";

            //Buscar en la BD el número más alto existente con ese prefijo, la consulta busca todo lo que empiece con "FR-BAL-"
            string sql = $"SELECT Codigoinventario FROM Productos WHERE Codigoinventario LIKE '{prefijo}%'";

            int maxNumero = 0;

            try
            {
                DataTable dt = ConexionBD.EjecutarConsulta(sql, null);

                //Recorremos los resultados para encontrar el número mayor
                foreach (DataRow row in dt.Rows)
                {
                    string codigoBd = row["Codigoinventario"].ToString();
                    //El código viene así: FR-BAL-005
                    //Lo partimos por guiones
                    string[] partes = codigoBd.Split('-');

                    //La parte numérica es la última (índice 2)
                    if (partes.Length >= 3)
                    {
                        if (int.TryParse(partes[partes.Length - 1], out int numeroEncontrado))
                        {
                            if (numeroEncontrado > maxNumero) maxNumero = numeroEncontrado;
                        }
                    }
                }
            }
            catch
            {
                //Si falla la conexión, asumimos que es el primero
                maxNumero = 0;
            }

            //Sumamos 1 al máximo encontrado
            int siguienteNumero = maxNumero + 1;

            //Retornamos el código formateado con ceros a la izquierda (D3 = 3 dígitos)
            //Resultado: FR-BAL-001
            return $"{prefijo}{siguienteNumero.ToString("D3")}";
        }
    }
    //Clase para crear una ventana donde vamos a introducir una nueva categoria
    public static class InputBox
    {
        public static string Show(string title, string promptText)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            //Configuración de la ventana
            form.Text = title;
            label.Text = promptText;
            buttonOk.Text = "Aceptar";
            buttonCancel.Text = "Cancelar";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            //Diseño y Posición
            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            //Propiedades de la ventana
            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            //Mostrar y devolver resultado
            DialogResult dialogResult = form.ShowDialog();
            return dialogResult == DialogResult.OK ? textBox.Text : "";
        }
    }
}
