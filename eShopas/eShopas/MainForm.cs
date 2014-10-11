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
        Database database = new Database();
        
        public MainForm()
        {


            InitializeComponent();
           
            database.fillDataGrid(this.dataGridView1);
         


             //   FillGridWithValues(allData);


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

       /* private void FillGridWithValues(List<Dictionary<string, string>> fillData)
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int id = (int)dataGridView1[0, index].Value;
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
