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
    public partial class General_Template2 : Form
    {
        public General_Template2()
        {
            InitializeComponent();
        }

        public static String PBF = "";
        public static String totCITPaid = "0";
        public static String totProfitSelfAssess = "";
        ComputationClass computation = new ComputationClass();

        private void General_Template2_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MMM-yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MMM-yyyy";
            
            General_Template genTemplate = new General_Template();
            //General_Templat6 genTemp6 = new General_Templat6();
            dateTimePicker1.Text =  General_Templat6.yearend + "" + (int.Parse(DateTime.Today.ToString("yyyy")) -1 );
            companytext.Text = (General_Template.company);
            TINtext.Text = (General_Template.tin);
            reviewDatetext.Text = General_Template.reviewdate;
            Reftext.Text = General_Template.Ref;
            DueDateText.Text = dateTimePicker1.Value.AddMonths(6).ToString("dd MMMM, yyyy");
            
           // int mnths = (dateTimePicker1.Value.AddMonths(6));
            DateTime incrmdate = dateTimePicker1.Value.AddMonths(6);
            DateTime incrmdate1 = dateTimePicker2.Value.AddDays(0);
            getLateRemarks();
            getRemarks();

           // testText.Text = computeMonth();
            LSPText.Text =computeLsp();
            DueDateText.Text = dateTimePicker1.Value.AddMonths(6).ToString("dd MMMM, yyyy");
            
            
        }

        public string computeLsp()
        {
            DateTime incrmdate = dateTimePicker1.Value.AddMonths(6);
            DateTime incrmdate1 = dateTimePicker2.Value.AddDays(0);

            int yeardiff = (incrmdate1.Year - incrmdate.Year)*12;
            int monthdiff = incrmdate1.Month - incrmdate.Month;

            int totmonth = yeardiff + monthdiff;
            int lsp = 25000;

            for (int i=1;i<totmonth;i++)
            {
                lsp = lsp + 5000;
            }

            if (totmonth <=0)
                return "No Penalty";
            else
                return  computation.commaSeparator( lsp.ToString());


        }
        public string computeMonth()
        {
            DateTime incrmdate = dateTimePicker1.Value.AddMonths(6);
            DateTime incrmdate1 = dateTimePicker2.Value.AddDays(0);

            int yeardiff = (incrmdate1.Year - incrmdate.Year) * 12;
            int monthdiff = incrmdate1.Month - incrmdate.Month;

            int totmonth = yeardiff + monthdiff;
            int lsp = 25000;

            for (int i = 1; i <= totmonth; i++)
            {
                lsp = lsp + 5000;
            }

            return totmonth.ToString();
        }



    
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {


            DateTime selectedDate = dateTimePicker1.Value;
            DateTime lastDayOfMonth = new DateTime(
                selectedDate.Year,
                selectedDate.Month,
                DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month));
            dateTimePicker1.Value = lastDayOfMonth;



            
            
            
            DueDateText.Text = dateTimePicker1.Value.AddMonths(6).ToString("dd MMM, yyyy");
            DateTime incrmdate = dateTimePicker1.Value.AddMonths(6);
            DateTime incrmdate1 = dateTimePicker2.Value.AddDays(0);

            LSPText.Text = computeLsp();
            getLateRemarks();
            getRemarks(); ;
        }

        private void General_Template2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MaxDate = DateTime.Today;
            LSPText.Text = computeLsp();
            getLateRemarks();
            getRemarks();
        }

       

        private void LSPPaidText_TextChanged(object sender, EventArgs e)
        {
            string mystr = LSPPaidText.Text;

            LSPPaidText.Text = computation.commaSeparator(mystr);
            LSPPaidText.Select(LSPPaidText.Text.Length, 0);
           
            if (LSPText.Text != "No Penalty")
               
                {
                    string str = LSPPaidText.Text;

                    LSPPaidText.Text = str;
                    LSPPaidText.Select(LSPPaidText.Text.Length, 0);
                    OutLSP.Text = computation.commaSeparator((computation.validate((LSPText.Text)) - computation.validate((LSPPaidText.Text))).ToString());
            
                }
            
               
        }
        private void getLateRemarks()
        {
            String str = "";
            DateTime incrmdate = dateTimePicker1.Value.AddMonths(6);
            DateTime incrmdate1 = dateTimePicker2.Value.AddDays(0);
            if (incrmdate1 > incrmdate)
            {
                String days = (incrmdate1 - incrmdate).Days.ToString();
               // days.Split('.')
                str = days;
            }
            else
                str= "Not Late";

            daysLateText.Text = str;
        }

        private void getRemarks()
        {
            DateTime incrmdate = dateTimePicker1.Value.AddMonths(6);
            DateTime incrmdate1 = dateTimePicker2.Value.AddDays(0);
            String days = (incrmdate1 - incrmdate).Days.ToString();
            if (int.Parse(days) > 60)
            
                remarkText.Text = "More than 60 days\n" + "Use Section 32";
            
            else if (int.Parse(days) <= 59 )
                remarkText.Text = "Less than 60 days\n" + "Compute LSP Only";
            else 
                remarkText.Text = "Exactly 60 days";

        }

        private void LSPPaidText_KeyPress(object sender, KeyPressEventArgs e)
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

        private void LSPText_TextChanged(object sender, EventArgs e)
        {
            string str = LSPText.Text;

            LSPText.Text =str;
            LSPText.Select(LSPText.Text.Length, 0);

            if(LSPText.Text != "No Penalty")
            OutLSP.Text = computation.commaSeparator( (computation.validate( LSPText.Text) - computation.validate(LSPPaidText.Text)).ToString());
            else
            {
                double res = 0 - computation.validate(LSPPaidText.Text);
                OutLSP.Text = computation.commaSeparator(res.ToString());
            }
        
        }

        private void daysLateText_TextChanged(object sender, EventArgs e)
        {
            DateTime incrmdate = dateTimePicker1.Value.AddMonths(6);
            DateTime incrmdate1 = dateTimePicker2.Value.AddDays(0);
            String days = (incrmdate1 - incrmdate).Days.ToString();
            if (int.Parse(days) > 60)
            {
                remarkText.Text = "More than 60 days\n" + "Use Section 32";
            }
            else
                remarkText.Text = "Less than 60 days\n" + "Compute LSP Only";
        }

   

        private void WHTText_TextChanged(object sender, EventArgs e)
        {
            string str = WHTText.Text;

            WHTText.Text = computation.commaSeparator(str);
            WHTText.Select(WHTText.Text.Length, 0);

           // if ( CITselfassesText.Text !="")
               
                    CashText.Text =computation.commaSeparator((computation.validate( CITselfassesText.Text) - computation.validate(WHTText.Text)).ToString());
        }

        private void TPRPPText_TextChanged(object sender, EventArgs e)
        {
            string str = TPRPPText.Text;

            TPRPPText.Text = computation.commaSeparator(str);
            TPRPPText.Select(TPRPPText.Text.Length, 0);

            double citpaid = 0;
                    citpaid = (computation.validate( TPRPPText.Text) * 0.30) - computation.validate( CITselfassesText.Text);

            if (citpaid >=0)
                CITRPPText.Text = computation.commaSeparator(citpaid.ToString());
            else
                CITRPPText.Text = "";
            
           // else
              //  CITRPPText.Text = computation.commaSeparator( citpaid.ToString());
            double citpaid1 = 0;

            
            citpaid1 = (computation.validate( TPselfassessText.Text) * 0.30);
            if (citpaid1 >= 0)
                CITselfassesText.Text = computation.commaSeparator(citpaid1.ToString());

            //else
               // CITselfassesText.Text = computation.commaSeparator(citpaid1.ToString());

            double citpaid2 = 0;
            citpaid2 = (computation.validate(TPTaxAudText.Text) * 0.30) - (computation.validate(CITRPPText.Text) + 
                computation.validate(CITselfassesText.Text));
            if (citpaid2 >= 0)
                CITTaxAudText.Text = computation.commaSeparator(citpaid2.ToString());
               
            //else
               // CITTaxAudText.Text = computation.commaSeparator(citpaid2.ToString());
               
            TPAssesment.Text = computation.commaSeparator(Math.Max(Math.Max(computation.validate(TPselfassessText.Text), 
                computation.validate(TPRPPText.Text)), computation.validate(TPTaxAudText.Text)).ToString());
           /* if (TPTaxAudText.Text == "")
                CITTaxAudText.Text = "0";*/

            
        }

        private void TPTaxAudText_TextChanged(object sender, EventArgs e)
        {
            string str = TPTaxAudText.Text;

            TPTaxAudText.Text = computation.commaSeparator(str);
            TPTaxAudText.Select(TPTaxAudText.Text.Length, 0);

            double citpaid = 0;
                    citpaid = (computation.validate( TPRPPText.Text) * 0.30) - computation.validate(( CITselfassesText.Text));
            if (citpaid >= 0)
                CITRPPText.Text = computation.commaSeparator(citpaid.ToString());

           // else
                //CITRPPText.Text = computation.commaSeparator(citpaid.ToString());


            double citpaid1 = 0;
            if(TPselfassessText.Text!="")
            citpaid1 = computation.validate( TPselfassessText.Text) * 0.30;
            if (citpaid1 >= 0)
                CITselfassesText.Text = computation.commaSeparator(citpaid1.ToString());

            //else
               // CITselfassesText.Text = computation.commaSeparator(citpaid1.ToString());

            double citpaid2 = 0;
            citpaid2 = (computation.validate(TPTaxAudText.Text) * 0.30 )- (computation.validate(CITRPPText.Text)
                +  computation.validate(CITselfassesText.Text));
            if (citpaid2 >= 0)
                CITTaxAudText.Text = computation.commaSeparator(citpaid2.ToString());
            else
                CITTaxAudText.Text = "";
            //else
               // CITTaxAudText.Text = computation.commaSeparator(citpaid2.ToString());
            
           
           TPAssesment.Text = computation.commaSeparator((Math.Max(Math.Max(computation.validate(TPselfassessText.Text), 
               computation.validate( TPRPPText.Text)), computation.validate(TPTaxAudText.Text))).ToString());

            
        }

        private void TPAssesment_TextChanged(object sender, EventArgs e)
        {
            string str = TPAssesment.Text;

            TPAssesment.Text = computation.commaSeparator(str);
            TPAssesment.Select(TPAssesment.Text.Length, 0);

            double citpaid = 0;
                    citpaid = (computation.validate( TPRPPText.Text) * 0.30) - computation.validate(CITselfassesText.Text);
            if (citpaid >= 0)
                CITRPPText.Text = computation.commaSeparator(citpaid.ToString());

            //else
               // CITRPPText.Text = computation.commaSeparator(citpaid.ToString());


            double citpaid1 = 0;
            citpaid1 = computation.validate(TPselfassessText.Text) * 0.30;
            if (citpaid1 >= 0)
                CITselfassesText.Text = computation.commaSeparator(citpaid1.ToString());

            //else
               // CITselfassesText.Text = computation.commaSeparator( citpaid1.ToString());

            double citpaid2 = 0;
            
            citpaid2 = (computation.validate(TPTaxAudText.Text) * 0.30) - (computation.validate( CITRPPText.Text) +
                computation.validate( CITselfassesText.Text));
            if (citpaid2 >= 0 )
                CITTaxAudText.Text = computation.commaSeparator(citpaid2.ToString());
            
            
            //else
               // CITTaxAudText.Text = computation.commaSeparator( citpaid2.ToString());
            TPAssesment.Text =computation. commaSeparator((Math.Max(Math.Max(computation.validate( TPselfassessText.Text), 
                computation.validate( TPRPPText.Text)), computation.validate( TPTaxAudText.Text))).ToString());
            
        }

        private void CITselfassesText_TextChanged(object sender, EventArgs e)
        {
            string str = CITselfassesText.Text;

            CITselfassesText.Text = computation.commaSeparator(str);
            CITselfassesText.Select(CITselfassesText.Text.Length, 0);
            double citpaid = 0;
                
                    citpaid = (computation.validate( TPRPPText.Text) * 0.30) - computation.validate( CITselfassesText.Text);
            
            if (citpaid >= 0)
                CITRPPText.Text = computation.commaSeparator(citpaid.ToString());

            //else
               // CITRPPText.Text = computation.commaSeparator( citpaid.ToString());


            double citpaid1 = 0;
            citpaid1 = computation.validate( TPselfassessText.Text) * 0.30;
            if (citpaid1 >= 0)
                CITselfassesText.Text = computation.commaSeparator(citpaid1.ToString());

            //else
                //CITselfassesText.Text = computation.commaSeparator(citpaid1.ToString());

            double citpaid2 = 0;
            citpaid2 = (computation.validate(TPTaxAudText.Text) * 0.30) - (computation.validate(CITRPPText.Text)+ computation.validate( CITselfassesText.Text));
          if (citpaid2 >= 0)
              CITTaxAudText.Text = computation.commaSeparator(citpaid2.ToString());
                
            //else
                //CITTaxAudText.Text = computation. commaSeparator( citpaid2.ToString());
                TPAssesment.Text = computation.commaSeparator( (Math.Max(Math.Max(computation.validate( TPselfassessText.Text), 
                    computation.validate(  TPRPPText.Text)), computation.validate( TPTaxAudText.Text))).ToString());
            
                    CashText.Text = computation.commaSeparator((computation.validate( CITselfassesText.Text) 
                        - computation.validate( WHTText.Text)).ToString());
                    TotCITText.Text = computation.commaSeparator((computation.validate(CITselfassesText.Text) + 
                        computation.validate(CITTaxAudText.Text) 
                        + computation.validate( CITRPPText.Text)).ToString());
                   // totCITPaid = CITselfassesText.Text;
        }

        private void CITRPPText_TextChanged(object sender, EventArgs e)
        {
            string str = CITRPPText.Text;

            CITRPPText.Text = computation.commaSeparator(str);
            CITRPPText.Select(CITRPPText.Text.Length, 0);
            double citpaid = 0;
                    citpaid = (computation.validate(  TPRPPText.Text) * 0.30) - computation.validate( CITselfassesText.Text);


                    if (citpaid >= 0)
                    {
                        str = computation.commaSeparator(citpaid.ToString());
                        CITRPPText.Text = str;
                    }

           // else
               // CITRPPText.Text = citpaid.ToString();


            double citpaid1 = 0;
            citpaid1 = computation.validate( TPselfassessText.Text) * 0.30;
            if (citpaid1 >= 0)
                CITselfassesText.Text = computation.commaSeparator(citpaid1.ToString());
            //else
               // CITselfassesText.Text = computation.commaSeparator( citpaid1.ToString());

            double citpaid2 = 0;
                citpaid2 = (computation.validate(  TPTaxAudText.Text) * 0.30) - 
                    (computation.validate(  CITRPPText.Text) + computation.validate( CITselfassesText.Text));
            //if (citpaid2 < 0)
               // CITTaxAudText.Text = "0";
                if (citpaid2 >= 0)
                
                CITTaxAudText.Text = computation.commaSeparator( citpaid2.ToString());
                TPAssesment.Text = computation.commaSeparator( (Math.Max(Math.Max(computation.validate( TPselfassessText.Text), 
                    computation.validate( TPRPPText.Text)), computation.validate(  TPTaxAudText.Text))).ToString());
            TotCITText.Text = computation. commaSeparator((computation.validate( CITselfassesText.Text) + 
                computation.validate( CITTaxAudText.Text) + computation.validate(  CITRPPText.Text)).ToString());
        
        }

        private void CITTaxAudText_TextChanged(object sender, EventArgs e)
        {
            string str = CITTaxAudText.Text;

            CITTaxAudText.Text = computation.commaSeparator(str);
            CITTaxAudText.Select(CITTaxAudText.Text.Length, 0);

            TotCITText.Text = computation.commaSeparator((computation.validate(CITselfassesText.Text) + 
                computation.validate( CITTaxAudText.Text) + computation.validate(  CITRPPText.Text)).ToString());
        
        }

        private void TPselfassessText_TextChanged(object sender, EventArgs e)
        {
            string str = TPselfassessText.Text;

            TPselfassessText.Text = computation.commaSeparator(str);
            TPselfassessText.Select(TPselfassessText.Text.Length, 0);

            double citpaid = 0;
                    citpaid = (computation.validate(  TPRPPText.Text) * 0.30) - computation.validate( CITselfassesText.Text);

            if (citpaid >= 0)
                CITRPPText.Text = computation.commaSeparator(citpaid.ToString());
            //else
                //CITRPPText.Text = computation.commaSeparator(citpaid.ToString());


            double citpaid1 = 0;

            citpaid1 =  computation.validate( TPselfassessText.Text) * 0.30;
            if (citpaid1 >= 0)
                CITselfassesText.Text = computation.commaSeparator(citpaid1.ToString()); ;
            //else
               // CITselfassesText.Text = computation.commaSeparator( citpaid1.ToString());

            double citpaid2 = 0;
                citpaid2 = (computation.validate( TPTaxAudText.Text) * 0.30) - 
                 ( computation.validate(  CITRPPText.Text) + computation.validate(CITselfassesText.Text));
           if (citpaid2 >= 0 )
               CITTaxAudText.Text = computation.commaSeparator(citpaid2.ToString());

           if (computation.validate(TPselfassessText.Text) > computation.validate(TPTaxAudText.Text))
               CITTaxAudText.Text = "";
           if (computation.validate(TPselfassessText.Text) > computation.validate(TPRPPText.Text))
               CITRPPText.Text = "";
            
            //else
               // CITTaxAudText.Text = computation.commaSeparator( citpaid2.ToString());
            
                    CashText.Text = computation.commaSeparator((computation.validate(  CITselfassesText.Text) - 
                        computation.validate(  WHTText.Text)).ToString());

                  /*  if (TPTaxAudText.Text == "")
                        CITTaxAudText.Text = "0";*/

            }


        private void Next_Click(object sender, EventArgs e)
        {
            PBF = General_Template.PBF;
            totCITPaid = TotCITText.Text;
            totProfitSelfAssess = TPselfassessText.Text;
            
            General_Template3 gen_template3 = new General_Template3();
            gen_template3.Show();
        }

        private void dividendText_TextChanged(object sender, EventArgs e)
        {
            string str = dividendText.Text;

            dividendText.Text = computation.commaSeparator(str);
            dividendText.Select(dividendText.Text.Length, 0);
        }

        private void OutLSP_TextChanged(object sender, EventArgs e)
        {
            string str = OutLSP.Text;

            OutLSP.Text =computation. commaSeparator(str);
            OutLSP.Select(OutLSP.Text.Length, 0);
        }

        private void LSPText_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dividendText_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TPselfassessText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46 && e.KeyChar != 45)
                e.Handled = true;
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains("."))
                {

                    e.Handled = true;
                }
            }
        }

        private void WHTText_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CashText_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TotCITText_TextChanged(object sender, EventArgs e)
        {
            string str = TotCITText.Text;

            TotCITText.Text = computation. commaSeparator(str);
            TotCITText.Select(TotCITText.Text.Length, 0);
        }

        private void TINtext_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reftext_TextChanged(object sender, EventArgs e)
        {

        }

        private void DueDateText_TextChanged(object sender, EventArgs e)
        {

        }

        private void LSPPaidText_Leave(object sender, EventArgs e)
        {
           double result = computation.validate(LSPPaidText.Text);
            if(result % 5000 != 0)
                MessageBox.Show("LSP Paid must be a multiple of 5000","Invalid LSP",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);

        }

        private void CashText_TextChanged(object sender, EventArgs e)
        {

        }

        private void CashText_Leave(object sender, EventArgs e)
        {
            if(computation.validate(CashText.Text)!= (0.30 * computation.validate(TPselfassessText.Text )))
            {
              DialogResult dr =  MessageBox.Show("Cash Paid is not 30% of Total Profit\nDo you want to continue?","Invalid Cah Paid",
                                                        MessageBoxButtons.YesNo,MessageBoxIcon.Error);

              if (dr == DialogResult.No)
                  CashText.Text = (0.30 * computation.validate(TPselfassessText.Text)).ToString();
                

            }

        }

    }
}
