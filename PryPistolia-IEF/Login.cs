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
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            lblUser.Text = "User";
            lblPass.Text = "Pass";

            btnIniciar.Enabled = false;

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            
            if (txtUser.Text == "" || txtPass.Text == "")
            {
                FormPrincipal formPrincipal = new FormPrincipal();
                this.Hide();
                formPrincipal.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos incorrectos.");
            }
        }
        
    }
}
