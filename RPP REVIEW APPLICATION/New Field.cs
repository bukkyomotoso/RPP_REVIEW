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
    public partial class New_Field : Form
    {
        public New_Field()
        {
            InitializeComponent();
        }

        public static string additionalfield = "";
        private void New_Field_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxAdditional_SelectedIndexChanged(object sender, EventArgs e)
        {
            additionalfield = comboBoxAdditional.SelectedText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CIT_EDT_Computation cit_edt = new CIT_EDT_Computation();
            if (comboBoxAdditional.Text == "")
                MessageBox.Show("Please select the field you want to add","Error adding field",MessageBoxButtons.OK,MessageBoxIcon.Error);
            additionalfield = comboBoxAdditional.SelectedText;
            this.Close();
            
        }
    }
}
