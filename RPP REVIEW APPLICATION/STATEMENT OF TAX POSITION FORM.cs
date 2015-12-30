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
    public partial class STATEMENT_OF_TAX_POSITION_FORM : Form
    {
        public STATEMENT_OF_TAX_POSITION_FORM()
        {
            InitializeComponent();
        }

        private void STATEMENT_OF_TAX_POSITION_FORM_Load(object sender, EventArgs e)
        {

        }

        private void textBox157_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            textBox33.Text = General_Templat6.companynamePNJ;
            textBox34.Text = General_Templat6.addressPNJ;
            textBox32.Text = General_Templat6.tinPNJ;

            textBox275.Text = General_Templat6.scheduleOfficer;
            textBox273.Text = General_Templat6.scheduleOfficerRank;
            textBox272.Text = General_Templat6.supervisor;
            textBox270.Text = General_Templat6.supervisorRank;

        }
    }
}
