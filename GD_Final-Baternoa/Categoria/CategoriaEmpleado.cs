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

namespace GD_Final_Baternoa.Categoria
{
    public partial class CategoriaEmpleado : Form
    {
        Conexion c = new Conexion();
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Gestion-V2;Persist Security Info=True;User ID=sa;Password=12345");
      

        public CategoriaEmpleado()
        {
            InitializeComponent();
            textBoxID.Enabled = false; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CategoriaEmpleado_Load(object sender, EventArgs e)
        {

            string sql = "SELECT *from CategoriaEmpleado";
            c.CargarConsulta(dataGridViewCatEmpleado, sql);
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            textBoxDescripcion.Text = "";
            textBoxNombre.Text = "";
            textBoxSueldo.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            string sql = "SELECT *from CategoriaEmpleado where NombreCategoria = '"+ nombre +"'";
            c.CargarConsulta(dataGridViewCatEmpleado, sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string nom = textBoxNombre.Text;
            string des = textBoxDescripcion.Text;
            float sueldo = System.Convert.ToSingle(textBoxSueldo.Text);
            con.Open();
            string sql2 = "INSERT INTO CategoriaEmpleado (NombreCategoria, Descripcion, SueldoBasico) VALUES ('" + nom + "','" + des + "'," + sueldo + ")";
            if (c.insertar(sql2))
            {
                MessageBox.Show("Registro insertado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT *from CategoriaEmpleado";
            c.CargarConsulta(dataGridViewCatEmpleado, sql3);
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxID.Text);
            string nom = textBoxNombre.Text;
            string des = textBoxDescripcion.Text;
            float sueldo = System.Convert.ToSingle(textBoxSueldo.Text);

            string sql2 = "UPDATE  CategoriaEmpleado set [NombreCategoria] = '" + nom + "', [Descripcion] = '" + des + "',[SueldoBasico] = " + sueldo + "  where idCategoriaEmpleado = " + id + "";
            if (c.insertar(sql2))
            {
                MessageBox.Show("Registro Modificado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT *from CategoriaEmpleado";
            c.CargarConsulta(dataGridViewCatEmpleado, sql3);
        }

        private void dataGridViewCatEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridViewCatEmpleado.Rows[e.RowIndex].Cells["idCategoriaEmpleado"].Value.ToString();
            textBoxNombre.Text = dataGridViewCatEmpleado.Rows[e.RowIndex].Cells["NombreCategoria"].Value.ToString();
            textBoxDescripcion.Text = dataGridViewCatEmpleado.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
            textBoxSueldo.Text = dataGridViewCatEmpleado.Rows[e.RowIndex].Cells["SueldoBasico"].Value.ToString();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxID.Text);
            string sql = "DELETE FROM CategoriaEmpleado where idCategoriaEmpleado = " + id + "";
            if (c.Eliminar(sql))
            {
                MessageBox.Show("Registro Eliminado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT *from CategoriaEmpleado";
            c.CargarConsulta(dataGridViewCatEmpleado, sql3);
        }
    }
}
