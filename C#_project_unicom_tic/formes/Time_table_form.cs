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
    public partial class Time_table_form : Form
    {
        public int id;
        public int update_id;
        public Time_table_form(int id_)
        {
            InitializeComponent();
            id = id_;
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
            }
            else
            {
                label3.Text = selectedDate.ToShortDateString();
            }


        }
    }
}
