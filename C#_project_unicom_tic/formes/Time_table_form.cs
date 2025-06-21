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
using static System.Windows.Forms.LinkLabel;

namespace C__project_unicom_tic.formes
{
    public partial class Time_table_form : Form
    {
        public int id;
        public int update_id;
        public string date;
        staf_controlar Staf_Controlar;
        public Time_table_form(int id_)
        {
            Staf_Controlar = new staf_controlar();
            InitializeComponent();
            id = id_;
            re_fresh();




            // add cors in combo box

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
        public void re_fresh()
        {

            //label1.Text= comboBox1.Text;
            //set teacher
            //
            List<teacher_vs_corse_modal> data3 = Staf_Controlar.ShowCourseTeacherOutput();
            List<teacher_vs_corse_modal> data4 = new List<teacher_vs_corse_modal>();
            List<teacher_modl> data5 = new List<teacher_modl>();

            int selectedCourseId = Convert.ToInt32(comboBox1.SelectedValue);

            foreach (var item in data3)
            {
                if (item.corse_id == selectedCourseId)
                {
                    data4.Add(item);
                }
            }
            foreach (var item in data4)
            {
                teacher_modl teacher = Staf_Controlar.show_teacher_(item.teacher_id);
                if (teacher.status== "Active")
                {
                    data5.Add(teacher);
                }
            }
            comboBox4.DataSource = data5;
            comboBox4.DisplayMember = "Name";   // Or "Name", depending on your class
            comboBox4.ValueMember = "Id";
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;




            // time lap
            List<string> time_lap = new List<string>() { "[9.00-10.30]", "[10.30-12.00]","[BREAK]","[1.00-2.30]","[2.30-4.00]","[holley day]"};
            List<string> time_lap_update = new List<string>();
            time_lap_update = time_lap;
            comboBox2.DataSource = time_lap_update;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;


            //class
            List<class_modal>class_data= Staf_Controlar.show_class_Output();
            List<class_modal> class_data2 = new List<class_modal>();
            class_data2 = class_data;
            comboBox3.DataSource = class_data2;
            comboBox3.DisplayMember = "Name";
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        public void clear()
        {
            //textBox1.Text = string.Empty;
           // textBox2.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            monthCalendar1.SetDate(DateTime.Today);
            label3.Text = "Select a date";
            dataGridView1.DataSource = null;

        }
        public void vew()
        {
            int courseId = 0;

            if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int parsedId))
            {
                courseId = parsedId;
                List<Time_table_modal> data = Staf_Controlar.Get_TimeTable_By_Date_And_Course(date, courseId);

                dataGridView1.DataSource = data;

                // Hide columns
                if (dataGridView1.Columns.Contains("Id"))
                    dataGridView1.Columns["Id"].Visible = false;

                if (dataGridView1.Columns.Contains("Corse_id"))
                    dataGridView1.Columns["Corse_id"].Visible = false;

                if (dataGridView1.Columns.Contains("status"))
                    dataGridView1.Columns["status"].Visible = false;
            }
            else
            {
                MessageBox.Show("Please select a valid course.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            re_fresh();
        }

        private void Time_table_form_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
            DateTime today = DateTime.Today;

            if (selectedDate < today)
            {
                label3.Text = "Please select today or a future date.";
                date = selectedDate.ToShortDateString();

                comboBox4.Visible= false;
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                button_update.Visible = false;
                button_add.Visible = false;
                button_Delete.Visible = false;
                label3.Text = date;
                vew(); // Refresh the view to show no data for past dates

                // Hide the button if the date is in the past  
            }
            else
            {
                label3.Text = selectedDate.ToShortDateString();
                date = selectedDate.ToShortDateString();
                button1.Visible = true;
                comboBox4.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                button_update.Visible = true;
                button_add.Visible = true;
                button_Delete.Visible = true;
                label3.Text = date;
                vew(); // Refresh the view to show data for the selected date
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            vew();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["Id"].Value != null)
            {
                update_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                // Optionally display or use id_num here
               // MessageBox.Show("Selected Id: " + update_id);
               Time_table_modal data = Staf_Controlar.get_time_table_by_id(update_id);
                if (data != null)
                {
                    comboBox1.SelectedValue = data.Corse_id;
                    comboBox4.Text = data.Teacher;
                    comboBox2.Text = data.Time_lap;
                    comboBox3.Text = data.class_name;
                    date = data.Date;
                    monthCalendar1.SetDate(DateTime.Parse(date)); // Set the calendar to the selected date
                    label3.Text = date; // Update the label to show the selected date
                }
                else
                {
                    MessageBox.Show("No data found for the selected ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        

    }

        private void button_add_Click(object sender, EventArgs e)
        {
            // Optional validation before object creation
            if (comboBox1.SelectedValue == null || comboBox4.SelectedIndex == -1 ||
                comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || string.IsNullOrWhiteSpace(date))
            {
                MessageBox.Show("Please fill all fields correctly.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Time_table_modal time_Table = new Time_table_modal
            {
                Date = date,
                Teacher = comboBox4.Text,
                Corse_id = Convert.ToInt32(comboBox1.SelectedValue),
                Time_lap = comboBox2.Text,
                class_name = comboBox3.Text,
                status = "Active"
            };
            Staf_Controlar.add_time_table(time_Table);
            vew();

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            // Optional validation before object creation
            if (comboBox1.SelectedValue == null || comboBox4.SelectedIndex == -1 ||
                comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || string.IsNullOrWhiteSpace(date))
            {
                MessageBox.Show("Please fill all fields correctly.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Time_table_modal time_Table = new Time_table_modal
            {
                Id = update_id, // Ensure you set the ID for updating
                Date = date,
                Teacher = comboBox4.Text,
                Corse_id = Convert.ToInt32(comboBox1.SelectedValue),
                Time_lap = comboBox2.Text,
                class_name = comboBox3.Text,
                status = "Active"
            };
            //Staf_Controlar.add_time_table(time_Table);
            Staf_Controlar.update_time_table(time_Table);
            vew();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (update_id <= 0)
            {
                MessageBox.Show("Please select a valid record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure you want to delete this time table entry?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                Staf_Controlar.delete_time_table(update_id);
            }
            vew();
        }
    }
}
