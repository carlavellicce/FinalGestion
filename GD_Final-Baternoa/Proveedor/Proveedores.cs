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

namespace GD_Final_Baternoa.Proveedor
{
    public partial class Proveedores : Form
    {

        Conexion c = new Conexion();
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Gestion-V2;Persist Security Info=True;User ID=sa;Password=12345");
       
        public Proveedores()
        {
            InitializeComponent();
            cargarProvincias();
        }

        public void cargarProvincias()
        {
            //con.Open();
            SqlCommand cmd = new SqlCommand("SELECT IdProvincia,NombreProvincia FROM provincia", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //con.Close();

            DataRow fila = dt.NewRow();
            fila["NombreProvincia"] = "Selecciona una Provincia";
            dt.Rows.InsertAt(fila, 0);

            comboBoxProvincia.ValueMember = "IdProvincia";
            comboBoxProvincia.DisplayMember = "NombreProvincia";
            comboBoxProvincia.DataSource = dt;

        }

        public void cargarLocalidad(string IdProvincia)
        {
            // con.Open();
            SqlCommand cmd = new SqlCommand("SELECT IdLocalidad,NombreLocalidad FROM localidad WHERE IdProvincia = @IdProvincia", con);
            cmd.Parameters.AddWithValue("IdProvincia", IdProvincia);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //con.Close();

            DataRow dr = dt.NewRow();
            dr["NombreLocalidad"] = "Selecciona una Localidad";
            dt.Rows.InsertAt(dr, 0);
            comboBoxLocalidad.ValueMember = "IdLocalidad";
            comboBoxLocalidad.DisplayMember = "NombreLocalidad";
            comboBoxLocalidad.DataSource = dt;

        }
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            string idprov = textBoxCUITProveedor.Text;
            string sql = "SELECT P.CUITProveedor, P.RazonSocial, P.Rubro, P.Telefono, P.CorreoElectronico, D.Calle , D.Numero, L.NombreLocalidad, L.idLocalidad, Pr.NombreProvincia, Pr.idProvincia from Proveedor as P, Domicilio as D, Localidad as L, Provincia as Pr where P.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia";
            c.CargarConsulta(dataGridViewProveedor, sql);
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            string sql = "SELECT P.CUITProveedor, P.RazonSocial, P.Rubro, P.Telefono, P.CorreoElectronico, D.Calle , D.Numero, L.NombreLocalidad, L.idLocalidad, Pr.NombreProvincia, Pr.idProvincia from Proveedor as P, Domicilio as D, Localidad as L, Provincia as Pr where P.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia";
            c.CargarConsulta(dataGridViewProveedor, sql);
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string calle = textBoxDireccion.Text;
            int num = int.Parse(textBoxNumero.Text);
            int local = Convert.ToInt32(comboBoxLocalidad.SelectedValue);
            string cuit = textBoxCUITProveedor.Text;
            string razon = textBoxRazonSocial.Text;
            string rubro = textBoxRubro.Text;
            string telefono = textBoxTelefono.Text;
            string correo = textBoxCorreo.Text;

            string sql = "INSERT INTO Domicilio (Calle, Numero, idLocalidad) VALUES ('" + calle + "'," + num + "," + local + ") SELECT SCOPE_IDENTITY();";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string idDom = reader[0].ToString();
            con.Close();

            con.Open();
            string sql2 = "INSERT INTO Proveedor (CUITProveedor, RazonSocial, Rubro, Telefono, CorreoElectronico, idDomicilio) VALUES ('" + cuit + "','" + razon + "','" + rubro + "','" + telefono + "','" + correo + "'," + idDom + ")";
            if (c.insertar(sql2))
            {
                MessageBox.Show("Registro insertado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT P.CUITProveedor, P.RazonSocial, P.Rubro, P.Telefono, P.CorreoElectronico, D.Calle , D.Numero, L.NombreLocalidad, L.idLocalidad, Pr.NombreProvincia, Pr.idProvincia from Proveedor as P, Domicilio as D, Localidad as L, Provincia as Pr where P.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia";
            c.CargarConsulta(dataGridViewProveedor, sql3);

        }

        private void comboBoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProvincia.SelectedValue.ToString() != null)
            {
                string IdProvincia = comboBoxProvincia.SelectedValue.ToString();
                cargarLocalidad(IdProvincia);

            }
        }

