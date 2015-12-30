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
    public partial class CIT_EDT_Computation : Form
    {
        public CIT_EDT_Computation()
        {
            InitializeComponent();
        }

        ComputationClass computation = new ComputationClass();
        double adjusted = 0;


        private void button1_Click(object sender, EventArgs e)
        {
            New_Field newfield = new New_Field();
            newfield.Show();

            String myselected = New_Field.additionalfield;
            lab7.Text = myselected;

            lab7.Visible = true;
            // buton1.Visible = true;
            txtBox7.Visible = true;


        }

        private void buton2_Click(object sender, EventArgs e)
        {
            lab9.Visible = true;
            //buton3.Visible = true;
            txtBox9.Visible = true;
        }

        private void buton3_Click(object sender, EventArgs e)
        {
            lab10.Visible = true;
            //buton.Visible = true;
            txtBox10.Visible = true;
        }

        private void buton1_Click(object sender, EventArgs e)
        {
            lab8.Visible = true;
            //buton2.Visible = true;
            txtBox8.Visible = true;
        }

        public  String loadDonation()
        {
            double donationVal = 0.00;
            double donationValue = 0.00;
            double donation = computation.validate(General_Template.donation);
            double totProfitSelfAssess = computation.validate(General_Template2.totProfitSelfAssess);
            
            if (donation == 0)
            {
                donationValue = 0;

            }
            else
            {
                if (computation.validate(General_Template2.totProfitSelfAssess) > 0)
                {

                    donationVal = (donation - ((totProfitSelfAssess + donation) * 0.10));
                    MessageBox.Show(donationVal.ToString());
                    MessageBox.Show(donation.ToString());
                    MessageBox.Show(totProfitSelfAssess.ToString());
                    

                    

                    if (donationVal < 0)
                    {
                        donationValue = 0;
                      
                    }
                    else
                    {
                        donationValue = donationVal;
                       
                    }
                }

                else if (computation.validate(General_Template2.totProfitSelfAssess) < 0){

                    donationValue = donation;
                    
                }
                    
                else
                {
                    if (donation > 0)
                        donationValue = donation;
                    else
                        donationValue = 0;
                }
            }

            return donationValue.ToString();
        }


        private void CIT_EDT_Computation_Load(object sender, EventArgs e)
        {
            //assessmentYear.Text =  General_Templat6
            double wht = computation.validate( STATEMENT_OF_WHT_SEARCH_POSITION_FORM.WHT);
            if (wht < 0)
                txtBox2.Text = Math.Abs(wht).ToString();
            if (General_Templat6.secManAgr == true)
                label17.Text = "Restricted to 100% of Assessable Profit";
            adjusted = computation.validate(textBox13.Text);
            textBox13.Text = General_Template3.tpselfassess;
            textBox14.Text = adjusted.ToString();
            // companytext.Text =  General_Template.company;
            // TINtext.Text = General_Template.tin;
            //Reftext.Text = General_Template.Ref;
            percent1text.Text = computation.validate(General_Template3.percentcostsales).ToString();
            // percent1text.Text = computation.validate("9").ToString();
            txtBox1.Text = computation.commaSeparator(General_Template3.costofsales).ToString();
            textBox24.Text = General_Template2.totCITPaid;
            textBox21.Text = General_Template3.TotCIT;
            
            if(computation.validate(loadDonation()) == 0)
            {
                txtBox6.Visible = false;
                delete6.Visible = false;
                lab6.Visible = false;
            }
            else
                txtBox6.Text = loadDonation();
            

        }

        private void Percenttext_TextChanged(object sender, EventArgs e)
        {
            string str = txtBox1.Text;
            double val2 = ((computation.validate(percent1text.Text) / 100) * computation.validate(General_Template.turnover));
            double val1 = computation.validate(General_Template.costofsales);
            //turnovertext.Text = computation.commaSeparator(str);

            //turnovertext.Select(turnovertext.Text.Length, 0);

            txtBox1.Text = computation.commaSeparator((val1 - val2).ToString());

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            ActiveControl = comboBoxList;
            comboBoxList.DroppedDown = true;
        }

        private void delete1_Click(object sender, EventArgs e)
        {
            lab1.Visible = false;
            delete1.Visible = false;
            percent1label.Visible = false;
            percent1text.Visible = false;
            txtBox1.Visible = false;
        }

        private void delete2_Click(object sender, EventArgs e)
        {
            lab2.Visible = false;
            delete2.Visible = false;
            txtBox2.Visible = false;
            double res = computation.validate(textBox14.Text) - computation.validate(txtBox2.Text);
            textBox14.Text = res.ToString();
        }

        private void delete3_Click(object sender, EventArgs e)
        {
            lab3.Visible = false;
            delete3.Visible = false;
            txtBox3.Visible = false;
            double res = computation.validate(textBox14.Text) - computation.validate(txtBox3.Text);
            textBox14.Text = res.ToString();
        }

        private void delete4_Click(object sender, EventArgs e)
        {
            lab4.Visible = false;
            delete4.Visible = false;
            txtBox4.Visible = false;
            double res = computation.validate(textBox14.Text) - computation.validate(txtBox4.Text);
            textBox14.Text = res.ToString();
        }

        private void delete5_Click(object sender, EventArgs e)
        {
            lab5.Visible = false;
            delete5.Visible = false;
            txtBox5.Visible = false;
            percent2label.Visible = false;
            percent2text.Visible = false;
            double res = computation.validate(textBox14.Text) - computation.validate(txtBox5.Text);
            textBox14.Text = res.ToString();
        }

        private void delete6_Click(object sender, EventArgs e)
        {
            lab6.Visible = false;
            delete6.Visible = false;
            txtBox6.Visible = false;
            double res = computation.validate(textBox14.Text) - computation.validate(txtBox6.Text);
            textBox14.Text = res.ToString();
        }

        private void delete7_Click(object sender, EventArgs e)
        {
            lab7.Visible = false;
            delete7.Visible = false;
            txtBox7.Visible = false;
            double res = computation.validate(textBox14.Text) - computation.validate(txtBox7.Text);
            textBox14.Text = res.ToString();
        }

        private void delete8_Click(object sender, EventArgs e)
        {
            lab8.Visible = false;
            delete8.Visible = false;
            txtBox8.Visible = false;
            double res = computation.validate(textBox14.Text) - computation.validate(txtBox8.Text);
            textBox14.Text = res.ToString();
        }

        private void delete9_Click(object sender, EventArgs e)
        {
            lab9.Visible = false;
            delete9.Visible = false;
            txtBox9.Visible = false;
            double res = computation.validate(textBox14.Text) - computation.validate(txtBox9.Text);
            textBox14.Text = res.ToString();
        }

        private void delete10_Click(object sender, EventArgs e)
        {
            lab10.Visible = false;
            delete10.Visible = false;
            txtBox10.Visible = false;
            double res = computation.validate(textBox14.Text) - computation.validate(txtBox10.Text);
            textBox14.Text = res.ToString();
        }

        private void comboBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = comboBoxList.SelectedIndex;
            comboBoxList.Visible = false;

            string selectedtext = "";

            if (idx == 0)
                selectedtext = "Advert and public relation";
            else if (idx == 1)
                selectedtext = "Capital Expenditure";
            else if (idx == 2)
                selectedtext = "Exchange Loss";
            else if (idx == 3)
                selectedtext = "Expenses on earning management fees";
            else if (idx == 4)
                selectedtext = "Fines and Penalties";
            else if (idx == 5)
                selectedtext = "Impairment loss";
            else if (idx == 6)
                selectedtext = "Import Duty";
            else if (idx == 7)
                selectedtext = "Legal Expenses iro Tax appeal, stamp duties,offences, renewal";
            else if (idx == 8)
                selectedtext = "Loss on disposal of fixed asset";
            else if (idx == 9)
                selectedtext = "Loss on disposal of investment";
            else if (idx == 10)
                selectedtext = "Miscellaneous Expenses";
            else if (idx == 11)
                selectedtext = "Payroll Tax Expenses";
            else if (idx == 12)
                selectedtext = "Pre-Operational Expenses";
            else if (idx == 13)
                selectedtext = "Provisions for Bad & Doubtful Debts";
            else if (idx == 14)
                selectedtext = "Provisions for gratuity";
            else if (idx == 15)
                selectedtext = "Recoverable sums under insurance on contract of indemnity";
            else if (idx == 16)
                selectedtext = "Revesal of previously disallowed expenses into income";
            else if (idx == 17)
                selectedtext = "Subscription";
            else if (idx == 18)
                selectedtext = "Sum reserved out of profit";
            else if (idx == 19)
                selectedtext = "Sundry Expenses";
            else if (idx == 20)
                selectedtext = "Taxes/Tax expenses";
            else if (idx == 21)
                selectedtext = "Undisclosed Income";
            else if (idx == 22)
                selectedtext = "Withdrawal of capital";



            if (lab1.Visible == false)
            {

                lab1.Text = selectedtext;
                lab1.Visible = true;
                delete1.Visible = true;
                txtBox1.Visible = true;
                txtBox1.Text = "";
            }

            else if (lab2.Visible == false)
            {
                lab2.Text = selectedtext;
                lab2.Visible = true;
                delete2.Visible = true;
                txtBox2.Visible = true;
                txtBox2.Text = "";


            }
            else if (lab3.Visible == false)
            {
                lab3.Text = selectedtext;
                lab3.Visible = true;
                delete3.Visible = true;
                txtBox3.Visible = true;
                txtBox3.Text = "";
            }
            else if (lab4.Visible == false)
            {
                lab4.Text = selectedtext;
                lab4.Visible = true;
                delete4.Visible = true;
                txtBox4.Visible = true;
                txtBox4.Text = "";
            }
            else if (lab5.Visible == false)
            {
                lab5.Text = selectedtext;
                lab5.Visible = true;
                delete5.Visible = true;
                txtBox5.Visible = true;
                txtBox5.Text = "";
            }
            else if (lab6.Visible == false)
            {
                lab6.Text = selectedtext;
                lab6.Visible = true;
                delete6.Visible = true;
                txtBox6.Visible = true;
                txtBox6.Text = "";
            }
            else if (lab7.Visible == false)
            {
                lab7.Text = selectedtext;
                lab7.Visible = true;
                delete7.Visible = true;
                txtBox7.Visible = true;
                txtBox7.Text = "";
            }

            else if (lab8.Visible == false)
            {
                lab8.Text = selectedtext;
                lab8.Visible = true;
                delete8.Visible = true;
                txtBox8.Visible = true;
                txtBox8.Text = "";
            }
            else if (lab9.Visible == false)
            {
                lab9.Text = selectedtext;
                lab9.Visible = true;
                delete9.Visible = true;
                txtBox9.Visible = true;
                txtBox9.Text = "";
            }
            else
            {
                lab10.Text = selectedtext;
                lab10.Visible = true;
                delete10.Visible = true;
                txtBox10.Visible = true;
                txtBox10.Text = "";
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void percent1text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
        }

        private void percent2text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            string str = textBox14.Text;

            textBox14.Text = computation.commaSeparator(str);

            textBox14.Select(textBox14.Text.Length, 0);
            double res = computation.validate(textBox3.Text) + computation.validate(textBox14.Text);

            textBox4.Text = res.ToString();
            textBox19.Text = (0.02 * computation.validate(textBox14.Text)).ToString();
            

        }

        private void txtBox1_TextChanged(object sender, EventArgs e)
        {


            string str = txtBox1.Text;

            txtBox1.Text = computation.commaSeparator(str);

            txtBox1.Select(txtBox1.Text.Length, 0);

            double res = computation.validate(txtBox1.Text) + computation.validate(txtBox2.Text) + computation.validate(txtBox3.Text)
                + computation.validate(txtBox4.Text) + computation.validate(txtBox5.Text) + computation.validate(txtBox6.Text)
                + computation.validate(txtBox7.Text) + computation.validate(txtBox8.Text) + computation.validate(txtBox9.Text)
                + computation.validate(txtBox10.Text) + computation.validate(textBox13.Text);

            textBox14.Text = res.ToString();
        }

        private void txtBox2_TextChanged(object sender, EventArgs e)
        {

            string str = txtBox2.Text;

            txtBox2.Text = computation.commaSeparator(str);

            txtBox2.Select(txtBox2.Text.Length, 0);

            double res = computation.validate(txtBox1.Text) + computation.validate(txtBox2.Text) + computation.validate(txtBox3.Text)
                 + computation.validate(txtBox4.Text) + computation.validate(txtBox5.Text) + computation.validate(txtBox6.Text)
                 + computation.validate(txtBox7.Text) + computation.validate(txtBox8.Text) + computation.validate(txtBox9.Text)
                 + computation.validate(txtBox10.Text) + computation.validate(textBox13.Text);

            textBox14.Text = res.ToString();

        }

        private void txtBox3_TextChanged(object sender, EventArgs e)
        {
            string str = txtBox3.Text;

            txtBox3.Text = computation.commaSeparator(str);

            txtBox3.Select(txtBox3.Text.Length, 0);
            double res = computation.validate(txtBox1.Text) + computation.validate(txtBox2.Text) + computation.validate(txtBox3.Text)
                 + computation.validate(txtBox4.Text) + computation.validate(txtBox5.Text) + computation.validate(txtBox6.Text)
                 + computation.validate(txtBox7.Text) + computation.validate(txtBox8.Text) + computation.validate(txtBox9.Text)
                 + computation.validate(txtBox10.Text) + computation.validate(textBox13.Text);

            textBox14.Text = res.ToString();
        }

        private void txtBox4_TextChanged(object sender, EventArgs e)
        {
            string str = txtBox4.Text;

            txtBox4.Text = computation.commaSeparator(str);

            txtBox4.Select(txtBox4.Text.Length, 0);
            double res = computation.validate(txtBox1.Text) + computation.validate(txtBox2.Text) + computation.validate(txtBox3.Text)
                 + computation.validate(txtBox4.Text) + computation.validate(txtBox5.Text) + computation.validate(txtBox6.Text)
                 + computation.validate(txtBox7.Text) + computation.validate(txtBox8.Text) + computation.validate(txtBox9.Text)
                 + computation.validate(txtBox10.Text) + computation.validate(textBox13.Text);

            textBox14.Text = res.ToString();
        }

        private void txtBox5_TextChanged(object sender, EventArgs e)
        {
            string str = txtBox5.Text;

            txtBox5.Text = computation.commaSeparator(str);

            txtBox5.Select(txtBox5.Text.Length, 0);
            double res = computation.validate(txtBox1.Text) + computation.validate(txtBox2.Text) + computation.validate(txtBox3.Text)
                 + computation.validate(txtBox4.Text) + computation.validate(txtBox5.Text) + computation.validate(txtBox6.Text)
                 + computation.validate(txtBox7.Text) + computation.validate(txtBox8.Text) + computation.validate(txtBox9.Text)
                 + computation.validate(txtBox10.Text) + computation.validate(textBox13.Text);

            textBox14.Text = res.ToString();
        }

        private void txtBox6_TextChanged(object sender, EventArgs e)
        {
            string str = txtBox6.Text;

            txtBox6.Text = computation.commaSeparator(str);

            txtBox6.Select(txtBox6.Text.Length, 0);
            double res = computation.validate(txtBox1.Text) + computation.validate(txtBox2.Text) + computation.validate(txtBox3.Text)
                 + computation.validate(txtBox4.Text) + computation.validate(txtBox5.Text) + computation.validate(txtBox6.Text)
                 + computation.validate(txtBox7.Text) + computation.validate(txtBox8.Text) + computation.validate(txtBox9.Text)
                 + computation.validate(txtBox10.Text) + computation.validate(textBox13.Text);

            textBox14.Text = res.ToString();
        }

        private void txtBox7_TextChanged(object sender, EventArgs e)
        {
            string str = txtBox7.Text;

            txtBox7.Text = computation.commaSeparator(str);

            txtBox7.Select(txtBox7.Text.Length, 0);
            double res = computation.validate(txtBox1.Text) + computation.validate(txtBox2.Text) + computation.validate(txtBox3.Text)
                 + computation.validate(txtBox4.Text) + computation.validate(txtBox5.Text) + computation.validate(txtBox6.Text)
                 + computation.validate(txtBox7.Text) + computation.validate(txtBox8.Text) + computation.validate(txtBox9.Text)
                 + computation.validate(txtBox10.Text) + computation.validate(textBox13.Text);

            textBox14.Text = res.ToString();
        }

        private void txtBox8_TextChanged(object sender, EventArgs e)
        {
            string str = txtBox8.Text;

            txtBox8.Text = computation.commaSeparator(str);

            txtBox8.Select(txtBox8.Text.Length, 0);
            double res = computation.validate(txtBox1.Text) + computation.validate(txtBox2.Text) + computation.validate(txtBox3.Text)
                 + computation.validate(txtBox4.Text) + computation.validate(txtBox5.Text) + computation.validate(txtBox6.Text)
                 + computation.validate(txtBox7.Text) + computation.validate(txtBox8.Text) + computation.validate(txtBox9.Text)
                 + computation.validate(txtBox10.Text) + computation.validate(textBox13.Text);

            textBox14.Text = res.ToString();
        }

        private void txtBox9_TextChanged(object sender, EventArgs e)
        {
            string str = txtBox9.Text;

            txtBox9.Text = computation.commaSeparator(str);

            txtBox9.Select(txtBox9.Text.Length, 0);
            double res = computation.validate(txtBox1.Text) + computation.validate(txtBox2.Text) + computation.validate(txtBox3.Text)
                 + computation.validate(txtBox4.Text) + computation.validate(txtBox5.Text) + computation.validate(txtBox6.Text)
                 + computation.validate(txtBox7.Text) + computation.validate(txtBox8.Text) + computation.validate(txtBox9.Text)
                 + computation.validate(txtBox10.Text) + computation.validate(textBox13.Text);

            textBox14.Text = res.ToString();
        }

        private void txtBox10_TextChanged(object sender, EventArgs e)
        {
            string str = txtBox10.Text;

            txtBox10.Text = computation.commaSeparator(str);

            txtBox10.Select(txtBox10.Text.Length, 0);
            double res = computation.validate(txtBox1.Text) + computation.validate(txtBox2.Text) + computation.validate(txtBox3.Text)
                 + computation.validate(txtBox4.Text) + computation.validate(txtBox5.Text) + computation.validate(txtBox6.Text)
                 + computation.validate(txtBox7.Text) + computation.validate(txtBox8.Text) + computation.validate(txtBox9.Text)
                 + computation.validate(txtBox10.Text) + computation.validate(textBox13.Text);

            textBox14.Text = res.ToString();


        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string str = textBox3.Text;

            textBox3.Text = computation.commaSeparator(str);

            textBox3.Select(textBox3.Text.Length, 0);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string str = textBox2.Text;

            textBox2.Text = computation.commaSeparator(str);

            textBox2.Select(textBox2.Text.Length, 0);
            double res = computation.validate(textBox1.Text) - computation.validate(textBox2.Text);

            textBox3.Text = res.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string str = textBox1.Text;

            textBox1.Text = computation.commaSeparator(str);

            textBox1.Select(textBox1.Text.Length, 0);
            double res = computation.validate(textBox1.Text) - computation.validate(textBox2.Text);

            textBox3.Text = res.ToString();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void txtBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBox7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBox8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBox9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBox10_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            string str = textBox3.Text;

            textBox3.Text = computation.commaSeparator(str);

            textBox3.Select(textBox3.Text.Length, 0);
            double res = computation.validate(textBox3.Text) + computation.validate(textBox13.Text);

            textBox4.Text = res.ToString();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (computation.validate(textBox4.Text) > 0 && (computation.validate(textBox4.Text) > computation.validate(textBox16.Text)))
                textBox17.Text = textBox16.Text;

            else
                if (computation.validate(textBox4.Text) > 0 && (computation.validate(textBox4.Text) < computation.validate(textBox16.Text)))
                    textBox17.Text = textBox4.Text;

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            if (computation.validate(textBox4.Text) > 0 && (computation.validate(textBox4.Text) > computation.validate(textBox16.Text)))
                textBox17.Text = textBox16.Text;

            else
                if (computation.validate(textBox4.Text) > 0 && (computation.validate(textBox4.Text) < computation.validate(textBox16.Text)))
                    textBox17.Text = textBox4.Text;
                else
                    textBox17.Text = "";

            textBox5.Text = (computation.validate(textBox4.Text) - computation.validate(textBox17.Text)).ToString();
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

            if (textBox17.Text == "" && computation.validate(textBox4.Text) > 0)
                textBox15.Text = textBox17.Text;
            else
                if (textBox17.Text == "" && computation.validate(textBox4.Text) < 0)
                    textBox15.Text = (computation.validate(textBox16.Text) + computation.validate(textBox4.Text)).ToString();
                else
                    textBox15.Text = "";

            textBox5.Text = (computation.validate(textBox4.Text) - computation.validate(textBox17.Text)).ToString();



        }

      

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            if (computation.validate(textBox5.Text) == 0 || computation.validate(textBox5.Text) < 0)
                textBox12.Text = "";
            else
                if (computation.validate(textBox5.Text) > 0 && General_Templat6.secManAgr == false)
                    textBox12.Text = (computation.validate(textBox5.Text) * 0.67).ToString();

                else
                    if (computation.validate(textBox5.Text) > 0 && General_Templat6.secManAgr == true)
                        textBox12.Text = (computation.validate(textBox5.Text)).ToString();

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            string str = textBox12.Text;

            textBox12.Text = computation.commaSeparator(str);

            textBox12.Select(textBox12.Text.Length, 0);
            textBox11.Text = (computation.validate(textBox6.Text) - computation.validate(textBox12.Text)).ToString();
            textBox23.Text = (computation.validate(textBox5.Text) - computation.validate(textBox12.Text)).ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           // textBox11.Text = (computation.validate(textBox6.Text) - computation.validate(textBox12.Text)).ToString();
        }


        private void textBox12_TextChanged_1(object sender, EventArgs e)
        {
            textBox11.Text = (computation.validate(textBox6.Text) - computation.validate(textBox12.Text)).ToString();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_2(object sender, EventArgs e)
        {
            string str = textBox3.Text;

            textBox3.Text = computation.commaSeparator(str);

            textBox3.Select(textBox3.Text.Length, 0);
            double res = computation.validate(textBox3.Text) + computation.validate(textBox14.Text);

            textBox4.Text = res.ToString();
        }

        private void textBox4_TextChanged_2(object sender, EventArgs e)
        {
            string str = textBox4.Text;

            textBox4.Text = computation.commaSeparator(str);

            textBox4.Select(textBox4.Text.Length, 0);
            

            if (computation.validate(textBox4.Text) > 0 && (computation.validate(textBox4.Text) > computation.validate(textBox16.Text)))
                textBox17.Text = textBox16.Text;
            else
                if (computation.validate(textBox4.Text) > 0 && (computation.validate(textBox4.Text) == computation.validate(textBox16.Text)))
                    //textBox17.Text = textBox17.Text = (computation.validate(textBox4.Text) - computation.validate(textBox16.Text)).ToString();
                    textBox17.Text = textBox16.Text;

                else
                    if (computation.validate(textBox4.Text) > 0 && (computation.validate(textBox4.Text) < computation.validate(textBox16.Text)))
                        textBox17.Text = textBox4.Text;

            if (computation.validate(textBox4.Text) < 0)
            {
                textBox15.Text = (Math.Abs(computation.validate(textBox4.Text)) + Math.Abs(computation.validate(textBox16.Text))).ToString();
                textBox17.Text = "0";
            }
            else
            {
                if ((computation.validate(textBox4.Text) - computation.validate(textBox16.Text)) > 0)
                {
                   // textBox15.Text = (computation.validate(textBox4.Text) - computation.validate(textBox16.Text)).ToString();
                    textBox15.Text = "0";
                }
                else
                {
                    textBox15.Text = (computation.validate(textBox16.Text) - computation.validate(textBox17.Text)).ToString();
                }
            }

                if (computation.validate(textBox4.Text) - computation.validate(textBox17.Text) > 0)
                    textBox5.Text = (computation.validate(textBox4.Text) - computation.validate(textBox17.Text)).ToString();

                else
                    textBox5.Text = "0";
            
        }

        private void textBox16_TextChanged_1(object sender, EventArgs e)
        {
            string str = textBox16.Text;

            textBox16.Text = computation.commaSeparator(str);

            textBox16.Select(textBox16.Text.Length, 0);
            
            
            
            if (computation.validate(textBox4.Text) > 0 && (computation.validate(textBox4.Text) > computation.validate(textBox16.Text)))
                textBox17.Text = textBox16.Text;
            else
                if (computation.validate(textBox4.Text) > 0 && (computation.validate(textBox4.Text) == computation.validate(textBox16.Text)))
                    //textBox17.Text = (computation.validate(textBox4.Text) - computation.validate(textBox16.Text)).ToString();
                    textBox17.Text = textBox16.Text;
                else
                    if (computation.validate(textBox4.Text) > 0 && (computation.validate(textBox4.Text) < computation.validate(textBox16.Text)))
                        textBox17.Text = textBox4.Text;

            if (computation.validate(textBox4.Text) < 0)
            {
                textBox15.Text = (Math.Abs(computation.validate(textBox4.Text)) + Math.Abs(computation.validate(textBox16.Text))).ToString();
                textBox17.Text = "0";
            }
            else
            {
                if ((computation.validate(textBox4.Text) - computation.validate(textBox16.Text)) > 0)
                    //textBox15.Text = (computation.validate(textBox4.Text) - computation.validate(textBox16.Text)).ToString();
                    textBox15.Text = "0";
                else
                    if ((computation.validate(textBox4.Text) - computation.validate(textBox16.Text)) < 0)
                        textBox15.Text = (computation.validate(textBox16.Text) - computation.validate(textBox17.Text)).ToString();
                    else
                        textBox15.Text = (computation.validate(textBox16.Text) - computation.validate(textBox17.Text)).ToString();
            }
        }

        private void textBox17_TextChanged_1(object sender, EventArgs e)
        {
            string str = textBox17.Text;

            textBox17.Text = computation.commaSeparator(str);

            textBox17.Select(textBox17.Text.Length, 0);
            

            if (computation.validate(textBox4.Text) < 0)
            {
                textBox15.Text = (Math.Abs(computation.validate(textBox4.Text)) + Math.Abs(computation.validate(textBox16.Text))).ToString();
                textBox17.Text = "0";
            }
            else
            {
                if ((computation.validate(textBox4.Text) - computation.validate(textBox16.Text)) > 0)
                    textBox15.Text = (computation.validate(textBox4.Text) - computation.validate(textBox16.Text)).ToString();
                else
                    textBox15.Text = (computation.validate(textBox16.Text) - computation.validate(textBox17.Text)).ToString();
            }

            textBox5.Text = (computation.validate(textBox4.Text) - computation.validate(textBox17.Text)).ToString();

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            
            string str = textBox15.Text;

            textBox15.Text = computation.commaSeparator(str);

            textBox15.Select(textBox15.Text.Length, 0);

        }

 

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox6.Clear();
            string str = textBox7.Text;

            textBox7.Text = computation.commaSeparator(str);

            textBox7.Select(textBox7.Text.Length, 0);
            double res = (computation.validate(textBox10.Text) + computation.validate(textBox9.Text) + computation.validate(textBox7.Text)
                            + computation.validate(textBox8.Text));
            textBox6.Text = res.ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox6.Clear();
            string str = textBox8.Text;

            textBox8.Text = computation.commaSeparator(str);

            textBox8.Select(textBox8.Text.Length, 0);
            double res = (computation.validate(textBox10.Text) + computation.validate(textBox9.Text) + computation.validate(textBox7.Text)
                            + computation.validate(textBox8.Text) );
            textBox6.Text = res.ToString();
        }

        //private void textBox10_TextChanged(object sender, EventArgs e)
        //{
            
        //}

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox6.Clear();
            string str = textBox9.Text;

            textBox9.Text = computation.commaSeparator(str);

            textBox9.Select(textBox9.Text.Length, 0);
            double res = (computation.validate(textBox10.Text) + computation.validate(textBox9.Text) + computation.validate(textBox7.Text)
                            + computation.validate(textBox8.Text));
            textBox6.Text = res.ToString();
        }

        private void textBox12_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void textBx10_TextChanged(object sender, EventArgs e)
        {
            textBox6.Clear();
            string str = textBox10.Text;

            textBox10.Text = computation.commaSeparator(str);

            textBox10.Select(textBox10.Text.Length, 0);
            double res = (computation.validate(textBox10.Text) + computation.validate(textBox9.Text) + computation.validate(textBox7.Text)
                            + computation.validate(textBox8.Text) );
            textBox6.Text = res.ToString();
        }

        private void textBox5_TextChanged_2(object sender, EventArgs e)
        {
            //MessageBox.Show(General_Templat6.secManAgr.ToString());
            string str = textBox5.Text;

            textBox5.Text = computation.commaSeparator(str);

            textBox5.Select(textBox5.Text.Length, 0);
            if (computation.validate(textBox5.Text) == 0 || computation.validate(textBox5.Text) < 0)
                textBox12.Text = "0";

            if (! minTaxBasis.Checked)
            {

                if (General_Templat6.secManAgr == false && computation.validate(textBox6.Text) < (computation.validate(textBox5.Text) * 0.6667))
                    textBox12.Text = textBox6.Text;
                else if (General_Templat6.secManAgr == false && computation.validate(textBox6.Text) >= (computation.validate(textBox5.Text) * 0.6667))
                    textBox12.Text = (computation.validate(textBox5.Text) * 0.6667).ToString();

                else
                    if (General_Templat6.secManAgr == true && computation.validate(textBox6.Text) < computation.validate(textBox5.Text))
                        textBox12.Text = textBox6.Text;
                    else if (General_Templat6.secManAgr == true && computation.validate(textBox6.Text) >= computation.validate(textBox5.Text))
                        textBox12.Text = textBox5.Text;
            }

            else
            {
                 if (General_Templat6.secManAgr == false && computation.validate(textBox6.Text) < (computation.validate(textBox5.Text) * 0.6667))
                    textBox12.Text = textBox6.Text;
                else if (General_Templat6.secManAgr == false && computation.validate(textBox6.Text) >= (computation.validate(textBox5.Text) * 0.6667))
                    textBox12.Text = (computation.validate(textBox5.Text)).ToString();

                else
                    if (General_Templat6.secManAgr == true && computation.validate(textBox6.Text) < computation.validate(textBox5.Text))
                        textBox12.Text = textBox6.Text;
                    else if (General_Templat6.secManAgr == true && computation.validate(textBox6.Text) >= computation.validate(textBox5.Text))
                        textBox12.Text = textBox5.Text;
            }


            textBox23.Text = (computation.validate(textBox5.Text) - computation.validate(textBox12.Text)).ToString();
            }
            
        

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            string str = textBox6.Text;

            textBox6.Text = computation.commaSeparator(str);

            textBox6.Select(textBox6.Text.Length, 0);

            if (computation.validate(textBox6.Text) == 0)
            {
                textBox12.Text = "0";
            }

            else
                if (General_Templat6.secManAgr == false && computation.validate(textBox6.Text) < (computation.validate(textBox5.Text) * 0.6667))
                    textBox12.Text = textBox6.Text;
                else if (General_Templat6.secManAgr == false && computation.validate(textBox6.Text) >= (computation.validate(textBox5.Text) * 0.6667))
                    textBox12.Text = (computation.validate(textBox5.Text) * 0.6667).ToString();

                else
                    if (General_Templat6.secManAgr == true && computation.validate(textBox6.Text) < computation.validate(textBox5.Text) )
                        textBox12.Text = textBox6.Text;
                    else if (General_Templat6.secManAgr == true && computation.validate(textBox6.Text) >= computation.validate(textBox5.Text))
                        textBox12.Text = textBox5.Text;


            textBox11.Text = (computation.validate(textBox6.Text) - computation.validate(textBox12.Text)).ToString();
        }

        private void textBox11_TextChanged_1(object sender, EventArgs e)
        {
            string str = textBox11.Text;

            textBox11.Text = computation.commaSeparator(str);

            textBox11.Select(textBox11.Text.Length, 0);
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            string str = textBox23.Text;

            textBox23.Text = computation.commaSeparator(str);

            textBox23.Select(textBox23.Text.Length, 0);

            textBox18.Text = (0.30 * computation.validate(textBox23.Text)).ToString();

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            string str = textBox18.Text;

            textBox18.Text = computation.commaSeparator(str);

            textBox18.Select(textBox18.Text.Length, 0);
            textBox22.Text = (computation.validate(textBox18.Text) - computation.validate(textBox24.Text)).ToString();
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            string str = textBox22.Text;

            textBox22.Text = computation.commaSeparator(str);

            textBox22.Select(textBox22.Text.Length, 0);

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            string str = textBox19.Text;

            textBox19.Text = computation.commaSeparator(str);

            textBox19.Select(textBox19.Text.Length, 0);

            textBox20.Text = (computation.validate(textBox19.Text) - computation.validate(textBox21.Text)).ToString();
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            string str = textBox21.Text;

            textBox21.Text = computation.commaSeparator(str);

            textBox21.Select(textBox21.Text.Length, 0);

            textBox20.Text = (computation.validate(textBox19.Text) - computation.validate(textBox21.Text)).ToString();
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            string str = textBox20.Text;

            textBox20.Text = computation.commaSeparator(str);

            textBox20.Select(textBox20.Text.Length, 0);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            STATEMENT_OF_TAX_POSITION_FORM stateForm = new STATEMENT_OF_TAX_POSITION_FORM();
            stateForm.Show();
        }

        private void percent2label_Click(object sender, EventArgs e)
        {

        }

        private void percent1label_Click(object sender, EventArgs e)
        {

        }

        private void percent2text_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

      

       

        

        
       


    }
}

