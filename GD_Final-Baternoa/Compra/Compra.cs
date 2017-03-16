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
    public partial class Compra : Form
    {
        Conexion c = new Conexion();

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Gestion-V2;Persist Security Info=True;User ID=sa;Password=12345");
        public Compra()
        {
            InitializeComponent();
            cargarProveedor();
            cargarEmpleado();
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
            fila["RazonSocial"] = "Selecciona un Proveedor";
            dt.Rows.InsertAt(fila, 0);

            comboBoxProveedor.ValueMember = "CUITProveedor";
            comboBoxProveedor.DisplayMember = "RazonSocial";
            comboBoxProveedor.DataSource = dt;

        }
        public void cargarEmpleado()
        {
            //con.Open();
            SqlCommand cmd = new SqlCommand("SELECT idEmpleado, ApellidoyNombre FROM Empleado", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //con.Close();

            DataRow fila = dt.NewRow();
            fila["ApellidoyNombre"] = "Selecciona un Empleaado";
            dt.Rows.InsertAt(fila, 0);

            comboBoxEmpleado.ValueMember = "idEmpleado";
            comboBoxEmpleado.DisplayMember = "ApellidoyNombre";
            comboBoxEmpleado.DataSource = dt;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Compra_Load(object sender, EventArgs e)
        {
            textBoxFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            textBoxHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
