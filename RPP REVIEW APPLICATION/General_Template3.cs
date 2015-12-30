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
    public partial class General_Template3 : Form
    {
        public General_Template3()
        {
            InitializeComponent();
        }
        public static String company = "";
        public static String TotCIT = "";
        public static String tin = "";
        public static String Ref = "";
        public static String reviewdate = "";
        public static String assess_profit = "";
        public static String costofsales = "";
        public static String percentcostsales = "";
        public static String turnover = "";
        public static String tpselfassess = "";
        public static String totalAssessibleProfit = "";
        public static String tpRpp = "";
        public static String tpTaxAud = "";
        public static String citSelfAssess = "";
        public static String citRPP = "";
        public static String citTaxAud = "";
        public static String totalCITText = "";

        //double adjusted = 0.0;

        ComputationClass computation = new ComputationClass();
        private void General_Template3_Load(object sender, EventArgs e)
        {
            companytext.Text = General_Template.company;
            TINtext.Text = General_Template.tin;
            reviewDatetext.Text = General_Template.reviewdate;
            Reftext.Text = General_Template.Ref;
            turnover = General_Template.turnover;
            costofsales = General_Template.costofsales; 

            if (computation.validate( General_Template.turnover) > 100000000)
                nitdefpayable.Text = computation.commaSeparator((0.01 * computation.validate ( General_Template.PBF)).ToString());
           
        }
        private void TPRPPText_TextChanged(object sender, EventArgs e)
        {
            string str = TPRPPText.Text;

            TPRPPText.Text = computation.commaSeparator(str);

            TPRPPText.Select(TPRPPText.Text.Length, 0);
            
            double citpaid = 0;
           

            citpaid = (computation.validate(TPRPPText.Text)* 0.020) - computation.validate(CITselfassesText.Text);

            if (citpaid >= 0)
                CITRPPText.Text = computation.commaSeparator( citpaid.ToString());
            //else
                //CITRPPText.Text = citpaid.ToString();


            double citpaid1 = 0;


            citpaid1 = (computation.validate(TPselfassessText.Text) * 0.020);
            if (citpaid1 >= 0)
                CITselfassesText.Text = computation.commaSeparator( citpaid1.ToString());
            //else
               // CITselfassesText.Text = citpaid1.ToString();

            double citpaid2 = 0;
           
                citpaid2 = (computation.validate(TPTaxAudText.Text) * 0.020) - 
                    computation.validate(  CITRPPText.Text) + computation.validate(  CITselfassesText.Text);
            if (citpaid2 >0 && TPTaxAudText.Text != "")
                CITTaxAudText.Text =  computation.commaSeparator( citpaid2.ToString());
            //else
                //CITTaxAudText.Text = citpaid2.ToString();

                TPAssesment.Text =computation.commaSeparator( (Math.Max(Math.Max(computation.validate(TPselfassessText.Text), 
                    computation.validate(  TPRPPText.Text)), computation.validate( TPTaxAudText.Text))).ToString());

        }

        private void TPTaxAudText_TextChanged(object sender, EventArgs e)
        {
            string str = TPTaxAudText.Text;

            TPTaxAudText.Text = computation.commaSeparator(str);

            TPTaxAudText.Select(TPTaxAudText.Text.Length, 0);
            
            double citpaid = 0;
            
                    citpaid = (computation.validate( TPRPPText.Text) * 0.020) - computation.validate( CITselfassesText.Text);
             
            if (citpaid >= 0)
                CITRPPText.Text = computation.commaSeparator( citpaid.ToString());

            double citpaid1 = 0;
            citpaid1 = computation.validate( TPselfassessText.Text) * 0.020;
            if (citpaid1 >= 0)
                CITselfassesText.Text = citpaid1.ToString();  

            //else
                //CITselfassesText.Text = citpaid1.ToString();

            double citpaid2 = 0;
                citpaid2 = (computation.validate( TPTaxAudText.Text) * 0.020) - 
                    computation.validate(  CITRPPText.Text) + computation.validate(  CITselfassesText.Text);
            if (citpaid2 > 0)
                CITTaxAudText.Text = citpaid2.ToString();
                
            //else
              //  CITTaxAudText.Text = citpaid2.ToString();
                TPAssesment.Text = (Math.Max(Math.Max(computation.validate( TPselfassessText.Text),
                    computation.validate( TPRPPText.Text)), computation.validate( TPTaxAudText.Text)).ToString());

        }

        private void TPAssesment_TextChanged(object sender, EventArgs e)
        {
            string str = TPAssesment.Text;

            TPAssesment.Text = computation.commaSeparator(str);

            TPAssesment.Select(TPAssesment.Text.Length, 0);
            double citpaid = 0;

                    citpaid = ((computation.validate(  TPRPPText.Text) * 0.020) - computation.validate(CITselfassesText.Text));
            
            if (citpaid >= 0)
                CITRPPText.Text = computation.commaSeparator( citpaid.ToString());

            //else
               // CITRPPText.Text = citpaid.ToString();


            double citpaid1 = 0;
            citpaid1 = (computation.validate(TPselfassessText.Text) * 0.020);
            if (citpaid1 >= 0)
                CITselfassesText.Text = computation.commaSeparator( citpaid1.ToString());
             
           // else
                //CITselfassesText.Text = citpaid1.ToString();

            double citpaid2 = 0;
                citpaid2 = (computation.validate (TPTaxAudText.Text) * 0.020) - (computation.validate(CITRPPText.Text) + 
                    computation.validate(CITselfassesText.Text));
            if (citpaid2 >= 0 && TPTaxAudText.Text != "")
                CITTaxAudText.Text =computation.commaSeparator(  citpaid2.ToString());

            //else
               // CITTaxAudText.Text = citpaid2.ToString();

           
               str = computation.commaSeparator( (Math.Max(Math.Max(computation.validate(TPselfassessText.Text), computation.validate(TPRPPText.Text)),
                    computation.validate(TPTaxAudText.Text)).ToString()));
               TPAssesment.Text = str;

        }

        private void CITselfassesText_TextChanged(object sender, EventArgs e)
        {
            string str = CITselfassesText.Text;

            CITselfassesText.Text = computation.commaSeparator(str);

            CITselfassesText.Select(CITselfassesText.Text.Length, 0);
            
            
            //string str = CITselfassesText.Text;
            double citpaid = 0;
            
                    citpaid = (computation.validate(TPRPPText.Text) * 0.020) - computation.validate(CITselfassesText.Text);
                
                
            
            if (citpaid >= 0)
                CITRPPText.Text = computation.commaSeparator( citpaid.ToString());

           // else
                //CITRPPText.Text = citpaid.ToString();


            double citpaid1 = 0;
            citpaid1 = (computation.validate(TPselfassessText.Text) * 0.020);
            if (citpaid1 >= 0)
            {
                str = citpaid1.ToString();
                CITselfassesText.Text = computation.commaSeparator(str);
            }

            //else
               // CITselfassesText.Text = citpaid1.ToString();

            double citpaid2 = 0;
                citpaid2 = (computation.validate(TPTaxAudText.Text) * 0.020) - (computation.validate(CITRPPText.Text) +
                    computation.validate(CITselfassesText.Text));
            if (citpaid2 > 0 && TPTaxAudText.Text != "")
                CITTaxAudText.Text = computation.commaSeparator( citpaid2.ToString());
               
            //else
                //CITTaxAudText.Text = citpaid2.ToString();
                TPAssesment.Text = computation.commaSeparator( (Math.Max(Math.Max(computation.validate(TPselfassessText.Text), 
                    computation.validate(TPRPPText.Text)), computation.validate(TPTaxAudText.Text))).ToString());

           
                
                    //CashText.Text = (Double.Parse(CITselfassesText.Text) - double.Parse(WHTText.Text)).ToString();
                    TotCITText.Text = computation.commaSeparator( (computation.validate(CITselfassesText.Text) + computation.validate(CITTaxAudText.Text) + 
                        computation.validate(CITRPPText.Text)).ToString());
                

        }

        private void CITRPPText_TextChanged(object sender, EventArgs e)
        {
            string str = CITRPPText.Text;

            CITRPPText.Text = computation.commaSeparator(str);

            CITRPPText.Select(CITRPPText.Text.Length, 0);
            double citpaid = 0;
            
                    citpaid = (computation.validate(TPRPPText.Text) * 0.020) - computation.validate(CITselfassesText.Text);
                
            
            if (citpaid >= 0)
                CITRPPText.Text = computation.commaSeparator( citpaid.ToString());
           // else
               // CITRPPText.Text = citpaid.ToString();


            double citpaid1 = 0;
            citpaid1 = (computation.validate(TPselfassessText.Text) * 0.020);
            if (citpaid1 >= 0)
                CITselfassesText.Text = computation.commaSeparator( citpaid1.ToString());
           // else
               // CITselfassesText.Text = citpaid1.ToString();

            double citpaid2 = 0;
           citpaid2 = (computation.validate(TPTaxAudText.Text) * 0.020) - (computation.validate(CITRPPText.Text) + 
               computation.validate(CITselfassesText.Text));
            if (citpaid2 >= 0 && TPTaxAudText.Text != "")
                CITTaxAudText.Text = computation.commaSeparator( citpaid2.ToString());
            //else
                //CITTaxAudText.Text = citpaid2.ToString();
                TPAssesment.Text = computation.commaSeparator( (Math.Max(Math.Max(computation.validate(TPselfassessText.Text), 
                    computation.validate(TPRPPText.Text)), computation.validate(TPTaxAudText.Text))).ToString());

    TotCITText.Text = computation.commaSeparator( (computation.validate(CITselfassesText.Text) + computation.validate(CITTaxAudText.Text) 
        + computation.validate(CITRPPText.Text)).ToString());

        }

        private void CITTaxAudText_TextChanged(object sender, EventArgs e)
        {
            string str = CITTaxAudText.Text;

            CITTaxAudText.Text = computation.commaSeparator(str);

            CITTaxAudText.Select(CITTaxAudText.Text.Length, 0);
            TotCITText.Text = computation.commaSeparator( (computation.validate (CITselfassesText.Text) + computation.validate(CITTaxAudText.Text) 
                + computation.validate(CITRPPText.Text)).ToString());

        }

        

        private void TPselfassessText_TextChanged(object sender, EventArgs e)
        {
            
            string str = TPselfassessText.Text;

            TPselfassessText.Text = computation.commaSeparator(str);

            TPselfassessText.Select(TPselfassessText.Text.Length, 0);

            double citpaid = 0;
                    citpaid = (computation.validate(TPRPPText.Text) * 0.020) - computation.validate(CITselfassesText.Text);

            if (citpaid >= 0)
                CITRPPText.Text = computation.commaSeparator( citpaid.ToString());

           // else
                //CITRPPText.Text = citpaid.ToString();


            double citpaid1 = 0;
                citpaid1 = computation.validate(TPselfassessText.Text) * 0.020;
            if (citpaid1 >= 0)
                CITselfassesText.Text = computation.commaSeparator( citpaid1.ToString());
           // else
               // CITselfassesText.Text = citpaid1.ToString();

            double citpaid2 = 0;
                citpaid2 =  (computation.validate(TPTaxAudText.Text) * 0.020) - 
                    (computation.validate(CITRPPText.Text) + computation.validate(CITselfassesText.Text));
            if (citpaid2 >= 0 && TPTaxAudText.Text !="")
                CITTaxAudText.Text = computation.commaSeparator( citpaid2.ToString());
            //else
               // CITTaxAudText.Text = citpaid2.ToString();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string str = "Companies and enterprises with an annual turnover of N100,000,000.00 and above operating as:\n\n" +

"•  GSM Service Providers or telecommunications companies;\n\n" +
"•  Cyber companies and internet providers;\n\n" +
"•  Pensions managers and pension related companies;\n\n" +
"•  Banks and other financial institutions;\n\n" +
"•  Insurance companies;\n\n" +

"A company shall compute 1% of the profit before tax of each year of assessment.\n\n" +

"Such levy paid by the companies shall be tax deductable.\n\n" +

"THE NATIONAL INFORMATION TECHNOLOGY DEVELOPMENT AGENCY ACT 2007\n\n" +
"Oluwole O. Oni:";
            if (checkBox1.Checked == true)
                MessageBox.Show(str, "Note on NITDEF");
        }

       
        private void nitdefpaid_TextChanged(object sender, EventArgs e)
        {
            string str = nitdefpaid.Text;

            nitdefpaid.Text = computation.commaSeparator(str);

            nitdefpaid.Select(nitdefpaid.Text.Length, 0);

                nitdefliability.Text = computation.commaSeparator( (computation.validate(nitdefpayable.Text) 
                    - computation.validate(nitdefpaid.Text)).ToString());
            
               
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            
            totalAssessibleProfit = TPAssesment.Text;
            General_Template4 gentemplate4 = new General_Template4();
            gentemplate4.Show();
        }

        private void TPselfassessText_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TPRPPText_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TPTaxAudText_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TPAssesment_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CITselfassesText_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CITRPPText_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CITTaxAudText_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TotCITText_KeyPress(object sender, KeyPressEventArgs e)
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

        private void nitdefpayable_KeyPress(object sender, KeyPressEventArgs e)
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

        private void nitdefpaid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void nitdefliability_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string str = textBox3.Text;

            textBox3.Text = computation.commaSeparator(str);

            textBox3.Select(textBox3.Text.Length, 0);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void TotCITText_TextChanged(object sender, EventArgs e)
        {
            string str = TotCITText.Text;

            TotCITText.Text = computation.commaSeparator(str);

            TotCITText.Select(TotCITText.Text.Length, 0);
        }

        private void nitdefpayable_TextChanged(object sender, EventArgs e)
        {
            string str = nitdefpayable.Text;

            nitdefpayable.Text = computation.commaSeparator(str);

            nitdefpayable.Select(nitdefpayable.Text.Length, 0);
        }

        private void nitdefliability_TextChanged(object sender, EventArgs e)
        {
            string str = nitdefliability.Text;

            nitdefliability.Text = computation.commaSeparator(str);

            nitdefliability.Select(nitdefliability.Text.Length, 0);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ISICCombo.Text = "";
            int elements = comboBox1.SelectedIndex;

            if (elements != 5 && elements != 6)

                WHT1Text.Text = "10%";
            else
                WHT1Text.Text = "5%";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int elements = comboBox2.SelectedIndex;
            if (elements != 5 && elements != 6)

                WHT2Text.Text = "10%";
            else
                WHT2Text.Text = "5%";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int elements = comboBox4.SelectedIndex;
            if (elements != 5 && elements != 6)

                WHT3Text.Text = "10%";
            else
                WHT3Text.Text = "5%";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int elements = comboBox3.SelectedIndex;
            if (elements != 5 && elements != 6)

                WHT4Text.Text = "10%";
            else
                WHT4Text.Text = "5%";
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int elements = comboBox5.SelectedIndex;
            if (elements != 5 && elements != 6)

                WHT5Text.Text = "10%";
            else
                WHT5Text.Text = "5%";
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            int elements = comboBox7.SelectedIndex;
            if (elements != 5 && elements != 6)

                WHT6Text.Text = "10%";
            else
                WHT6Text.Text = "5%";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string str = textBox1.Text;

            textBox1.Text = computation.commaSeparator(str);

            textBox1.Select(textBox1.Text.Length, 0);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string str = textBox2.Text;

            textBox2.Text = computation.commaSeparator(str);

            textBox2.Select(textBox2.Text.Length, 0);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string str = textBox4.Text;

            textBox4.Text = computation.commaSeparator(str);

            textBox4.Select(textBox4.Text.Length, 0);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string str = textBox5.Text;

            textBox5.Text = computation.commaSeparator(str);

            textBox5.Select(textBox5.Text.Length, 0);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string str = textBox6.Text;

            textBox6.Text = computation.commaSeparator(str);

            textBox6.Select(textBox6.Text.Length, 0);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int elements = comboBox6.SelectedIndex;
            if (elements != 5 && elements != 6)

                WHT7Text.Text = "10%";
            else
                WHT6Text.Text = "5%";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string str = textBox7.Text;

            textBox7.Text = computation.commaSeparator(str);

            textBox7.Select(textBox7.Text.Length, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CIT_EDT_Computation cit_eit = new CIT_EDT_Computation();
            company = companytext.Text;
            tin=TINtext.Text;
            Ref = Reftext.Text;
            tpselfassess = TPselfassessText.Text;
           // costofsales = costS
           // turnover = turnovertext.Text;
            percentcostsales = (computation.validate(costofsales) / computation.validate(turnover) * 100).ToString();
            totalAssessibleProfit = TPAssesment.Text;
            cit_eit.Show();
        }

        private void WHTView_Click(object sender, EventArgs e)
        {
            CIT_EDT_Computation cit_eit = new CIT_EDT_Computation();
            TotCIT = TotCITText.Text;
            company = companytext.Text;
            tin = TINtext.Text;
            Ref = Reftext.Text;
            tpselfassess = TPselfassessText.Text;
            // costofsales = costS
            // turnover = turnovertext.Text;
            percentcostsales = (computation.validate(costofsales) / computation.validate(turnover) * 100).ToString();
            totalAssessibleProfit = TPAssesment.Text;
            cit_eit.Show();
            STATEMENT_OF_WHT_SEARCH_POSITION_FORM whtForm = new STATEMENT_OF_WHT_SEARCH_POSITION_FORM();
            whtForm.Show();
        }

        }
    }

