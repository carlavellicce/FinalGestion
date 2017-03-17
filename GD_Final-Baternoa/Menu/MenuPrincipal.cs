using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GD_Final_Baternoa.Menu
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnLiquidacion_Click(object sender, EventArgs e)
        {
            Liquidacion.Principal al = new Liquidacion.Principal();
            al.Visible = true;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Cliente.Clientes c = new Cliente.Clientes();
            c.Visible = true;
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            Proveedor.Proveedores p = new Proveedor.Proveedores();
            p.Visible = true;
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            Empleado.Empleados emp = new Empleado.Empleados();
            emp.Visible = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Producto.Productos p = new Producto.Productos();
            p.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Categoria.CategoriasPrincipal ca = new Categoria.CategoriasPrincipal();
            ca.Visible = true;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Empleado.ABMUsuario abmu = new Empleado.ABMUsuario();
            abmu.Visible = true; 
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {

        }
    }
}
