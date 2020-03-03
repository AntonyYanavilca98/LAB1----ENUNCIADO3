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
using System.Configuration;

namespace PjConexion3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Yanavilca"].ConnectionString);

        public void ListaProductos()
        {
            using (SqlDataAdapter df = new SqlDataAdapter("Usp_ListaProductos_Neptuno", cn))
            {
                df.SelectCommand.CommandType = CommandType.StoredProcedure;
                using (DataSet Da = new DataSet())
                {
                    df.Fill(Da,"Productos");
                    dgClientes.DataSource = Da.Tables["Productos"];
                    lblTotal.Text = Da.Tables["Productos"].Rows.Count.ToString();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListaProductos();
        }
    }
}
