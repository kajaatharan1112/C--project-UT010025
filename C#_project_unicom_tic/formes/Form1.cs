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
        public Form1()
        {
            InitializeComponent();
            login_form_ form= new login_form_();
            LoadForm_1(form);
            /*buttion_Form data= new buttion_Form();
            LoadForm_2(data); */  
            
        }
        public void call()
        {
            buttion_Form data= new buttion_Form();
            LoadForm_2(data);
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
            if (this.panel4.Controls.Count == 0)
            {
                this.panel3.Controls.RemoveAt(0);
                Form form = formObj as Form;
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                this.panel3.Controls.Add(form);
                this.panel3.Tag = form;
                form.Show();
            }

            
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
            buttion_Form data = new buttion_Form();
            LoadForm_2(data);

        }
    }
}
