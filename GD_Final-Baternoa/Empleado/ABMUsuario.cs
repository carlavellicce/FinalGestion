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
using System.Security.Cryptography;

namespace GD_Final_Baternoa.Empleado
{
    public partial class ABMUsuario : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source = EMYLAVENIA\SQLEXPRESS; Initial Catalog = Gestion-V2; Integrated Security = True");

        private string passwordUsuario = null;
        private string passEncriptado;

        public ABMUsuario()
        {
            InitializeComponent();
            cargarEmpleados();
        }


        private void ABMUsuario_Load(object sender, EventArgs e)
        {

        }

        public void cargarEmpleados()
        {

            SqlCommand cmd = new SqlCommand("SELECT idEmpleado,ApellidoyNombre FROM Empleado", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            DataRow fila = dt.NewRow();
            fila["ApellidoyNombre"] = "Selecciona un Empleado";
            dt.Rows.InsertAt(fila, 0);

            comboEmpleados.ValueMember = "IdEmpleado";
            comboEmpleados.DisplayMember = "ApellidoyNombre";
            comboEmpleados.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreU.Text;
            int idEmp = int.Parse(comboEmpleados.SelectedValue.ToString());

            passwordUsuario = txtCont.Text;
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(passwordUsuario);
            byte[] hash = md5.ComputeHash(inputBytes);
            passwordUsuario = BitConverter.ToString(hash).Replace("-", "");
            passEncriptado = passwordUsuario.ToString();

            if (txtCont.Text == txtCont2.Text)
            {

                SqlConnection con = new SqlConnection(@"Data Source = EMYLAVENIA\SQLEXPRESS; Initial Catalog = Gestion-V2; Integrated Security = True");
                con.Open();
                SqlCommand cmd = new SqlCommand(string.Format("Insert Into Usuario (NombreUsuario,Contraseña,idEmpleado) VALUES('{0}', '{1}', '{2}')", nombre, passEncriptado, idEmp), con);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cuenta creada");
                con.Close();
            }
            else
                MessageBox.Show("Las contraseñas no coinciden");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Dispose();
        }
    }
}
