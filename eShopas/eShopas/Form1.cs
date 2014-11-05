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
using System.Net;
using System.IO;



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
        public string GetSiteContents(string url)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                byte[] buf = new byte[8192];
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream resStream = response.GetResponseStream();
                string tempString = null;
                int count = 0;
                do
                {
                    count = resStream.Read(buf, 0, buf.Length);
                    if (count != 0)
                    {
                        tempString = Encoding.ASCII.GetString(buf, 0, count);
                        sb.Append(tempString);
                    }
                }
                while (count > 0);

                return sb.ToString();
            }
            catch(Exception ex){
                return "false";
            }
        }

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
            bool connectionOpen = true;
            string url = String.Format("http://178.62.9.252/_api/login_check/{0}/{1}/", usernameTextBox.Text, passwordTextBox.Text);
            string answ = GetSiteContents(url);

            if (answ == "true")
            try
            {

                string Query = string.Format("SELECT marsud.bts_groups.id FROM marsud.bts_users__groups INNER JOIN marsud.bts_groups ON marsud.bts_users__groups.group_id = marsud.bts_groups.id inner join marsud.bts_users on user_id = bts_users.id WHERE marsud.bts_users.username = '{0}'", usernameTextBox.Text);
          
                connection = new MySQLConnection(connectionString);
            connection.Open();   

            MySqlCommand cmd = new MySqlCommand(Query, connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                int permissions = reader.GetInt32(0);
                if (permissions > 1)
                {
                    connectionOpen = false;
                    this.Visible = false;
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    mainForm.permissions = permissions;

                }

                connection.Close();  
            }                
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            finally
            {
                if (connectionOpen)
                {
                    connection.Close();
                }
            }
                
            
        }
    }
}
