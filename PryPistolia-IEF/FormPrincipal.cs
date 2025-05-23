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
    public partial class FormPrincipal : Form
    {
        FormAuditoria FormAuditoria = new FormAuditoria();
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void auditoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAuditoria.Show
        }
    }
}
