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
        public FormLogin()
        {
            InitializeComponent();
            Conexion miConexion = new Conexion();
            txtUser.TextChanged += ValidateInputFields;
            txtPass.TextChanged += ValidateInputFields;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUser.Text = "User";
            txtPass.Text = "Pass";

            btnIniciar.Enabled = false; // Desactivar botón inicialmente
        }

        // Método para validar si ambos campos tienen texto y habilitar el botón
        private void ValidateInputFields(object sender, EventArgs e)
        {
            btnIniciar.Enabled = !string.IsNullOrWhiteSpace(txtUser.Text) && !string.IsNullOrWhiteSpace(txtPass.Text);
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
               // Open();
                // Aquí puedes agregar lógica de autenticación si es necesario
                // Por ejemplo, verificar si las credenciales son correctas

                if (IsValidCredentials(txtUser.Text, txtPass.Text))
                {
                    // Si las credenciales son correctas, abrir el formulario principal
                    FormPrincipal formPrincipal = new FormPrincipal();
                    this.Hide();
                    formPrincipal.ShowDialog();
                    this.Close();
                }
                else
                {
                    // Mostrar mensaje de error y limpiar los campos
                    MessageBox.Show("Datos incorrectos. Por favor, intenta nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearFields();
                }
            }
        }

        // Método para validar credenciales (puedes reemplazar esto con tu lógica real)
        private bool IsValidCredentials(string username, string password)
        {
            // Ejemplo simple: verificar si coinciden con valores predeterminados
            // Aquí deberías consultar una base de datos o un sistema de autenticación
            return username == "admin" && password == "1234";
        }

        // Método para limpiar los campos de entrada
        private void ClearFields()
        {
            txtUser.Clear();
            txtPass.Clear();
            btnIniciar.Enabled = false;
            txtUser.Focus();
        }
    }
}
