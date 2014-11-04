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

        public void fillUserDataGrid(DataGridView grid)
        {
            string Query = "select id, username as 'Vartotojo vardas', email as 'El. Pastas', enabled as 'Aktyvus', last_login as 'Paskutinis prisijungimas', locked, expires_at from marsud.bts_users";
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

        public enum PermisionsEnum
        {
            Vartotojas = 1,
            Administratorius = 2,
            Pagrindinis_administratorius = 3
        }
        public enum userState
        {
            Aktyvus = 1,
            Blokuotas = 2
        }

        public void fillDropDowns(ComboBox perm, ComboBox userEnabled)
        {

            
            perm.DataSource = Enum.GetNames(typeof(PermisionsEnum));
            userEnabled.DataSource = Enum.GetNames(typeof(userState));


        }


        public enum UserGroups
        {
            Vartotojas = 1,
            Administratorius = 2,
            Pagrindinis_Administratorius = 3
        }

      

        public void fillUserDataById(int id, TextBox username, TextBox email, ComboBox permissions, ComboBox userEnabled)
        {
            string Query = "select username, email, enabled, last_login from marsud.bts_users where id="+id;
            string Query2 = string.Format("SELECT Id FROM marsud.bts_users__groups INNER JOIN marsud.bts_groups ON marsud.bts_users__groups.group_id = marsud.bts_groups.id WHERE user_id ={0}", id);

            int selectedId = 0;

            try
            {

                connection = new MySQLConnection(connectionString);
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(Query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                username.Text = reader.GetString(0);
                email.Text = reader.GetString(1);
                userEnabled.SelectedIndex = reader.GetInt32(2) == 1 ? 0 : 1;

                reader.Close();

                MySqlCommand cmd2 = new MySqlCommand(Query2, connection);
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                reader2.Read();
                selectedId = reader2.GetInt32(0);
                reader2.Close();


               

                //(JobType)Enum.Parse(typeof(PermisionsEnum), comboBox1.SelectedText);

                permissions.SelectedIndex = selectedId-1;




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

        public void updateUserInfo(int id, TextBox email, ComboBox permissions, ComboBox userEnabled)
        {
            string Query = string.Format("update marsud.bts_users__groups set marsud.bts_users__groups.group_id = {0} where user_id = {1}", permissions.SelectedIndex + 1, id);
            string Query2 = string.Format("update marsud.bts_users set email='{0}', enabled={1} where marsud.bts_users.id = {2}", email.Text, userEnabled.SelectedIndex == 0 ? 1 : 0, id);
            try
            {

                connection = new MySQLConnection(connectionString);
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                MySqlCommand cmd2 = new MySqlCommand(Query2, connection);
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();
                

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
