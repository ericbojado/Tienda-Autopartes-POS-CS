using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Tienda_Autopartes_ProyectoFinal.FrmVentas;


namespace Tienda_Autopartes_ProyectoFinal
{
    public partial class FrmVentas : Form
    {
        bool EsConsulta;//Para asignar una sentencia de busqueda en LlenarLv
        string Sentencia;//Variable donde se guardara la sentencia
        bool detenerNUD;//Booleano para detener el evento valuechanged del nud
        private Form volvermenu;//Se almacenara el from menu principal, ya que el botón regresar vuelve a este
        private int columnaOrdenada = -1; //Sirve para ordenar

        string ObtenerIdUsuario()//Aqui se obtiene el id de usuario para utilizarlo posteriormente
        {
            using (OleDbConnection nuevo = ConexionBD.ConectarBase())//Todos los using son para abrir y cerrar las conexiones correctamente, evitando errores
            {
                string id = "";//Donde se almacena el valor del id recuperado de la bd
                string sentencia = "SELECT Id FROM Usuarios WHERE Usuario = '" + FrmLogin.UsuarioActual + "'";//Sentencia para obtener el id del usuario

                using (OleDbCommand ComandoIdEmpleado = new OleDbCommand(sentencia, nuevo))//Using para indicarle al programa que se esta utilizando el comando de ESTE METODO, y que no tome ningun otro
                {
                    using (OleDbDataReader datos = ComandoIdEmpleado.ExecuteReader())//Igual con este, agarra los datos obtenidos con el comando, y los guarda en el datareader de ESTE METODO
                    {
                        if (datos.Read())//Mientras se este usando el datareader...
                            id = datos["Id"].ToString();//...se guardaran los id como string en la variable
                    }
                }

                return id;//Retorna el id
            }
        }


        private void LlenarLv()//Metodo para rellenar el lvproductos, ya sea al iniciar el form, o al hacer una consulta
        {
            LvProductos.Items.Clear();//Se limpia el lv al iniciar para evitar duplicados

            //Conexion con la BD
            using (OleDbConnection nuevo = ConexionBD.ConectarBase())//Using para abrir la conexion de ESTE METODO
            {
                //Si EsConsulta es true, se ejecuta la sentencia para buscar
                if (EsConsulta)
                {
                    Sentencia = "SELECT Id, Nombre, Descripcion, Categoria, Stock, Precio FROM Productos WHERE Nombre LIKE '%" + TxtBuscar.Text
                         + "%' OR Descripcion LIKE '%" + TxtBuscar.Text + "%' OR Categoria LIKE '%" + TxtBuscar.Text + "%' OR Precio LIKE '%" + TxtBuscar.Text + "%' OR Id LIKE '%" + TxtBuscar.Text + "%';";//Seleccionando todos los productos que coincidan con la busqueda
                }
                else//Sino, se ejecuta la sentencia normal para llenar el lv
                {
                    Sentencia = "SELECT Id, Nombre, Descripcion, Categoria, Stock, Precio FROM Productos;";//Seleccionando todos los productos para que se muestren al ingresar
                }

                //Enviar sentencia SQL
                using (OleDbCommand ComandoLlenarVentas = new OleDbCommand(Sentencia, nuevo))//Using para utilizar unicamente el comando de ESTE METODO
                {
                    //Recuperar informacion
                    using (OleDbDataReader DatosLlenarVentas = ComandoLlenarVentas.ExecuteReader())//Igual aca, el datareader de ESTE METODO
                    {
                        if (DatosLlenarVentas.HasRows)//Si hay filas...
                        {
                            //...el datareader seguira acumulando datos
                            while (DatosLlenarVentas.Read())
                            {
                                ListViewItem productos = new ListViewItem(DatosLlenarVentas["Nombre"].ToString());//Se crea un item para cada fila nueva
                                productos.Tag = DatosLlenarVentas["Id"].ToString();//Se agrega como .tag porque no se desea mostrar en el lv, pero si se necesita el valor
                                productos.SubItems.Add(DatosLlenarVentas["Descripcion"].ToString());//Subitem (columna)
                                productos.SubItems.Add(DatosLlenarVentas["Categoria"].ToString());//Subitem (columna)
                                productos.SubItems.Add(DatosLlenarVentas["Stock"].ToString());//Subitem (columna)
                                productos.SubItems.Add(DatosLlenarVentas["Precio"].ToString());//Subitem (columna)

                                LvProductos.Items.Add(productos);//Se agrega el item con los datos proporcionados el lv
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron resultados.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);//Indica al usuario que no hubieron resultados para su busqueda
                        }
                    }
                }
            }
        }

