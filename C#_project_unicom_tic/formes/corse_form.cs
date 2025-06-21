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
    public partial class corse_form : Form
    {
        staf_controlar Staf_Controlar;
        public int id;
        public int update_id;
        public corse_form(int id_)
        {
            Staf_Controlar = new staf_controlar();
            InitializeComponent();
            id= id_;
            vew(0);

            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;


            button1.Visible = false;  
            button3.Visible = false;
            button5.Visible = false;
            comboBox1.Visible = false;
        }


        private void subject_viw()
        {
            List<teacher_vs_corse_modal> data1 = Staf_Controlar.ShowCourseTeacherOutput();
            List<teacher_vs_corse_modal> data2 = new List<teacher_vs_corse_modal>();
            List<teacher_modl> data3 = new List<teacher_modl>();

            foreach (teacher_vs_corse_modal i in data1)
            {
                if (i.corse_id == update_id)
                {
                    data2.Add(i);
                }
            }

            foreach (teacher_vs_corse_modal i in data2)
            {
                teacher_modl data4 = Staf_Controlar.show_teacher_(i.teacher_id);
                if (data4 != null)
                {
                    data3.Add(data4);
                }
            }

            dataGridView1.DataSource = null;             // Clear old data first
            dataGridView1.DataSource = data3;            // Bind list, not single object
            dataGridView1.ClearSelection();

            if (dataGridView1.Columns.Contains("Id"))
            {
                dataGridView1.Columns["Id"].Visible = false;
            }

            // clear(); // uncomment if needed
        }


        private void vew(int dd)
        {
            List<Corse_modal> data = Staf_Controlar.show_course_Output();
            List<Corse_modal> data_actve = new List<Corse_modal>();
            List<Corse_modal> data_non_active = new List<Corse_modal>();


            foreach (Corse_modal item in data)
            {
                if (item.status == "Non_Active")
                {
                    data_non_active.Add(item);
                }
                else if (item.status == "Active")
                {
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
            textBox_name.Text = string.Empty;
        }

        private void corse_form_Load(object sender, EventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            Corse_modal course = new Corse_modal
            {
                Name = textBox_name.Text.Trim(),
                status = "Active",
                Join_date = DateTime.Now.ToString("yyyy-MM-dd"),
                Out_date = "countnew"
            };

            if (string.IsNullOrWhiteSpace(course.Name))
            {
                MessageBox.Show("Course name is required.");
                textBox_name.Text = string.Empty;
                return;
            }
            else 
            { 
                Staf_Controlar.add_course(course); 
            }
            vew(0);

        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            textBox_name.Text = textBox_name.Text.Trim();

            List<Corse_modal> existingCourses = Staf_Controlar.show_course_Output();
            bool nameExists = existingCourses.Any(c => c.Name.Equals(textBox_name.Text, StringComparison.OrdinalIgnoreCase));

            if (nameExists)
            {
                label_name.Text = "Course name already exists.";
                label_name.ForeColor = Color.Red;
                button_add.Visible = false;
            }
            else
            {
                label_name.Text = "Course name is available.";
                label_name.ForeColor = Color.Green;
                button_add.Visible = true;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["Id"].Value != null)
            {
                int course_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                Corse_modal course_data = Staf_Controlar.show_course(course_id);
                update_id = course_data.Id;

                if (course_data != null && course_data.Id != 0)
                {
                    // Make labels visible if needed
                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;

                    button1.Visible = true;
                    button3.Visible = true;
                    button5.Visible = true;
                    comboBox1.Visible = true;

                    // Populate UI fields
                    // update_id += course_data.Id;
                    textBox_name.Text = course_data.Name;
                    label7.Text = course_data.Join_date;
                    label8.Text = course_data.Out_date;
                    label10.Text = course_data.status;
                }
                else
                {
                    MessageBox.Show("Course not found.");
                }
            }

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_name.Text))
            {
                MessageBox.Show("Course name is required.");
                return;
            }

            Corse_modal course = new Corse_modal
            {
                Id = update_id,
                Name = textBox_name.Text.Trim(),
                status = label10.Text,
                Join_date = label7.Text,
                Out_date = label8.Text
            };

            Staf_Controlar.update_course(course);

            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            vew(0);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_name.Text))
            {
                MessageBox.Show("Course name is required.");
                return;
            }

            Corse_modal course = new Corse_modal
            {
                Id = update_id,
                Name = textBox_name.Text.Trim(),
                status = "Non_Active",
                Join_date = label7.Text,
                Out_date = DateTime.Now.ToString("yyyy-MM-dd")
               
            };

            Staf_Controlar.update_course(course);
            student_controlar data = new student_controlar(); // Ensure this class is not static
            string dd = "Non_Active";
            data.update_student_status_by_course(update_id, dd);


            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            vew(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button_add.Visible = false;
            button_update.Visible = false;
            button_Delete.Visible = false;
            vew(1);
        }

        private void staf_detail_Click(object sender, EventArgs e)
        {
            button_add.Visible = true;
            button_update.Visible = true;
            button_Delete.Visible = true;
            vew(0);

            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;

            button1.Visible = false;
            button3.Visible = false;
            button5.Visible = false;
            comboBox1.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // update_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
            List<teacher_modl> data = Staf_Controlar.show_teacher_Output();
            List<teacher_modl> data2 = new List<teacher_modl>();

            // Filter only Active teachers
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
                comboBox1.DisplayMember = "Subject";   // Or "Name", depending on your class
                comboBox1.ValueMember = "Id";
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                comboBox1.DataSource = null;
                MessageBox.Show("No active teachers available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                teacher_vs_corse_modal data1 = new teacher_vs_corse_modal();
                data1.teacher_id = Convert.ToInt32(comboBox1.SelectedValue);
                data1.corse_id = update_id;

                Staf_Controlar.add_teacher_vs_course(data1);
            }
            else
            {
                MessageBox.Show("Please select a teacher from the list.");
            }
            subject_viw();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            subject_viw();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label_show_Click(object sender, EventArgs e)
        {

        }
    }
}
