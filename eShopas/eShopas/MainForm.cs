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
           // MySQLConnection connection = null;
           // string connectionString = "datasource=stud.if.ktu.lt;port=3306;username=marsud;password=peu3uj5Cohximiph";
           // DataTable dataTable = new DataTable();

           // string Query = "select id, username, email, enabled, last_login, locked, expires_at from marsud.bts_users";
           // try
           // {              

           //     connection = new MySQLConnection(connectionString);
           //     connection.Open();

           //     MySqlCommand cmd = new MySqlCommand(Query, connection);

           //     /*
           //     using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
           //     {
           //         da.Fill(dataTable);
                    
           //     }
                
           //     dataGridView1.DataSource = dataTable;
           //     dataGridView1.DataMember = dataTable.TableName;

           //     DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
           //     btnColumn.HeaderText = "Treat";
           //     btnColumn.Text = "Treat";
           //     btnColumn.UseColumnTextForButtonValue = true;
           //     //btnColumn.DataPropertyName = "id";
           //     dataGridView1.Columns.Add(btnColumn);
           //     */
           //     MySqlDataReader reader = cmd.ExecuteReader();
           //     int row = 0;


           //     List<Dictionary<string, string>> allData = new List<Dictionary<string, string>>();

           //     while(reader.Read())
           //     {

           //         Dictionary<string, string> keyPair = new Dictionary<string, string>();

           //         keyPair.Add("id", reader["id"].ToString());
           //         keyPair.Add("username", reader["username"].ToString());
           //         keyPair.Add("email", reader["email"].ToString());
           //         keyPair.Add("locked", reader["locked"].ToString());

           //         allData.Add(keyPair);

           //        /* allData.Sort(
           //         delegate(KeyValuePair<string, string> firstPair,
           //         KeyValuePair<string, string> nextPair)
           //         {
           //             //return firstPair.Value.CompareTo(nextPair.Value);
           //             return firstPair          nextPair["id"];
           //         }*/


           //         /*string id = reader["id"].ToString();

           //         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
           //         if (row == 0)
           //         {
           //             tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));                        
           //         }
           //         Label lab = new Label();
           //         lab.Text = reader["id"].ToString();

           //         Label lab2 = new Label();
           //         lab2.Text = reader["username"].ToString();

           //         Label lab3 = new Label();
           //         lab3.Text = reader["email"].ToString();

           //         Label lab4 = new Label();
           //         lab4.Text = reader["locked"].ToString();
                    
           //         tableLayoutPanel1.Controls.Add(lab, 0, row);
           //         tableLayoutPanel1.Controls.Add(lab2, 1, row);
           //         tableLayoutPanel1.Controls.Add(lab3, 2, row);
           //         tableLayoutPanel1.Controls.Add(lab4, 3, row);
           //         row++;
           //         */


           //     }

                

           //     FillGridWithValues(allData);


           //    /*
           //     allData.Sort((first, next) =>
           //     {
           //         return first["id"].CompareTo(next["id"]);
           //     });



           //     List<Dictionary<string, string>> ordered = allData.OrderByDescending(x => x["username"]).ToList();

           //     List<Dictionary<string, string>> ord2 = allData.OrderBy(x => x["id"]).ToList();
           //     */

           // }
           // catch (Exception ex)
           // {

           //     throw ex;
           // }
           // finally
           // {
           //     connection.Close();
           // }
        }

       

        private void užsakymaiToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
        }
        /*
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Button btn = senderGrid[e.ColumnIndex, e.RowIndex] as Button;
                //TODO - Button Clicked - Execute Code Here
            }
        }*/

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

      
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /*private void FillGridWithValues(List<Dictionary<string, string>> fillData)
        {
            for(int row = 0; row < fillData.Count(); row++){
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                if (row == 0)
                {
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }
                Label lab = new Label();
                
                lab.Text = fillData[row]["id"].ToString();

                Label lab2 = new Label();
                lab2.Text = fillData[row]["username"].ToString();

                Label lab3 = new Label();
                lab3.Text = fillData[row]["email"].ToString();

                Label lab4 = new Label();  
                lab4.Text = fillData[row]["locked"].ToString();
                

                tableLayoutPanel1.Controls.Add(lab, 0, row);
                tableLayoutPanel1.Controls.Add(lab2, 1, row);
                tableLayoutPanel1.Controls.Add(lab3, 2, row);
                tableLayoutPanel1.Controls.Add(lab4, 3, row);
                
            }

            

        }*/

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {



        }

        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            

        }

        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            


       //     this.tableLayoutPanel1.CellPaint += new TableLayoutCellPaintEventHandler(tableLayoutPanel1_CellPaint);

        }

        /*void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0 || e.Row == 2)
            {
                Graphics g = e.Graphics;
                Rectangle r = e.CellBounds;
                g.FillRectangle(new SolidBrush(Color.Gray), r);
            }
        }*/

    }
}
