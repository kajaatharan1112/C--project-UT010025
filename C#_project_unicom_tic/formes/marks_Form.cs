using C__project_unicom_tic.controlar;
using C__project_unicom_tic.modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__project_unicom_tic.formes
{
    public partial class marks_Form : Form
    {
        public int id = 0;
        public int value = 0;
        public int ddd = 0;
        public int student_count = 0;
        public int update_id;

        staf_controlar Staf_Controlar;
        marks__controlarClass Marks__Controlar;
        public marks_Form(int id__)
        {
            InitializeComponent();
            id=id__;
            Staf_Controlar=new staf_controlar();
            Marks__Controlar=new marks__controlarClass();


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

            comboBox3.Visible = false;
            textBox1.Visible = false;
            add_name.Visible = false;

            if (id__ >= 500500 && id__ <= 999999)
            {
               button3.Visible = false;
               button5.Visible = false;
            }


        }

        public void vew()
        {
            if (ddd != 0)
            {
                List<marks_modal> data = Marks__Controlar.show_all_marks();
                List<marks_modal> data2 = new List<marks_modal>();
                ddd = 1;

                foreach (marks_modal mark in data)
                {

                    if (Convert.ToInt32(comboBox2.SelectedValue) == mark.Exam_Id)
                    {
                        data2.Add(mark);
                    }
                }

                dataGridView1.DataSource = data2;
                if (dataGridView1.Columns.Contains("student_ID"))
                    dataGridView1.Columns["student_ID"].Visible = false;

                if (dataGridView1.Columns.Contains("Exam_Id"))
                    dataGridView1.Columns["Exam_Id"].Visible = false; 
            }

        }
        private void marks_Form_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<marks_modal> data = Marks__Controlar.show_all_marks();
            List<marks_modal>data2 = new List<marks_modal>();
            ddd = 1;

            foreach (marks_modal mark in data)
            {

                if (Convert.ToInt32(comboBox2.SelectedValue) ==mark.Exam_Id)
                {
                    data2.Add(mark);
                }
            }

            dataGridView1.DataSource = data2;
            if (dataGridView1.Columns.Contains("student_ID"))
                dataGridView1.Columns["student_ID"].Visible = false;

            if (dataGridView1.Columns.Contains("Exam_Id"))
                dataGridView1.Columns["Exam_Id"].Visible = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int value = 0;
            button2.Visible = true;

            if (comboBox1.SelectedValue != null && Convert.ToInt32(comboBox1.SelectedValue) != 0)
            {
                value = Convert.ToInt32(comboBox1.SelectedValue);
                label1.Text = value.ToString();
            }

            if (value > 0)
            {
                List<Exam_modal> data = Staf_Controlar.get_exams_by_course(value);
                List<Exam_modal> data_Active = new List<Exam_modal>();
                List<Exam_modal> data_non_Active = new List<Exam_modal>();

                foreach (Exam_modal exam in data)
                {
                    if (exam.Status == "Active")
                    {
                        data_Active.Add(exam);
                    }
                    else
                    {
                        data_non_Active.Add(exam);
                    }
                }

                // ✅ You can choose either list based on your logic
                comboBox2.DataSource = data_Active; // or use `data_non_Active` or `data`
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int value = 0;
            button2.Visible = false;

            if (comboBox1.SelectedValue != null && Convert.ToInt32(comboBox1.SelectedValue) != 0)
            {
                value = Convert.ToInt32(comboBox1.SelectedValue);
                label1.Text = value.ToString();
            }

            if (value > 0)
            {
                List<Exam_modal> data = Staf_Controlar.get_exams_by_course(value);
                List<Exam_modal> data_Active = new List<Exam_modal>();
                List<Exam_modal> data_non_Active = new List<Exam_modal>();

                foreach (Exam_modal exam in data)
                {
                    if (exam.Status == "Active")
                    {
                        data_Active.Add(exam);
                    }
                    else
                    {
                        data_non_Active.Add(exam);
                    }
                }

                // ✅ You can choose either list based on your logic
                comboBox2.DataSource = data_non_Active; // or use `data_non_Active` or `data`
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            }

        }
        public void mark_student()
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Exam_modal data =Staf_Controlar.show_exam_(Convert.ToInt32(comboBox2.SelectedValue));
            data.Status = "Non_Active";
            Staf_Controlar.update_exam(data);
            add_name.Visible = true;
            button5.Visible = true;


            label1.Text = Convert.ToString(comboBox1.SelectedValue);
            Exam_modal exam = Staf_Controlar.show_exam_(value);
            List<student_modal> data11 = Staf_Controlar.get_students_by_course(Convert.ToInt32(comboBox1.SelectedValue));
            comboBox3.DataSource = data11;
            comboBox3.DisplayMember = "Name"; // Assuming 'Name' is a property in student_modal
            comboBox3.ValueMember = "Id";


            comboBox3.Visible = true;
            textBox1.Visible = true;
            add_name.Visible = true;
        }

        private void add_name_Click(object sender, EventArgs e)
        {



            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                marks_modal marks = new marks_modal
                {
                    Exam_Id = Convert.ToInt32(comboBox2.SelectedValue),
                    student_Name = comboBox3.Text,
                    exam_marks = Convert.ToInt32(textBox1.Text),
                    student_ID = Convert.ToInt32(comboBox3.SelectedValue),
                };

                Staf_Controlar.add_marks(marks);
                vew();
                textBox1.Text = "";
                comboBox3.SelectedIndex = -1; // Clear the selection
                label1.Text = "Marks added successfully!";
            }
            else
            {
                label1.Text = "Please enter marks.";

            }
             vew();
                
                
            


        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int dd = Convert.ToInt32(textBox1.Text);
                textBox1.Text = textBox1.Text.Trim();
            }
            catch(Exception ex)
            {
                textBox1.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int kk = Convert.ToInt32(comboBox2.SelectedValue);
            label2.Text= kk.ToString();
            Staf_Controlar.delete_marks(update_id,kk);
            vew() ;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["student_ID"].Value != null)
            {
                try
                {
                    int update_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["student_ID"].Value);
                    label2.Text = update_id.ToString();





                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid ID value. " + ex.Message);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            vew() ;
        }
    }
    
}
