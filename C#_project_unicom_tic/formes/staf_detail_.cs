using C__project_unicom_tic.controlar;
using C__project_unicom_tic.modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__project_unicom_tic.formes
{
    public partial class staf_detail_ : Form
    {
        int user_id;
        int update_id;
        admin_controlar Admin_Controlar;
        public staf_detail_(int id)
        {
            user_id = id;
            InitializeComponent();
            Admin_Controlar = new admin_controlar();
            vew(0);



            textBox_user_name.Visible=false;
            label_user_name.Visible = false;
            button1.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
        }

        private void vew(int dd)
        {
            List<staf_modal> data = Admin_Controlar.all_staf_output();
            List<staf_modal> data_actve = new List<staf_modal>();
            List<staf_modal> data_non_active = new List<staf_modal>();


            foreach (staf_modal item in data)
            {
                if (item.status == "Non_Active")
                {
                    //item.status = "Non Active";
                    data_non_active.Add(item);
                }
                else if (item.status == "Active")
                {
                    //item.status = "Active";
                    data_actve.Add(item);
                }
            }

            if (dd == 1)
            {
                dataGridView1.DataSource = data_non_active;
            }
            else
            {
                dataGridView1.DataSource = data_actve;
            }
            dataGridView1.ClearSelection();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["status"].Visible = false;
            clear();
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
        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            textBox_name.Text=textBox_name.Text.Trim();
        }

        private void textBox_Address_TextChanged(object sender, EventArgs e)
        {
            textBox_Address.Text=textBox_Address.Text.Trim();
        }

        private void label_nic_number_Click(object sender, EventArgs e)
        {

        }

        private void textBox_nic_number_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int dd = Convert.ToInt32(textBox_nic_number.Text);
            }
            catch (Exception ex)
            {
                textBox_nic_number.Text = "";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_user_name.Text == null || textBox_user_name.Text.Trim() == "")
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
                Admin_Controlar.add_user(data3);

                textBox_user_name.Text = "";
                textBox_user_name.Visible = false;
                button1.Visible = false;
                label_user_name.Visible = false;
                label4.Visible = false;


            }

        }

        private void textBox_user_name_TextChanged(object sender, EventArgs e)
        {
            textBox_user_name.Text = textBox_user_name.Text.Trim();
            //xtBox_user_name.Text = textBox_user_name.Text.Trim();
            List<user_modal> existingUsers = Admin_Controlar.show_user_Output();
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

        private void button_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_name.Text) &&
               !string.IsNullOrWhiteSpace(textBox_Address.Text) &&
               !string.IsNullOrWhiteSpace(textBox_nic_number.Text))
            {
                try
                {
                    staf_modal data = new staf_modal();
                    data.Name = textBox_name.Text;
                    data.Nic_number = Convert.ToInt32(textBox_nic_number.Text);
                    data.Join_date = DateTime.Now.ToString("yyyy-MM-dd");
                    data.Out_date = "countnew";
                    data.status = "Active";
                    data.Adderss = textBox_Address.Text;

                    Admin_Controlar.add_staff(data);

                    List<staf_modal> data1 = Admin_Controlar.all_staf_output();
                    if (data1.Count > 0)
                    {
                        staf_modal modal = data1[data1.Count - 1];
                        label_show.Text = modal.Id.ToString();
                        update_id = modal.Id;
                    }

                    textBox_user_name.Text = "";
                    textBox_user_name.Visible = true;
                    button1.Visible = true;
                    label_user_name.Visible = true;
                    label4.Visible = true;
                    vew(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            else
            {
                //label2.Visible = true;
                label_show.Text = "Complete all details.";
                label_show.ForeColor = Color.Red;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_name.Text) &&
                !string.IsNullOrWhiteSpace(textBox_Address.Text) &&
                !string.IsNullOrWhiteSpace(textBox_nic_number.Text))
            { staf_modal data = new staf_modal();
            data.Id = update_id;
            data.Name = textBox_name.Text;
            data.Nic_number = Convert.ToInt32(textBox_nic_number.Text);
            data.Join_date = label7.Text;
            data.Out_date = label8.Text;
            data.status = label10.Text;
            data.Adderss = textBox_Address.Text.Trim();

            if (!string.IsNullOrWhiteSpace(data.Name) &&
                !string.IsNullOrWhiteSpace(data.Adderss) &&
                !string.IsNullOrWhiteSpace(textBox_nic_number.Text))
            {
                Admin_Controlar.update_staff(data);
                //MessageBox.Show("Admin updated successfully!");
                vew(0);
                clear();
            }
            else
            {
                label_show.Text = "Complete all details.";
                label_show.ForeColor = Color.Red;
            }

            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
                clear();
            }
            else
            {
                //label2.Visible = true;
                label_show.Text = "Complete all details.";
                label_show.ForeColor = Color.Red;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["Id"].Value != null) 
            {
                //taGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int staff_id_num = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value );
                staf_modal staf_data = Admin_Controlar.show_staff_(staff_id_num);
                update_id = staf_data.Id;

                if (staf_data != null && staf_data.Id != 0)
                {

                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;

                    textBox_name.Text = staf_data.Name;
                    textBox_nic_number.Text = Convert.ToString(staf_data.Nic_number);
                    textBox_Address.Text = staf_data.Adderss;
                    label7.Text = staf_data.Join_date;
                    label8.Text= staf_data.Out_date;
                    label10.Text= staf_data.status;
                }
                else
                {
                    MessageBox.Show("Admin not found.");
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void staf_detail__Load(object sender, EventArgs e)
        {

        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_name.Text) &&
                !string.IsNullOrWhiteSpace(textBox_Address.Text) &&
                !string.IsNullOrWhiteSpace(textBox_nic_number.Text))
            { 
                DialogResult result = MessageBox.Show(
               "Are you sure you want to delete?",
               "Confirm Delete",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
               );

                if (result == DialogResult.Yes)
                {
                    staf_modal data = new staf_modal();
                    data.Id = update_id;
                    data.Name = textBox_name.Text;
                    data.Nic_number = Convert.ToInt32(textBox_nic_number.Text);
                    data.Join_date = label7.Text;
                    data.Out_date = DateTime.Now.ToString("yyyy-MM-dd");
                    data.status = "Non_Active";
                    data.Adderss = textBox_Address.Text.Trim();

                    if (!string.IsNullOrWhiteSpace(data.Name) &&
                        !string.IsNullOrWhiteSpace(data.Adderss) &&
                        !string.IsNullOrWhiteSpace(textBox_nic_number.Text))
                    {
                        Admin_Controlar.update_staff(data);
                        vew(0);
                        clear();
                    }
                    else
                    {
                        label_show.Text = "Complete all details.";
                        label_show.ForeColor = Color.Red;
                    }

                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    label10.Visible = false;
                    label11.Visible = false;
                    clear();

                    Admin_Controlar.delete_user_(update_id);

                    MessageBox.Show("bye bye");
                    // Application.Exit();
                }
                else
                {
                    vew(0);
                    MessageBox.Show("Delete operation cancelled.");
                }
            }
            else
            {
                //label2.Visible = true;
                label_show.Text = "Complete all details.";
                label_show.ForeColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button_add.Visible = false;
            button_update.Visible = false;
            button_Delete.Visible = false;
            vew(1);
            clear();
        }

        private void staf_detail_Click(object sender, EventArgs e)
        {

            button_add.Visible = true;
            button_update.Visible = true;
            button_Delete.Visible = true;
            vew(0);
            clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    
}
