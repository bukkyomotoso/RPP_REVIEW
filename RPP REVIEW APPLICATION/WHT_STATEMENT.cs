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
    public partial class STATEMENT_OF_WHT_SEARCH_POSITION_FORM : Form
    {
        public STATEMENT_OF_WHT_SEARCH_POSITION_FORM()
        {
            InitializeComponent();
        }

        ComputationClass computation = new ComputationClass();
        public static String WHT = "";


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void STATEMENT_OF_WHT_SEARCH_POSITION_FORM_Load(object sender, EventArgs e)
        {
            int year = int.Parse(General_Template.yearOfAssessment);
            textBox2.Text = year.ToString();
            textBox3.Text = (year - 1).ToString();
            textBox4.Text = (year - 2).ToString();
            textBox1.Text = (year - 3).ToString();
           
            textBox12.Text = (year - 4).ToString();
            textBox11.Text = (year - 3).ToString();
            textBox10.Text = (year - 2).ToString();
            textBox9.Text = (year - 1).ToString();

            textBox21.Text = General_Template.turnover;
           textBox5.Text =  (computation.validate(textBox21.Text) - computation.validate(textBox17.Text)).ToString();
           textBox33.Text = General_Templat6.companynamePNJ;
           textBox34.Text = General_Templat6.addressPNJ;
           textBox32.Text = General_Templat6.tinPNJ;

           textBox25.Text = General_Templat6.scheduleOfficer;
           textBox27.Text = General_Templat6.scheduleOfficerRank;
           textBox30.Text = General_Templat6.supervisor;
           textBox28.Text = General_Templat6.supervisorRank;

            

     

        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            string str = textBox17.Text;

            textBox17.Text = computation.commaSeparator(str);

            textBox17.Select(textBox17.Text.Length, 0);
            textBox5.Text = (computation.validate(textBox21.Text) - computation.validate(textBox17.Text)).ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string str = textBox5.Text;

            textBox5.Text = computation.commaSeparator(str);

            textBox5.Select(textBox5.Text.Length, 0);

        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WHT = textBox5.Text;
            CIT_EDT_Computation cit_eit = new CIT_EDT_Computation();
            cit_eit.Show();
        }
    }
}