        private void Clear()
        {
            textBoxCUITProveedor.Text = "";
            textBoxRazonSocial.Text = "";
            textBoxRubro.Text = "";
            textBoxDireccion.Text = "";
            textBoxCorreo.Text = "";
            textBoxNumero.Text = "";
            textBoxTelefono.Text = "";
            cargarProvincias();

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            string idProv = textBoxCUITProveedor.Text;            
            string sql = "DELETE FROM Proveedor where CUITProveedor = '" + idProv + "'";
            if (c.Eliminar(sql))
            {
                MessageBox.Show("Registro Eliminado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT P.CUITProveedor, P.RazonSocial, P.Rubro, P.Telefono, P.CorreoElectronico, D.Calle , D.Numero, L.NombreLocalidad, L.idLocalidad, Pr.NombreProvincia, Pr.idProvincia from Proveedor as P, Domicilio as D, Localidad as L, Provincia as Pr where P.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia";
            c.CargarConsulta(dataGridViewProveedor, sql3);
        }

        private void dataGridViewProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // string Proveedorleccionado = dataGridViewProveedor.Rows[e.RowIndex].Cells[0].Value.ToString();
            //MessageBox.Show("clienteseleccionado :" + Proveedorleccionado);

            
            textBoxCUITProveedor.Text = dataGridViewProveedor.Rows[e.RowIndex].Cells["CUITProveedor"].Value.ToString();
            textBoxRazonSocial.Text = dataGridViewProveedor.Rows[e.RowIndex].Cells["RazonSocial"].Value.ToString();
            textBoxRubro.Text = dataGridViewProveedor.Rows[e.RowIndex].Cells["Rubro"].Value.ToString();
            textBoxTelefono.Text = dataGridViewProveedor.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
            textBoxCorreo.Text =  dataGridViewProveedor.Rows[e.RowIndex].Cells["CorreoElectronico"].Value.ToString();
            textBoxDireccion.Text = dataGridViewProveedor.Rows[e.RowIndex].Cells["Calle"].Value.ToString();
            textBoxNumero.Text = dataGridViewProveedor.Rows[e.RowIndex].Cells["Numero"].Value.ToString();

           // comboBoxProvincia.ValueMember = dataGridViewProveedor.Rows[e.RowIndex].Cells["idProvincia"].Value.ToString();
            comboBoxProvincia.DisplayMember = dataGridViewProveedor.Rows[e.RowIndex].Cells["idProvincia"].Value.ToString();
            //comboBoxLocalidad.ValueMember = dataGridViewProveedor.Rows[e.RowIndex].Cells["idLocalidad"].Value.ToString();
            comboBoxLocalidad.DisplayMember = dataGridViewProveedor.Rows[e.RowIndex].Cells["NombreLocalidad"].Value.ToString();


            
           

            
        }

        private void dataGridViewProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {

            string calle = textBoxDireccion.Text;
            int num = int.Parse(textBoxNumero.Text);


            int local = Convert.ToInt32(comboBoxLocalidad.SelectedValue);
            string idProv = textBoxCUITProveedor.Text;
            string razon = textBoxRazonSocial.Text;
            string rubro = textBoxRubro.Text;
            string telefono = textBoxTelefono.Text;
            string correo = textBoxCorreo.Text;
            con.Open();
           


            string sql = "select [idDomicilio]from Proveedor where CUITProveedor = '" + idProv + "' ";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string id= reader[0].ToString();

            string sql1 = "UPDATE Domicilio set [Calle] = '" + calle + "', [Numero] = " + num + ", [idLocalidad] = " + local + " where idDomicilio = " + id + "";
            c.insertar(sql1);


            string sql2 = "UPDATE  Proveedor set [RazonSocial] = '" + razon + "', [Rubro] = '" + rubro + "', [Telefono] = '" + telefono + "', [CorreoElectronico] = '" + correo + "'  where CUITProveedor = '" + idProv +"' ";
            if (c.insertar(sql2))
            {
                MessageBox.Show("Registro Modificado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT P.CUITProveedor, P.RazonSocial, P.Rubro, P.Telefono, P.CorreoElectronico, D.Calle , D.Numero, L.NombreLocalidad, L.idLocalidad, Pr.NombreProvincia from Proveedor as P, Domicilio as D, Localidad as L, Provincia as Pr where P.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia";
            c.CargarConsulta(dataGridViewProveedor, sql3);
        }
    }
}
