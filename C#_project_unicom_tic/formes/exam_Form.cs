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
    public partial class exam_Form : Form
    {
        staf_controlar Staf_Controlar;
        public int id;
        public int update_id;
        public int ddd = 0;
        public int TimeTable_id;
        public exam_Form(int id_)
        {
            InitializeComponent();
            id = id_;
            Staf_Controlar = new staf_controlar();





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

        private void vew()
        {
            if (ddd != 0)
            {
                List<Exam_modal> data = Staf_Controlar.show_exam_Output();
                List<Exam_modal> data2 = new List<Exam_modal>();
                foreach (var item in data)
                {
                    if (item.Corse_Id == Convert.ToInt32(comboBox1.SelectedValue) && item.Status == "Active")
                    {
                        data2.Add(item);
                    }
                    
                }
                dataGridView1.DataSource = data2;

                // Hide columns
                if (dataGridView1.Columns.Contains("Id"))
                    dataGridView1.Columns["Id"].Visible = false;

                if (dataGridView1.Columns.Contains("Corse_id"))
                    dataGridView1.Columns["Corse_id"].Visible = false;

                if (dataGridView1.Columns.Contains("status"))
                    dataGridView1.Columns["status"].Visible = false;

                if (dataGridView1.Columns.Contains("time_table_id"))
                    dataGridView1.Columns["time_table_id"].Visible = false;
            }
        }

        private void exam_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            vew();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddd = Convert.ToInt32(comboBox1.SelectedValue);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Please select a valid course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ddd = 0;
            }

            vew();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["Id"].Value != null)
            {
                try
                {
                    update_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    label2.Text = update_id.ToString();



                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid ID value. " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid row with a valid ID.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (update_id != 0)
            {
                try
                {
                    Exam_modal data = Staf_Controlar.show_exam_(update_id);
                    TimeTable_id= data.time_table_id ;
                    label2.Text=TimeTable_id.ToString();//--------------------------------------
                    if (TimeTable_id==0)
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
                        Staf_Controlar.delete_time_table(TimeTable_id);
                    }
                    vew();

                    Staf_Controlar.delete_exam_(update_id);
                    //Staf_Controlar.delete_time_table(TimeTable_id);
                    MessageBox.Show("Exam and related timetable deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Deletion failed: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid IDs. Please select a valid exam and timetable.");
            }

            vew();
        }
    }
}
