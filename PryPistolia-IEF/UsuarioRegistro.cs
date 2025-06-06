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
            private readonly string cadenaConexion = "Server=localhost\\SQLEXPRESS01;Database=Usuarios;Trusted_Connection=True;";
            public string EstadoConexion { get; private set; }

            public bool ValidarUsuario(string User, string Pass)
            {
                const string sql = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @User AND Pass = @Pass";

                try
                {
                    using (var conexion = new SqlConnection(cadenaConexion))
                    using (var comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@User", User);
                        comando.Parameters.AddWithValue("@Pass", Pass);

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

            public bool RegistrarUsuario(string User, string nombre, string apellido, string descripcion)
            {
                const string sql = @"
            INSERT INTO Usuarios (Login, Nombre, Apellido, Descripcion, FechaRegistro, TiempoUsoMinutos, Contraseña)
            VALUES (@login, @nombre, @apellido, @desc, GETDATE(),)";

                try
                {
                    using (var conexion = new SqlConnection(cadenaConexion))
                    using (var comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", User);
                        comando.Parameters.AddWithValue("@apellido", apellido);
                        comando.Parameters.AddWithValue("@desc", descripcion);


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

            public void RegistrarLogInicioSesion(string User)
            {
                const string sql = "INSERT INTO Auditoria (User, FechaHoraInicio) VALUES (@User, GETDATE())";

                try
                {
                    using (var conexion = new SqlConnection(cadenaConexion))
                    using (var comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@User", User);
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
