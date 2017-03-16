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

namespace GD_Final_Baternoa.Compra
{
    public partial class CompraConsulta : Form
    {
        Conexion c = new Conexion();

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Gestion-V2;Persist Security Info=True;User ID=sa;Password=12345");
        public CompraConsulta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Compra com = new Compra();
            com.Visible = true;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
