using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GD_Final_Baternoa.Venta
{
    public partial class ConsultaVentas : Form
    {
        public ConsultaVentas()
        {
            InitializeComponent();
        }

        private void ConsultaVentas_Load(object sender, EventArgs e)
        {

        }

        private void buttonNueva_Click(object sender, EventArgs e)
        {
            Venta.PantallaVenta ven = new Venta.PantallaVenta();
            ven.Visible = true;

        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
