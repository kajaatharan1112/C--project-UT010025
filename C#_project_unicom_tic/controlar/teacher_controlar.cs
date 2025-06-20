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
    internal class teacher_controlar:student_controlar
    {

        //thecher activites
        //add class name 
        //
        //
        //

        public void add_class(class_modal data)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = "INSERT INTO Class_table (Name) VALUES (@Name);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", data.name);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New class created successfully!");
                }
            }
        }

        public List<class_modal> show_class_Output()
        {
            List<class_modal> data = new List<class_modal>();

            using (var connection = DB_connection.Get_Connection())
            {
                string query = "SELECT * FROM Class_table;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new class_modal
                            {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            return data;
        }


        public class_modal show_class_(int class_id)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"SELECT * FROM Class_table WHERE Id = @Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", class_id);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new class_modal
                            {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return new class_modal
            {
                id = 0,
                name = "Not Found"
            };
        }

        public void delete_class_(int class_id)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"DELETE FROM Class_table WHERE Id = @Id;";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", class_id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Class deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Class not found or delete failed.");
                    }
                }
            }
        }

        public void update_class(class_modal classData)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"UPDATE Class_table SET Name = @Name WHERE Id = @Id;";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", classData.name);
                    cmd.Parameters.AddWithValue("@Id", classData.id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Class updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Class ID may not exist.");
                    }
                }
            }
        }


    }
}
