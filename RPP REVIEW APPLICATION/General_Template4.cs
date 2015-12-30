using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPP_REVIEW_APPLICATION
{
    public partial class General_Template4 : Form
    {
        public General_Template4()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string str= "These are income from activities other than normal business operations, such as: \n\n"+
            
    "rental income and profit from the sale of assets.";
            if (checkBox1.Checked == true)
                
                MessageBox.Show(str,"Note on other Income");
        }

        private void General_Template4_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            string str = "These are income from activities other than normal business operations, such as: \n\n" +

    "rental income and profit from the sale of assets.";
            if (checkBox2.Checked == true)

                MessageBox.Show(str, "Note on other Income");
        }
    }
}
