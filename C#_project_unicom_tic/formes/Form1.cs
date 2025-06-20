//using C__project_unicom_tic.formes;
using C__project_unicom_tic.controlar;
using C__project_unicom_tic.formes;
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


namespace C__project_unicom_tic
{
    public partial class Form1 : Form
    {
        user_controlar_ User_Controlar_;

        public int user_id = 000001;
        public string Date = DateTime.Now.ToString("yyyy-MM-dd");
        public int ROOL_ID = 0;
        public Form1()
        {
            User_Controlar_ = new user_controlar_();    

            InitializeComponent();
            /*buttion_Form data= new buttion_Form();
            LoadForm_2(data); */

            pictureBox1.Visible = false;
            button3.Visible = false;
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
            //label1.Text = Date;

        }
        

        public void LoadForm_1(object formObj)
        {
            if (this.panel4.Controls.Count > 0)
            {
                panel4.Controls.Clear();
            }
            Form form = formObj as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel4.Controls.Add(form);
            this.panel4.Tag = form;
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
           

            List<user_modal>data= new List<user_modal>();
            data = User_Controlar_.show_user_Output();
            foreach (user_modal item in data)
            {
                if (item.Name == textBox1.Text && item.Password == textBox2.Text)
                {
                    int rool_id=item.User_id;
                    label4.Text= Convert.ToString(rool_id);
                    ROOL_ID = rool_id;
                    //MessageBox.Show(Convert.ToString(ROOL_ID), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    if (rool_id >=100000 && rool_id<=100050)
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







                }
                else
                {
                    label1.Text = "invalide input";
                }
            }
           
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
            admin_update_form data = new admin_update_form(ROOL_ID);
            LoadForm_1(data);
            

            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text=textBox1.Text.Trim();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.Trim();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label4.Text = label4.Text.Trim();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            staf_detail_ data = new staf_detail_(ROOL_ID);
            LoadForm_1(data);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            teacher_detail_form teacher_Detail_Form = new teacher_detail_form(ROOL_ID);
            LoadForm_1(teacher_Detail_Form);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            corse_form corse_Form = new corse_form(ROOL_ID);
            LoadForm_1(corse_Form);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            class_and_labForm class_And_LabForm = new class_and_labForm(ROOL_ID);
            LoadForm_1(class_And_LabForm);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Time_table_form time_Table_Form = new Time_table_form(ROOL_ID);
            LoadForm_1(time_Table_Form);
        }
    }
}
