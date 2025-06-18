using C__project_unicom_tic.data;
using C__project_unicom_tic.modals;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__project_unicom_tic.controlar
{
    internal class user_controlar_
    {
        public void add_user(user_modal data)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = "INSERT INTO User_table (User_id, User_name, Password) VALUES (@User_id, @Name, @Password);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@User_id", data.User_id);
                    cmd.Parameters.AddWithValue("@Name", data.Name);
                    cmd.Parameters.AddWithValue("@Password", data.Password);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New user created successfully!");
                }
            }
        }

        public List<user_modal> show_user_Output()
        {
            List<user_modal> data = new List<user_modal>();

            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"SELECT * FROM User_table;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new user_modal
                            {
                                User_id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Password = reader.GetString(2)
                            });
                        }
                    }
                }
            }

            return data;
        }

        public void delete_user_(int user_id_num)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"DELETE FROM User_table WHERE User_id = @UserId;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", user_id_num);
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update_User(user_modal user)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"UPDATE User_table 
                         SET User_name = @User_name, 
                             Password = @Password 
                         WHERE User_id = @User_id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@User_name", user.Name);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@User_id", user.User_id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Update failed. User ID not found.");
                    }
                }
            }
        }

    }
}

