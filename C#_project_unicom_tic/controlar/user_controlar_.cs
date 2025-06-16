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

    }
}

