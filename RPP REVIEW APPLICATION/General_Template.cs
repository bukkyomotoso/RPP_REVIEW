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
    public partial class General_Template : Form
    {
        public General_Template()
        {
            InitializeComponent();
        }

        //RPPCLASS rppclass = new RPPCLASS();
        ComputationClass computation = new ComputationClass();
        
        public static String comp1 = "";
        public static String year = "";
        public static String turnover = "";
        public static String trnover = "";
        public static String PBF = "";
        public static String grossprofit = "";
        public static String netasset = "";
        public static String sharedcapital = "";
        public static String  otherinc= "";
        public static String revdate = "";
        public static String refno1 = "";
        public static String tin1 = "";
        public static String dtpicker1 = "";

        public static String company ="";
        public static String tin = "";
        public static String Ref ="";
        public static String reviewdate = "";
        public static String costofsales = "";
        public static String percentcostsales = "";
        public static String donation = "";
        public static String totalProfit = "";
        public static String yearOfAssessment = "";
      
       
        
        private void button1_Click(object sender, EventArgs e)
        {
            year = assessmentlabel.Text;
            comp1 = companytext.Text;
            netasset = netAssettext.Text;
            turnover = turnovertext.Text;
            otherinc = otherIncomeText.Text;
            grossprofit = grossprofittext.Text;
            sharedcapital = sharedcapitaltext.Text;
            costofsales = costSalesText.Text;
           

            String coy = companytext.Text;
            Minimum_Tax mintax = new Minimum_Tax();
            mintax.Show();
           mintax.getValues();
           // MessageBox.Show(commaSeparator("300.123"));
        }
        
       

       

        private void turnovertext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46 )
	        e.Handled = true;
	    if (e.KeyChar == 46)
	    {
            if ((sender as TextBox).Text.Contains("."))
            {

                e.Handled = true;
            }
	    }
        }

        private void costSalesText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void grossprofittext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void otherIncomeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void netAssettext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void sharedcapitaltext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string str = textBox5.Text;

            textBox5.Text = computation.commaSeparator(str);
            textBox5.Select(textBox5.Text.Length, 0);
            //textBox5.Select(textBox5.TextLength);
        }

        private void costSalesText_TextChanged_1(object sender, EventArgs e)
        {
                string str = costSalesText.Text;

            costSalesText.Text = computation. commaSeparator(str);
           costSalesText.Select(costSalesText.Text.Length, 0);
            double res = (computation.validate(turnovertext.Text) - computation.validate(costSalesText.Text));
            String res1 = res.ToString();
            grossprofittext.Text = computation. commaSeparator(res1);
        }
        
       
        private void turnovertext_TextChanged(object sender, EventArgs e)
        {
            string str = turnovertext.Text;
            
            turnovertext.Text = computation. commaSeparator(str);
            
            turnovertext.Select(turnovertext.Text.Length, 0);
            String res1 = (computation.validate(turnovertext.Text) - computation.validate(costSalesText.Text)).ToString();
            grossprofittext.Text = computation. commaSeparator(res1).ToString();

            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            company = companytext.Text;
            tin = TINtext.Text;
            Ref = Reftext.Text;
            reviewdate = dateTimePicker1.Value.ToString("d-MM-yyyy");
            comp1 = companytext.Text;
            //revdate = 
            refno1 = Reftext.Text;
            tin1 = TINtext.Text;
            dtpicker1 = dateTimePicker1.Value.ToString("d-MM-yyyy");
            PBF = textBox19.Text;
            costofsales = costSalesText.Text;
            turnover = turnovertext.Text;
            donation = textBox7.Text;

            
           General_Template2 gen_template2 = new General_Template2();
            gen_template2.Show();
        }

       /* private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

            reviewDatetext.Text = monthCalendar1.SelectionRange.ToString();
        }*/

        private void General_Template_Load(object sender, EventArgs e)
        {
            assessmentYear.Text = System.DateTime.Now.Year.ToString();
            yearOfAssessment = assessmentYear.Text;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MMM-yyyy";
            
            companytext.Text = General_Templat6.companynamePNJ;
            TINtext.Text = General_Templat6.tinPNJ;

        }

        

        private void otherIncomeText_TextChanged(object sender, EventArgs e)
        {
            string str = otherIncomeText.Text;

            otherIncomeText.Text = computation. commaSeparator(str);

            otherIncomeText.Select(otherIncomeText.Text.Length, 0);
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            string str = textBox17.Text;

            textBox17.Text = computation. commaSeparator(str);

            textBox17.Select(textBox17.Text.Length, 0);
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            string str = textBox16.Text;

            textBox16.Text = computation. commaSeparator(str);

            textBox16.Select(textBox16.Text.Length, 0);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string str = textBox7.Text;

            textBox7.Text = computation. commaSeparator(str);

            textBox7.Select(textBox7.Text.Length, 0);
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            string str = textBox18.Text;

            textBox18.Text = computation. commaSeparator(str);

            textBox18.Select(textBox18.Text.Length, 0);
            
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            string str = textBox19.Text;

            textBox19.Text = computation.commaSeparator(str);

            textBox19.Select(textBox19.Text.Length, 0);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            string str = textBox9.Text;

            textBox9.Text = computation. commaSeparator(str);

            textBox9.Select(textBox9.Text.Length, 0);
            
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            string str = textBox20.Text;

            textBox20.Text = computation. commaSeparator(str);

            textBox20.Select(textBox20.Text.Length, 0);
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            string str = textBox15.Text;

            textBox15.Text = computation. commaSeparator(str);

            textBox15.Select(textBox15.Text.Length, 0);
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            string str = textBox13.Text;

            textBox13.Text = computation. commaSeparator(str);

            textBox13.Select(textBox13.Text.Length, 0);
        }

        private void netAssettext_TextChanged(object sender, EventArgs e)
        {
            string str = netAssettext.Text;

            netAssettext.Text = computation. commaSeparator(str);

            netAssettext.Select(netAssettext.Text.Length, 0);
        }

        private void sharedcapitaltext_TextChanged(object sender, EventArgs e)
        {
            string str = sharedcapitaltext.Text;

            sharedcapitaltext.Text = computation. commaSeparator(str);

            sharedcapitaltext.Select(sharedcapitaltext.Text.Length, 0);
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            string str = textBox22.Text;

            textBox22.Text = computation. commaSeparator(str);

            textBox22.Select(textBox22.Text.Length, 0);
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            string str = textBox21.Text;

            textBox21.Text = computation. commaSeparator(str);

            textBox21.Select(textBox21.Text.Length, 0);
        }

        private void grossprofittext_TextChanged(object sender, EventArgs e)
        {
            string str = grossprofittext.Text;

            grossprofittext.Text = computation. commaSeparator(str);

            grossprofittext.Select(grossprofittext.Text.Length, 0);
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57 ) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void netAssettext_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void sharedcapitaltext_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TINtext_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TINtext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void TINtext_Leave(object sender, EventArgs e)
        {
            if (TINtext.TextLength != 13)
                MessageBox.Show("Please, enter a valid 13 character TIN");
        }

        private void General_Template_Leave(object sender, EventArgs e)
        {

        }

        private void turnovertext_Leave(object sender, EventArgs e)
        {
           //turnovertext.Text= computation.roundoff(turnovertext.Text);
        }

        private void Previousbutton_Click(object sender, EventArgs e)
        {
           // General_Templat6 gentemp = new General_Templat6();
           // gentemp.Show();
            
        }

        private void CIT_EITbutton_Click(object sender, EventArgs e)
        {
           /* CIT_EDT_Computation cit_eit = new CIT_EDT_Computation();
            company = companytext.Text;
            tin=TINtext.Text;
            Ref = Reftext.Text;
            costofsales = costSalesText.Text;
            turnover = turnovertext.Text;
            percentcostsales = (computation.validate(costofsales) / computation.validate(turnover) * 100).ToString();
            cit_eit.Show();*/
        }

        private void General_Template_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void WHT_Form_Click(object sender, EventArgs e)
        {
            turnover = turnovertext.Text;
            STATEMENT_OF_WHT_SEARCH_POSITION_FORM whtForm = new STATEMENT_OF_WHT_SEARCH_POSITION_FORM();
            whtForm.Show();
        }

       

        
        

        

        

       
       
    }
}
