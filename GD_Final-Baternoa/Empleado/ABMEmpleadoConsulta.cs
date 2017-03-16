using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GD_Final_Baternoa.Empleado
{
    public partial class ABMEmpleadoConsulta : Form
    {
        Conexion c = new Conexion();
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Gestion-V2;Persist Security Info=True;User ID=sa;Password=12345");
        public ABMEmpleadoConsulta()
        {
            InitializeComponent();
        }

      

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            Empleado.ABMEmpleados ABMEN = new Empleado.ABMEmpleados();
            ABMEN.Visible = true;
        }

        private void buttonNuevoFliar_Click(object sender, EventArgs e)
        {
            Empleado.ABMFamiliar ABMEF = new Empleado.ABMFamiliar();
            ABMEF.Visible = true;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            int idEmp = int.Parse(textBoxEmpleado.Text);
            if (idEmp == 0)
            {
                string sql = "SELECT *FROM Empleado";
                c.CargarConsulta(dataGridViewEmpleado, sql);
                string sql3 = "SELECT *FROM Familiar";
                c.CargarConsulta(dataGridViewGrupoFliar, sql3);
            }
            else
            {
                //int idProv = int.Parse(textBoxProveedor.Text);
                string sql = "SELECT *FROM Empleado where idEmpleado = " + idEmp + "";
                c.CargarConsulta(dataGridViewEmpleado, sql);

                string sql2 = "SELECT *FROM Familiar where idEmpleado = " + idEmp + "";
                c.CargarConsulta(dataGridViewGrupoFliar, sql2);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
