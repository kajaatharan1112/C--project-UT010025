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
    public partial class class_and_labForm : Form
    {
        public int id;
        public int update_id;
        public class_and_labForm(int id_)
        {
            id = id_;
            InitializeComponent();
        }

        private void class_and_labForm_Load(object sender, EventArgs e)
        {

        }
    }
}
