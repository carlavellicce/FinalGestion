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

namespace GD_Final_Baternoa
{
    public partial class Login : Form
    {

        private string password = null;
        private string contraseñaEncrip;

        public Login()
        {
            InitializeComponent();

        }

      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreU = txtUsuario.Text;

            password = txtContraseña.Text;
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);
            password = BitConverter.ToString(hash).Replace("-", "");
            contraseñaEncrip = password.ToString();

            SqlConnection con = new SqlConnection(@"Data Source = EMYLAVENIA\SQLEXPRESS; Initial Catalog = Gestion-V2; Integrated Security = True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Usuario Where NombreUsuario='" + nombreU + "' and Contraseña= '" + contraseñaEncrip + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                if (nombreU == "Administrador")
                {
                    this.Hide();
                    Menu.MenuPrincipal mp = new Menu.MenuPrincipal();
                    mp.Show();
                }
                else {
                    this.Hide();
                    Menu.MenuSecundario ms = new Menu.MenuSecundario();
                    ms.Show();
                }

            }
            else
            {
                MessageBox.Show("DATOS DE USUARIO INCORRECTOS");
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
           Conexion c = new Conexion();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
