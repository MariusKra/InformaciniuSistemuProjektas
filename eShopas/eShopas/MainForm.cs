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
        public int permissions { get; set; }

        Database database = new Database();
        int permissionsId;
        int isUserEnabled;
        bool filterOn = false;
        public MainForm()
        {


            InitializeComponent();
            database.fillDropDowns(UserPermissionsComboBox, UserEnabledComboBox, OrdersStateComboBox, OrdersStateFilterComboBox);
            tableLayoutPanel1.Visible = false;

            database.fillOrdersInfoList(dataGridView2, null);
            dataGridView2.Rows[0].Cells[0].Selected = false;

            OrdersDateFromFilterDatePicker.Value = DateTime.Now.AddMonths(-1);
            OrdersTillDateFilterDatetPicker.Value = DateTime.Now.AddMonths(1);


        }

       

        private void užsakymaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAll();
            tableLayoutPanel3.Visible = true;
           
            // Užsakytas, Apmokėtas, Atšauktas

            database.fillOrdersInfoList(dataGridView2, null);
            dataGridView2.Rows[0].Cells[0].Selected = false;



           
        }


        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            //last_selected = dataGridView1.CurrentCell.RowIndex;
            try
            {
                int index = dataGridView2.CurrentCell.RowIndex;
                int id = (int)dataGridView2[0, index].Value;
                database.fillCartByOrder(dataGridView3, id);
                database.fillOrderInfo(OrdersUsernameTextBox, OrderIdTextBox, OrdersStateComboBox, id);


            }
            catch (Exception ex)
            {
                dataGridView1.ClearSelection();

            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void hideAll()
        {
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = false;
            tableLayoutPanel3.Visible = false;
            tableLayoutPanel4.Visible = false;
            if (permissions != 3)
            {
                UserPermissionsComboBox.Visible = false;
                labelUserPermissionsLabel.Visible = false;
            }

        }

      
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


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
            //last_selected = dataGridView1.CurrentCell.RowIndex;
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                int id = (int)dataGridView1[0, index].Value;
                database.fillUserDataById(id, usernameTextBox, emailTextBox, UserPermissionsComboBox, UserEnabledComboBox);


            }
            catch (Exception ex)
            {
                dataGridView1.ClearSelection();

            }
        }

        private void vartotojaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAll();
            tableLayoutPanel1.Visible = true;
            database.fillUserDataGrid(this.dataGridView1);
            dataGridView1.Rows[0].Cells[0].Selected = false;
            // ištrinti user su delete o ne enabled varnelę nuimt

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void prekėsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAll();
            tableLayoutPanel2.Visible = true;
            //visa logika prekiu pridejimo







        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pardavimųStatistikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAll();
            tableLayoutPanel4.Visible = true;
            //pardavim7 statistikos logika
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

         // permissionsId = Int32.Parse((Database.PermisionsEnum)UserPermissionsComboBox.SelectedValue))+1;

            permissionsId = UserPermissionsComboBox.SelectedIndex + 1;

           // string str = Enum.Parse(typeof(Database.PermisionsEnum), (UserPermissionsComboBox.SelectedValue.ToString())).ToString();


        }

        private void UserEnabledComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            isUserEnabled = ((int)UserEnabledComboBox.SelectedIndex == 0) ? 1 : 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
               int index = dataGridView1.CurrentCell.RowIndex;
                int id = (int)dataGridView1[0, index].Value;
                

                database.updateUserInfo(id, emailTextBox, UserPermissionsComboBox, UserEnabledComboBox);
                database.fillUserDataGrid(dataGridView1);
               // dataGridView1.CurrentCell = dataGridView1.Rows[id].Cells[0];

                //dataGridView1.SelectedRows.Clear();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if((int)dataGridView1[0, row.Index].Value == id)
                           row.Selected = true;
                }



                //dataGridView1.Rows[index].Selected = true;


        }

        private void button2_Click(object sender, EventArgs e)// delete button
        {
            if (MessageBox.Show("Ar tikrai norite ištrinti šį vartotoją?", "Ištrinti vartotoją", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                int id = (int)dataGridView1[0, index].Value;
                database.DeleteUser(id);
                database.fillUserDataGrid(dataGridView1);
                // dataGridView1.CurrentCell = dataGridView1.Rows[id].Cells[0];

                //dataGridView1.SelectedRows.Clear();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if ((int)dataGridView1[0, row.Index].Value == id)
                        row.Selected = true;
                }
            } 

        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try{
            int index = dataGridView2.CurrentCell.RowIndex;
            int OrderId = (int)dataGridView2[0, index].Value;

            int index2 = dataGridView3.CurrentCell.RowIndex;
            int productId = (int)dataGridView3[0, index].Value;

            database.flllCartItemQuantity(OrderId, productId, CartSelectedProductQuantityTextBox);
            
             }
            catch (Exception ex)
            {
                dataGridView1.ClearSelection();

            }
        }

      

        private void OrderFilterButton_Click(object sender, EventArgs e)
        {
            OrdersFilter filter = new OrdersFilter()
            {
                Username = OrdersUsernameFilterTextBox.Text,
                State = (OrdersStateFilterComboBox.SelectedIndex == 0 ? "": Enum.GetName(typeof(Database.OrderStates), OrdersStateFilterComboBox.SelectedIndex)),
                startDate = OrdersDateFromFilterDatePicker.Value.ToString("yyyy-MM-dd"),
                endDate = OrdersTillDateFilterDatetPicker.Value.ToString("yyyy-MM-dd"),
            };
            database.fillOrdersInfoList(dataGridView2, filter);

            dataGridView3.DataSource = null;
            if (dataGridView2.RowCount != 0)
            {
                dataGridView2.Rows[0].Cells[0].Selected = false;

            }
            filterOn = true;

        }

        private void UpdateOrdersButton_Click(object sender, EventArgs e)
        {

                 try
            {
                int index = dataGridView2.CurrentCell.RowIndex;
                int id = (int)dataGridView2[0, index].Value;
                database.updateOrderInfo(id, OrdersStateComboBox.SelectedValue.ToString());
                if (filterOn)
                {
                    OrdersFilter filter = new OrdersFilter()
                    {
                        Username = OrdersUsernameFilterTextBox.Text,
                        State = (OrdersStateFilterComboBox.SelectedIndex == 0 ? "" : Enum.GetName(typeof(Database.OrderStates), OrdersStateFilterComboBox.SelectedIndex)),
                        startDate = OrdersDateFromFilterDatePicker.Value.ToString("yyyy-MM-dd"),
                        endDate = OrdersTillDateFilterDatetPicker.Value.ToString("yyyy-MM-dd"),
                    };
                    database.fillOrdersInfoList(dataGridView2, filter);

           
                }
                else
                    database.fillOrdersInfoList(dataGridView2, null);
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    if ((int)dataGridView2[0, row.Index].Value == id)
                        row.Selected = true;
                    else
                        row.Selected = false;
                }


            }
            catch (Exception ex)
            {

            }
        }

        private void ProductQuantitySaveButton_Click(object sender, EventArgs e)
        {



        }

        private void DeleteOrderProduct_Click(object sender, EventArgs e)
        {

        }

        private void OrdersFilterClearButton_Click(object sender, EventArgs e)
        {
            OrdersUsernameFilterTextBox.Text = "";
            OrdersStateFilterComboBox.SelectedIndex = 0;
            dataGridView2.DataSource = null;
            database.fillOrdersInfoList(dataGridView2, null);
            dataGridView2.Rows[0].Cells[0].Selected = false;
            filterOn = false;
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
