using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryPistolia_IEF
{
    public partial class FormLogin : Form
    {
        private UsuarioRegistro Usuario;
                public string connectionString = "Server = localhost\\SQLEXPRESS; Database = Gestion; Trusted_Connection = True";
            Conexion c = new Conexion();
        public FormLogin()
        {
            InitializeComponent();

            Usuario = new UsuarioRegistro();
        
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //lblConexion.Text = Usuario.estadoConexion;
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string User = txtUser.Text.Trim();
            string Pass = txtPass.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Pass))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Datos adicionales (puedes agregar TextBox para estos)
            string nombre = "Nuevo";
            string apellido = "Usuario";
            string descripcion = "Registrado desde el sistema";

            try
            {
                bool registrado = Usuario.UsuarioRegistro(User, Nombre, Apellido, Descripcion, Pass);
                if (registrado)
                {
                    MessageBox.Show("Usuario registrado correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al registrar: " + Usuario.estadoConexion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string login = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debe ingresar el usuario y la contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool loginExitoso = Usuario.ValidarLogin(login, password);
                if (loginExitoso)
                {
                    MessageBox.Show("Inicio de sesión exitoso", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                    // Pasar el login al formulario principal
                    FormPrincipal principal = new FormPrincipal(Usuario);
                    principal.ShowDialog();

                    // Cerrar la aplicación cuando se cierre el formulario principal
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex);
            }    
        }
    }
}
