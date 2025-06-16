using C__project_unicom_tic.controlar;
using C__project_unicom_tic.modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__project_unicom_tic.formes
{
    public partial class admin_update_form : Form
    {
        private admin_controlar Admin_controlar;
        private user_controlar_ User_Controlar_;
       
        public admin_update_form()
        {
            Admin_controlar = new admin_controlar();
            User_Controlar_=new user_controlar_();
            InitializeComponent();
            viw();


            label4.Visible = false;
            textBox_user_name.Visible = false;
            label_user_name.Visible=false;
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
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
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
          /*  Form1 form = new Form1();   
            label_name.Text=Convert.ToString(form.user_id);*/
         
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
                textBox_nic_number.Text = "";
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
            user_modal data3= new user_modal();
            data3.User_id = Convert.ToInt32(label_show.Text);
            data3.Name=textBox_user_name.Text;
            data3.Password = "Admin@123";
            User_Controlar_.add_user(data3);


            textBox_user_name.Text = "";

        }

        private void textBox_user_name_TextChanged(object sender, EventArgs e)
        {
            textBox_user_name.Text=textBox_user_name.Text.Trim();
        }
    }
}
