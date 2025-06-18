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
    public partial class staf_detail_ : Form
    {
        int user_id;
        public staf_detail_(int id)
        {
            user_id = id;
            InitializeComponent();
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
