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
    public partial class CategoriaProducto : Form
    {
        Conexion c = new Conexion();
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Gestion-V2;Persist Security Info=True;User ID=sa;Password=12345");
        public CategoriaProducto()
        {
            InitializeComponent();
            textBoxID.Enabled = false;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CategoriaProducto_Load(object sender, EventArgs e)
        {
            string sql = "SELECT *from CategoriaProducto";
            c.CargarConsulta(dataGridViewCatProd, sql);
        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            string nom = textBoxNomCat.Text;
            string sql = "SELECT *from CategoriaProducto where NombreCategoria = '"+ nom +"'";
            c.CargarConsulta(dataGridViewCatProd, sql);
        }

        private void Clear()
        {
            textBoxID.Text = "";
            textBoxDescripcion.Text = "";
            textBoxNomCat.Text = "";
            string sql = "SELECT *from CategoriaProducto";
            c.CargarConsulta(dataGridViewCatProd, sql);

        }
        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {

            string nom = textBoxNomCat.Text;
            string des = textBoxDescripcion.Text;
            
            con.Open();
            string sql2 = "INSERT INTO CategoriaProducto (NombreCategoria, Descripcion) VALUES ('" + nom + "','" + des + "')";
            if (c.insertar(sql2))
            {
                MessageBox.Show("Registro insertado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT *from CategoriaProducto";
            c.CargarConsulta(dataGridViewCatProd, sql3);
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            
            int id = int.Parse(textBoxID.Text);

            con.Open();
            string sql2 = "DELETE FROM CategoriaProducto where idCategoriaProducto = " + id + "";
            
            if (c.insertar(sql2))
            {
                MessageBox.Show("Registro Eliminado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT *from CategoriaProducto";
            c.CargarConsulta(dataGridViewCatProd, sql3);
        }

        private void dataGridViewCatProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridViewCatProd.Rows[e.RowIndex].Cells["idCategoriaProducto"].Value.ToString();
            textBoxNomCat.Text = dataGridViewCatProd.Rows[e.RowIndex].Cells["NombreCategoria"].Value.ToString();
            textBoxDescripcion.Text = dataGridViewCatProd.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxID.Text);
            string nom = textBoxNomCat.Text;
            string des = textBoxDescripcion.Text;

            string sql2 = "UPDATE  CategoriaProducto set [NombreCategoria] = '" + nom + "', [Descripcion] = '" + des + "'  where idCategoriaProducto = " + id + "";
            if (c.insertar(sql2))
            {
                MessageBox.Show("Registro Modificado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT *from CategoriaProducto";
            c.CargarConsulta(dataGridViewCatProd, sql3);
        }
    }
    }


