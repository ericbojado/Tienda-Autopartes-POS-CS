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
    public partial class FrmInventario : Form
    {
        private Form volvermenu;//Se almacenara el from menu principal, ya que el botón regresar vuelve a este
        private int columnaOrdenada = -1; //Sirve para ordenar
        public FrmInventario(Form volver)
        {
            InitializeComponent();
            volvermenu = volver;
        }
        private void ConfigurarListView()
        {
            //Configurar ListView
            LvProductos.View = View.Details;
            LvProductos.FullRowSelect = true;
            LvProductos.GridLines = true;
            LvProductos.LabelEdit = false;

            //Definición de Columnas.
            LvProductos.Columns.Clear();
            LvProductos.Columns.Add("ID", 0, HorizontalAlignment.Left);
            LvProductos.Columns.Add("Cod. Inventario", 100, HorizontalAlignment.Left);
            LvProductos.Columns.Add("Nombre", 250, HorizontalAlignment.Left);
            LvProductos.Columns.Add("Descripción", 200, HorizontalAlignment.Center);
            LvProductos.Columns.Add("Categoría", 120, HorizontalAlignment.Left);
            LvProductos.Columns.Add("Stock", 80, HorizontalAlignment.Left);
            LvProductos.Columns.Add("Precio", 80, HorizontalAlignment.Left);
            LvProductos.Columns.Add("Imagen", 0, HorizontalAlignment.Left);
        }
        private void AplicarSeguridadCRUD()
        {
            //Verificamos si el Rol Registrado es Operativo o Administrador
            string rolUsuario = FrmLogin.RolActual;

            if (rolUsuario == "Operativo")
            {
                //Ocultar botones de modificación de datos
                BtnAgregar.Visible = false;
                BtnModificar.Visible = false;
                BtnEliminar.Visible = false;
            }
            //Si es Administrador, los botones se quedan visibles por defecto.
        }

        private void MostrarResultadosEnListView(System.Data.DataTable dt)
        {

            LvProductos.Items.Clear(); //Limpia la lista antes de añadir nuevos resultados

            foreach (System.Data.DataRow fila in dt.Rows)
            {
                //Crea el Item (usando el ID como columna principal, que es la que se usa para Modificar/Eliminar)
                //La columna 'ID' debe ser la primera para que FrmInventario la pueda usar.
                ListViewItem item = new ListViewItem(fila["Id"].ToString());

                //Guardar ID real (IdProducto) en el .Tag para MODIFICAR/ELIMINAR
                item.SubItems.Add(fila["Codigoinventario"].ToString());
                item.SubItems.Add(fila["Nombre"].ToString());
                item.SubItems.Add(fila["Descripcion"].ToString());
                item.SubItems.Add(fila["Categoria"].ToString());
                item.SubItems.Add(fila["Stock"].ToString());
                item.SubItems.Add(Convert.ToDecimal(fila["Precio"]).ToString("C2")); //Agrega Precio, formateado como moneda
                item.Tag = fila["id"].ToString();
                item.SubItems.Add(fila["RutaImagen"].ToString());

                LvProductos.Items.Add(item); //Se agregan las filas y datos correspondientes al listView
            }
            //Actualizar los registros mostrados en el label
            LblNumProductos.Text = "Num. de Productos: " + dt.Rows.Count.ToString();
        }
        private void FrmInventario_Load(object sender, EventArgs e)
        {
            RdBusqAprox.Checked = true;
            //Configurar la vista de la lista
            ConfigurarListView();

            //Aplicar Seguridad por Rol (Ocultar botones si es Operativo)
            AplicarSeguridadCRUD();

            //Seleccionar el primer campo de búsqueda (Indice 0 es "Nombre")
            CboCampo.SelectedIndex = 0;

            //Carga Inicial de Productos
            //Aseguramos que la caja de texto esté limpia para traer todos los productos
            TxtBuscar.Text = string.Empty;

            BtnBuscar_Click(null, null);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            //Se agrega ComboBox y se implementa para una mejor Busqueda
            string campo = CboCampo.SelectedItem.ToString();
            string termino = TxtBuscar.Text.Trim();
            string clausulaWHERE = "";

            string terminoLimpio = termino.Replace("'", "''");

            //Mapeo del Campo Seleccionado al Nombre de Columna REAL de la BD
            string campoSQL = campo;
            bool esCampoNumerico = false;


            string campoCombo = CboCampo.SelectedItem.ToString().Trim().ToUpperInvariant();
            //Usamos el nombre que el usuario ve en el ComboBox para el mapeo
            if (campo == "Código de inventario")
            {
                //Usamos corchetes para Access y el nombre de la columna.
                campoSQL = "[Codigoinventario]";
                esCampoNumerico = false;
            }
            else if (campo == "Precio")
            {
                campoSQL = "Precio";
                esCampoNumerico = true;
            }
            else //Asumimos que es Nombre si no es Precio ni Código Inventario
            {
                campoSQL = "Nombre";
                esCampoNumerico = false;
            }
            //Construir la cláusula WHERE y el valor del parámetro
            if (!string.IsNullOrEmpty(termino))
            {
                if (RdBusqExac.Checked)
                {
                    //Búsqueda exacta (=)
                    if (esCampoNumerico) //Logica para precio
                    {
                        if (decimal.TryParse(termino,
                         System.Globalization.NumberStyles.Any, //Permite estilos como $, comas, etc.
                         System.Globalization.CultureInfo.CurrentCulture, //Usar la cultura actual del usuario
                         out decimal valorNumerico))
                        {
                            //Usar InvariantCulture para forzar el PUNTO decimal en la consulta SQL
                            string valorSQL = valorNumerico.ToString(System.Globalization.CultureInfo.InvariantCulture);

                            //NUEVA CLAVE: Se encierra el valor en CDbl() para que Access lo reconozca como número.
                            clausulaWHERE = " WHERE " + campoSQL + " = CDbl('" + valorSQL + "')";
                        }
                        else
                        {
                            MessageBox.Show("El campo " + campo + " debe ser un número entero válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Detiene la búsqueda
                        }
                    }
                    else //Si NO es Campo Numérico (es Nombre o Codigoinventario)
                    {
                        clausulaWHERE = " WHERE " + campoSQL + " = '" + terminoLimpio + "'";
                    }
                }
                else if (RdBusqAprox.Checked)
                {
                    if (!esCampoNumerico)
                    {
                        //Lógica Aproximada: Usa comodines '%...%'
                        clausulaWHERE = " WHERE " + campoSQL + " LIKE '%" + terminoLimpio + "%'";
                    }
                    else
                    {
                        //Evitar búsquedas LIKE en campos numéricos
                        MessageBox.Show("La búsqueda aproximada no es apropiada para el campo precio, que es numérico.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Detiene la búsqueda
                    }
                }
            }

            //Preparar la Consulta SQL
            string consultaSQL = $"SELECT id, Codigoinventario, Nombre, Descripcion, Categoria, Stock, Precio, RutaImagen FROM Productos {clausulaWHERE}";

            try
            {
                System.Data.DataTable resultados = ConexionBD.EjecutarConsulta(consultaSQL, null);
                //Mostrar Resultados
                MostrarResultadosEnListView(resultados);
            }
            catch (Exception ex)
            {
                //Esto atrapará errores de la BD, evitando que el formulario se rompa al iniciar.
                MessageBox.Show("Error al ejecutar la búsqueda: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmGestionInventario agregarInventario = new FrmGestionInventario();
            agregarInventario.ShowDialog();
            BtnBuscar_Click(null, null);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            //Verificar si hay un producto seleccionado en el ListView
            if (LvProductos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un producto de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Obtener el ID y el Nombre del producto seleccionado
            string idProducto = LvProductos.SelectedItems[0].Tag.ToString();

            //Se obtiene el nombre del producto para mostrarlo y confirmar la eliminacion
            string nombreProducto = LvProductos.SelectedItems[0].SubItems[2].Text;

            //Aqui se pide confirmación al usuario antes de borrar
            DialogResult resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar el producto '{nombreProducto}' (ID: {idProducto})? Esta acción no se puede deshacer.",
                                                     "Confirmar Eliminación",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);
            //Verificacion de respuesta
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    //Ejecutar la consulta DELETE
                    //Usamos Id (I mayúscula) sin comillas, ya que sabemos que funciona para la clave primaria.
                    string consultaSQL = "DELETE FROM Productos WHERE Id = " + idProducto;

                    ConexionBD.EjecutarConsulta(consultaSQL, null);

                    MessageBox.Show("Producto eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Recargar el ListView para reflejar los cambios
                    BtnBuscar_Click(null, null); //Este se usa como para recargar el listView, si tuvo una actualizacion lo refresca
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            //Validar que al menos haya una fila seleccionada en el ListView
            if (LvProductos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista para modificar.", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Con esto se obtiene el Id del producto para que este se pueda modificar
            string idProducto = LvProductos.SelectedItems[0].Tag.ToString();

            //Obtener el Nombre del producto
            //El nombre está en la subcolumna 2 (ID=0, Cod. Inventario=1, Nombre=2)
            string nombreProducto = LvProductos.SelectedItems[0].SubItems[2].Text;

            //Validar que el ID no sea nulo/vacío
            if (string.IsNullOrEmpty(idProducto))
            {
                MessageBox.Show("No se pudo obtener el ID del producto seleccionado.", "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Si el Id del producto no es nulo y si conincide, se procede abrir el Formulario de modificar
            FrmGestionInventario modificarInventario = new FrmGestionInventario(idProducto, nombreProducto);
            modificarInventario.ShowDialog();

            //Recargar la lista para mostrar los cambios
            BtnBuscar_Click(null, null);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            volvermenu.Show();//Usa la instancia existente
            this.Close();
        }

        private void CboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboCampo.Text == "Precio")
                RdBusqExac.Checked = true;
        }

        private void LvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LvProductos.SelectedItems.Count == 0)
            {
                PbImgProducto.Image = null;
                return;
            }

            try
            {
                //Obtener el texto y limpiar espacios (Trim)
                string rutaBD = LvProductos.SelectedItems[0].SubItems[7].Text.Trim();
                
                //Esto une: (CarpetaPrograma) + (Subir 2 niveles) + (Base de datos) + (RutaImagen)
                string rutaRelativa = System.IO.Path.Combine(Application.StartupPath, @"..\..\Base de datos", rutaBD);

                //Obtener la ruta EXACTA que Windows está intentando leer
                string rutaAbsoluta = System.IO.Path.GetFullPath(rutaRelativa);

                if (System.IO.File.Exists(rutaAbsoluta))
                {
                    PbImgProducto.ImageLocation = rutaAbsoluta;
                    PbImgProducto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    string rutaRelativaerror = System.IO.Path.Combine(Application.StartupPath, @"..\..\Base de datos", "img/imgdefault.jpg");
                    string rutaAbsolutaerror = System.IO.Path.GetFullPath(rutaRelativaerror);

                    PbImgProducto.ImageLocation = rutaAbsolutaerror;
                }
            }
            catch
            {
                string rutaRelativa = System.IO.Path.Combine(Application.StartupPath, @"..\..\Base de datos", "img/imagen_error.jpg");
                string rutaAbsoluta = System.IO.Path.GetFullPath(rutaRelativa);

                PbImgProducto.ImageLocation = rutaAbsoluta;
            }
        }

        private void LvProductos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determinar si la columna seleccionada es la misma que la anterior
            if (e.Column != columnaOrdenada)
            {
                // Si es diferente, ordenar esa columna de forma ascendente
                columnaOrdenada = e.Column;
                LvProductos.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Si es la misma, invertir el orden (de Ascendente a Descendente)
                if (LvProductos.Sorting == SortOrder.Ascending)
                    LvProductos.Sorting = SortOrder.Descending;
                else
                    LvProductos.Sorting = SortOrder.Ascending;
            }

            // Llamar a la clase ListViewItemComparer para hacer el ordenamiento
            LvProductos.ListViewItemSorter = new ListViewItemComparer(e.Column, LvProductos.Sorting);

            // Ejecutar el ordenamiento
            LvProductos.Sort();
        }
    }
}
