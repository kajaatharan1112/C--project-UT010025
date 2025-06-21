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
    internal class student_controlar : user_controlar_
    {
        public  void insert_student(student_modal student)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"INSERT INTO Student_table (Name, Course_Id, Status, Nic_number, Address)
                         VALUES (@Name, @Course_Id, @Status, @Nic_number, @Address);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Course_Id", student.corse_id);
                    cmd.Parameters.AddWithValue("@Status", student.status);
                    cmd.Parameters.AddWithValue("@Nic_number", student.Nic_number);
                    cmd.Parameters.AddWithValue("@Address", student.Adderss);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public  List<student_modal> show_student_Output()
        {
            List<student_modal> students = new List<student_modal>();
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"SELECT * FROM Student_table;";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new student_modal
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                corse_id = reader.GetInt32(2),
                                status = reader.GetString(3),
                                Nic_number = reader.GetInt32(4),
                                Adderss = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return students;
        }



        public  void update_student(student_modal student)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"UPDATE Student_table 
                         SET Name = @Name,
                             Course_Id = @Course_Id,
                             Status = @Status,
                             Nic_number = @Nic_number,
                             Address = @Address
                         WHERE Id = @Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Course_Id", student.corse_id);
                    cmd.Parameters.AddWithValue("@Status", student.status);
                    cmd.Parameters.AddWithValue("@Nic_number", student.Nic_number);
                    cmd.Parameters.AddWithValue("@Address", student.Adderss);
                    cmd.Parameters.AddWithValue("@Id", student.Id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No student found with this ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public  void delete_student(int id)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = "DELETE FROM Student_table WHERE Id = @Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No student found with this ID.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public  void update_student_status_by_course(int courseId, string newStatus)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"UPDATE Student_table 
                         SET Status = @Status 
                         WHERE Course_Id = @Course_Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@Course_Id", courseId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{rowsAffected} student(s) updated.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public  List<student_modal> get_students_by_course(int courseId)
        {
            List<student_modal> students = new List<student_modal>();

            using (var connection = DB_connection.Get_Connection())
            {
                string query = "SELECT * FROM Student_table WHERE Course_Id = @Course_Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Course_Id", courseId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            student_modal student = new student_modal
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                corse_id = Convert.ToInt32(reader["Course_Id"]),
                                Nic_number = Convert.ToInt32(reader["Nic_number"]),
                                status = reader["Status"].ToString(),
                                Adderss = reader["Address"].ToString()
                            };

                            students.Add(student);
                        }
                    }
                }
            }

            return students;
        }

        public  student_modal get_student_by_id(int id)
        {
            student_modal student = null;

            using (var connection = DB_connection.Get_Connection())
            {
                string query = "SELECT * FROM Student_table WHERE Id = @Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            student = new student_modal
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                corse_id = Convert.ToInt32(reader["Course_Id"]),
                                Nic_number = Convert.ToInt32(reader["Nic_number"]),
                                status = reader["Status"].ToString(),
                                Adderss = reader["Address"].ToString()
                            };
                        }
                    }
                }
            }

            return student;
        }






    }
}
