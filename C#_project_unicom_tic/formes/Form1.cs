//using C__project_unicom_tic.formes;
using C__project_unicom_tic.formes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace C__project_unicom_tic
{
    public partial class Form1 : Form
    {
        public int user_id = 000001;
        public string Date = DateTime.Now.ToString("yyyy-MM-dd");
        public Form1()
        {
            InitializeComponent();
            /*buttion_Form data= new buttion_Form();
            LoadForm_2(data); */

            pictureBox1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            label1.Text = Date;

        }
        

        public void LoadForm_1(object formObj)
        {
            if (this.panel4.Controls.Count > 0)
            {
                this.panel4.Controls.RemoveAt(0);
            }

            Form form = formObj as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel4.Controls.Add(form);
            this.panel4.Tag = form;
            form.Show();
        }
        public void LoadForm_2(object formObj)
        {
            if (this.panel3.Controls.Count>0)
            {
                this.panel3.Controls.RemoveAt(0); 
            }
            Form form = formObj as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(form);
            this.panel3.Tag = form;
            form.Show();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            //--------------------------------
            textBox1.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            button2.Visible = false;
            User_name.Visible = false;
            Password.Visible = false;
            pictureBox2.Visible = false;
            //--------------------------------
            pictureBox1.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            //------------------------------
        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void User_name_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            admin_update_form data = new admin_update_form();
            LoadForm_1(data);
            

            
            
        }
    }
}
