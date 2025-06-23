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
    internal class marks__controlarClass:student_controlar
    {
        public void add_marks(marks_modal data)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = "INSERT INTO Marks_table (Student_Id, Exam_Id, Exam_marks, student_name) " +
                               "VALUES (@Student_Id, @Exam_Id, @Exam_marks, @student_name);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Student_Id", data.student_ID);
                    cmd.Parameters.AddWithValue("@Exam_Id", data.Exam_Id);
                    cmd.Parameters.AddWithValue("@Exam_marks", data.exam_marks);
                    cmd.Parameters.AddWithValue("@student_name", data.student_Name);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Marks added successfully!");
                }
            }
        }


        public List<marks_modal> show_all_marks()
        {
            List<marks_modal> data = new List<marks_modal>();

            using (var connection = DB_connection.Get_Connection())
            {
                string query = "SELECT * FROM Marks_table;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(new marks_modal
                        {
                            student_ID = reader.GetInt32(0),
                            Exam_Id = reader.GetInt32(1),
                            exam_marks = reader.GetInt32(2),
                            student_Name = reader.GetString(3)
                        });
                    }
                }
            }

            return data;
        }


        /*public marks_modal get_marks(int studentId, int examId)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = "SELECT * FROM Marks_table WHERE Student_Id = @Student_Id AND Exam_Id = @Exam_Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Student_Id", studentId);
                    cmd.Parameters.AddWithValue("@Exam_Id", examId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new marks_modal
                            {
                                student_ID = reader.GetInt32(0),
                                Exam_Id = reader.GetInt32(1),
                                exam_marks = reader.GetInt32(2),
                                student_Name = reader.GetString(3)
                            };
                        }
                    }
                }
            }

            return null;
        }*/


        public void delete_marks(int studentId, int examId)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = "DELETE FROM Marks_table WHERE Student_Id = @Student_Id AND Exam_Id = @Exam_Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Student_Id", studentId);
                    cmd.Parameters.AddWithValue("@Exam_Id", examId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Marks delet successfully!");
                }
            }
        }

        public void update_marks(marks_modal data)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"UPDATE Marks_table 
                         SET Exam_marks = @Exam_marks, 
                             student_name = @student_name 
                         WHERE Student_Id = @Student_Id AND Exam_Id = @Exam_Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Exam_marks", data.exam_marks);
                    cmd.Parameters.AddWithValue("@student_name", data.student_Name);
                    cmd.Parameters.AddWithValue("@Student_Id", data.student_ID);
                    cmd.Parameters.AddWithValue("@Exam_Id", data.Exam_Id);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Marks updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Update failed.");
                    }
                }
            }
        }


        public marks_modal get_marks(int courseId, int examId)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"
            SELECT M.Student_Id, M.Exam_Id, M.Exam_marks, M.student_name, E.Name AS Exam_Name
            FROM Marks_table M
            LEFT JOIN Exam_table E ON M.Exam_Id = E.Id
            WHERE M.Exam_Id = @Exam_Id AND E.Course_Id = @Course_Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Exam_Id", examId);
                    cmd.Parameters.AddWithValue("@Course_Id", courseId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new marks_modal
                            {
                                student_ID = reader.GetInt32(0),
                                Exam_Id = reader.GetInt32(1),
                                exam_marks = reader.GetInt32(2),
                                student_Name = reader.GetString(3),
                                Exam_Name = reader.GetString(4)
                            };
                        }
                    }
                }
            }

            return null;
        }









    }

}
