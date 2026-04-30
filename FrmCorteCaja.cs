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
    public partial class FrmCorteCaja : Form
    {
        private Form volvermenu;//Se almacenara el from menu principal, ya que el botón regresar vuelve a este
        private int columnaOrdenada = -1; //Sirve para ordenar
        public class OpcionCombo
        {
            public string Valor { get; set; } //Para el ID del usuario
            public string Texto { get; set; } //Para el NombreCompleto
            public string Usuario { get; set; } //Para comparar con FrmLogin.UsuarioActual

            public override string ToString()
            {
                return Texto; //Esto es lo que se verá en el ComboBox
            }
        }
        public FrmCorteCaja(Form volver)
        {
            InitializeComponent();
            volvermenu = volver;
        }

        private void FrmCorteCaja_Load(object sender, EventArgs e)
        {
            //Configurar el ListView
            ConfigurarListView();

            //Cargar Empleados en el ComboBox
            CargarEmpleados();

            //Seleccionar fecha actual por defecto y cargar ventas de hoy
            McFecha.SetDate(DateTime.Now);
            BtnCargar_Click(null, null);
        }
        private void ConfigurarListView()
        {
            LvVentas.View = View.Details;
            LvVentas.GridLines = true;
            LvVentas.FullRowSelect = true;

            //Limpiar y agregar columnas
            LvVentas.Columns.Clear();
            LvVentas.Columns.Add("ID Venta", 80);
            LvVentas.Columns.Add("Empleado", 150);
            LvVentas.Columns.Add("Fecha y Hora", 150);
            LvVentas.Columns.Add("Total", 100);
        }

        private void CargarEmpleados()
        {
            //Consulta para traer a los usuarios activos
            string consulta = "SELECT Id, NombreCompleto, Usuario FROM Usuarios";

            try
            {
                DataTable dt = ConexionBD.EjecutarConsulta(consulta);

                CmbEmpleados.Items.Clear();

                //Agregamos una opción "TODOS" por defecto para ver ventas generales
                CmbEmpleados.Items.Add(new OpcionCombo { Valor = "0", Texto = "Todos los empleados", Usuario = "" });

                int indiceUsuarioLogueado = 0; //Por defecto "Todos"

                foreach (DataRow row in dt.Rows)
                {
                    OpcionCombo opcion = new OpcionCombo
                    {
                        Valor = row["Id"].ToString(),
                        Texto = row["NombreCompleto"].ToString(),
                        Usuario = row["Usuario"].ToString()
                    };

                    int index = CmbEmpleados.Items.Add(opcion);

                    //Si el usuario de la base de datos coincide con el logueado
                    if (opcion.Usuario == FrmLogin.UsuarioActual)
                    {
                        indiceUsuarioLogueado = index;
                    }
                }

                //Seleccionamos al usuario que está logueado actualmente
                CmbEmpleados.SelectedIndex = indiceUsuarioLogueado;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        private void BTregresar_Click(object sender, EventArgs e)
        {
            volvermenu.Show();//Usa la instancia existente
            this.Close();
        }

        private void BTcerrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplicacion Cerrada", "Gracias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Cierre de la aplicacion
            Application.Exit();
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            //Obtener fecha (buscamos por texto porque en tu BD es Texto Corto)
            string fechaSeleccionada = McFecha.SelectionStart.ToString("yyyy-MM-dd");

            //Obtener selección del combo
            OpcionCombo empleadoSeleccionado = (OpcionCombo)CmbEmpleados.SelectedItem;
            if (empleadoSeleccionado == null) return;

            //Consulta Directa a Ventas (Sin JOIN para evitar errores de Access)
            string consulta = "SELECT Id, IdUsuario, FechaVenta, Total FROM Ventas WHERE FechaVenta LIKE @fecha + '%'";

            var parametros = new Dictionary<string, object>();
            parametros.Add("@fecha", fechaSeleccionada);

            //Filtro por empleado (Si no es "TODOS")
            if (empleadoSeleccionado.Valor != "0")
            {
                //Convertimos el valor a NÚMERO para que Access no se queje
                if (int.TryParse(empleadoSeleccionado.Valor, out int idUsuarioNum))
                {
                    consulta += " AND IdUsuario = @idUsuario";
                    parametros.Add("@idUsuario", idUsuarioNum); // Enviamos un número real
                }
            }

            try
            {
                DataTable dtResultados = ConexionBD.EjecutarConsulta(consulta, parametros);

                // Llamamos a la función que llena la lista y busca los nombres
                MostrarEnListView(dtResultados);
                CalcularTotal(dtResultados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar: " + ex.Message);
            }
        }
        private void MostrarEnListView(DataTable dt)
        {
            LvVentas.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["Id"].ToString());

                //Buscar el nombre del empleado manualmente
                string idEnVenta = row["IdUsuario"].ToString();
                string nombreEmpleado = "Desconocido";

                //Recorremos el ComboBox para encontrar a quién pertenece ese ID
                foreach (OpcionCombo op in CmbEmpleados.Items)
                {
                    if (op.Valor == idEnVenta)
                    {
                        nombreEmpleado = op.Texto;
                        break;
                    }
                }
                //Actualizar los registros mostrados en el label
                LblVentas.Text = "Ventas: " + dt.Rows.Count.ToString();

                item.SubItems.Add(nombreEmpleado);
                item.SubItems.Add(row["FechaVenta"].ToString());

                //Formato de dinero
                double total = 0;
                double.TryParse(row["Total"].ToString(), out total);
                item.SubItems.Add(total.ToString("C2"));

                LvVentas.Items.Add(item);
            }
        }

        private void CalcularTotal(DataTable dt)
        {
            double totalDia = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (double.TryParse(row["Total"].ToString(), out double venta))
                {
                    totalDia += venta;
                }
            }
            LblTotal.Text = "Total: " + totalDia.ToString("C2");
        }

        private void LvVentas_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determinar si la columna seleccionada es la misma que la anterior
            if (e.Column != columnaOrdenada)
            {
                // Si es diferente, ordenar esa columna de forma ascendente
                columnaOrdenada = e.Column;
                LvVentas.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Si es la misma, invertir el orden (de Ascendente a Descendente)
                if (LvVentas.Sorting == SortOrder.Ascending)
                    LvVentas.Sorting = SortOrder.Descending;
                else
                    LvVentas.Sorting = SortOrder.Ascending;
            }

            // Llamar a la clase ListViewItemComparer para hacer el ordenamiento
            LvVentas.ListViewItemSorter = new ListViewItemComparer(e.Column, LvVentas.Sorting);

            // Ejecutar el ordenamiento
            LvVentas.Sort();
        }
    }

}

