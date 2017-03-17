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
    public partial class VerFamilia : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = EMYLAVENIA\SQLEXPRESS; Initial Catalog = Gestion-V2; Integrated Security = True");
        private string valorEnForm2; 
        int sumaH = 0;

        public VerFamilia(string valor)
        {
            InitializeComponent();
            this.valorEnForm2 = valor;
        }

        private void CargarFamiliar()
        {
            con.Open();
            SqlDataAdapter daf = new SqlDataAdapter("Select * From Familiar Where idEmpleado = '" + txtIDEmpleado.Text + "'", con);
            DataSet dsf = new DataSet();
            daf.Fill(dsf, "Familiar");

            dgvFamilia.DataSource = dsf;
            dgvFamilia.DataMember = "Familiar";
            con.Close();
        } 

        private void VerFamilia_Load(object sender, EventArgs e)
        {
            txtIDEmpleado.Text = valorEnForm2;

            CargarFamiliar();

        }

        private void dgvFamilia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDNI.Text = dgvFamilia.CurrentRow.Cells["DNI"].Value.ToString();
            dtpFamiliar.Text = dgvFamilia.CurrentRow.Cells["FechaNacimiento"].Value.ToString();

            int edad;
            edad = System.DateTime.Today.Year - dtpFamiliar.Value.Year;
            if (System.DateTime.Today.Month < dtpFamiliar.Value.Month)
            {
                if (dtpFamiliar.Value.Day < System.DateTime.Today.Day)
                {
                    edad = edad - 1;
                }
            }
            else
            { }

            txtEdad.Text = edad.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sumaH = sumaH + 1;
            txtSumaHijos.Text = sumaH.ToString();
            dgvFamilia.Rows.Remove(dgvFamilia.CurrentRow);
        }


        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
             Liquidacion.PantallaLiquidacion pl = new Liquidacion.PantallaLiquidacion();
             pl.txtHijos.Text = txtSumaHijos.Text;
             pl.Show();
            


        }
    }
}
