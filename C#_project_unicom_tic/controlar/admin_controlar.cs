﻿using C__project_unicom_tic.data;
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

    //The jobs that are allowed only for admin are mentioned below.
    //Changes made to the schedule for admin
    //
    //
    //
    internal class admin_controlar : staf_controlar
    {
        public void add_admin(admin_modal data)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = "INSERT INTO Admin_table (Name, Nic_number, Address) VALUES (@Name, @Nic_number, @Address);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", data.Name);
                    cmd.Parameters.AddWithValue("@Nic_number", data.Nic_number);
                    cmd.Parameters.AddWithValue("@Address", data.Address);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New admin created successfully!");
                }
            }
        }





        public List<admin_modal> show_admin_Output()
        {
            List<admin_modal> data = new List<admin_modal>();

            using (var connection = DB_connection.Get_Connection())
            {

                string query = @"SELECT * FROM Admin_table ;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new admin_modal
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Nic_number=reader.GetInt32(2),
                                Address = reader.GetString(3),
                                
                            });


                        }
                    }
                }

            }
            return data;

        }



         public admin_modal show_admin_(int admin_id_num)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"SELECT * FROM Admin_table WHERE Id = @Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", admin_id_num);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                       if (reader.Read())
                        {
                            return new admin_modal
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Nic_number = reader.GetInt32(2),
                                Address = reader.GetString(3)
                            };
                        }
                    }
                }
            }
            return new admin_modal
            {
                Id = 0,
                Name = "Not Found",
                Nic_number = 0,
                Address = "Not Found"
            };
         }

        public void delete_admin_(int admin_id_num)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"DELETE FROM Admin_table WHERE Id = @Id;";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", admin_id_num);
                    int rowsAffected = cmd.ExecuteNonQuery(); 
                }
            }
        }

        public void update_admin(admin_modal admin)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"UPDATE Admin_table 
                         SET Name = @Name, 
                             Nic_number = @Nic_number, 
                             Address = @Address 
                         WHERE Id = @Id AND Id BETWEEN 100000 AND 100050;";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", admin.Name);
                    cmd.Parameters.AddWithValue("@Nic_number", admin.Nic_number);
                    cmd.Parameters.AddWithValue("@Address", admin.Address);
                    cmd.Parameters.AddWithValue("@Id", admin.Id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Admin updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Update failed. ID may be out of valid range.");
                    }
                }
            }
        }


        //Changes made to the schedule for staf
        //
        //
        //
        //




        public void add_staff(staf_modal data)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = "INSERT INTO Staff_table (Name, Nic_number, Status, Join_date, Out_date, Address) " +
                               "VALUES (@Name, @Nic_number, @Status, @Join_date, @Out_date, @Address);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", data.Name);
                    cmd.Parameters.AddWithValue("@Nic_number", data.Nic_number);
                    cmd.Parameters.AddWithValue("@Status", data.status);
                    cmd.Parameters.AddWithValue("@Join_date", data.Join_date);
                    cmd.Parameters.AddWithValue("@Out_date", data.Out_date);
                    cmd.Parameters.AddWithValue("@Address", data.Adderss);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New staff member added successfully!");
                }
            }
        }

        public List<staf_modal> all_staf_output()
        {
            List<staf_modal> data = new List<staf_modal>();

            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"SELECT * FROM Staff_table;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new staf_modal
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Nic_number = reader.GetInt32(2),
                                status = reader.GetString(3),
                                Join_date = reader.GetString(4),
                                Out_date = reader.GetString(5),
                                Adderss = reader.GetString(6)
                            });
                        }
                    }
                }
            }
            return data;

        }

        public staf_modal show_staff_(int staff_id_num)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"SELECT * FROM Staff_table WHERE Id = @Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", staff_id_num);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new staf_modal
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Nic_number = reader.GetInt32(2),
                                status = reader.GetString(3),
                                Join_date = reader.GetString(4),
                                Out_date = reader.GetString(5),
                                Adderss = reader.GetString(6)
                            };
                        }
                    }
                }
            }

            return new staf_modal
            {
                Id = 0,
                Name = "Not Found",
                Nic_number = 0,
                status = "Not Found",
                Join_date = "Not Found",
                Out_date = "Not Found",
                Adderss = "Not Found"
            };
        }



        public void delete_staff_(int staff_id_num)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"DELETE FROM Staff_table WHERE Id = @Id;";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", staff_id_num);
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
        }


        public void update_staff(staf_modal staff)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string query = @"UPDATE Staff_table 
                         SET Name = @Name, 
                             Nic_number = @Nic_number, 
                             Status = @Status,
                             Join_date = @Join_date, 
                             Out_date = @Out_date, 
                             Address = @Address 
                         WHERE Id = @Id AND Id BETWEEN 105000 AND 240000;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", staff.Name);
                    cmd.Parameters.AddWithValue("@Nic_number", staff.Nic_number);
                    cmd.Parameters.AddWithValue("@Status", staff.status);
                    cmd.Parameters.AddWithValue("@Join_date", staff.Join_date);
                    cmd.Parameters.AddWithValue("@Out_date", staff.Out_date);
                    cmd.Parameters.AddWithValue("@Address", staff.Adderss);
                    cmd.Parameters.AddWithValue("@Id", staff.Id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Staff updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Update failed. ID may be out of valid range.");
                    }
                }
            }
        }

    }
}
