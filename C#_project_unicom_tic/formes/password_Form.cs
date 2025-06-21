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
    public partial class password_Form : Form
    {
        public int id;
        public string user_name;
        public string password;
        user_controlar_ User_Controlar_;
        public password_Form(int id_)
        {
            InitializeComponent();
            id = id_;
            User_Controlar_ = new user_controlar_();


            List<user_modal> existingUsers = User_Controlar_.show_user_Output();
            foreach (var user in existingUsers)
            {
                if (user.User_id == id)
                {
                    textBox1.Text = user.Name;
                    textBox2.Text = user.Password;
                    textBox3.Text = user.Password;
                    user_name = user.Name;
                    password = user.Password;
                    //button1.Visible = false; // Disable button if user already exists
                    break;
                }
            }
        }

        private void password_Form_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Trim();
            //xtBox_user_name.Text = textBox_user_name.Text.Trim();
            List<user_modal> existingUsers = User_Controlar_.show_user_Output();
            bool nameExists = existingUsers.Any(u => u.Name.Equals(textBox1.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            if (nameExists)
            {
                label1.Text = "User name already exists.";
                label1.ForeColor = Color.Red;
                button1.Visible = false;
             
            }
            else
            {
                label1.Text = "User name is available.";
                label1.ForeColor = Color.Green;
                button1.Visible = true;
                user_name = textBox1.Text.Trim();

            }
            textBox1.Text= textBox1.Text.Trim();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.Trim();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.Trim();
            if (textBox2.Text != textBox3.Text)
            {
                label2.Text = "Passwords do not match.";
                label2.ForeColor = Color.Red;
                

                if(user_name == textBox3.Text.Trim())
                {
                    label2.Text = "Passwords match but user name is the same as password.";
                    label2.ForeColor = Color.Orange;
                    button1.Visible = true;
                }
                else
                {
                    button1.Visible = false;
                }

            }
            else
            {
                label2.Text = "Passwords match.";
                label2.ForeColor = Color.Green;
                button1.Visible = true;
                password = textBox3.Text.Trim();
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(user_name) && !string.IsNullOrWhiteSpace(password))
            {
                user_modal data = new user_modal
                {
                    User_id = id,
                    Name = user_name.Trim(),
                    Password = password.Trim()
                };

                User_Controlar_.Update_User(data);
            }
            else
            {
                MessageBox.Show("Username and password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
