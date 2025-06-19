using C__project_unicom_tic.controlar;
using C__project_unicom_tic.modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__project_unicom_tic.formes
{
    public partial class teacher_detail_form : Form
    {
        public int id;
        public int update_id;
        staf_controlar Staf_Controlar;
        public teacher_detail_form(int id_)
        {
            Staf_Controlar=new staf_controlar();
            InitializeComponent();
            id = id_;
            List<string> combo = new List<string>
                {
                    "mathematics", "Python", "C#", "framework", "data structure and algorithm",
                    "AI", "machine learning", "Database Systems", "Networking", "Cyber Security", "Cloud Computing", "Web Development"
                };

            comboBox1.DataSource = combo;
            comboBox1.Text="";
            vew(0);


            textBox_user_name.Visible = false;
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
            List<teacher_modl> data = Staf_Controlar.show_teacher_Output();
            List<teacher_modl> data_actve = new List<teacher_modl>();
            List<teacher_modl> data_non_active = new List<teacher_modl>();


            foreach (teacher_modl item in data)
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
            comboBox1.Text = "";
        }

        private void teacher_detail_form_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void label_show_Click(object sender, EventArgs e)
        {

        }

        private void textBox_user_name_TextChanged(object sender, EventArgs e)
        {
            textBox_user_name.Text = textBox_user_name.Text.Trim();
            //xtBox_user_name.Text = textBox_user_name.Text.Trim();
            List<user_modal> existingUsers = Staf_Controlar.show_user_Output();
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
             !string.IsNullOrWhiteSpace(textBox_nic_number.Text)&&
             !string.IsNullOrWhiteSpace(comboBox1.Text) )
            {
                try
                {
                    teacher_modl data = new teacher_modl();
                    data.Name = textBox_name.Text;
                    data.Nic_number = Convert.ToInt32(textBox_nic_number.Text);
                    data.Subject = comboBox1.Text;
                    data.Join_date = DateTime.Now.ToString("yyyy-MM-dd");
                    data.Out_date = "countnew";
                    data.status = "Active";
                    data.Adderss = textBox_Address.Text;

                    Staf_Controlar.add_teacher(data);

                    List<teacher_modl> data1 = Staf_Controlar.show_teacher_Output();
                    if (data1.Count > 0)
                    {
                        teacher_modl modal = data1[data1.Count - 1];
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
                Staf_Controlar.add_user(data3);

                textBox_user_name.Text = "";
                textBox_user_name.Visible = false;
                button1.Visible = false;
                label_user_name.Visible = false;
                label4.Visible = false;


            }
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            textBox_name.Text = textBox_name.Text.Trim();
        }

        private void textBox_Address_TextChanged(object sender, EventArgs e)
        {
            textBox_Address.Text = textBox_Address.Text.Trim();
        }

        private void textBox_nic_number_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_nic_number.Text = textBox_nic_number.Text.Trim();
                if (!string.IsNullOrEmpty(textBox_nic_number.Text) && !int.TryParse(textBox_nic_number.Text, out _))
                {
                    label_nic_number.Text = "NIC number must be a number.";
                    label_nic_number.ForeColor = Color.Red;
                    label_address.Text = "";
                }
                else
                {
                    label_nic_number.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["Id"].Value != null)
            {
                //taGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int teacher_id_num = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                teacher_modl teacher_data = Staf_Controlar.show_teacher_(teacher_id_num);
                update_id = teacher_data.Id;

                if (teacher_data != null && teacher_data.Id != 0)
                {

                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;

                    textBox_name.Text = teacher_data.Name;
                    textBox_nic_number.Text = Convert.ToString(teacher_data.Nic_number);
                    textBox_Address.Text = teacher_data.Adderss;
                    label7.Text = teacher_data.Join_date;
                    label8.Text = teacher_data.Out_date;
                    label10.Text = teacher_data.status;
                    comboBox1.Text = teacher_data.Subject;
                }
                else
                {
                    MessageBox.Show("Admin not found.");
                }
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_name.Text) &&
             !string.IsNullOrWhiteSpace(textBox_Address.Text) &&
             !string.IsNullOrWhiteSpace(textBox_nic_number.Text) &&
             !string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                    teacher_modl data = new teacher_modl();
                data.Id = update_id;
                data.Name = textBox_name.Text;
                data.Nic_number = Convert.ToInt32(textBox_nic_number.Text);
                data.Join_date = label7.Text;
                data.Out_date = label8.Text;
                data.status = label10.Text;
                data.Adderss = textBox_Address.Text.Trim();
                data.Subject = comboBox1.Text.Trim();

                if (!string.IsNullOrWhiteSpace(data.Name) &&
                    !string.IsNullOrWhiteSpace(data.Adderss) &&
                    !string.IsNullOrWhiteSpace(textBox_nic_number.Text))
                {
                    Staf_Controlar.update_teacher(data);
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


            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_name.Text) &&
            !string.IsNullOrWhiteSpace(textBox_Address.Text) &&
            !string.IsNullOrWhiteSpace(textBox_nic_number.Text) &&
            !string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                DialogResult result = MessageBox.Show(
              "Are you sure you want to delete?",
              "Confirm Delete",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question
              );
                    teacher_modl data = new teacher_modl();
                data.Id = update_id;
                data.Name = textBox_name.Text;
                data.Nic_number = Convert.ToInt32(textBox_nic_number.Text);
                data.Join_date = label7.Text;
                data.Out_date = DateTime.Now.ToString("yyyy-MM-dd");
                data.status = "Non_Active";
                data.Adderss = textBox_Address.Text.Trim();
                data.Subject = comboBox1.Text.Trim();

                if (!string.IsNullOrWhiteSpace(data.Name) &&
                    !string.IsNullOrWhiteSpace(data.Adderss) &&
                    !string.IsNullOrWhiteSpace(textBox_nic_number.Text))
                {
                    Staf_Controlar.update_teacher(data);
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
                    Staf_Controlar.delete_user_(update_id);
                }
                else
                {
                    label_show.Text = "Complete all details.";
                    label_show.ForeColor = Color.Red;
                }
        }

        private void staf_detail_Click(object sender, EventArgs e)
        {
            button_add.Visible = true;
            button_update.Visible = true;
            button_Delete.Visible = true;
            vew(0);
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button_add.Visible = false;
            button_update.Visible = false;
            button_Delete.Visible = false;
            vew(1);
            clear();
        }
    }
    
}
