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

namespace GD_Final_Baternoa.Producto
{
    public partial class Productos : Form
    {
        Conexion c = new Conexion();
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Gestion-V2;Persist Security Info=True;User ID=sa;Password=12345");
        public Productos()
        {
            InitializeComponent();
            cargarCategoria();
            cargarProveedor();
        }

        public void cargarCategoria()
        {
            //con.Open();
            SqlCommand cmd = new SqlCommand("SELECT IdCategoriaProducto,NombreCategoria FROM CategoriaProducto", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //con.Close();

            DataRow fila = dt.NewRow();
            fila["NombreCategoria"] = "Selecciona una Categoria";
            dt.Rows.InsertAt(fila, 0);

            comboBoxCategoria.ValueMember = "IdCategoriaProducto";
            comboBoxCategoria.DisplayMember = "NombreCategoria";
            comboBoxCategoria.DataSource = dt;

        }
        public void cargarProveedor()
        {
            //con.Open();
            SqlCommand cmd = new SqlCommand("SELECT CUITProveedor, RazonSocial FROM Proveedor", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //con.Close();

            DataRow fila = dt.NewRow();
            fila["RazonSocial"] = "Selecciona una Proveedor";
            dt.Rows.InsertAt(fila, 0);

           comboBoxProveedor.ValueMember = "CUITProveedor";
           comboBoxProveedor.DisplayMember = "RazonSocial";
           comboBoxProveedor.DataSource = dt;

        }
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            string cod = textBoxCodigo.Text;
            string sql = "SELECT P.Codigo, P.Tipo, P.Marca, P.Precio, P.Stock, C.idCategoriaProducto, C.NombreCategoria , Pr.CUITProveedor, Pr.RazonSocial  from Producto as P, CategoriaProducto as C, Proveedor as Pr where P.idCategoriaProducto = C.idCategoriaProducto and P.CUITProveedor = Pr.CUITProveedor and P.Codigo = "+ cod +"";
            c.CargarConsulta(dataGridViewProducto, sql);
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            string sql = "SELECT P.Codigo, P.Tipo, P.Marca, P.Precio, P.Stock, C.idCategoriaProducto, C.NombreCategoria , Pr.CUITProveedor, Pr.RazonSocial  from Producto as P, CategoriaProducto as C, Proveedor as Pr where P.idCategoriaProducto = C.idCategoriaProducto and P.CUITProveedor = Pr.CUITProveedor";
            c.CargarConsulta(dataGridViewProducto, sql);
        }

        private void Clear()
        {
            textBoxCodigo.Text = "";
            textBoxMarca.Text = "";
            textBoxPrecio.Text = "";
            textBoxStock.Text = "";
            textBoxTipo.Text = "";
            cargarProveedor();
            cargarCategoria();
            string sql = "SELECT P.Codigo, P.Tipo, P.Marca, P.Precio, P.Stock, C.idCategoriaProducto, C.NombreCategoria , Pr.CUITProveedor, Pr.RazonSocial  from Producto as P, CategoriaProducto as C, Proveedor as Pr where P.idCategoriaProducto = C.idCategoriaProducto and P.CUITProveedor = Pr.CUITProveedor";
            c.CargarConsulta(dataGridViewProducto, sql);

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(textBoxCodigo.Text);
            string tipo = textBoxTipo.Text;
            string marca = textBoxMarca.Text;
            float precio =  System.Convert.ToSingle(textBoxPrecio.Text);
            int stock = int.Parse(textBoxStock.Text);
            int cat = Convert.ToInt32(comboBoxCategoria.SelectedValue);
            int prov = Convert.ToInt32(comboBoxProveedor.SelectedValue);

            con.Open();
            string sql2 = "INSERT INTO Producto (Codigo, Tipo, Marca, Precio, Stock, idCategoriaProducto, CUITProveedor) VALUES (" + codigo + ",'" + tipo + "','" + marca + "','" + precio + "','" + stock + "'," + cat + ",'"+ prov +"')";
            if (c.insertar(sql2))
            {
                MessageBox.Show("Registro insertado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT P.Codigo, P.Tipo, P.Marca, P.Precio, P.Stock, C.idCategoriaProducto, C.NombreCategoria , Pr.CUITProveedor, Pr.RazonSocial  from Producto as P, CategoriaProducto as C, Proveedor as Pr where P.idCategoriaProducto = C.idCategoriaProducto and P.CUITProveedor = Pr.CUITProveedor";
            c.CargarConsulta(dataGridViewProducto, sql3);
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(textBoxCodigo.Text);
            string sql = "DELETE FROM Producto where Codigo = " + cod + "";
            if (c.Eliminar(sql))
            {
                MessageBox.Show("Registro Eliminado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT P.Codigo, P.Tipo, P.Marca, P.Precio, P.Stock, C.idCategoriaProducto, C.NombreCategoria , Pr.CUITProveedor, Pr.RazonSocial  from Producto as P, CategoriaProducto as C, Proveedor as Pr where P.idCategoriaProducto = C.idCategoriaProducto and P.CUITProveedor = Pr.CUITProveedor";
            c.CargarConsulta(dataGridViewProducto, sql3);
        }

        private void dataGridViewProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridViewProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxCodigo.Text = dataGridViewProducto.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
            textBoxMarca.Text = dataGridViewProducto.Rows[e.RowIndex].Cells["Marca"].Value.ToString();
            textBoxPrecio.Text = dataGridViewProducto.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
            textBoxTipo.Text = dataGridViewProducto.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();
            textBoxStock.Text = dataGridViewProducto.Rows[e.RowIndex].Cells["Stock"].Value.ToString();

            string pr = dataGridViewProducto.Rows[e.RowIndex].Cells["CUITProveedor"].Value.ToString();

            SqlCommand cmd = new SqlCommand("SELECT CUITProveedor, RazonSocial FROM Proveedor where CUITProveedor = '" + pr + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxProveedor.ValueMember = "CUITProveedor";
            comboBoxProveedor.DisplayMember = "RazonSocial";
            comboBoxProveedor.DataSource = dt;

            //string ca = dataGridViewProducto.Rows[e.RowIndex].Cells["CUITProveedor"].Value.ToString();
            string ca = dataGridViewProducto.Rows[e.RowIndex].Cells["idCategoriaProducto"].Value.ToString();
            int num = int.Parse(ca);
            SqlCommand cmd1 = new SqlCommand("SELECT idCategoriaProducto, NombreCategoria FROM CategoriaProducto where idCategoriaProducto = " + num + "", con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            comboBoxCategoria.ValueMember = "idCategoriaProducto";
            comboBoxCategoria.DisplayMember = "NombreCategoria";
            comboBoxCategoria.DataSource = dt1;

        }

        private void checkBoxCambiar_CheckedChanged(object sender, EventArgs e)
        {
            
            cargarProveedor();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cargarCategoria();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {

        }
    }
}