        private void AgregarCarrito()//Metodo (o funcion, no me acuerdo) para agregar los productos seleccionados al carrito de venta
        {
            if (LvProductos.SelectedItems.Count != 0)//If para verificar que haya al menos un item seleccionado
            {
                AumentarCantidad();//checar si hay existencias y aumentar la cantidad y disminuir el stock
            }
            else
            {
                MessageBox.Show("No hay productos seleccionados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);//Aparece un messagebox indicandole al usuario que no ha seleccionado productos
            }
        }

        public double Total()//Para obtener el total a pagar
        {
            double preciofinal = 0;//Se incializa en cero

            if (LvCarrito.Items.Count != 0)//If para comprobar que el carrito no esta vacio
            {
                for (int i = 0; i < LvCarrito.Items.Count; i++)//For para recorrer todos los elementos del carrito
                {
                    double precios = Convert.ToDouble(LvCarrito.Items[i].SubItems[4].Text);//Se guardan los precios de todos los items del lv carrito
                    int cantidad = int.Parse(LvCarrito.Items[i].SubItems[3].Text);//Los valores de la columna del item i 
                    double totalcant = precios * cantidad;//Se obtiene el precio por la cantidad de unidades compradas
                    preciofinal += totalcant;//Se acumulan los precios en la variable para el precio final
                }
            }

            return preciofinal;//Retorna el precio final para el ticket
        }

        private void Ticket(DateTime fecha)//Para crear un ticket de los productos en el carrito
        {
            double preciofinal;//Aqui se almacenara el precio final
            string todosprecios = "";//Donde se acumularan los nombres, precios, y cantidades a mostrar

            for (int i = 0; i < LvCarrito.Items.Count; i++)//For para recorrer todos los items en el carrito
            {
                string nombre = LvCarrito.Items[i].SubItems[0].Text;//Ejemplo de columna, guarda el nombre del producto segun el indice del item y el indice de la columna
                string precio = LvCarrito.Items[i].SubItems[4].Text;//Ejemplo de columna, guarda el precio del producto segun el indice del item y el indice de la columna
                string cantidad = LvCarrito.Items[i].SubItems[3].Text;//Ejemplo de columna, guarda el precio del producto segun el indice del item y el indice de la columna
                todosprecios += nombre + " -> $" + precio + "\n" + " -> Unidades: " + cantidad + "\n";//Se almacenan los items del carrito en la variable string hasta que i llegue al total de items
            }

            string fechaformateada = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            preciofinal = Total();//Se atrapa el retorno de la funcion, o el precio final
            MessageBox.Show("VENTA REALIZADA. \n\n" + todosprecios + "Total a pagar: $" + preciofinal + "\n\n" + fecha + "\n\n" + "Atiende: " + FrmLogin.UsuarioActual, "Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Reiniciar();
        }

        public static class Fecha//Clase para obtener la fecha y que no se actualice una vez este en la venta
        {
            public static DateTime fechaactual { get; set; }//Almacena la fecha UNICAMENTE cuando se manda a llamar, y no se actualiza
        }

        private void AumentarPorNUD(int nuevaCantidad)//Aumenta la cantidad del producto seleccionado mediante el nud (numericupdown)
        {
            if (LvCarrito.SelectedItems.Count == 0) return;

            ListViewItem itemCarrito = LvCarrito.SelectedItems[0];
            string idProducto = itemCarrito.Tag.ToString();

            // Buscamos el producto en la lista de inventario para saber su stock real máximo
            int stockMaximo = 0;
            foreach (ListViewItem prod in LvProductos.Items)
            {
                if (prod.Tag.ToString() == idProducto)
                {
                    stockMaximo = int.Parse(prod.SubItems[3].Text);
                    break;
                }
            }

            // Validaciones
            if (nuevaCantidad <= 0)
            {
                // Preguntar si borrar
                if (MessageBox.Show("¿Eliminar producto del carrito?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    LvCarrito.Items.Remove(itemCarrito);
                }
                else
                {
                    // Si dice que no, regresamos a 1 (para evitar 0 o negativos)
                    detenerNUD = true;
                    NUDCantidad.Value = 1;
                    itemCarrito.SubItems[3].Text = "1";
                    detenerNUD = false;
                }
                return;
            }

            if (nuevaCantidad > stockMaximo)
            {
                MessageBox.Show("Stock insuficiente. Máximo disponible: " + stockMaximo);

                // Regresamos el NUD al máximo posible
                detenerNUD = true;
                NUDCantidad.Value = stockMaximo;
                itemCarrito.SubItems[3].Text = stockMaximo.ToString();
                detenerNUD = false;
                return;
            }

            // Si pasa las validaciones, solo actualizamos el texto visual
            itemCarrito.SubItems[3].Text = nuevaCantidad.ToString();
        }

        private void AumentarCantidad()//Checa si ya existe un producto en el carrito, si existe, aumenta la cantidad, sino, lo agrega
        {
            if (LvProductos.SelectedItems.Count == 0) return;

            //Tomamos el producto seleccionado del inventario
            ListViewItem itemInventario = LvProductos.SelectedItems[0];
            string idProducto = itemInventario.Tag.ToString();
            string nombre = itemInventario.SubItems[0].Text;
            string desc = itemInventario.SubItems[1].Text;
            string cat = itemInventario.SubItems[2].Text;
            int stockDisponible = int.Parse(itemInventario.SubItems[3].Text); // Stock Real
            double precio = double.Parse(itemInventario.SubItems[4].Text);

            //Verificar si hay stock físico
            if (stockDisponible <= 0)
            {
                MessageBox.Show("Este producto está agotado.", "Sin Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Buscar si ya está en el carrito
            ListViewItem itemCarrito = null;
            foreach (ListViewItem item in LvCarrito.Items)
            {
                if (item.Tag.ToString() == idProducto)
                {
                    itemCarrito = item;
                    break;
                }
            }

            //Lógica de Agregado Visual
            if (itemCarrito != null)
            {
                //Si ya existe, obtenemos cuánto lleva y vemos si le cabe uno más
                int cantidadEnCarrito = int.Parse(itemCarrito.SubItems[3].Text);

                if (cantidadEnCarrito + 1 > stockDisponible)
                {
                    MessageBox.Show("No puedes agregar más. Solo tienes " + stockDisponible + " unidades.", "Límite Alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Solo aumentamos el número visualmente
                itemCarrito.SubItems[3].Text = (cantidadEnCarrito + 1).ToString();
            }
            else
            {
                //Si es nuevo, lo creamos con cantidad 1
                ListViewItem nuevoItem = new ListViewItem(nombre);
                nuevoItem.Tag = idProducto;
                nuevoItem.SubItems.Add(desc);
                nuevoItem.SubItems.Add(cat);
                nuevoItem.SubItems.Add("1"); //Cantidad inicial
                nuevoItem.SubItems.Add(precio.ToString());
                LvCarrito.Items.Add(nuevoItem);
            }
        }
        private int ObtenerUltimoIdVenta()
        {
            int ultimoId = 0;

            using (OleDbConnection con = ConexionBD.ConectarBase())//Conexion a la bd
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT MAX(IdVenta) FROM DetalleVenta", con))//Comando
                {
                    var result = cmd.ExecuteScalar();//Se guarda el resultado unico en un var
                    if (result != DBNull.Value)//Si el resultado no es un dato nulo de la bd
                        ultimoId = Convert.ToInt32(result);//Se convierte el id de object a int
                }
            }
            int nuevoId = ultimoId + 1;//Se le suma uno al id para no duplicarlo
            return nuevoId;//Se retorna para insertarlo
        }
        private void InsertarDetalleVenta()//Para mandar los detalles de la venta a la bd
        {
            int idventa = ObtenerUltimoIdVenta();//Se manda a llamar el metodo anterior y se guarda en un int

            using (OleDbConnection nuevo = ConexionBD.ConectarBase())//Usando la conexion de ESTE METODO    
            {
                for (int i = 0; i < LvCarrito.Items.Count; i++)//For para recorrer todos los items del lv carrito
                {
                    string idproducto = LvCarrito.Items[i].Tag.ToString();//Se guarda el id almacenado en el carrito en un string
                    string cantidadproducto = LvCarrito.Items[i].SubItems[3].Text;//Se guarda la cantidad almacenada en el carrito en un string
                    string preciouni = LvCarrito.Items[i].SubItems[4].Text;//Se guarda el precio almacenado en el carrito en un string
                    Sentencia = "INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, PrecioUnitario) VALUES (" + idventa + ", " + idproducto + ", " + cantidadproducto + ", " + preciouni + ");";//Sentencia para insertar el id, la cantidad, y el precio unitario de los productos comprados
                    using (OleDbCommand ComandoInsertarDetalles = new OleDbCommand(Sentencia, nuevo))//Usando el comando de ESTE METODO   
                    {
                        ComandoInsertarDetalles.ExecuteNonQuery();//Se manda la sentencia a la bd 
                    }
                }
            }
        }


        private void DatosCorte(DateTime fecha)//Para mandar los datos de la venta a la bd
        {
            using (OleDbConnection nuevo = ConexionBD.ConectarBase())//Usando la conexion de ESTE METODO 
            {
                string id = ObtenerIdUsuario();//Se guarda el id del empleado (obtenido en el metodo llamado) en un string
                string fechaformateada = fecha.ToString("yyyy-MM-dd HH:mm:ss");
                double precioventa = Total();//Se obtiene el precio final del metodo llamado
                string Sentencia = "INSERT INTO Ventas (IdUsuario, FechaVenta, Total) VALUES ('" + id + "', '" + fechaformateada + "', '" + precioventa + "');";//Sentencia para insertar el id, la fecha, y el precio final de los productos comprados
                using (OleDbCommand ComandoInsertarVenta = new OleDbCommand(Sentencia, nuevo))//Usando el comando de ESTE METODO 
                {
                    ComandoInsertarVenta.ExecuteNonQuery();//Se manda la sentencia a la bd 
                }
            }
        }
        public FrmVentas(Form volver)//Se pide como parametro la ventana anterior
        {
            InitializeComponent();
            volvermenu = volver;//Se guarda la ventana anterior a esta en el form declarado anteriormente
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            //Inicializar la consulta como false
            EsConsulta = false;

            //Personalizacion del lvproductos
            LvProductos.View = View.Details;
            LvProductos.FullRowSelect = true;
            LvProductos.GridLines = true;
            LvProductos.MultiSelect = true;//Permite que el usuario seleccione varios elementos del lv

            //Personalizacion del lvcarrito
            LvCarrito.View = View.Details;
            LvCarrito.FullRowSelect = true;
            LvCarrito.GridLines = true;

            //Columnas lvproductos
            LvProductos.Columns.Add("Nombre", 150);
            LvProductos.Columns.Add("Descripción", 150);
            LvProductos.Columns.Add("Categoría", 100);
            LvProductos.Columns.Add("Stock", 70);
            LvProductos.Columns.Add("Precio", 80);

            //Columnas lvcarrito
            LvCarrito.Columns.Add("Nombre", 150);
            LvCarrito.Columns.Add("Descripción", 150);
            LvCarrito.Columns.Add("Categoría", 100);
            LvCarrito.Columns.Add("Cantidad", 70);
            LvCarrito.Columns.Add("Precio", 80);

            //Se manda a llamar el llenado del lvproductos en cuanto se inicie el formulario
            LlenarLv();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            //Cambiar la consulta a true
            EsConsulta = true;

            //Se manda a llamar el metodo
            LlenarLv();
        }

        private void BtnCobrar_Click(object sender, EventArgs e)
        {
            if (LvCarrito.Items.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.");
                return;
            }

            try
            {
                DateTime fechaVenta = DateTime.Now;

                //Insertar Venta y Detalles
                DatosCorte(fechaVenta);
                InsertarDetalleVenta();

                //Descontar Stock Físico
                DescontarStockFinal();

                //Imprimir
                Ticket(fechaVenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la venta: " + ex.Message);
            }
        }

        private void BtnAgregarCarrito_Click(object sender, EventArgs e)
        {
            //Al seleccionar y presionar el boton de agregar, se manda a llamar al metodo encargado de esto, declarado anteriormente
            AgregarCarrito();
        }

        private void NUDCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (detenerNUD)//Si detener nud es verdadero, detiene el evento de valuechanged, ya que se esta cambiando dentro del metodo Aumentarpornud
                return;//Retorna nada y deja que el metodo trabaje

            int cantnueva = (int)NUDCantidad.Value;//Se almacena el valor del nud en un int
            AumentarPorNUD(cantnueva);//Se manda a llamar el metodo aumentarpornud y se le asigna el valor anterior
        }
        private void LvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LvCarrito.SelectedItems.Count == 0)//Si no hay items seleccionados en el carrito
                return;//No se retorna nada, hasta que el usuario seleccione uno y se ejecute lo siguiente

            ListViewItem it = LvCarrito.SelectedItems[0];//Asignando el item seleccionado del carrito a it
            string cant = it.SubItems[3].Text.Trim();//Guardando la cantidad del item anterior en un string

            try
            {
                detenerNUD = true;//Se detiene el evento de changedvalue del nud, ya que, como estamos regresando el valor al anterior, lo puede tomar como una nueva ejecucion de este, y puede causar problemas
                NUDCantidad.Value = int.Parse(cant);//Se inicia el nud con la cantidad del producto seleccionado
            }
            finally
            {
                detenerNUD = false;//Se deja de detener el nud, ya que se ha realizado la accion necesaria
            }
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            volvermenu.Show();//Usa la instancia existente
            this.Close();
        }
        private void Reiniciar()
        {
            LvProductos.Items.Clear();
            LvCarrito.Items.Clear();
            TxtBuscar.Clear();
            NUDCantidad.Value = 0;
            EsConsulta = false;
            LlenarLv();
        }
        private void DescontarStockFinal()
        {
            using (OleDbConnection conexion = ConexionBD.ConectarBase())
            {
                //Recorremos todo el carrito
                foreach (ListViewItem itemCompra in LvCarrito.Items)
                {
                    string idProducto = itemCompra.Tag.ToString();
                    int cantidadComprada = int.Parse(itemCompra.SubItems[3].Text);

                    //Consulta SQL: Restamos lo comprado al stock actual
                    string sql = "UPDATE Productos SET Stock = Stock - " + cantidadComprada + " WHERE Id = " + idProducto;

                    using (OleDbCommand cmd = new OleDbCommand(sql, conexion))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
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

        private void LvCarrito_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determinar si la columna seleccionada es la misma que la anterior
            if (e.Column != columnaOrdenada)
            {
                // Si es diferente, ordenar esa columna de forma ascendente
                columnaOrdenada = e.Column;
                LvCarrito.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Si es la misma, invertir el orden (de Ascendente a Descendente)
                if (LvCarrito.Sorting == SortOrder.Ascending)
                    LvCarrito.Sorting = SortOrder.Descending;
                else
                    LvCarrito.Sorting = SortOrder.Ascending;
            }

            // Llamar a la clase ListViewItemComparer para hacer el ordenamiento
            LvCarrito.ListViewItemSorter = new ListViewItemComparer(e.Column, LvCarrito.Sorting);

            // Ejecutar el ordenamiento
            LvCarrito.Sort();
        }
    }
}
