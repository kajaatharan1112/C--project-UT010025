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
    internal class teacher_controlar : student_controlar
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


        //time table funcations 
        //
        //
        //
        //
        //
        //
        public void add_time_table(Time_table_modal data)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"INSERT INTO Time_table 
                         (Date, Teacher, Course_Id, Time_Lap, Class_name, Status) 
                         VALUES 
                         (@Date, @Teacher, @Course_Id, @Time_Lap, @Class_name, @Status);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Date", data.Date);
                    cmd.Parameters.AddWithValue("@Teacher", data.Teacher);
                    cmd.Parameters.AddWithValue("@Course_Id", data.Corse_id);
                    cmd.Parameters.AddWithValue("@Time_Lap", data.Time_lap);
                    cmd.Parameters.AddWithValue("@Class_name", data.class_name);
                    cmd.Parameters.AddWithValue("@Status", data.status);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New time table record added!");
                }
            }
        }


        public List<Time_table_modal> show_time_table_Output()
        {
            List<Time_table_modal> data = new List<Time_table_modal>();

            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"SELECT * FROM Time_table;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new Time_table_modal
                            {
                                Id = reader.GetInt32(0),
                                Date = reader.GetString(1),
                                Teacher = reader.GetString(2),
                                Corse_id = reader.GetInt32(3),
                                Time_lap = reader.GetString(4),
                                class_name = reader.GetString(5),
                                status = reader.GetString(6)
                            });
                        }
                    }
                }
            }

            return data;
        }



        public List<Time_table_modal> Get_TimeTable_By_Date_And_Course(string date, int course_id)
        {
            List<Time_table_modal> result = new List<Time_table_modal>();

            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"SELECT * FROM Time_table WHERE Date = @Date AND Course_Id = @CourseId;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@CourseId", course_id);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Time_table_modal item = new Time_table_modal
                            {
                                Id = reader.GetInt32(0),
                                Date = reader.GetString(1),
                                Teacher = reader.GetString(2),
                                Corse_id = reader.GetInt32(3),
                                Time_lap = reader.GetString(4),
                                class_name = reader.GetString(5),
                                status = reader.GetString(6)
                            };

                            result.Add(item);
                        }
                    }
                }
            }

            return result;

        }


        public void update_time_table(Time_table_modal data)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"UPDATE Time_table 
                         SET Date = @Date,
                             Teacher = @Teacher,
                             Course_Id = @Course_Id,
                             Time_Lap = @Time_Lap,
                             Class_name = @Class_name,
                             Status = @Status
                         WHERE Id = @Id AND Id BETWEEN 10000000 AND 99999999;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Date", data.Date);
                    cmd.Parameters.AddWithValue("@Teacher", data.Teacher);
                    cmd.Parameters.AddWithValue("@Course_Id", data.Corse_id);
                    cmd.Parameters.AddWithValue("@Time_Lap", data.Time_lap);
                    cmd.Parameters.AddWithValue("@Class_name", data.class_name);
                    cmd.Parameters.AddWithValue("@Status", data.status);
                    cmd.Parameters.AddWithValue("@Id", data.Id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Time table updated successfully!");
                    else
                        MessageBox.Show("Update failed. Invalid ID.");
                }
            }
        }

        public Time_table_modal get_time_table_by_id(int id)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"SELECT * FROM Time_table WHERE Id = @Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Time_table_modal
                            {
                                Id = reader.GetInt32(0),
                                Date = reader.GetString(1),
                                Teacher = reader.GetString(2),
                                Corse_id = reader.GetInt32(3),
                                Time_lap = reader.GetString(4),
                                class_name = reader.GetString(5),
                                status = reader.GetString(6)
                            };
                        }
                    }
                }
            }

            // Return default object if not found
            return new Time_table_modal
            {
                Id = 0,
                Date = "Not Found",
                Teacher = "Not Found",
                Corse_id = 0,
                Time_lap = "Not Found",
                class_name = "Not Found",
                status = "Not Found"
            };
        }


        public void delete_time_table(int id)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"DELETE FROM Time_table WHERE Id = @Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Time table entry deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No matching time table entry found.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }




        //
        //
        //
        //
        ///
        //
        //
        //

        //                                                   exam funcations
        //
        //
        //
        //
        //
        //
        //

        public void Add_Exam(Exam_modal data)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = "INSERT INTO Exam_table (Name, Teacher_Id, Course_Id, Status) VALUES (@Name, @Teacher_Id, @Course_Id, @Status);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", data.Name);
                    cmd.Parameters.AddWithValue("@Teacher_Id", data.Teacher_Id);
                    cmd.Parameters.AddWithValue("@Course_Id", data.Corse_Id);
                    cmd.Parameters.AddWithValue("@Status", data.Status);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New exam created successfully!");
                }
            }
        }


        public List<Exam_modal> Show_Exam_Output()
        {
            List<Exam_modal> data = new List<Exam_modal>();

            using (var connection = DB_connection.Get_Connection())
            {
                string query = "SELECT * FROM Exam_table;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new Exam_modal
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Teacher_Id = reader.GetInt32(2),
                                Corse_Id = reader.GetInt32(3),
                                Status = reader.GetString(4)
                            });
                        }
                    }
                }
            }

            return data;
        }


        public Exam_modal Show_Exam_By_Id(int exam_id)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = "SELECT * FROM Exam_table WHERE Id = @Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", exam_id);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Exam_modal
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Teacher_Id = reader.GetInt32(2),
                                Corse_Id = reader.GetInt32(3),
                                Status = reader.GetString(4)
                            };
                        }
                    }
                }
            }

            return new Exam_modal
            {
                Id = 0,
                Name = "Not Found",
                Teacher_Id = 0,
                Corse_Id = 0,
                Status = "Not Found"
            };
        }

        public void Update_Exam(Exam_modal data)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"UPDATE Exam_table 
                         SET Name = @Name, 
                             Teacher_Id = @Teacher_Id, 
                             Course_Id = @Course_Id, 
                             Status = @Status 
                         WHERE Id = @Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", data.Name);
                    cmd.Parameters.AddWithValue("@Teacher_Id", data.Teacher_Id);
                    cmd.Parameters.AddWithValue("@Course_Id", data.Corse_Id);
                    cmd.Parameters.AddWithValue("@Status", data.Status);
                    cmd.Parameters.AddWithValue("@Id", data.Id);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                        MessageBox.Show("Exam updated successfully!");
                    else
                        MessageBox.Show("Update failed. Exam not found.");
                }
            }
        }


        public void Delete_Exam(int exam_id)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = "DELETE FROM Exam_table WHERE Id = @Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", exam_id);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                        MessageBox.Show("Exam deleted successfully!");
                    else
                        MessageBox.Show("Delete failed. Exam not found.");
                }
            }
        }



        public List<Exam_modal> Get_Exams_By_CourseId(int courseId)
        {
            List<Exam_modal> data = new List<Exam_modal>();

            using (var connection = DB_connection.Get_Connection())
            {
                string query = "SELECT * FROM Exam_table WHERE Course_Id = @Course_Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Course_Id", courseId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new Exam_modal
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Teacher_Id = reader.GetInt32(2),
                                Corse_Id = reader.GetInt32(3),
                                Status = reader.GetString(4)
                            });
                        }
                    }
                }
            }

            return data;
        }






    }
}

    


    

