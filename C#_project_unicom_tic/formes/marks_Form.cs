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
    public partial class marks_Form : Form
    {
        public int id = 0;
        public int value = 0;
        public int ddd = 0;
        public int student_count = 0;

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

        private void button2_Click(object sender, EventArgs e)
        {
            Exam_modal data =Staf_Controlar.show_exam_(Convert.ToInt32(comboBox2.SelectedValue));
            data.Status = "Non_Active";
            Staf_Controlar.update_exam(data);
        }

        private void add_name_Click(object sender, EventArgs e)
        {
            //label3.Text = "click_addd";
            //value=Convert.ToInt32(label1.Text);    
            if (value != 0)
            {

                label1.Text = Convert.ToString(comboBox1.SelectedValue);
                Exam_modal exam = Staf_Controlar.show_exam_(value);
                //MessageBox.Show("student id", " Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<student_modal> data = Staf_Controlar.get_students_by_course(Convert.ToInt32(comboBox1.SelectedValue));
               // student_modal student1 = data[0];

                if (data.Count > 0)
                {
                    student_modal student = data[0];
                    data.RemoveAt(0);
                    label3.Text = student.Name;

                    if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        marks_modal marks = new marks_modal
                        {
                            Exam_Id = Convert.ToInt32(comboBox2.SelectedValue),                    
                            student_Name = student.Name,
                            exam_marks = Convert.ToInt32(textBox1.Text),
                            student_ID = student.Id
                        };

                        Staf_Controlar.add_marks(marks);
                        
                    }
                    else
                    {
                        label1.Text = "Please enter marks.";
                    }

                    vew();
                }
                else
                {
                   // label3.Text = student1.status;  // corrected typo
                }
            }


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
    }
    
}
