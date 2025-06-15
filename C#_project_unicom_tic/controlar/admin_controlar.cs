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
    internal class admin_controlar : staf_controlar
    {
        public void add_admin(admin_modal data)
        {
            using (var connection = DB_connection.Get_Connection())
            {
                //connection.Open(); // Ensure the connection is open
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
    }
 }
