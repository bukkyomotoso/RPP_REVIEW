using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
//using Microsoft.Reporting.WinForms;
namespace RPP_REVIEW_APPLICATION
{
    public partial class Minimum_Tax : Form
    {

        ComputationClass computation = new ComputationClass();
       
        public Minimum_Tax()
        {
            InitializeComponent();

            double to_below_500 = 500000;
            AtextBox4.Text =  computation.commaSeparator((to_below_500.ToString()));
            BtextBox2.Text = computation.commaSeparator((to_below_500.ToString()));
            DetailscheckBox.Visible = true;
            //detailsTextBox.Visible = true;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);


        }
        
       
        

        private void showDetails()
        {
            String str = "(Section(s) 33 and 11(4) of Company Income Tax Act, LFN 2004.); \n" +
                ".....where in any year of assessment the ascertainment of total assessable profits " +
                    "from all sources of a company results in a loss, or where a company's ascertained total profits " +
                    "results in no tax payable or tax payable which is less than the minimum tax, there shall be levied and " +
                    "paid by the company the minimum tax.\n" +
                    "EXCEPTION \n" +
                    "Minimum tax is not applicable to:\n" +
                     "• a company with at least 25%   foreign equity, (with evidence of the certificate of foreign capital equity).\n" +

                      "• those engaged in agricultural trade or business   (Only livestocks & plantation)\n" +

                      "• to any company during the first four calendar years of commencement of business.";
            MessageBox.Show(str, "Note on Minimum Tax");
            //detailsTextBox.Text = str;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getValues();
        }


        public void getValues()
        {
            //Computes the Values for Section A

            double to_below_500 = 500000;
            

            double va_grossprofit = 0;
           va_grossprofit = (computation.validate(General_Template.grossprofit) + computation.validate(General_Template.otherinc)) * 0.005;
           AtextBox5a.Text = computation.commaSeparator(va_grossprofit.ToString());

           double va_netassets = computation.validate(General_Template.netasset) * 0.005;
           AtextBox6.Text = computation.commaSeparator((va_netassets.ToString()));

            double va_sharedcapital = computation.validate(General_Template.sharedcapital) * 0.0025;
            AtextBox7.Text = computation.commaSeparator(va_sharedcapital.ToString());

            double va_to_below_500 =  computation.validate(AtextBox4.Text);
           
            AtextBox8.Text = computation.commaSeparator((0.0025 * va_to_below_500).ToString());

            //Computes the values for Section B


            double turnvover = computation.validate((BtextBox1.Text));
            
            double turnover_excess_500k = turnvover - to_below_500;
            BtextBox3.Text = computation.commaSeparator(turnover_excess_500k.ToString());
            BtextBox4.Text =computation.commaSeparator(turnover_excess_500k.ToString());
            BtextBox8.Text = computation.commaSeparator((0.00125 * turnover_excess_500k).ToString());

           // double highest_A = Math.Max(computation.validate((AtextBox8.Text)), 
               // Math.Max(va_sharedcapital, Math.Max(va_grossprofit, va_netassets)));
            double highest_A = Math.Max(Math.Max(Math.Max(computation.validate(AtextBox8.Text),computation.validate(AtextBox7.Text)),
                computation.validate(AtextBox6.Text)), computation.validate(AtextBox5a.Text));
                
            CtextBox1.Text = computation.commaSeparator(highest_A.ToString());
            //CtextBox2.Text = computation.commaSeparator(BtextBox8.Text);
            CtextBox2.Text = BtextBox8.Text;
            CtextBox3.Text = computation.commaSeparator((highest_A + computation.validate(CtextBox2.Text)).ToString());
            CtextBox5.Text =        computation.commaSeparator((computation.validate(CtextBox3.Text) - computation.validate(CtextBox4.Text)).ToString());


        }

        private void DetailscheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DetailscheckBox.Checked == true)
            {
                showDetails();

            }
            DetailscheckBox.Checked = false;

