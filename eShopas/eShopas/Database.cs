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


        //----------------------------------------------------------------- USER EDIT Modulis
        public List<User> getUsersForListBox(){

            string Query = "select id, username, email, locked, last_login, expires_at from marsud.bts_users";
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

                    users.Add(new User(
                        int.Parse(reader["id"].ToString()), 
                        reader["username"].ToString(), 
                        reader["email"].ToString()));

                    


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
            string Query =
            "SELECT marsud.bts_users.id, marsud.bts_users.username AS  'Vartotojo vardas', " +
            "marsud.bts_users.email AS  'El. Pastas', locked AS  'Blokuotas', " +
            "last_login AS 'Paskutinis prisijungimas', marsud.bts_groups.name AS  'Teises'" +
            "FROM marsud.bts_users, marsud.bts_users__groups INNER JOIN marsud.bts_groups ON " +
            "marsud.bts_users__groups.group_id = marsud.bts_groups.id WHERE user_id = bts_users.id";
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
            string Query = "select username, email, locked, last_login from marsud.bts_users where id="+id;
            string Query2 = string.Format("SELECT Id FROM marsud.bts_users__groups INNER JOIN"+
            "marsud.bts_groups ON marsud.bts_users__groups.group_id = marsud.bts_groups.id WHERE user_id ={0}", id);

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
                userEnabled.SelectedIndex = reader.GetInt32(2) == 1 ? 1 : 0;

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

        public void updateByQuery(string query1, string query2)
        {
            try
            {

                connection = new MySQLConnection(connectionString);
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query1, connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
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

        public void updateUserInfo(int id, TextBox email, ComboBox permissions, ComboBox userEnabled)
        {
            string Query = string.Format("update marsud.bts_users__groups set marsud.bts_users__groups.group_id = {0} where user_id = {1}", permissions.SelectedIndex + 1, id);
            string Query2 = string.Format("update marsud.bts_users set email='{0}', locked={1} where marsud.bts_users.id = {2}", email.Text, userEnabled.SelectedIndex == 0 ? 0 : 1, id);

            updateByQuery(Query, Query2);
        }

        public void DeleteUser(int id)
        {
            string Query = string.Format("Delete from marsud.bts_users__groups where marsud.bts_users__groups.user_id = {0}", id);
            string Query2 = string.Format("Delete from marsud.bts_users where marsud.bts_users.id = {0}", id);

            updateByQuery(Query, Query2);           

        }
        //----------------------------------------------------------------- USER EDIT Modulis baigtas

        public void gridFillWithQuery(DataGridView grid, string query)
        {

            try
            {

                connection = new MySQLConnection(connectionString);
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
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



        public void fillOrdersInfoList(DataGridView grid){

            string Query = "SELECT marsud.bts_orders.id, marsud.bts_users.username as Vartotojas, "+
                "status as Busena, created_at as 'Sukurimo data' from "+
                "marsud.bts_orders inner join marsud.bts_users on marsud.bts_users.id = marsud.bts_orders.user";
            gridFillWithQuery(grid, Query);

        }

        public void fillCartByOrder(DataGridView grid, int id)
        {
            string Query = String.Format(" Select title as Pavadinimas, "+
            "bts_packs.quantity as Kiekis, marsud.bts_attributes.name as dydis, marsud.bts_attributes.price as Kaina, created_at as 'Sukurimo data' from marsud.bts_attributes, " +
            "marsud.bts_packs inner join marsud.bts_products on "+
            "marsud.bts_packs.product = marsud.bts_products.id where marsud.bts_packs.cart = {0} and marsud.bts_packs.product = marsud.bts_attributes.product", id);
            gridFillWithQuery(grid, Query);


        }



               

    }
}
