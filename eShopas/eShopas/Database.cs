using System;
using System.Collections.Generic;
using System.Linq;
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
    class Database
    {
        MySQLConnection connection = null;
        string connectionString = "datasource=stud.if.ktu.lt;port=3306;username=marsud;password=peu3uj5Cohximiph";
        DataTable dataTable = new DataTable();

        public List<User> getUsersForListBox(){
                    
        

            string Query = "select id, username, email, enabled, last_login, locked, expires_at from marsud.bts_users";
            try
            {

                connection = new MySQLConnection(connectionString);
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(Query, connection);

              
                MySqlDataReader reader = cmd.ExecuteReader();
                int row = 0;

                List<User> users = new System.Collections.Generic.List<User>();
                //List<Dictionary<string, string>> allData = new List<Dictionary<string, string>>();

                while (reader.Read())
                {

                    users.Add(new User(int.Parse(reader["id"].ToString()), reader["username"].ToString(), reader["email"].ToString()));

                    /*
                    Dictionary<string, string> keyPair = new Dictionary<string, string>();

                    keyPair.Add("id", reader["id"].ToString());
                    keyPair.Add("username", reader["username"].ToString());
                    keyPair.Add("email", reader["email"].ToString());
                    keyPair.Add("locked", reader["locked"].ToString());

                    allData.Add(keyPair);
               */


                }
                return users;
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

        public void fillDataGrid(DataGridView grid)
        {
            string Query = "select id, username, email, enabled, last_login, locked, expires_at from marsud.bts_users";
            try
            {

                connection = new MySQLConnection(connectionString);
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(Query, connection);
                MySqlDataAdapter dbAdapter = new MySqlDataAdapter(cmd);

                DataTable dtRecords = new DataTable();
                dbAdapter.Fill(dtRecords);
                grid.DataSource = dtRecords; //dataGrid

             
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
