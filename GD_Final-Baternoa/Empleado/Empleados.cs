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
    public partial class Empleados : Form
    {
        Conexion c = new Conexion();
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Gestion-V2;Persist Security Info=True;User ID=sa;Password=12345");
        public Empleados()
        {
            InitializeComponent();
            cargarProvincias();
            cargarCategoria();
            textBoxIDEmp.Enabled = false;
            textBoxIdEmpleado.Enabled = false;


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

        public void cargarCategoria()
        {
            // con.Open();
            SqlCommand cmd = new SqlCommand("SELECT idCategoriaEmpleado, NombreCategoria FROM CategoriaEmpleado", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //con.Close();

            DataRow fila = dt.NewRow();
            fila["NombreCategoria"] = "Selecciona una Categoria";
            dt.Rows.InsertAt(fila, 0);

            comboBoxCategoria.ValueMember = "idCategoriaEmpleado";
            comboBoxCategoria.DisplayMember = "NombreCategoria";
            comboBoxCategoria.DataSource = dt;

        }

        private void Clear()
        {
            textBoxCUIL.Text = "";
            textBoxNombre.Text = "";
            textBoxDireccion.Text = "";
            textBoxNumero.Text = "";
            textBoxTelefono.Text = "";
            textBoxEstadoCivil.Text = "";
            dateTimePicker1.Text = "";
            cargarProvincias();
            cargarCategoria();
            string sql = "SELECT E.idEmpleado, E.CUIL, E.ApellidoyNombre, E.FechaIngreso, E.Telefono, E.EstadoCivil, CT.idCategoriaEmpleado, CT.NombreCategoria, D.Calle , D.Numero, L.idLocalidad, L.NombreLocalidad, Pr.idProvincia, Pr.NombreProvincia from Empleado as E, CategoriaEmpleado as CT, Domicilio as D, Localidad as L, Provincia as Pr where E.idCategoriaEmpleado = CT.idCategoriaEmpleado and E.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia";
            c.CargarConsulta(dataGridViewEmpleado, sql);

            string sql1 = "SELECT F.NombreyApellido, F.DNI, F.Parentezco, F.FechaNacimiento, E.idEmpleado from Familiar as F, Empleado as E where F.idEmpleado = E.idEmpleado";
            c.CargarConsulta(dataGridViewFamiliar, sql1);

        }

        private void Clear2()
        {
            textBoxIdEmpleado.Text = "";
            textBoxDNIFamiliar.Text = "";
            textBoxNombreFamiliar.Text = "";
            textBoxParentezco.Text = "";
            dateTimePicker2.Text = "";
            string sql1 = "SELECT F.NombreyApellido, F.DNI, F.Parentezco, F.FechaNacimiento, E.idEmpleado from Familiar as F, Empleado as E where F.idEmpleado = E.idEmpleado";
            c.CargarConsulta(dataGridViewFamiliar, sql1);
        } 

        private void Empleados_Load(object sender, EventArgs e)
        {
            
            string sql = "SELECT E.idEmpleado, E.CUIL, E.ApellidoyNombre, E.FechaIngreso, E.Telefono, E.EstadoCivil, CT.idCategoriaEmpleado, CT.NombreCategoria, D.Calle , D.Numero, L.idLocalidad, L.NombreLocalidad, Pr.idProvincia, Pr.NombreProvincia from Empleado as E, CategoriaEmpleado as CT, Domicilio as D, Localidad as L, Provincia as Pr where E.idCategoriaEmpleado = CT.idCategoriaEmpleado and E.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia";
            c.CargarConsulta(dataGridViewEmpleado, sql);
            
            
            string sql2 = "SELECT F.NombreyApellido, F.DNI, F.Parentezco, F.FechaNacimiento, E.idEmpleado from Familiar as F, Empleado as E where F.idEmpleado = E.idEmpleado";
            c.CargarConsulta(dataGridViewFamiliar, sql2);
            
        }

        private void comboBoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IdProvincia = comboBoxProvincia.SelectedValue.ToString();
            cargarLocalidad(IdProvincia);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonConsulta_Click(object sender, EventArgs e)
        {
            string cuil = textBoxCUIL.Text;
            string sql = "SELECT E.idEmpleado, C.ApellidoyNombre, C.Telefono,  D.Calle , D.Numero, L.idLocalidad, L.NombreLocalidad, Pr.idProvincia, Pr.NombreProvincia, CT.idCategoriaEmpleado, CA.NombreCategoria from Cliente as C, Domicilio as D, Localidad as L, Provincia as Pr, CategoriaEmpleado as CA where C.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia and E.idCategoriaEmpleado = CA.idCategoriaEmpleado and  E.CUIL = '" + cuil + "'";
            c.CargarConsulta(dataGridViewEmpleado, sql);

            string sql2 = "SELECT F.NombreyApellido, F.DNI, F.Parentezco, F.FechaNacimiento, E.idEmpleado from Familiar as F, Empleado as E where F.idEmpleado = E.idEmpleado and E.idEmpleado = "+ cuil+" ";
            c.CargarConsulta(dataGridViewFamiliar, sql2);


        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int cuil = Convert.ToInt32(textBoxCUIL.Text);

            string sql = "DELETE FROM Empleado where CUIL = " + cuil + "";
            if (c.Eliminar(sql))
            {
                MessageBox.Show("Registro Eliminado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT E.idEmpleado, C.ApellidoyNombre, C.Telefono,  D.Calle , D.Numero, L.idLocalidad, L.NombreLocalidad, Pr.idProvincia, Pr.NombreProvincia, CT.idCategoriaEmpleado, CA.NombreCategoria from Cliente as C, Domicilio as D, Localidad as L, Provincia as Pr, CategoriaEmpleado as CA where C.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia and E.idCategoriaEmpleado = CA.idCategoriaEmpleado";
            c.CargarConsulta(dataGridViewEmpleado, sql3);
        }

        private void dataGridViewEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           textBoxCUIL.Text = dataGridViewEmpleado.Rows[e.RowIndex].Cells["CUIL"].Value.ToString();
            textBoxCUIL.Enabled = false;
           textBoxNombre.Text = dataGridViewEmpleado.Rows[e.RowIndex].Cells["ApellidoyNombre"].Value.ToString();
           dateTimePicker1.Text = dataGridViewEmpleado.Rows[e.RowIndex].Cells["FechaIngreso"].Value.ToString();
           textBoxTelefono.Text = dataGridViewEmpleado.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
           textBoxEstadoCivil.Text = dataGridViewEmpleado.Rows[e.RowIndex].Cells["EstadoCivil"].Value.ToString();
           textBoxDireccion.Text = dataGridViewEmpleado.Rows[e.RowIndex].Cells["Calle"].Value.ToString();
           textBoxNumero.Text = dataGridViewEmpleado.Rows[e.RowIndex].Cells["Numero"].Value.ToString();
           textBoxIDEmp.Text = dataGridViewEmpleado.Rows[e.RowIndex].Cells["idEmpleado"].Value.ToString();

            string iden = dataGridViewEmpleado.Rows[e.RowIndex].Cells["NombreProvincia"].Value.ToString();

            SqlCommand cmd = new SqlCommand("SELECT IdProvincia,NombreProvincia FROM provincia where NombreProvincia = '" + iden + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxProvincia.ValueMember = "IdProvincia";
            comboBoxProvincia.DisplayMember = "NombreProvincia";
            comboBoxProvincia.DataSource = dt;


            string i = dataGridViewEmpleado.Rows[e.RowIndex].Cells["idLocalidad"].Value.ToString();
            int num = int.Parse(i);
            SqlCommand cmd1 = new SqlCommand("SELECT IdLocalidad,NombreLocalidad FROM localidad WHERE IdLocalidad = " + num + "", con);
            cmd.Parameters.AddWithValue("IdProvincia", i);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            comboBoxLocalidad.ValueMember = "IdLocalidad";
            comboBoxLocalidad.DisplayMember = "NombreLocalidad";
            comboBoxLocalidad.DataSource = dt1;


            
            string categ = dataGridViewEmpleado.Rows[e.RowIndex].Cells["NombreCategoria"].Value.ToString();
            //int cat = int.Parse(categ);
            SqlCommand cmd3 = new SqlCommand("SELECT idCategoriaEmpleado, NombreCategoria FROM CategoriaEmpleado where NombreCategoria = '" + categ + "'", con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            comboBoxCategoria.ValueMember = "idCategoriaEmpleado";
            comboBoxCategoria.DisplayMember = "NombreCategoria";
            comboBoxCategoria.DataSource = dt3;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxIDEmp.Text);
            //string sql = "SELECT F.idFamiliar, F.NombreyApellido, F.DNI, F.Parentezco, F.FechaNacimiento, E.idEmpleado from Familiar as F, Empleado as E where F.idEmpleado = E.idEmpleado and E.idEmpleado = " + id + " ";
            string sql = "SELECT *from Familiar where Familiar.idEmpleado = "+ id +" ";
            c.CargarConsulta(dataGridViewFamiliar, sql);
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewFamiliar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxDNIFamiliar.Enabled = false;
            textBoxIdEmpleado.Text = dataGridViewFamiliar.Rows[e.RowIndex].Cells["idEmpleado"].Value.ToString();
            textBoxNombreFamiliar.Text = dataGridViewFamiliar.Rows[e.RowIndex].Cells["NombreyApellido"].Value.ToString();
            textBoxDNIFamiliar.Text = dataGridViewFamiliar.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
            textBoxParentezco.Text = dataGridViewFamiliar.Rows[e.RowIndex].Cells["Parentezco"].Value.ToString();
            dateTimePicker2.Text = dataGridViewFamiliar.Rows[e.RowIndex].Cells["FechaNAcimiento"].Value.ToString();

            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clear2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxDNIFamiliar.Text);
            string sql2 =  "SELECT *from Familiar where DNI = " + id + " ";
            c.CargarConsulta(dataGridViewFamiliar, sql2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string nomb = textBoxNombreFamiliar.Text;
            int dni = int.Parse(textBoxDNIFamiliar.Text);
            string paren = textBoxParentezco.Text;
            DateTime fecha = Convert.ToDateTime(dateTimePicker2.Text);
            int idemp = int.Parse(textBoxIDEmp.Text);
            con.Open();
            string sql2 = " INSERT into Familiar (NombreyApellido, DNI, Parentezco, FechaNacimiento, idEmpleado) VALUES ('" + nomb + "'," + dni + ",'" + paren + "', '" + fecha + "', " + idemp + ")";
            if (c.insertar(sql2))
            {
                MessageBox.Show("Registro insertado");
            }
            con.Close();
            Clear2();
            string sql3 = "SELECT F.NombreyApellido, F.DNI, F.Parentezco, F.FechaNacimiento, E.idEmpleado from Familiar as F, Empleado as E where F.idEmpleado = E.idEmpleado";
            c.CargarConsulta(dataGridViewFamiliar, sql3);
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string calle = textBoxDireccion.Text;
            int num = int.Parse(textBoxNumero.Text);
            int local = Convert.ToInt32(comboBoxLocalidad.SelectedValue);
            string cuil = textBoxCUIL.Text;
            string nombre = textBoxNombre.Text;
            DateTime fecha = Convert.ToDateTime(dateTimePicker1.Text);
            string telef = textBoxTelefono.Text;
            string estado = textBoxEstadoCivil.Text;
            int catego = Convert.ToInt32(comboBoxCategoria.SelectedValue);



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
            string sql2 = " INSERT into Empleado (CUIL , ApellidoyNombre, FechaIngreso, Telefono, EstadoCivil, idDomicilio, idCategoriaEmpleado) VALUES ('" + cuil + "','" + nombre + "','" + fecha + "','" + telef + "','" + estado + "'," + idDom + "," + catego + ")";
            if (c.insertar(sql2))
            {
                MessageBox.Show("Registro insertado");
            }
            con.Close();
            Clear();
            string sql3 = " SELECT E.idEmpleado, C.ApellidoyNombre, C.Telefono,  D.Calle , D.Numero, L.idLocalidad, L.NombreLocalidad, Pr.idProvincia, Pr.NombreProvincia, CT.idCategoriaEmpleado, CA.NombreCategoria,  from Cliente as C, Domicilio as D, Localidad as L, Provincia as Pr, CategoriaEmpleado as CA where C.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia and E.idCategoriaEmpleado = CA.idCategoriaEmpleado ";
            c.CargarConsulta(dataGridViewEmpleado, sql3);
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            int idemp = int.Parse(textBoxIDEmp.Text);
            string calle = textBoxDireccion.Text;
            int num = int.Parse(textBoxNumero.Text);
            int local = Convert.ToInt32(comboBoxLocalidad.SelectedValue);
            string nombre = textBoxNombre.Text;
            DateTime fecha = Convert.ToDateTime(dateTimePicker1.Text);
            string telef = textBoxTelefono.Text;
            string estado = textBoxEstadoCivil.Text;
            int categoria = Convert.ToInt32(comboBoxCategoria.SelectedValue);
            

            con.Open();

            string sql = "select [idDomicilio] from Empleado where idEmpleado = " + idemp + "";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string id = reader[0].ToString();


            string sql1 = " UPDATE Domicilio set [Calle] = '" + calle + "', [Numero] = " + num + ", [idLocalidad] = " + local + " where idDomicilio = " + id + "";
            c.insertar(sql1);



            string sql2 = " UPDATE  Empleado set [ApellidoyNombre] = '" + nombre + "', [FechaIngreso] = '" + fecha + "', [Telefono] = '" + telef + "', [EstadoCivil] = '" + estado + "', [idCategoriaEmpleado] = " + categoria + "   where idEmpleado = " + idemp + "";
            if (c.insertar(sql2))
            {
                MessageBox.Show("Registro Modificado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT E.idEmpleado, C.ApellidoyNombre, C.Telefono,  D.Calle , D.Numero, L.idLocalidad, L.NombreLocalidad, Pr.idProvinca, Pr.NombreProvincia, CT.idCategoriaEmpleado, CA.NombreCategoria from Cliente as C, Domicilio as D, Localidad as L, Provincia as Pr, CategoriaEmpleado as CA where C.idDomicilio = D.idDomicilio and D.idLocalidad = L.idLocalidad and L.idProvincia = Pr.idProvincia and E.idCategoriaEmpleado = CA.idCategoriaEmpleado";
            c.CargarConsulta(dataGridViewEmpleado, sql3);
        }
    

        private void button3_Click(object sender, EventArgs e)
        {
            
            string nomb = textBoxNombreFamiliar.Text;
            int dni = int.Parse(textBoxDNIFamiliar.Text);
            string paren = textBoxParentezco.Text;
            DateTime fecha = Convert.ToDateTime(dateTimePicker2.Text);
            int idemp = int.Parse(textBoxIDEmp.Text);
            


            string sql2 = "UPDATE  Familiar set [NombreyApellido] = '" + nomb + "', [dni] = " + dni  + ", [Parentezco] = '" + paren + "', [FechaNacimiento] = '" + fecha + "'  where DNI = " + dni + "";
            if (c.insertar(sql2))
            {
                MessageBox.Show("Registro Modificado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT F.NombreyApellido, F.DNI, F.Parentezco, F.FechaNacimiento, E.idEmpleado from Familiar as F, Empleado as E where F.idEmpleado = E.idEmpleado";
            c.CargarConsulta(dataGridViewFamiliar, sql3);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            int dni = int.Parse(textBoxDNIFamiliar.Text);

            string sql = "DELETE FROM Familiar where DNI = " + dni + "";
            if (c.Eliminar(sql))
            {
                MessageBox.Show("Registro Eliminado");
            }
            con.Close();
            Clear();
            string sql3 = "SELECT F.NombreyApellido, F.DNI, F.Parentezco, F.FechaNacimiento, E.idEmpleado from Familiar as F, Empleado as E where F.idEmpleado = E.idEmpleado";
            c.CargarConsulta(dataGridViewFamiliar, sql3);
        }
    

        private void checkBoxCambiar_CheckedChanged(object sender, EventArgs e)
        {
            cargarProvincias();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cargarCategoria();
        }

        public  string  CalcularEdad(int idF)
            {
            con.Open();

            string sql1 = " SELECT [FechaNacimiento] from Familiar where DNI = " + idF + "";
            SqlCommand cmd1 = new SqlCommand(sql1);
            cmd1.CommandType = System.Data.CommandType.Text;
            cmd1.Connection = con;
            SqlDataReader reader1 = cmd1.ExecuteReader();
            reader1.Read();
            string fec = reader1[0].ToString();
            DateTime fechaNac = Convert.ToDateTime(fec);
            con.Close();

            con.Open();
            DateTime fechaAct = DateTime.Now.AddYears(-1);
            string sql = " SELECT DATEDIFF( YEAR, '"+ fechaNac + "', '" + fechaAct + "')";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string edad = reader[0].ToString();

            return edad;






        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}

