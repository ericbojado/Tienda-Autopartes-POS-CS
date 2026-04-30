using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb; //Importa la biblioteca de Microsoft que contiene todas las herramientas para conectarse a bases de datos "OLE DB", que es la que usa Access.


namespace Tienda_Autopartes_ProyectoFinal
{
    /* 'public static class' significa que es una clase pública, estática y se puede mandar a llamar en cualquier parte del proyecto.
     - No se pueden crear "instancias" de ella (no se puede hacer 'new ConexionDB()').
     - Para mandar a llamar se usa directamente: ConexionDB.Metodo() */
    public static class ConexionBD
    {
        private static OleDbConnection Conexion; //Creamos una variable de tipo OleDbConnection

        private static String CadConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\Base de Datos\Proyecto_Final_BD.accdb;Persist Security Info=False;";//Creamos una variable que almacena la cadena de conexión, aqui es donde se indica la direccion de la base de datos.

        //Procedimiento para conectar a la Base de Datos
        public static OleDbConnection ConectarBase()
        {
            Conexion = new OleDbConnection(CadConexion); //Instanciamos una variable de tipo OleDbConnection que almacena info. sobre la conexión, como el nombre del servidor y la base de datos.
            Conexion.Open();//Abrimos la conexión con la base de datos.

            return Conexion;//Retornamos la conexión.
        }

        //Procedimiento para desconectar a la Base de Datos
        public static OleDbConnection DesconectarBase()
        {
            Conexion.Close();
            return Conexion;
        }

        //Método para consultar y traer informacion de la base de datos
        public static DataTable EjecutarConsulta(string consultaSQL, Dictionary<string, object> parametros = null)
        {
            DataTable dt = new DataTable();

            //El 'using' asegura que los objetos de conexión se cierren y liberen la memoria.
            using (OleDbConnection conexion = new OleDbConnection(CadConexion))
            {
                using (OleDbCommand comando = new OleDbCommand(consultaSQL, conexion))
                {
                    //Manejo de Parámetros (CLAVE para la seguridad)
                    //Esta parte sirve para que no se pueda hackear la base de datos tan fácil
                    if (parametros != null)
                    {
                        foreach (var param in parametros)
                        {
                            //Usa AddWithValue para agregar el parámetro de forma segura.
                            comando.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    try
                    {
                        conexion.Open();
                        //OleDbDataAdapter ejecuta el comando y llena el DataTable.
                        OleDbDataAdapter da = new OleDbDataAdapter(comando);
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        //Se lanza la excepción para que el formulario la atrape y muestre.
                        throw new Exception("Error al ejecutar la consulta en la Base de Datos: " + ex.Message, ex);
                    }
                }
            }
            return dt;
        }

        public static bool EjecutarComandoSQL(string consultaSQL, Dictionary<string, object> parametros = null)
        {
            using (OleDbConnection conexion = new OleDbConnection(CadConexion))
            {
                using (OleDbCommand comando = new OleDbCommand(consultaSQL, conexion))
                {
                    if (parametros != null)
                    {
                        foreach (var param in parametros)
                        {
                            comando.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    try
                    {
                        conexion.Open();
                        // ExecuteNonQuery devuelve el número de filas afectadas.
                        int filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al ejecutar el comando SQL: " + ex.Message, ex);
                    }
                }
            }
        }
    }
}
