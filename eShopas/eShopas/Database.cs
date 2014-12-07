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
using System.Collections;
using Newtonsoft.Json;

namespace eShopas
{

	public class OrdersFilter
	{
		public string Username { get; set; }
		public string State { get; set; }
		public string startDate { get; set; }
		public string endDate { get; set; }
	
	}

	public class UsersFilter
	{
		public string Username { get; set; }
		public int State { get; set; }
	}

	public class OrderStatisticsFilter
	{
		public string startDate { get; set; }
		public string endDate { get; set; }
	}

	public class JsonAttributes
	{
		public int id { get; set; }
		public string name { get; set; }
		public string value { get; set; }
	}
	class Database
	{
		MySQLConnection connection = null;
		string connectionString = "datasource=stud.if.ktu.lt;port=3306;username=marsud;password=peu3uj5Cohximiph";
		DataTable dataTable = new DataTable();
		public int loggedUserId { get; set; } 

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

		public void fillUserDataGrid(DataGridView grid, UsersFilter filter)
		{
			/*string Query =
			"SELECT marsud.bts_users.id, marsud.bts_users.username AS  'Vartotojo vardas', " +
			"marsud.bts_users.email AS  'El. Pastas', locked AS  'Blokuotas', " +
			"last_login AS 'Paskutinis prisijungimas', marsud.bts_groups.name AS  'Teises'" +
			"FROM marsud.bts_users, marsud.bts_users__groups INNER JOIN marsud.bts_groups ON " +
			"marsud.bts_users__groups.group_id = marsud.bts_groups.id WHERE user_id = bts_users.id";
			*/
			string Query = "SELECT marsud.bts_users.id, marsud.bts_users.username AS  'Vartotojo vardas', " +
			"marsud.bts_users.email AS  'El. Pastas', locked AS  'Blokuotas', " +
			"last_login AS 'Paskutinis prisijungimas' from marsud.bts_users";

			string str = "";
			if (filter != null)
			{
				if (!string.IsNullOrEmpty(filter.Username))
					Query = Query + " where username LIKE'" + filter.Username+"%'";

				if (filter.State != 0)
				{
					if (!string.IsNullOrEmpty(str))
					{
						Query = Query + " and locked = " + (filter.State == 2 ? 1 : 0);
					}
					else
					{
						Query = Query + " where locked = " + (filter.State == 2 ? 1 : 0);
					}
				}
				
			}
			Query = Query + str;

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
			Administratorius = 2/*,
			Pagrindinis_administratorius = 3*/
		}
		public enum userState
		{
			Aktyvus = 1,
			Blokuotas = 2
		}

		/*public enum OrderStates
		{
			waiting = 1,
			processing = 2,
			sent = 3,
			done = 4

		}*/
		 public enum OrderStates
		{
			Laukia_vykdymo = 1,
			Vykdomas = 2,
			Išsiųstas = 3,
			Įvykdytas = 4

		}

		 public string TranslateStateToEnglish(string state)
		 {
			 switch (state)
			 {
				 case "Laukia_vykdymo": return "waiting";
				 case "Vykdomas": return "processing";
				 case "Išsiųstas": return "sent";
				 case "Įvykdytas": return "done";
			 }
			 return "";
		 }
		 public string TranslateStateToLithuanian(string state)
		 {
			 switch (state)
			 {
				 case "waiting": return "Laukia_vykdymo";
				 case "processing": return "Vykdomas";
				 case "sent": return "Išsiųstas";
				 case "done": return "Įvykdytas";
			 }
			 return "";
		 }


		/*
		 * 
		 * 

			const STATUS_WAITING = 'waiting';
			const STATUS_PROCESING = 'processing';
			const STATUS_SENT = 'sent';
			const STATUS_DONE = 'done';
		 * */
		public void fillDropDowns(List<ComboBox> perm, List<ComboBox> userEnabled, ComboBox orderState, ComboBox orderStateFilter)
		{                        

			for (int l = 0; l < perm.Count; l++)
			{

				ComboBox j = perm[l];
				
				if (j.Name == "UserEdit_UserPermissionsFilterComboBox")
				{
					int k = 1;
					
					j.Items.Insert(0, "");
					foreach (var item in Enum.GetNames(typeof(PermisionsEnum)))
					{

						j.Items.Insert(k, item);

						k++;
					}
				}
				else
				{
					j.DataSource = Enum.GetNames(typeof(PermisionsEnum));
				}

			}
			for (int l = 0; l < userEnabled.Count; l++)
			{

				ComboBox j = userEnabled[l];
				if (j.Name == "UserEdit_UserStateFilterComboBox")
				{
					int k = 1;
					j.Items.Insert(0, "");
					foreach (var item in Enum.GetNames(typeof(userState)))
					{

						j.Items.Insert(k, item);

						k++;
					}
					j.SelectedIndex = 0;
				}
				else
				{
					j.DataSource = Enum.GetNames(typeof(userState));
				}
			}


			orderState.DataSource = Enum.GetNames(typeof(OrderStates));
		   
			int i = 1;
			orderStateFilter.Items.Insert(0, "");
			foreach(var item in Enum.GetNames(typeof(OrderStates))){
				
					orderStateFilter.Items.Insert(i, item);
				
				i++;
			}

		}


