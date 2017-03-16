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

namespace GD_Final_Baternoa
{
    public partial class Login : Form
    {
      
        public Login()
        {
            InitializeComponent();


        }

      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //comentario de prueba git Primer intento

            //COMENTARIO EMILIA


            Menu.MenuPrincipal MP = new Menu.MenuPrincipal();
            MP.Visible = true;

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
