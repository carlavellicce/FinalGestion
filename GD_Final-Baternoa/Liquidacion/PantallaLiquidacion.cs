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
            for (int i = 1950; i <= DateTime.Now.Year; i++)
            {
                comboAño.Items.Add(i);
            }
        }

        public void comboMeses()
        {
            comboMes.Items.Add("Enero");
            comboMes.Items.Add("Febrero");
            comboMes.Items.Add("Marzo");
            comboMes.Items.Add("Abril");
            comboMes.Items.Add("Mayo");
            comboMes.Items.Add("Junio");
            comboMes.Items.Add("Julio");
            comboMes.Items.Add("Agosto");
            comboMes.Items.Add("Septiembre");
            comboMes.Items.Add("Octubre");
            comboMes.Items.Add("Noviembre");
            comboMes.Items.Add("Diciembre");
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

            if (txtDesc.Text == "Sueldo Basico" | txtDesc.Text == "Antiguedad" | txtDesc.Text == "Jubilacion" | txtDesc.Text == "Obra Social" | txtDesc.Text == "Hijos Menores")
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
        private void CargarFamiliar()
        {
            con.Open();
            SqlDataAdapter daf = new SqlDataAdapter("Select * From Familiar Where idEmpleado = '" + comboEmpleado.SelectedValue + "' and Parentezco = 'Hijo' ", con);
            DataSet dsf = new DataSet();
            daf.Fill(dsf, "Familiar");

            dgvFamilia.DataSource = dsf;
            dgvFamilia.DataMember = "Familiar";
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CargarFamiliar();


        }

        private void dgvFamilia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDNI.Text = dgvFamilia.CurrentRow.Cells["DNI"].Value.ToString();
            dtpFamiliar.Text = dgvFamilia.CurrentRow.Cells["FechaNacimiento"].Value.ToString();

            int edad;
            edad = System.DateTime.Today.Year - dtpFamiliar.Value.Year;
            if (System.DateTime.Today.Month < dtpFamiliar.Value.Month)
            {
                if (dtpFamiliar.Value.Day < System.DateTime.Today.Day)
                {
                    edad = edad - 1;
                }
            }
            else
            { }

            txtEdad.Text = edad.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sumaH = sumaH + 1;
            txtHijos.Text = sumaH.ToString();
            dgvFamilia.Rows.Remove(dgvFamilia.CurrentRow);
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
            }
        }

    }
    }