		public enum UserGroups
		{
			Vartotojas = 1,
			Administratorius = 2/*,
			Pagrindinis_Administratorius = 3*/
		}

	  

		public void fillUserDataById(int id, TextBox username, TextBox email, ComboBox permissions, ComboBox userEnabled)
		{
			string Query = "select username, email, locked, roles from marsud.bts_users where id="+id;
			/*string Query2 = string.Format("SELECT Id FROM marsud.bts_users__groups INNER JOIN"+
			" marsud.bts_groups ON marsud.bts_users__groups.group_id = marsud.bts_groups.id WHERE user_id ={0}", id);
			*/


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
				selectedId = (reader.GetString(3).IndexOf("ROLE_ADMIN") > 0 ? 2: 1 );
				reader.Close();

				
					  

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
				if (!string.IsNullOrEmpty(query2))
				{
					MySqlCommand cmd2 = new MySqlCommand(query2, connection);
					cmd2.ExecuteNonQuery();
					cmd2.Dispose();
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

		public void updateUserInfo(int id, TextBox email, ComboBox permissions, ComboBox userEnabled)
		{
			
			//string Query = string.Format("update marsud.bts_users set marsud.bts_users.roles = '{0}' where id = {1}", (permissions.SelectedIndex + 1 == 2? "a:1:{i:0;s:10:ROLE_ADMIN;}": "a:0:{}"), id);
			string Query2 = string.Format("update marsud.bts_users set email='{0}', locked={1} where marsud.bts_users.id = {2}", email.Text, userEnabled.SelectedIndex == 0 ? 0 : 1, id);

			updateByQuery(Query2, null);
		}

		public void DeleteUser(int id)
		{
			string Query = string.Format("Delete from marsud.bts_users__groups where marsud.bts_users__groups.user_id = {0}", id);
			string Query2 = string.Format("Delete from marsud.bts_users where marsud.bts_users.id = {0}", id);

			updateByQuery(Query, Query2);           

		}
		//----------------------------------------------------------------- USER EDIT Modulis baigtas

		public bool gridFillWithQuery(DataGridView grid, string query)
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
				return true;
			   
			}
			catch (Exception ex)
			{

				throw ex;
				return false;
			}
			finally
			{
				connection.Close();

			}

		}



		public bool fillOrdersInfoList(DataGridView grid, OrdersFilter filter){
			/*string Query = "SELECT marsud.bts_carts.id, marsud.bts_users.username as Vartotojas, " +
					"status as Busena, created_at as 'Sukurimo data' from " +
					"marsud.bts_carts inner join marsud.bts_users on marsud.bts_users.id = marsud.bts_carts.user{0}";
			*/
			//SELECT marsud.bts_carts.id, marsud.bts_users.username as Vartotojas, status as Busena, created_at as 'Sukurimo data' from marsud.bts_carts inner join marsud.bts_users on marsud.bts_users.id = marsud.bts_carts.user where bts_users.id = 1
			string Query = "SELECT marsud.bts_carts.id as 'Užsakymo nr', marsud.bts_users.username as Vartotojas, " +
					"status as Busena, created_at as 'Sukurimo data' from " +
					"marsud.bts_carts inner join marsud.bts_users on marsud.bts_users.id = marsud.bts_carts.user{0}";
		   

			string str = "";
			if (filter == null)
			{
				Query = String.Format(Query,"");
			}
			else
			{
				/*
				Query = String.Format("SELECT marsud.bts_orders.id, marsud.bts_users.username as Vartotojas, " +
					"status as Busena, created_at as 'Sukurimo data' from " +
					"marsud.bts_orders inner join marsud.bts_users on marsud.bts_users.id = marsud.bts_orders.user where {0}{1}{2}", 
					"marsud.bts_users.username="+filter.Username, filter.State);*/
			/*http://www.w3schools.com/sql/sql_wildcards.asp*/
			   
				if (!string.IsNullOrEmpty(filter.Username))
				{
					str = " where marsud.bts_users.username LIKE'" + filter.Username+"%'";
				}

				if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(filter.State))
				{
					str = str + " and marsud.bts_carts.status= '" + TranslateStateToEnglish(filter.State)+"'";
				}
				else if (!string.IsNullOrEmpty(filter.State))
				{
					str = " where marsud.bts_carts.status='" + TranslateStateToEnglish(filter.State) + "'";
				}
				if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(filter.startDate) && filter.startDate!= filter.endDate)
				{
					str = str + " and marsud.bts_carts.created_at>'" + filter.startDate+"'";

				}
				else if (!string.IsNullOrEmpty(filter.startDate))
				{
					str = " where marsud.bts_carts.created_at>'" + filter.startDate +"'";
				}

