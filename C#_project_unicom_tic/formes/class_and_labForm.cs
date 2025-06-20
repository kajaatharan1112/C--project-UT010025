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
    public partial class class_and_labForm : Form
    {
        public int id;
        public int update_id;
        teacher_controlar Teacher_Controlar;
        public class_and_labForm(int id_)
        {
            Teacher_Controlar = new teacher_controlar();
            id = id_;
            InitializeComponent();
            viw();
        }
        private void viw()
        {
            List<class_modal> data1 = Teacher_Controlar.show_class_Output();
            dataGridView1.DataSource = data1;
            dataGridView1.ClearSelection();
            dataGridView1.Columns["Id"].Visible = false;
            textBox_name.Text = "";
        }

        private void class_and_labForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            textBox_name.Text = textBox_name.Text.Trim();

            List<class_modal> existingCourses = Teacher_Controlar.show_class_Output();
            bool nameExists = existingCourses.Any(c => c.name.Equals(textBox_name.Text, StringComparison.OrdinalIgnoreCase));

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

        private void button_add_Click(object sender, EventArgs e)
        {
            class_modal newClass = new class_modal();
            newClass.name = textBox_name.Text.Trim();

            if (string.IsNullOrWhiteSpace(newClass.name))
            {
                MessageBox.Show("Please enter a valid class name.");
                return;
            }

            try
            {
                Teacher_Controlar.add_class(newClass);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding class: {ex.Message}");
            }
            viw();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["Id"].Value != null)
            {
                //taGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int id_num = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                class_modal class_data = Teacher_Controlar.show_class_(id_num);
                update_id = class_data.id;

                if (class_data != null && class_data.id != 0)
                {

                    textBox_name.Text = class_data.name;
                }
                else
                {
                    MessageBox.Show("Admin not found.");
                }
            }

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            class_modal newClass = new class_modal();
            newClass.name = textBox_name.Text.Trim();
            newClass.id = update_id;

            if (string.IsNullOrWhiteSpace(newClass.name))
            {
                MessageBox.Show("Please enter a valid class name.");
                return;
            }

            try
            {
                Teacher_Controlar.update_class(newClass);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding class: {ex.Message}");
            }
            viw();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if(update_id != 0) 
            { Teacher_Controlar.delete_class_(update_id); }
            viw() ;
            
        }
    }
}
