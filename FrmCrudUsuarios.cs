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
    public partial class FrmCrudUsuarios : Form
    {
        private Form volvermenu;//Se almacenara el from menu principal, ya que el botón regresar vuelve a este
        private int columnaOrdenada = -1; //Sirve para ordenar
        public FrmCrudUsuarios(Form volver)
        {
            InitializeComponent();
            volvermenu = volver;
        }
        private void FrmCrudUsuarios_Load(object sender, EventArgs e)
        {
            RdBusqAprox.Checked = true;

            ConfigurarLV();

            SeguridadCRUD();

            CboCampo.SelectedIndex = 0;

            TxtBuscar.Text = string.Empty;

            BtnBuscar_Click(null, null);
        }
        private void ConfigurarLV()
        {
            LvUsuarios.View = View.Details;
            LvUsuarios.FullRowSelect = true;
            LvUsuarios.GridLines = true;
            LvUsuarios.LabelEdit = false;

            LvUsuarios.Columns.Clear();
            LvUsuarios.Columns.Add("ID", 0, HorizontalAlignment.Left);
            LvUsuarios.Columns.Add("NOMBRE", 200, HorizontalAlignment.Center);
            LvUsuarios.Columns.Add("USUARIO", 120, HorizontalAlignment.Center);
            LvUsuarios.Columns.Add("ROL", 80, HorizontalAlignment.Center);

        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            //Obtener datos de la interfaz
            string campo = CboCampo.SelectedItem.ToString();
            string termino = TxtBuscar.Text.Trim();
            string clausulaWHERE = "";

            //Traducir lo que ve el usuario al nombre real en la BD (esto para NombreCompleto)
            string campoSQL = campo;

            //Solo corregimos "Nombre" porque en la BD es "NombreCompleto"
            if (campo == "Nombre")
            {
                campoSQL = "NombreCompleto";
            }

            //Construcción de la cláusula WHERE
            if (!string.IsNullOrEmpty(termino))
            {
                //Limpieza básica para evitar errores con comillas simples en el texto
                string terminoLimpio = termino.Replace("'", "''");

                if (RdBusqExac.Checked)
                {
                    //Búsqueda Exacta
                    clausulaWHERE = $" WHERE [{campoSQL}] = '{terminoLimpio}'";
                }
                else if (RdBusqAprox.Checked)
                {
                    //Búsqueda Aproximada (Usamos % para SQL estándar)
                    clausulaWHERE = $" WHERE [{campoSQL}] LIKE '%{terminoLimpio}%'";
                }
            }

            //Consulta SQL Final
            //NOTA: Usamos corchetes [] especialmente en [Password] para evitar errores de palabras reservadas en Access
            string consultaSQL = $"SELECT [id], [NombreCompleto], [Usuario], [Rol] FROM [Usuarios] {clausulaWHERE}";

            try
            {
                System.Data.DataTable resultados = ConexionBD.EjecutarConsulta(consultaSQL, null);
                MostrarResultadosListView(resultados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar la búsqueda: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmGestionUsuarios agregarUsuario = new FrmGestionUsuarios();
            agregarUsuario.ShowDialog();
            BtnBuscar_Click(null, null);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (LvUsuarios.SelectedItems.Count == 0)
            {
                MessageBox.Show("Para llevar a cabo esta acción necesita seleccionar un registro", "-ATENCIÓN-", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string idRegistro = LvUsuarios.SelectedItems[0].Tag.ToString();
            string NombreRegistro = LvUsuarios.SelectedItems[0].SubItems[1].Text;
            string UsuarioRegistro = LvUsuarios.SelectedItems[0].SubItems[2].Text;

            DialogResult resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar el registro '{UsuarioRegistro}' (Nombre: {NombreRegistro})? Esta acción NO se puede deshacer.", "-ATENCION-", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    string consultaSQL = "DELETE FROM Usuarios WHERE Id = " + idRegistro;

                    ConexionBD.EjecutarConsulta(consultaSQL, null);

                    MessageBox.Show("Se eliminó el registro con éxito", "ACCIÓN REALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BtnBuscar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Surgió un error a la hora de eliminar el registro: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (LvUsuarios.SelectedItems.Count == 0)
            {
                MessageBox.Show("Para llaver a cabo esta acción necesita seleccionar un registro", "-ATENCIÓN-", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string idUsuario = LvUsuarios.SelectedItems[0].Tag.ToString();

            if (string.IsNullOrEmpty(idUsuario))
            {
                MessageBox.Show("No se pudo obtener el ID del registro seleccionado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmGestionUsuarios modificarInv = new FrmGestionUsuarios(idUsuario);
            modificarInv.ShowDialog();

            BtnBuscar_Click(null, null);
        }

        private void SeguridadCRUD()
        {
            if (FrmLogin.RolActual != "Administrador")
            {
                BtnAgregar.Enabled = false;
                BtnAgregar.Visible = false;

                BtnEliminar.Enabled = false;
                BtnEliminar.Visible = false;

                BtnModificar.Enabled = false;
                BtnModificar.Visible = false;
            }
        }

        private void MostrarResultadosListView(System.Data.DataTable dt)
        {
            LvUsuarios.Items.Clear();//Limpia la lista antes de añadir nuevos resultados

            foreach (System.Data.DataRow fila in dt.Rows)
            {
                ListViewItem item = new ListViewItem(fila["Id"].ToString());

                item.SubItems.Add(fila["NombreCompleto"].ToString());
                item.SubItems.Add(fila["Usuario"].ToString());
                item.SubItems.Add(fila["Rol"].ToString());

                item.Tag = fila["id"].ToString();

                LvUsuarios.Items.Add(item);
            }

            //Actualizar los registros mostrados en el label
            LblNumUsuarios.Text = "Num. de Usuarios: " + dt.Rows.Count.ToString();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            volvermenu.Show();//Usa la instancia existente
            this.Hide();
        }

        private void LvUsuarios_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determinar si la columna seleccionada es la misma que la anterior
            if (e.Column != columnaOrdenada)
            {
                // Si es diferente, ordenar esa columna de forma ascendente
                columnaOrdenada = e.Column;
                LvUsuarios.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Si es la misma, invertir el orden (de Ascendente a Descendente)
                if (LvUsuarios.Sorting == SortOrder.Ascending)
                    LvUsuarios.Sorting = SortOrder.Descending;
                else
                    LvUsuarios.Sorting = SortOrder.Ascending;
            }

            // Llamar a la clase ListViewItemComparer para hacer el ordenamiento
            LvUsuarios.ListViewItemSorter = new ListViewItemComparer(e.Column, LvUsuarios.Sorting);

            // Ejecutar el ordenamiento
            LvUsuarios.Sort();
        }
    }
}