				if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(filter.endDate) && filter.startDate != filter.endDate)
				{
					str = str + " and marsud.bts_carts.created_at<'" + filter.endDate+"'";

				}
				else if (!string.IsNullOrEmpty(filter.endDate))
				{
					str = " where marsud.bts_carts.created_at<'" + filter.endDate+"'";
				}

				if (!string.IsNullOrEmpty(str))
				{
					Query = String.Format(Query, str);
					
				}				
				
			}

			gridFillWithQuery(grid, Query + " order by marsud.bts_carts.id desc");
			for (int i = 0; i < grid.RowCount; i++)
			{
				
				string atr = (string)grid[2, i].Value;
			   
				grid[2, i].Value = TranslateStateToLithuanian(atr);

			}        

				return true;

		}

		public void fillCartByOrder(DataGridView grid, int id)
		{
			/*string Query = String.Format(" Select bts_attributes.id, title as Pavadinimas, "+
			"bts_packs.quantity as Kiekis, marsud.bts_attributes.name as dydis, marsud.bts_attributes.price as Kaina, created_at as 'Sukurimo data' from marsud.bts_attributes, " +
			"marsud.bts_packs inner join marsud.bts_products on "+
			"marsud.bts_packs.product = marsud.bts_products.id where marsud.bts_packs.cart = {0} and marsud.bts_packs.product = marsud.bts_attributes.product", id);
			*/
			/*SELECT * FROM bts_products, bts_attributes_groups, bts_attributes, bts_brands, bts_carts inner join bts_packs on bts_carts.id = bts_packs.cart WHERE bts_packs.product = bts_products.id and bts_attributes_groups.product = bts_products.id and bts_attributes.attribute_group = bts_attributes_groups.id and bts_brands.id = bts_products.brand and bts_carts.id = 1*/

			//string Query = String.Format("SELECT * FROM bts_carts inner join bts_packs on bts_carts.id = bts_packs.cart WHERE bts_carts.id = {0}", id);
			//string Query = String.Format("SELECT * FROM marsud.bts_products, marsud.bts_attributes_groups, marsud.bts_attributes, marsud.bts_brands, marsud.bts_carts inner join marsud.bts_packs on bts_carts.id = bts_packs.cart WHERE bts_packs.product = bts_products.id and bts_attributes_groups.product = bts_products.id and bts_attributes.attribute_group = bts_attributes_groups.id and bts_brands.id = bts_products.brand and bts_carts.id = {0}", id);

			string Query = String.Format("SELECT bts_products.id, name as 'Aprašymas', real_price as 'Kaina', quantity as Kiekis, " +
			"attributes as 'Savybės'FROM marsud.bts_products, marsud.bts_carts inner join marsud.bts_packs on "+ 
			"bts_carts.id = bts_packs.cart WHERE bts_products.id = bts_packs.product "+
			"and bts_carts.id = {0}", id);
			
			gridFillWithQuery(grid, Query);
			DataGridViewColumn column5 = grid.Columns[4];
			column5.Width = 200;
            DataGridViewColumn column1 = grid.Columns[0];
            column1.Width = 50;
            DataGridViewColumn column2 = grid.Columns[1];
            column2.Width = 200;
            DataGridViewColumn column3 = grid.Columns[2];
            column3.Width = 50;
            DataGridViewColumn column4 = grid.Columns[3];
            column4.Width = 50;

			for (int i = 0; i < grid.RowCount; i++)
			{
				string str = "";
				string atr = (string)grid[4, i].Value;               
				List<JsonAttributes> attributes = JsonConvert.DeserializeObject<List<JsonAttributes>>(atr);
				foreach (JsonAttributes j in attributes)
				{
					str = String.Format("{0} {1}:{2} ", str, j.name, j.value);
				}
				grid[4, i].Value = str;

			}        

			//grid.Columns.Add("")



		}

		public void fillOrderInfo(TextBox username, TextBox order_id, ComboBox state, int id){
			string Query = "select marsud.bts_carts.id, bts_users.username, status from marsud.bts_carts inner join marsud.bts_users on bts_users.id = bts_carts.user where bts_carts.id=" + id;
			

			int selectedId = 0;

			try
			{

				connection = new MySQLConnection(connectionString);
				connection.Open();

				MySqlCommand cmd = new MySqlCommand(Query, connection);
				MySqlDataReader reader = cmd.ExecuteReader();
				reader.Read();
				order_id.Text = reader.GetString(0);
				username.Text = reader.GetString(1);

				string stateName = TranslateStateToLithuanian(reader.GetString(2));
				int i = 1;
				for(i = 1; i <= 3; i++){
					if (stateName == Enum.GetName(typeof(OrderStates), i))
					{
						break;
					}
				}

				state.SelectedIndex = i - 1;

				reader.Close();

	   

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

		public void updateOrderInfo(int id, string state)
		{
			string Query = "update marsud.bts_carts set status='"+TranslateStateToEnglish(state)+"' where id="+id;
			updateByQuery(Query, null);


		}

		public void flllCartItemQuantity(int Orderid, int productId, TextBox quantityTextBox)
		{
			//string Query = string.Format("select quantity from marsud.bts_packs where cart={0} and id={1}", Orderid, productId);
			string Query = string.Format("SELECT quantity " +
			"FROM marsud.bts_products, marsud.bts_carts inner join marsud.bts_packs on " +
			"bts_carts.id = bts_packs.cart where bts_packs.cart = {0} and bts_products.id = {1} and product = {1}", Orderid, productId);

			try
			{

				connection = new MySQLConnection(connectionString);
				connection.Open();

				MySqlCommand cmd = new MySqlCommand(Query, connection);
				MySqlDataReader reader = cmd.ExecuteReader();

				if (reader.Read())
				{
					string quantity = reader.GetString(0);
					quantityTextBox.Text = quantity;

				}
				else
				{
					quantityTextBox.Text = "0";
				}
				reader.Close();



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

		public void updatePackItemQuantity(int cartId, int productId, int quantity)
		{
			string Query = string.Format("update marsud.bts_packs set quantity = {0} where cart = {1} and product = {2}", quantity, cartId, productId);

			updateByQuery(Query, null);
		}

		public void deletePackItem(int cartId, int productId)
		{
			string Query = string.Format("delete from marsud.bts_packs where cart = {0} and product = {1}", cartId, productId);

			updateByQuery(Query, null);
		}

		public void deleteOrder(int cartId)
		{
			string Query = string.Format("delete from marsud.bts_packs where cart = {0}", cartId);
			string Query2 = string.Format("delete from marsud.bts_carts where id = {0}", cartId);

			updateByQuery(Query, Query2);

		}

		public void fillOrderStatisticsGrid(DataGridView grid, OrderStatisticsFilter filter)
		{
			//SELECT name, real_price, sum(quantity), sum(quantity)*real_price, bts_carts.created_at FROM marsud.bts_products, marsud.bts_carts inner join marsud.bts_packs on bts_carts.id = bts_packs.cart where bts_carts.status = 'done' and product = bts_products.id group by product
			string Query = "SELECT name as 'Pavadinimas', real_price as 'Kaina', sum(quantity) as 'Kiekis', sum(quantity)*real_price as 'Pardavimų suma' " +
			"FROM marsud.bts_products, marsud.bts_carts inner join marsud.bts_packs on bts_carts.id = bts_packs.cart "+
			"where bts_carts.status = 'done' and product = bts_products.id";
			if (filter != null)
			{
				string str = "";

				if (!string.IsNullOrEmpty(filter.startDate) && filter.startDate!= filter.endDate)
				{
					str = str + " and marsud.bts_carts.created_at>='" + filter.startDate+"'";

				}
				

				if (!string.IsNullOrEmpty(filter.endDate) && filter.startDate != filter.endDate)
				{
					str = str + " and marsud.bts_carts.created_at<='" + filter.endDate+"'";

				}
				Query = Query + str;

			}

			Query = Query + " group by product order by Kiekis desc";
			gridFillWithQuery(grid, Query);
            DataGridViewColumn column1 = grid.Columns[0];
            column1.Width = 200;
            DataGridViewColumn column2 = grid.Columns[1];
            column2.Width = 100;
            DataGridViewColumn column3 = grid.Columns[2];
            column3.Width = 100;
		}


	}
}
