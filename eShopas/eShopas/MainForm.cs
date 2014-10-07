using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySQLConnection = MySql.Data.MySqlClient.MySqlConnection;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace eShopas
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            MySQLConnection connection = null;
            string connectionString = "datasource=stud.if.ktu.lt;port=3306;username=marsud;password=peu3uj5Cohximiph";
            DataTable dataTable = new DataTable();

            string Query = "select * from marsud.bts_users";
            try
            {              

                connection = new MySQLConnection(connectionString);
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(Query, connection);

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }

                dataGridView1.DataSource = dataTable;
                dataGridView1.DataMember = dataTable.TableName;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        private void užsakymaiToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
