using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace GD_Final_Baternoa
{
    class Conexion
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;
        

        public Conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=.;Initial Catalog=Gestion-V2;Persist Security Info=True;User ID=sa;Password=12345");
                cn.Open();
                MessageBox.Show("Conectado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto la base de datos: " + ex.ToString());
            }
        }

  

        public bool insertar(string sql)
        {
           // cn.Open();
            cmd = new SqlCommand(sql,cn);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
               // cn.Close();
                return true;
            }
            else { return false; }
            
        }

        public bool Modificar(string sql)
        {
            // cn.Open();
            cmd = new SqlCommand(sql, cn);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                // cn.Close();
                return true;
            }
            else { return false; }

        }
        public bool Eliminar(string sql)
        {
            // cn.Open();
            cmd = new SqlCommand(sql, cn);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                // cn.Close();
                return true;
            }
            else { return false; }

        }

        public void CargarConsulta(DataGridView dgv, string sql)
        {
            da = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
        }




    }
}