            //else
               // detailsTextBox.Text = "";
        }




        private void PrintButton_Click_1(object sender, EventArgs e)
        {
            CaptureScreen();
            DetailscheckBox.Visible = false;
             //detailsTextBox.Visible = false;

             DialogResult result = printDialog1.ShowDialog();
             if (result == DialogResult.OK)
             {
                 printDocument1.Print();
             }

   
          else
          {
             // detailsTextBox.Visible=true;
            DetailscheckBox.Visible=true;
          }

          DetailscheckBox.Visible = true;
         // detailsTextBox.Visible = true;
         }

        private void printDocument1_PrintPage(System.Object sender,
          System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void Minimum_Tax_Load(object sender, EventArgs e)
        {
            companyText.Text = General_Template.comp1;
            AssessmentText.Text = General_Template.year;
            AtextBox1.Text = computation.commaSeparator((computation.validate(General_Template.grossprofit) 
                + computation.validate(General_Template.otherinc)).ToString());
            //AtextBox1.Text = "1";
            AtextBox2.Text = computation.commaSeparator(General_Template.netasset.ToString());
            AtextBox3.Text = computation.commaSeparator(General_Template.sharedcapital.ToString());
            BtextBox1.Text = computation.validate(General_Template.turnover.ToString()).ToString();
            //AtextBox1.Text = (Double.Parse(General_Template.turnover) - Double.Parse(General_Template.costofsales)).ToString();
            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
           // this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
           // this.reportViewer2.RefreshReport();
            //this.reportViewer3.RefreshReport();
            //this.reportViewer4.RefreshReport();
            //this.reportViewer1.RefreshReport();
        }

        private void CtextBox4_TextChanged(object sender, EventArgs e)
        {


            string str = CtextBox4.Text;
            CtextBox4.Text = computation.commaSeparator(str);
            CtextBox4.Select(CtextBox4.Text.Length, 0);
             double res = (computation.validate(CtextBox3.Text) - computation.validate( CtextBox4.Text));
             CtextBox5.Text = computation.commaSeparator(res.ToString());
             
        }

        private void CtextBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BtextBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void AtextBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void AtextBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void AtextBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void AtextBox4_TextChanged(object sender, EventArgs e)
        {
            string str = AtextBox4.Text;

            AtextBox4.Text = computation.commaSeparator(str);
            AtextBox4.Select(AtextBox4.Text.Length, 0);
        }

        private void AtextBox1_TextChanged(object sender, EventArgs e)
        {
            string str = AtextBox1.Text;

            AtextBox1.Text = computation. commaSeparator(str);
            AtextBox1.Select(AtextBox1.Text.Length, 0);
        }

        private void AtextBox5a_TextChanged(object sender, EventArgs e)
        {
            string str = AtextBox1.Text;

            AtextBox1.Text = computation. commaSeparator(str);
            AtextBox1.Select(AtextBox1.Text.Length, 0);
        }

        private void AtextBox6_TextChanged(object sender, EventArgs e)
        {
            string str = AtextBox6.Text;

            AtextBox6.Text = computation .commaSeparator(str);
            AtextBox6.Select(AtextBox6.Text.Length, 0);
        }

        private void AtextBox7_TextChanged(object sender, EventArgs e)
        {
            string str = AtextBox7.Text;

            AtextBox7.Text = computation. commaSeparator(str);
            AtextBox7.Select(AtextBox7.Text.Length, 0);
        }

        private void AtextBox8_TextChanged(object sender, EventArgs e)
        {
            string str = AtextBox8.Text;

            AtextBox8.Text = computation.commaSeparator(str);
            AtextBox8.Select(AtextBox8.Text.Length, 0);
        }

        private void AtextBox2_TextChanged(object sender, EventArgs e)
        {
            string str = AtextBox2.Text;

            AtextBox2.Text = computation.commaSeparator(str);
            AtextBox2.Select(AtextBox2.Text.Length, 0);
        }
        
        private void AtextBox3_TextChanged(object sender, EventArgs e)
        {
            string str = AtextBox3.Text;

            AtextBox3.Text = computation.commaSeparator(str);
            AtextBox3.Select(AtextBox3.Text.Length, 0);
        }

        private void BtextBox1_TextChanged(object sender, EventArgs e)
        {
            string str = BtextBox1.Text;

            BtextBox1.Text = computation. commaSeparator(str);
            BtextBox1.Select(BtextBox1.Text.Length, 0);
        }

        private void BtextBox2_TextChanged(object sender, EventArgs e)
        {
            string str = BtextBox2.Text;

            BtextBox2.Text =computation.commaSeparator(str);
            BtextBox2.Select(BtextBox2.Text.Length, 0);
        }

        private void BtextBox3_TextChanged(object sender, EventArgs e)
        {
            string str = BtextBox3.Text;

            BtextBox3.Text = computation. commaSeparator(str);
            BtextBox3.Select(BtextBox3.Text.Length, 0);
        }

        private void BtextBox4_TextChanged(object sender, EventArgs e)
        {
            string str = BtextBox4.Text;

            BtextBox4.Text = computation. commaSeparator(str);
            BtextBox4.Select(BtextBox4.Text.Length, 0);
        }

        private void BtextBox8_TextChanged(object sender, EventArgs e)
        {
            string str = BtextBox8.Text;

            BtextBox8.Text = computation. commaSeparator(str);
            BtextBox8.Select(BtextBox8.Text.Length, 0);
        }

        private void CtextBox1_TextChanged(object sender, EventArgs e)
        {
            string str = CtextBox1.Text;

            CtextBox1.Text = computation.commaSeparator(str);
            CtextBox1.Select(CtextBox1.Text.Length, 0);
        }

        private void CtextBox2_TextChanged(object sender, EventArgs e)
        {
            string str = CtextBox2.Text;

            CtextBox2.Text = computation.commaSeparator(str);
            CtextBox2.Select(CtextBox2.Text.Length, 0);
        }

        private void CtextBox3_TextChanged(object sender, EventArgs e)
        {
            string str = CtextBox3.Text;

            CtextBox3.Text = computation.commaSeparator(str);
            CtextBox3.Select(CtextBox3.Text.Length, 0);
            //double res = 
        }

        private void CtextBox5_TextChanged(object sender, EventArgs e)
        {
            string str = CtextBox5.Text;


            CtextBox5.Text = computation.commaSeparator(str);
            CtextBox5.Select(CtextBox5.Text.Length, 0);
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            MinimumTax minimumTaxReport = new MinimumTax();
            minimumTaxReport.Show();
           // ReportParameter[] parms = new ReportParameter[2];
            //parms[0] = new ReportParameter("param_name", AtextBox1.Text);
            //parms[1] = new ReportParameter("param_course", AtextBox5a.Text);
           // this.reportViewer1.LocalReport.SetParameters(parms);
            //this.reportViewer1.RefreshReport();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        }

        }



