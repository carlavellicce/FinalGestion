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
    public partial class Clientes : Form
    {
        Conexion c = new Conexion();
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Gestion-V2;Persist Security Info=True;User ID=sa;Password=12345");

        public Clientes()
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



        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int dni = Convert.ToInt32(textBoxDNI.Text);
            
            string sql = "DELETE FROM Cliente where DNICliente = " + dni + "";
            if (c.Eliminar(sql))
            {
                MessageBox.Show("Registro Eliminado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT C.DNICliente, C.ApellidoyNombre, C.Telefono,  D.Calle , D.Numero, L.NombreLocalidad, D.idLocalidad, Pr.NombreProvincia, Pr.idProvincia from Cliente as C, Domicilio as D, Localidad as L, Provincia as Pr where C.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia";
            c.CargarConsulta(dataGridViewClientes, sql3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            textBoxDNI.Text = "";
            textBoxNombre.Text = "";
            textBoxCalle.Text = "";
            textBoxNumero.Text = "";
            textBoxTelefono.Text = "";
            cargarProvincias();

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            string sql = "SELECT C.DNICliente, C.ApellidoyNombre, C.Telefono,  D.Calle , D.Numero, L.NombreLocalidad, D.idLocalidad, Pr.NombreProvincia, Pr.idProvincia from Cliente as C, Domicilio as D, Localidad as L, Provincia as Pr where C.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia";
            c.CargarConsulta(dataGridViewClientes, sql);
        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            string idCli = textBoxDNI.Text;
            string sql = "SELECT C.DNICliente, C.ApellidoyNombre, C.Telefono,  D.Calle , D.Numero, L.NombreLocalidad, D.idLocalidad, Pr.NombreProvincia, Pr.idProvincia from Cliente as C, Domicilio as D, Localidad as L, Provincia as Pr where C.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia and CUITProveedor =  '" + idCli + "'";
            
            c.CargarConsulta(dataGridViewClientes, sql);
        }

        private void comboBoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProvincia.SelectedValue.ToString() != null)
            {
                string IdProvincia = comboBoxProvincia.SelectedValue.ToString();
                cargarLocalidad(IdProvincia);

            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string calle = textBoxCalle.Text;
            int num = int.Parse(textBoxNumero.Text);
            int local = Convert.ToInt32(comboBoxLocalidad.SelectedValue);
            int dni = Convert.ToInt32(textBoxDNI.Text);
            string nombre = textBoxNombre.Text;
            string telefono = textBoxTelefono.Text;
            

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
            string sql2 = "INSERT INTO Cliente (DNICliente, ApellidoyNombre, Telefono, idDomicilio) VALUES (" + dni + ",'" + nombre + "','" + telefono + "', " + idDom + ")";
            if (c.insertar(sql2))
            {
                MessageBox.Show("Registro insertado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT C.DNICliente, C.ApellidoyNombre, C.Telefono,  D.Calle , D.Numero, L.NombreLocalidad, D.idLocalidad, Pr.NombreProvincia, Pr.idProvincia from Cliente as C, Domicilio as D, Localidad as L, Provincia as Pr where C.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia";
            c.CargarConsulta(dataGridViewClientes, sql3);
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            string calle = textBoxCalle.Text;
            int num = int.Parse(textBoxNumero.Text);
           
            int dni = Convert.ToInt32(textBoxDNI.Text);
            string nombre = textBoxNombre.Text;
            string telefono = textBoxTelefono.Text;
            con.Open();


            
                int local = Convert.ToInt32(comboBoxLocalidad.SelectedValue);

                string sql = "select [idDomicilio]from Cliente where DNICliente = " + dni + "";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string id = reader[0].ToString();


                string sql1 = "UPDATE Domicilio set [Calle] = '" + calle + "', [Numero] = " + num + ", [idLocalidad] = " + local + " where idDomicilio = " + id + "";
                c.insertar(sql1);

            

            string sql2 = "UPDATE  Cliente set [ApellidoyNombre] = '" + nombre + "', [Telefono] = '" + telefono + "'  where DNICliente = " + dni + "";
            if (c.insertar(sql2))
            {
                MessageBox.Show("Registro Modificado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT C.DNICliente, C.ApellidoyNombre, C.Telefono,  D.Calle , D.Numero, L.NombreLocalidad, D.idLocalidad, Pr.NombreProvincia, Pr.idProvincia from Cliente as C, Domicilio as D, Localidad as L, Provincia as Pr where C.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia";
            c.CargarConsulta(dataGridViewClientes, sql3);
        }

        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
  
                textBoxDNI.Text = dataGridViewClientes.Rows[e.RowIndex].Cells["DNICliente"].Value.ToString();
                textBoxNombre.Text = dataGridViewClientes.Rows[e.RowIndex].Cells["ApellidoyNombre"].Value.ToString();
                textBoxTelefono.Text = dataGridViewClientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                textBoxCalle.Text = dataGridViewClientes.Rows[e.RowIndex].Cells["Calle"].Value.ToString();
                textBoxNumero.Text = dataGridViewClientes.Rows[e.RowIndex].Cells["Numero"].Value.ToString();

                string iden = dataGridViewClientes.Rows[e.RowIndex].Cells["NombreProvincia"].Value.ToString();
               
                SqlCommand cmd = new SqlCommand("SELECT IdProvincia,NombreProvincia FROM provincia where NombreProvincia = '" + iden + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBoxProvincia.ValueMember = "IdProvincia";
                comboBoxProvincia.DisplayMember = "NombreProvincia";
                comboBoxProvincia.DataSource = dt;


                string i = dataGridViewClientes.Rows[e.RowIndex].Cells["idLocalidad"].Value.ToString();
                int num = int.Parse(i);  
                SqlCommand cmd1 = new SqlCommand("SELECT IdLocalidad,NombreLocalidad FROM localidad WHERE IdLocalidad = "+ num +"", con);
                 cmd.Parameters.AddWithValue("IdProvincia", i);
                 SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                 DataTable dt1 = new DataTable();
                 da1.Fill(dt1);
                 comboBoxLocalidad.ValueMember = "IdLocalidad";
                 comboBoxLocalidad.DisplayMember = "NombreLocalidad";
                 comboBoxLocalidad.DataSource = dt1;
           
        }

        private void checkBoxCambiar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCambiar.Checked == true)
            {
                cargarProvincias();

            }
        }
    }
}
