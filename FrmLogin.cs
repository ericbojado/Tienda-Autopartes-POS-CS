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

namespace Tienda_Autopartes_ProyectoFinal
{
    public partial class FrmLogin : Form
    {
        //variables globales
        int intentos = 0; //Se coloca aqui para que no se reinicie el ciclo de las oportunidades
        public static string UsuarioActual;//Para guardar el usuario actual de la persona que inicio sesion
        public static string RolActual;//Para guardar el rol actual de la persona que inicio sesion 


        public FrmLogin()
        {
            InitializeComponent();
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void BtnContinuar_Click(object sender, EventArgs e)
        {

            if (ValidarCredencialesDesdeBD())//Llama al metodo de consulta de datos
            {
                // Guardamos la sesion en las variables globales
                UsuarioActual = TxtUsuario.Text.Trim();//Si la validación fue exitosa, toma el texto ingresado en la caja de usuario "TxtUsuario.Text",
                                                       //elimina cualquier espacio en blanco extra ".Trim()", y lo guarda en la variable estática UsuarioActual.

                RolActual = ObtenerRolUsuario();  // Llama al metodo para determinar su rol y el resultado que le de lo guarda en la variable "RolActual"

                AbrirMenuPrincipal();
            }
            else
            {
                Intentos();//Llama al metodo de intentos para saber si cerrar el programa o no
            }
        }

        private void AbrirMenuPrincipal()//Metodo para abrir el menu principal
        {
            FrmMenuPrincipal ventana = new FrmMenuPrincipal(); //Declara la ventana del menu principal como un elemento
            ventana.Show();//Muestra la ventana del menu principal
            this.Hide(); //Esto oculta la ventana
            return;//Para detener el ciclo
        }

        private void Intentos()//Metodo para contar la cantidad de intentos que se realizan 
        {
            intentos++;//Sumara uno al contador cada que uno de ambos datos que se solicitan sean incorrectos

            int respuesta;
            respuesta = ValidarContraseñaYUser();

            TxtPassword.Text = "";//Una vez la contraseña y/o el usuario sea incorrecto los TextBox se vaciaran
            TxtUsuario.Text = "";

            if (intentos < 3)//Contador que mientras la cantidad de intentos sea menor a tres
            {
                if (respuesta == 1)//Se compara la repuesta que se dio del metodo "ValidarContraseñaYUsser" y si es 1 se mostrara el siguiente mensaje
                {
                    MessageBox.Show("El usuario que ingreso es incorrecto, vuelva a intentarlo por favor.\n\nIntentos restantes: " + (3 - intentos), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (respuesta == 2)//Se compara la repuesta que se dio del metodo "ValidarContraseñaYUsser" y si es 1 se mostrara el siguiente mensaje
                {
                    MessageBox.Show("La contraseña que ingreso es incorrecta, vuelva a intentarlo por favor.\n\nIntentos restantes: " + (3 - intentos), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Se utilizaron todas sus oportunidades de ingreso.\n \nLo sentimos pero una vez cierre esta ventana se cerrara el programa","ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Hand); //Cuando se terminen las oportunidades se mostrara ese mensaje avisando que la aplicacion se cerrara

                Application.Exit();//A diferencia del "this.Close" que cierra solo una venta el "Application.Exit()" cerrara el programa completo
            }
        }


        private bool ValidarCredencialesDesdeBD()//Metodo para ver si la contraseña y usuario estan en la base de datos
        {
            try//Contiene el codigo que puede generar una excepción (un error, como un intento de conexión fallida a una base de datos o dividir por cero)
            {
                OleDbConnection con = ConexionBD.ConectarBase();//Para llamar el metodo de la conexion de la BD para abir la conexion a la BD

                string query = "SELECT COUNT(*) FROM Usuarios WHERE [Usuario]=@u AND [Password]=@p"; //Esta es una sentencia de Sql que cuenta cuantas filas y columnas hay en la tabla de Usuarios donde Usuario y Password coincidan con los valores proporcionados

                OleDbCommand cmd = new OleDbCommand(query, con); //Objeto para ejecutar el query y este se encuentra escrito en SQL y se usa para interactuar con la base de datos a traves de OleDb

                cmd.Parameters.AddWithValue("@u", TxtUsuario.Text);//Agrega los valores del texto ingresado {TxtUsuario.Text} y {TxtPassword.Text} como parámetros {@u} y {@p} en la consulta SQL evitando un ataque de inyeccion en sql
                cmd.Parameters.AddWithValue("@p", TxtPassword.Text);

                int resultado = (int)cmd.ExecuteScalar(); //Ejecuta la consulta de "ExecuteScalar()" y solo recupera el valor de la´primera fila que en este caso es el COUNT

                return resultado > 0;//Realiza un conteo para si es mayor a 0 entonces regresa un true, eso quiere decir que las credenciales son correctas
            }
            catch (Exception ex) //Contiene el código que se ejecuta para manejar o recuperarse de la excepción. Permite registrar el error o informar al usuario.
            {
                MessageBox.Show("Error al conectar a la base de datos:\n" + ex.Message,"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);//con la conexion a la base de datos, el ex.Message te aclara cual es ese error exactamente
                return false;
            }
            finally//Se usa para realizar una accion sucediera o no un error
            {
                ConexionBD.DesconectarBase();//Llama al metodo para cerrar la conexion con la base de datos
            }
        }

        private string ObtenerRolUsuario()//Metodo para substraer el rol del usuario desde la base de datos
        {
            try
            {
                OleDbConnection con = ConexionBD.ConectarBase(); //Lllama a la funcion para abrir la conexion con la base de datos y esta se almacena en la variable "con"

                string query = "SELECT Rol FROM Usuarios WHERE [Usuario]=@u AND [Password]=@p"; //Define un consulta que se hara en la base de datos

                OleDbCommand cmd = new OleDbCommand(query, con);/*Crea un objeto de comando para ejecutar la consulta SQL 
                                                                  definida (query) a través de la conexión (con).*/


                cmd.Parameters.AddWithValue("@u", TxtUsuario.Text);//Enlaza los valores ingresados por el usuario (TxtUsuario.Text y TxtPassword.Text)
                                                                   //a los marcadores de posición (@u y @p) en la consulta, previniendo ataques de Inyección SQL.
                cmd.Parameters.AddWithValue("@p", TxtPassword.Text);

                object resultado = cmd.ExecuteScalar();/*Ejecuta la consulta SQL El metodo "ExecuteScalar" está diseñado para devolver un solo valor
                                                       (la primera columna de la primera fila), que en este caso será el "Rol" del usuario.*/

                return resultado.ToString();//Convierte el resultado a texto para asi devolverlo con string
                
            }
            finally
            {
                ConexionBD.DesconectarBase();
            }
        }
        private int ValidarContraseñaYUser()//Matodo para conocer si el usuario y la contraseña, si no es el caso se mostrara un mensaje que aclare ambos, al ser int devolvera un nuero como resultado
        {
            try
            {
                OleDbConnection con = ConexionBD.ConectarBase(); //Lllama a la funcion para abrir la conexion con la base de datos y esta se almacena en la variable "con"

                string usser = "SELECT COUNT (*) FROM Usuarios WHERE [Usuario]=@u";//Contara cuantos registros coinciden con el nombre de usuario que se ingreso

                OleDbCommand cmdUsser = new OleDbCommand(usser, con);
                cmdUsser.Parameters.AddWithValue("@u", TxtUsuario.Text);/*Reemplaza "@u" en la consulta por lo que el usuario
                                                                         escribió en el TextBox ademas que te protege contra inyección SQL.*/

                int UsserExistente = (int)cmdUsser.ExecuteScalar();// el "ExecuteScalar()" ejecuta la consulta y de vuelve 1 solo valor: El COUNT(), si debuelve un 1 el usuario si existe y si es 0 entonces no existe

                if (UsserExistente == 0) // Este "if" hace que si el usuario no existe "que es igual a 0" regresara 1
                {
                    return 1;//retorna 1 si el usuario es incorrecto
                }

                string password = "SELECT COUNT (*) FROM Usuarios WHERE [Usuario] = @u AND [Password] = @p";//Consulta para verificar si el usuario y la contraseña coinciden, si coinciden regresa 1

                OleDbCommand cmdPass = new OleDbCommand(password, con);
                cmdPass.Parameters.AddWithValue("@p", TxtPassword.Text);//Envía usuario y contraseña reales
                cmdPass.Parameters.AddWithValue("@u", TxtUsuario.Text); //a los parámetros @u y @p

                int PassExistente = (int)cmdPass.ExecuteScalar();// el "ExecuteScalar()" ejecuta la consulta y de vuelve 1 solo valor: El COUNT(), si debuelve un 1 el usuario si existe y si es 0 entonces no existe

                if (PassExistente == 0)//Si uno de los dos datos es incorrecto regresara un 2
                {
                    return 2;//retorna 2 si la contraseña es incorrecta
                }

                return 0;//retorna 0 si todo es correcto
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;//Devuelve -1 para indicar que algo salió mal al conectar o consulta
            }
            finally
            {
                ConexionBD.DesconectarBase();
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
            if (char.IsSeparator(e.KeyChar))
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
