using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SqlClient;

namespace PryPistolia_IEF
{
    public class Conexion
    {
        private string connectionString;

        // Constructor que recibe la cadena de conexión
        public Conexion()
        {
            // Reemplaza los valores con los datos de tu base de datos
            connectionString = "Server=tu_servidor;Database=tu_base_de_datos;User Id=tu_usuario;Password=tu_contraseña;";
        }

        // Método para obtener la conexión
        public SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            try
            {
                conexion.Open();
                Console.WriteLine("Conexión exitosa.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
            }
            return conexion;
        }
    }
}
