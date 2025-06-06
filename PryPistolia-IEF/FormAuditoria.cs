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
    public partial class FormAuditoria : Form
    { 
            public FormAuditoria()
            {
                InitializeComponent();
            }

            private void FormAuditoria_Load(object sender, EventArgs e)
            {
                CargarAuditoria();
            }

            private void CargarAuditoria()
            {
                try
                {
                    // Establecer la consulta SQL
                    string consulta = "SELECT Usuario, FechaInicio, FechaCierre, DuracionSesion FROM Auditoria";

                    // Obtener la conexión a la base de datos
                    using (SqlConnection con = new conexion().ObtenerConexion())
                    {
                        // Crear el adaptador para llenar el DataTable
                        using (SqlDataAdapter adaptador = new SqlDataAdapter(consulta, con))
                        {
                            DataTable tabla = new DataTable();
                            adaptador.Fill(tabla);
                            // Asignar los datos al DataGridView
                            dgvAuditoria.DataSource = tabla;
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Error de base de datos: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la auditoría: " + ex.Message);
                }
            }
        }
