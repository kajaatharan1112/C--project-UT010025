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
    internal class staf_controlar : teacher_controlar
    {
        public void add_teacher(teacher_modl data)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"INSERT INTO Teacher_table 
                        (Name, Subject, Nic_number, Status, Join_date, Out_date, Address) 
                         VALUES 
                        (@Name, @Subject, @Nic_number, @Status, @Join_date, @Out_date, @Address);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", data.Name);
                    cmd.Parameters.AddWithValue("@Subject", data.Subject);
                    cmd.Parameters.AddWithValue("@Nic_number", data.Nic_number);
                    cmd.Parameters.AddWithValue("@Status", data.status);
                    cmd.Parameters.AddWithValue("@Join_date", data.Join_date);
                    cmd.Parameters.AddWithValue("@Out_date", data.Out_date);
                    cmd.Parameters.AddWithValue("@Address", data.Adderss);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New teacher added successfully!");
                }
            }
        }


        public List<teacher_modl> show_teacher_Output()
        {
            List<teacher_modl> data = new List<teacher_modl>();

            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"SELECT * FROM Teacher_table;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new teacher_modl
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Subject = reader.GetString(2),
                                Nic_number = reader.GetInt32(3),
                                status = reader.GetString(4),
                                Join_date = reader.GetString(5),
                                Out_date = reader.GetString(6),
                                Adderss = reader.GetString(7)
                            });
                        }
                    }
                }
            }

            return data;
        }




        public teacher_modl show_teacher_(int teacher_id_num)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"SELECT * FROM Teacher_table WHERE Id = @Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", teacher_id_num);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new teacher_modl
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Subject = reader.GetString(2),
                                Nic_number = reader.GetInt32(3),
                                status = reader.GetString(4),
                                Join_date = reader.GetString(5),
                                Out_date = reader.GetString(6),
                                Adderss = reader.GetString(7)
                            };
                        }
                    }
                }
            }

            return new teacher_modl
            {
                Id = 0,
                Name = "Not Found",
                Subject = "Not Found",
                Nic_number = 0,
                status = "Not Found",
                Join_date = "Not Found",
                Out_date = "Not Found",
                Adderss = "Not Found"
            };
        }

        public void delete_teacher_(int teacher_id_num)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"DELETE FROM Teacher_table WHERE Id = @Id;";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", teacher_id_num);
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
        }


        public void update_teacher(teacher_modl teacher)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"UPDATE Teacher_table 
                         SET Name = @Name, 
                             Subject = @Subject, 
                             Nic_number = @Nic_number, 
                             Status = @Status, 
                             Join_date = @Join_date, 
                             Out_date = @Out_date, 
                             Address = @Address 
                         WHERE Id = @Id AND Id BETWEEN 250000 AND 499999;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", teacher.Name);
                    cmd.Parameters.AddWithValue("@Subject", teacher.Subject);
                    cmd.Parameters.AddWithValue("@Nic_number", teacher.Nic_number);
                    cmd.Parameters.AddWithValue("@Status", teacher.status);
                    cmd.Parameters.AddWithValue("@Join_date", teacher.Join_date);
                    cmd.Parameters.AddWithValue("@Out_date", teacher.Out_date);
                    cmd.Parameters.AddWithValue("@Address", teacher.Adderss);
                    cmd.Parameters.AddWithValue("@Id", teacher.Id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Teacher updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Update failed. ID may be out of valid range.");
                    }
                }
            }
        }
        public List<teacher_modl> search_teacher(string searchTerm)
        {
            List<teacher_modl> data = new List<teacher_modl>();
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"SELECT * FROM Teacher_table WHERE Name LIKE @SearchTerm OR Subject LIKE @SearchTerm;";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new teacher_modl
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Subject = reader.GetString(2),
                                Nic_number = reader.GetInt32(3),
                                status = reader.GetString(4),
                                Join_date = reader.GetString(5),
                                Out_date = reader.GetString(6),
                                Adderss = reader.GetString(7)
                            });
                        }
                    }
                }
            }
            return data;
        }




    }

}
