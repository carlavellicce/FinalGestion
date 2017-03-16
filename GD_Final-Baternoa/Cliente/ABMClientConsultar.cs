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

namespace GD_Final_Baternoa.Cliente
{
    public partial class ABMCLienteConsulta : Form
    {
        Conexion c = new Conexion();
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Gestion-V2;Persist Security Info=True;User ID=sa;Password=12345");
        public ABMCLienteConsulta()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            Cliente.ABMClientes ABMC = new Cliente.ABMClientes();
            ABMC.Visible = true;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            int idCli = int.Parse(textBoxCliente.Text);
            if (idCli == 0)
            {
                string sql = "SELECT *FROM Cliente";
                c.CargarConsulta(dataGridViewCliente, sql);
            }
            else
            {
                string sql = "SELECT *FROM Cliente join Domicilio on Cliente.idDomicilio = Domicilio.idDomicilio WHERE DNICliente = " + idCli + "";
                c.CargarConsulta(dataGridViewCliente, sql);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {

            int idCli = int.Parse(textBoxCliente.Text);
            string sql = "DELETE FROM Cliente where DNICliente = " + idCli + "";

            if (c.insertar(sql))
            {
                MessageBox.Show("Registro Eliminado");
            }
        }
    }
}
