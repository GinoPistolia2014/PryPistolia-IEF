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
        public class FormPrincipal : Form
        {
            private MenuStrip menuStrip;

            public FormPrincipal()
            {
                InitializeComponent();
            }

            private void InitializeComponent()
            {
                // Crear el MenuStrip
                this.menuStrip = new MenuStrip();

                // Crear las opciones del menú
                var usuarioMenuItem = new ToolStripMenuItem("Usuario");
                var auditoriaMenuItem = new ToolStripMenuItem("Auditoria");

                // Agregar las opciones al MenuStrip
                this.menuStrip.Items.Add(usuarioMenuItem);
                this.menuStrip.Items.Add(auditoriaMenuItem);

                // Agregar el MenuStrip al formulario
                this.Controls.Add(this.menuStrip);

                // Configurar el formulario
                this.MainMenuStrip = this.menuStrip;
                this.Text = "Formulario con MenuStrip";
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Width = 400;
                this.Height = 300;
            }
        }
    }
}
