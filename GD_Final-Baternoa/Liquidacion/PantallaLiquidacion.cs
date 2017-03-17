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



namespace GD_Final_Baternoa.Liquidacion
{
    public partial class PantallaLiquidacion : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = EMYLAVENIA\SQLEXPRESS; Initial Catalog = Gestion-V2; Integrated Security = True");
        int sumaH = 0;
        int sumaC = 0;
        int sumarHijos = 0;
        int sumaComision = 0;


        public PantallaLiquidacion()
        {
            InitializeComponent();

            cargarCategorias();

            comboAños();
            comboMeses();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PantallaLiquidacion_Load(object sender, EventArgs e)
        {

        }
        public void comboAños()
        {
            for (int i = 2008; i <= DateTime.Now.Year; i++)
            {
                comboAño.Items.Add(i);
            }
        }

        public void comboMeses()
        {
            for (int i = 01; i <= 12; i++)
            {
                comboMes.Items.Add(i);
            }
        }

       


        public void cargarCategorias()
        {
            //con.Open();
            SqlCommand cmd = new SqlCommand("SELECT idCategoriaEmpleado, NombreCategoria FROM CategoriaEmpleado", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //con.Close();

            DataRow fila = dt.NewRow();
            fila["NombreCategoria"] = "Selecciona una Categoria";
            dt.Rows.InsertAt(fila, 0);

            comboCategoria.ValueMember = "idCategoriaEmpleado";
            comboCategoria.DisplayMember = "NombreCategoria";
            comboCategoria.DataSource = dt;

        }

        public void cargarCUIL(string idCategoriaEmpleado)
        {
            //con.Open();
            SqlCommand cmd = new SqlCommand("SELECT idEmpleado, ApellidoyNombre FROM Empleado WHERE idCategoriaEmpleado = @idCategoriaEmpleado", con);
            cmd.Parameters.AddWithValue("idCategoriaEmpleado", idCategoriaEmpleado);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //con.Close();

            DataRow dr = dt.NewRow();
            dr["ApellidoyNombre"] = "Seleccione un empleado";
            dt.Rows.InsertAt(dr, 0);

            comboEmpleado.ValueMember = "idEmpleado";
            comboEmpleado.DisplayMember = "ApellidoyNombre";
            comboEmpleado.DataSource = dt;
        }

        public void cargarConceptos(string idCategoriaEmpleado)
        {
            //con.Open();
            SqlCommand cmd = new SqlCommand("SELECT idConcepto, Descripcion FROM Concepto WHERE TipoCat = @idCategoriaEmpleado", con);
            cmd.Parameters.AddWithValue("idCategoriaEmpleado", idCategoriaEmpleado);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //con.Close();

            DataRow dr = dt.NewRow();
            dr["Descripcion"] = "Seleccione un concepto";
            dt.Rows.InsertAt(dr, 0);

            comboConceptos.ValueMember = "idConcepto";
            comboConceptos.DisplayMember = "Descripcion";
            comboConceptos.DataSource = dt;

        }

        private void comboEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboCategoria.SelectedValue.ToString() != null)
            {
                string idCategoriaEmpleado = comboCategoria.SelectedValue.ToString();
                cargarCUIL(idCategoriaEmpleado);
                cargarConceptos(idCategoriaEmpleado);

            }
        }

        private void comboConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cadcon2 = "Select * From Concepto Where idConcepto = '" + comboConceptos.SelectedValue + "'";
            SqlCommand cn = new SqlCommand(cadcon2, con);
            con.Open();

            SqlDataReader leer = cn.ExecuteReader();

            if (leer.Read())
            {
                txtIDCon.Text = leer["idConcepto"].ToString();
                txtDesc.Text = leer["Descripcion"].ToString();
                txtValor.Text = leer["Valor"].ToString();
                txtTipo.Text = leer["Tipo"].ToString();
            }
            else
            {
                txtIDCon.Text = string.Empty;
                txtDesc.Text = string.Empty;
                txtValor.Text = string.Empty;
                txtTipo.Text = string.Empty;
            }
            con.Close();

            if (txtDesc.Text == "Sueldo Basico" | txtDesc.Text == "Antiguedad" | txtDesc.Text == "Jubilacion" | txtDesc.Text == "Obra Social" | txtDesc.Text == "Hijos Menores" | txtDesc.Text == "Comision")
            {
                txtUnidades.ReadOnly = true;
                txtUnidades.Text = "";
            }
            else
            {
                txtUnidades.ReadOnly = false;
                txtUnidades.Text = "";
            }

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = txtIDCon.Text;
            string des = txtDesc.Text;
            string val = txtValor.Text;
            string tipo = txtTipo.Text;
            string basico = txtBasico.Text;
            string antig = txtAnt.Text;
            string unidades = txtUnidades.Text;
            string hijos = txtHijos.Text;
            string comi = txtComision.Text;
            float monto = 0;


