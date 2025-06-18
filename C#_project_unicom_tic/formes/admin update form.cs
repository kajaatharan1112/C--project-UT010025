using C__project_unicom_tic.controlar;
using C__project_unicom_tic.modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__project_unicom_tic.formes
{
    public partial class admin_update_form : Form
    {
        private admin_controlar Admin_controlar;
        private user_controlar_ User_Controlar_;
        public int id;
        public int update_id;

        public admin_update_form(int dd)
        {
            
            id = dd;

            Admin_controlar = new admin_controlar();
            User_Controlar_=new user_controlar_();
            InitializeComponent();
            viw();


            label4.Visible = false;
            textBox_user_name.Visible = false;
            label_user_name.Visible=false;
            button1.Visible = false;
        }
        private void clear()
        {
            textBox_name.Text = "";
            label_name.Text = "";
            label_nic_number.Text = "";
            label_address.Text = "";
            textBox_Address.Text = "";
            textBox_nic_number.Text = "";
        }
        private void viw()
        {
            List<admin_modal> data1 = Admin_controlar.show_admin_Output();
            dataGridView1.DataSource = data1;
            dataGridView1.ClearSelection();
            dataGridView1.Columns["Id"].Visible = false;
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                /*Form1 form = new Form1();
                int id = form.rool();*/

                label_show.Text = Convert.ToString(id);
                Admin_controlar.delete_admin_(id);
                User_Controlar_.delete_user_(id);
                viw();
                MessageBox.Show("bye bye");
                Application.Exit();
            }
            else
            {
               viw();
                MessageBox.Show("Delete operation cancelled.");
            }

            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox_name.Text=textBox_name.Text.Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_name.Text) &&
                !string.IsNullOrWhiteSpace(textBox_Address.Text) &&
                !string.IsNullOrWhiteSpace(textBox_nic_number.Text))
                        {
                try
                {
                    admin_modal data = new admin_modal();
                    data.Name = textBox_name.Text;
                    data.Nic_number = Convert.ToInt32(textBox_nic_number.Text);
                    data.Address = textBox_Address.Text;

                    Admin_controlar.add_admin(data);

                    List<admin_modal> data1 = Admin_controlar.show_admin_Output();
                    if (data1.Count > 0)
                    {
                        admin_modal modal = data1[data1.Count - 1];
                        label_show.Text = modal.Id.ToString();
                        update_id = modal.Id;
                    }

                    label4.Visible = true;
                    textBox_user_name.Visible = true;
                    label_user_name.Visible = true;
                    viw();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
               //label2.Visible = true;
                label2.Text = "Complete all details.";
                label2.ForeColor = Color.Red;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
         
        }

        private void textBox_nic_number_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int dd = Convert.ToInt32(textBox_nic_number.Text.Trim());
            }
            catch (FormatException)
            {
                label_nic_number.Text = "Input numbers only ";
                textBox_nic_number.Text = "0";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Address_TextChanged(object sender, EventArgs e)
        {
            textBox_Address.Text=textBox_Address.Text.Trim();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(textBox_user_name.Text ==null || textBox_user_name.Text.Trim() == "")
            {
                label_user_name.Text = "User name is required.";
            }
            else
               {
                user_modal data3 = new user_modal
                {
                    User_id = update_id,
                    Name = textBox_user_name.Text.Trim(),
                    Password = "Admin@123"
                };
                User_Controlar_.add_user(data3);

                textBox_user_name.Text = "";
                textBox_user_name.Visible = false;
                button1.Visible = false;
                
            }

        }

        private void textBox_user_name_TextChanged(object sender, EventArgs e)
        {
            textBox_user_name.Text=textBox_user_name.Text.Trim();
            List<user_modal> existingUsers = User_Controlar_.show_user_Output();
            bool nameExists = existingUsers.Any(u => u.Name.Equals(textBox_user_name.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            if (nameExists)
            {
                label_user_name.Text = "User name already exists.";
                label_user_name.ForeColor = Color.Red;
                button1.Visible = false; 
            }
            else
            {
                label_user_name.Text = "User name is available.";
                label_user_name.ForeColor = Color.Green;
                button1.Visible = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int admin_Id = Convert.ToInt32(row.Cells["Id"].Value);
                admin_modal admin_data = Admin_controlar.show_admin_(admin_Id);
                update_id = admin_data.Id;

                if (admin_data != null && admin_data.Id != 0)
                {
                    textBox_name.Text = admin_data.Name;
                    textBox_nic_number.Text=Convert .ToString(admin_data.Nic_number);
                    textBox_Address.Text = admin_data.Address;
                }
                else
                {
                    MessageBox.Show("Admin not found.");
                }
            }

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            admin_modal data = new admin_modal();
            data.Id = update_id;
            data.Name = textBox_name.Text.Trim();
            data.Nic_number = Convert.ToInt32(textBox_nic_number.Text.Trim());
            data.Address = textBox_Address.Text.Trim();

            if (!string.IsNullOrWhiteSpace(data.Name) &&
                !string.IsNullOrWhiteSpace(data.Address) &&
                !string.IsNullOrWhiteSpace(textBox_nic_number.Text))
            {
                Admin_controlar.update_admin(data);
                //MessageBox.Show("Admin updated successfully!");
                viw();
                clear();
            }
            else
            {
                label2.Text = "Complete all details.";
                label2.ForeColor = Color.Red;
            }
        }

        private void label_show_Click(object sender, EventArgs e)
        {

        }

        private void label_user_name_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
