using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryPistolia_IEF
{
    internal class UsuarioRegistro
    {
        internal class Usuario
        {
            private readonly string cadenaConexion = "Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;";
            public string EstadoConexion { get; private set; }

            public bool ValidarUsuario(string login, string contraseña)
            {
                const string sql = "SELECT COUNT(*) FROM Usuarios WHERE Login = @login AND Contraseña = @clave";

                try
                {
                    using (var conexion = new SqlConnection(cadenaConexion))
                    using (var comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@login", login);
                        comando.Parameters.AddWithValue("@clave", contraseña);

                        conexion.Open();
                        int cantidad = (int)comando.ExecuteScalar();
                        EstadoConexion = "Usuario validado correctamente.";
                        return cantidad > 0;
                    }
                }
                catch (Exception ex)
                {
                    EstadoConexion = $"Error: {ex.Message}";
                    return false;
                }
            }

            public bool RegistrarUsuario(string login, string nombre, string apellido, string descripcion, string clave)
            {
                const string sql = @"
            INSERT INTO Usuarios (Login, Nombre, Apellido, Descripcion, FechaRegistro, TiempoUsoMinutos, Contraseña)
            VALUES (@login, @nombre, @apellido, @desc, GETDATE(), 0, @clave)";

                try
                {
                    using (var conexion = new SqlConnection(cadenaConexion))
                    using (var comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@login", login);
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@apellido", apellido);
                        comando.Parameters.AddWithValue("@desc", descripcion);
                        comando.Parameters.AddWithValue("@clave", clave);

                        conexion.Open();
                        comando.ExecuteNonQuery();
                        EstadoConexion = "Usuario registrado correctamente.";
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    EstadoConexion = $"Error: {ex.Message}";
                    return false;
                }
            }

            public void RegistrarLogInicioSesion(string login)
            {
                const string sql = "INSERT INTO Auditoria (Login, FechaHoraInicio) VALUES (@login, GETDATE())";

                try
                {
                    using (var conexion = new SqlConnection(cadenaConexion))
                    using (var comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@login", login);
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }
                catch
                {
                    // Se podría agregar log de errores aquí si es necesario
                }
            }
        }
    }
}
