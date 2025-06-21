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
        public int id;
        public exam_Form(int id_)
        {
            InitializeComponent();
            id = id_;
        }

        private void exam_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