            if (txtDesc.Text == "Sueldo Basico")
            {
                txtBasico.Text = txtValor.Text;
                dgv.Rows.Add(id, des, val, tipo);
            }
            else
            {
                if (txtDesc.Text == "Antiguedad")
                {
                    monto = float.Parse(val) * float.Parse(basico) * float.Parse(antig);
                    dgv.Rows.Add(id, des, monto, tipo);
                }
                else
                {
                    if (txtDesc.Text == "Presentismo")
                    {
                        if (txtUnidades == null)
                        {
                            monto = float.Parse(val) * float.Parse(basico);
                            dgv.Rows.Add(id, des, monto, tipo);
                        }
                        else
                        {
                            monto = float.Parse(val) * float.Parse(basico) * float.Parse(unidades);
                            dgv.Rows.Add(id, des, monto, tipo);
                        }
                    }
                    else
                    {
                        if (txtDesc.Text == "Horas Extras")
                        {
                            monto = float.Parse(val) * float.Parse(unidades);
                            dgv.Rows.Add(id, des, monto, tipo);
                        }
                        else
                        {
                            if (txtDesc.Text == "Jubilacion")
                            {

                                monto = float.Parse(val) * float.Parse(basico);
                                dgv.Rows.Add(id, des, monto, tipo);

                            }
                            else
                            {
                                if (txtDesc.Text == "Obra Social")
                                {

                                    monto = float.Parse(val) * float.Parse(basico);
                                    dgv.Rows.Add(id, des, monto, tipo);
                                }
                                else {
                                    if (txtDesc.Text == "Hijos Menores")
                                    {
                                        monto = float.Parse(val) * float.Parse(hijos);
                                        dgv.Rows.Add(id, des, monto, tipo);
                                    }
                                    else {
                                        if (txtDesc.Text == "Comision")
                                        {
                                            monto = float.Parse(val) * float.Parse(comi);
                                            dgv.Rows.Add(id, des, monto, tipo);
                                        }

                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

            string cadcon = "Select * From Empleado Where idEmpleado = '" + comboEmpleado.SelectedValue + "'";
            SqlCommand cn = new SqlCommand(cadcon, con);
            con.Open();



            SqlDataReader leer = cn.ExecuteReader();

            if (leer.Read())
            {
                txtAyP.Text = leer["ApellidoyNombre"].ToString();
                txtCUIL.Text = leer["CUIL"].ToString();

                dateTimePicker2.Text = leer["FechaIngreso"].ToString();


            }
            else
            {
                txtAyP.Text = string.Empty;
                txtCUIL.Text = string.Empty;
            }
            con.Close();







            int antiguedad;
            antiguedad = System.DateTime.Today.Year - dateTimePicker2.Value.Year;
            if (System.DateTime.Today.Month < dateTimePicker2.Value.Month)
            {
                if (dateTimePicker2.Value.Day > System.DateTime.Today.Day)
                {
                    antiguedad = antiguedad - 1;
                }
            }
            else
            { }

            txtAnt.Text = antiguedad.ToString();


        }
       

        private void HijosMenores() {
           
            string cadcon = "Select * From Familiar Where idEmpleado = '" + comboEmpleado.SelectedValue + "'";
            SqlCommand cn = new SqlCommand(cadcon, con);
            con.Open();

            SqlDataReader leer = cn.ExecuteReader();
          
            while (leer.Read())
            {
                string dni = leer["DNI"].ToString();

                SqlConnection con2 = new SqlConnection(@"Data Source = EMYLAVENIA\SQLEXPRESS; Initial Catalog = Gestion-V2; Integrated Security = True");
                con2.Open();
                string sql1 = " SELECT [FechaNacimiento] from Familiar where DNI = " + dni + "";
                SqlCommand cmd1 = new SqlCommand(sql1);
                cmd1.CommandType = System.Data.CommandType.Text;
                cmd1.Connection = con2;
                SqlDataReader reader1 = cmd1.ExecuteReader();

                if (reader1.Read())
                {
                    
                    string fec = reader1[0].ToString();
                    DateTime fechaNac = Convert.ToDateTime(fec);
                    con2.Close();

                    SqlConnection con3 = new SqlConnection(@"Data Source = EMYLAVENIA\SQLEXPRESS; Initial Catalog = Gestion-V2; Integrated Security = True");
                    con3.Open();
                    DateTime fechaAct = DateTime.Now.AddYears(-1);
                    string sql = " SELECT DATEDIFF( YEAR, '" + fechaNac + "', '" + fechaAct + "')";
                    SqlCommand cmd = new SqlCommand(sql);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = con3;
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    string edad = reader[0].ToString();
                    int edadHijo = int.Parse(edad);
                    con3.Close();
                    if (edadHijo < 18)
                    {
                        sumarHijos = sumarHijos + 1;
                        txtHijos.Text = sumarHijos.ToString();
                    }
                }
                else
                {
                   // string fn = null;
                }
               
            }
            MessageBox.Show("Total de Hijos Menores Calculados");
            con.Close();


        } 

        private void CargarComisiones()
        {
            string mesPeriodo = comboMes.SelectedItem.ToString();
            string añoPeriodo = comboAño.SelectedItem.ToString();

            string cadcon = "Select * From Venta Where idEmpleado = '" + comboEmpleado.SelectedValue + "'";
            SqlCommand cn = new SqlCommand(cadcon, con);
            con.Open();

            SqlDataReader leer = cn.ExecuteReader();

            while (leer.Read())
            {
                string idV = leer["idVenta"].ToString();
                string montoCom = leer["ComisionEmpleado"].ToString();

                SqlConnection con2 = new SqlConnection(@"Data Source = EMYLAVENIA\SQLEXPRESS; Initial Catalog = Gestion-V2; Integrated Security = True");
                con2.Open();
                string sql1 = " SELECT [FechaVenta] from Venta where idVenta = " + idV + "";
                SqlCommand cmd1 = new SqlCommand(sql1);
                cmd1.CommandType = System.Data.CommandType.Text;
                cmd1.Connection = con2;
                SqlDataReader reader1 = cmd1.ExecuteReader();

                if (reader1.Read())
                {

                    string fec = reader1[0].ToString();
                    DateTime fechaV = Convert.ToDateTime(fec);
                    con2.Close();

                    SqlConnection con3 = new SqlConnection(@"Data Source = EMYLAVENIA\SQLEXPRESS; Initial Catalog = Gestion-V2; Integrated Security = True");
                    SqlConnection con4 = new SqlConnection(@"Data Source = EMYLAVENIA\SQLEXPRESS; Initial Catalog = Gestion-V2; Integrated Security = True");
                    con3.Open();
                  

                    string sql = " SELECT DATEPART( YEAR, '" + fechaV + "')";
                    SqlCommand cmd = new SqlCommand(sql);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = con3;
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    string añoVenta = reader[0].ToString();
                  

            

                    con3.Close();
                    con4.Open();

                    string sql2 = " SELECT DATEPART( MONTH, '" + fechaV + "')";
                    SqlCommand cmd2 = new SqlCommand(sql2);
                    cmd2.CommandType = System.Data.CommandType.Text;
                    cmd2.Connection = con4;
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    reader2.Read();
                    string mesVenta = reader2[0].ToString();
                    
                    con4.Close();

                    if (añoVenta.Equals(añoPeriodo))
                    {
                        if (mesVenta.Equals(mesPeriodo))
                        {
                            sumaComision = sumaComision + int.Parse(montoCom);
                            txtComision.Text = sumaComision.ToString();
                            MessageBox.Show("Comisiones calculadas");
                        }
                    }
                    else {
                        MessageBox.Show("No hay comisiones");
                    }
                }
                else
                {
                    // string fn = null;
                   
                }

            }
            con.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            HijosMenores();
        }

        private void dgvFamilia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string idempleado = comboEmpleado.SelectedValue.ToString();
            int ide = int.Parse(idempleado);
            string fechaHoy = DateTime.Now.ToString("dd/MM/yyyy");
            string periodo = comboMes.Text + "-" + comboAño.Text;





            string sql = "INSERT INTO Liquidacion (FechaLiquidacion, idEmpleado, Periodo) VALUES ('" + fechaHoy + "'," + ide + ",'" + periodo + "') SELECT SCOPE_IDENTITY();";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string idLiq = reader[0].ToString();
            con.Close();


            SqlCommand cmd2 = new SqlCommand("INSERT INTO DetalleLiquidacion VALUES (@monto, @idconcepto, @idliquidacion)", con);
            con.Open();
            try
            {

                foreach (DataGridViewRow row in dgv.Rows)
                {

                    cmd2.Parameters.Clear();

                    cmd2.Parameters.AddWithValue("@monto", Convert.ToString(row.Cells["Valor"].Value));
                    cmd2.Parameters.AddWithValue("@idconcepto", Convert.ToInt32(row.Cells["ID"].Value));
                    cmd2.Parameters.AddWithValue("@idliquidacion", idLiq);

                    cmd2.ExecuteNonQuery();

                }

            }

            catch (Exception)
            {

            }
            finally {
                MessageBox.Show("Liquidacion Realizada");

                txtAnt.Text = null;
                txtAyP.Text = null;
                txtBasico.Text = null;
                txtCUIL.Text = null;
                txtDesc.Text = null;
                txtHijos.Text = null;
                txtIDCon.Text = null;
                txtTipo.Text = null;
                txtUnidades.Text = null;
                txtValor.Text = null;
                dateTimePicker2.Text = null;
                comboMes.Text = null;
                comboAño.Text = null;
                dgv.Rows.Clear();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CargarComisiones();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
        }

        private void dgvComision_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
    
        }

        private void button10_Click(object sender, EventArgs e)
        {
       
        }

        private void comboMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }
