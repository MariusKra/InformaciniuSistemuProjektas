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



/*
 Hostname: stud.if.ktu.lt
Username: marsud
Password: peu3uj5Cohximiph
Database: marsud
 * */

namespace eShopas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySQLConnection connection = null;
            string connectionString = "datasource=stud.if.ktu.lt;port=3306;username=marsud;password=peu3uj5Cohximiph";
           

            try
            {
             string Query = "select * from marsud.bts_users where username='"+this.usernameTextBox.Text+"' and password ='"+this.passwordTextBox.Text+"'";
             //string Query = "select * from marsud.bts_users";
             
                connection = new MySQLConnection(connectionString);
            connection.Open();   

            MySqlCommand cmd = new MySqlCommand(Query, connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                
                this.Visible = false;
                Form mainForm = new MainForm();
                mainForm.Show();

            }
                    
            

          
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
    }
}
