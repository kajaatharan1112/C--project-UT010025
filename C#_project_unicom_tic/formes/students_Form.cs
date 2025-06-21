using C__project_unicom_tic.controlar;
using C__project_unicom_tic.modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__project_unicom_tic.formes
{
    public partial class students_Form : Form
    {
        staf_controlar Staf_Controlar;
        public int id;
        public int update_id;
        public int ddd=0;
        public students_Form(int id_)
        {
            InitializeComponent();
            Staf_Controlar = new staf_controlar();
            id_=id;


            List<Corse_modal> data = Staf_Controlar.show_course_Output();
            List<Corse_modal> data2 = new List<Corse_modal>();

            foreach (var item in data)
            {
                if (!string.IsNullOrEmpty(item.status) && item.status.Equals("Active", StringComparison.OrdinalIgnoreCase))
                {
                    data2.Add(item);
                }
            }

            // Bind to ComboBox
            if (data2.Count > 0)
            {
                comboBox1.DataSource = data2;
                comboBox1.DisplayMember = "Name";   // Or "Name", depending on your class
                comboBox1.ValueMember = "Id";
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                comboBox1.DataSource = null;
                MessageBox.Show("No active teachers available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void vew()
        {
            if (ddd!= 0)
            {
                
                int dd = Convert.ToInt32(comboBox1.SelectedValue);
                List<student_modal> data = Staf_Controlar.get_students_by_course(dd);

                dataGridView1.DataSource = data; // You were setting comboBox1.DataSource instead of dataGridView1

                dataGridView1.ClearSelection();

                if (dataGridView1.Columns.Contains("Id"))
                    dataGridView1.Columns["Id"].Visible = false;

                if (dataGridView1.Columns.Contains("status"))
                    dataGridView1.Columns["status"].Visible = false;

                if (dataGridView1.Columns.Contains("corse_id"))
                    dataGridView1.Columns["corse_id"].Visible = false; // Removed extra space in column name

                textBox_name.Clear();
                textBox_nic_number.Clear();
                textBox_Address.Clear();
            }

        }
        private void students_Form_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vew();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["Id"].Value != null)
            {
                //taGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int id_num = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                student_modal data = Staf_Controlar.get_student_by_id(id_num);
                update_id = data.Id;

                if (data != null && data.Id != 0)
                {

                    label6.Visible = true;
                    label7.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;

                    textBox_name.Text = data.Name;
                    textBox_nic_number.Text = Convert.ToString(data.Nic_number);
                    textBox_Address.Text = data.Adderss;
                    label10.Text = data.status;
                }
                else
                {
                    MessageBox.Show("Admin not found.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int dd = Convert.ToInt32(comboBox1.SelectedValue);
            List<student_modal> data = Staf_Controlar.get_students_by_course(dd);

            dataGridView1.DataSource = data; // You were setting comboBox1.DataSource instead of dataGridView1

            dataGridView1.ClearSelection();

            if (dataGridView1.Columns.Contains("Id"))
                dataGridView1.Columns["Id"].Visible = false;

            if (dataGridView1.Columns.Contains("status"))
                dataGridView1.Columns["status"].Visible = false;

            if (dataGridView1.Columns.Contains("corse_id"))
                dataGridView1.Columns["corse_id"].Visible = false; // Removed extra space in column name
            ddd= 1; // Set ddd to 1 to indicate that the data has been loaded
            textBox_name.Clear();
            textBox_nic_number.Clear();
            textBox_Address.Clear();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_name.Text) &&
              !string.IsNullOrWhiteSpace(textBox_Address.Text) &&
              !string.IsNullOrWhiteSpace(textBox_nic_number.Text))
            {
                try
                {
                    // Create and populate student object
                    student_modal data = new student_modal
                    {
                        Name = textBox_name.Text,
                        Nic_number = Convert.ToInt32(textBox_nic_number.Text),
                        status = "Active",
                        corse_id = Convert.ToInt32(comboBox1.SelectedValue),
                        Adderss = textBox_Address.Text
                    };

                    Staf_Controlar.insert_student(data);
                    List<student_modal> students = Staf_Controlar.show_student_Output();

                    if (students.Count > 0)
                    {
                        student_modal student = students[students.Count - 1];
                        label_show.Text=student.Id.ToString();
                        update_id = student.Id; // Update the update_id with the last inserted student's ID

                    }
                    else
                    {
                        MessageBox.Show("No students found.");
                    }
                    textBox_name.Clear();
                    textBox_nic_number.Clear();
                    textBox_Address.Clear();
                    label6.Visible = false;
                    label7.Visible = false;
                    label10.Visible = false;
                    label11.Visible = false;
                    MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (FormatException)
                {
                    MessageBox.Show("NIC number must be numeric.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                //label2.Visible = true;
                label_show.Text = "Complete all details.";
                label_show.ForeColor = Color.Red;
            }
            vew();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_name.Text) ||
            string.IsNullOrWhiteSpace(textBox_nic_number.Text) ||
            string.IsNullOrWhiteSpace(textBox_Address.Text) ||
            comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nicNumber, courseId;
            try
            {
                nicNumber = Convert.ToInt32(textBox_nic_number.Text);
                courseId = Convert.ToInt32(comboBox1.SelectedValue);
            }
            catch
            {
                MessageBox.Show("Invalid NIC number or course selection.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            student_modal data = new student_modal
            {
                Id = update_id,
                Name = textBox_name.Text,
                Nic_number = nicNumber,
                status = "Active",
                corse_id = courseId,
                Adderss = textBox_Address.Text
            };

            Staf_Controlar.update_student(data);

            textBox_name.Clear();
            textBox_nic_number.Clear();
            textBox_Address.Clear();
            label6.Visible = false;
            label7.Visible = false;
            label10.Visible = false;
            label11.Visible = false;

            MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            vew();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            Staf_Controlar.delete_student(update_id);
            Staf_Controlar.delete_user_(update_id);
            vew();
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
            textBox_Address.Text = textBox_Address.Text.Trim();
            try
            {
                int dd = Convert.ToInt32(textBox_nic_number.Text);
            }
            catch (Exception ex)
            {
                textBox_nic_number.Text = "";

            }
        }

        private void textBox_user_name_TextChanged(object sender, EventArgs e)
        {
            textBox_user_name.Text = textBox_user_name.Text.Trim();
           // textBox_user_name.Text = textBox_user_name.Text.Trim();
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

        private void staf_detail_Click(object sender, EventArgs e)
        {
            List<Corse_modal> data = Staf_Controlar.show_course_Output();
            List<Corse_modal> data2 = new List<Corse_modal>();

            foreach (var item in data)
            {
                if (!string.IsNullOrEmpty(item.status) && item.status.Equals("Active", StringComparison.OrdinalIgnoreCase))
                {
                    data2.Add(item);
                }
            }

            // Bind to ComboBox
            if (data2.Count > 0)
            {
                comboBox1.DataSource = data2;
                comboBox1.DisplayMember = "Name";   // Or "Name", depending on your class
                comboBox1.ValueMember = "Id";
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                comboBox1.DataSource = null;
                MessageBox.Show("No active teachers available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Corse_modal> data = Staf_Controlar.show_course_Output();
            List<Corse_modal> data2 = new List<Corse_modal>();

            foreach (var item in data)
            {
                if (!string.IsNullOrEmpty(item.status) && item.status.Equals("Non_Active", StringComparison.OrdinalIgnoreCase))
                {
                    data2.Add(item);
                }
            }

            // Bind to ComboBox
            if (data2.Count > 0)
            {
                comboBox1.DataSource = data2;
                comboBox1.DisplayMember = "Name";   // Or "Name", depending on your class
                comboBox1.ValueMember = "Id";
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                comboBox1.DataSource = null;
                MessageBox.Show("No active teachers available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
