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
    public partial class  General_Templat6 : Form
    {
        public General_Templat6()
        {
            InitializeComponent();
        }

        public static String tinPNJ = "";
        public static String companynamePNJ = "";
        public static String yearend = "";
        public static Boolean secManAgr = false;
        public static String addressPNJ = "";
        public static String scheduleOfficer = "";
        public static String scheduleOfficerRank = "";
        public static String supervisor = "";
        public static String supervisorRank = "";

        
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                BusaddText.Text = regaddText.Text;
                BusaddText.Enabled = false;
                Busadd2Text.Text = regadd2Text.Text;
                Busadd2Text.Enabled = false;
                //Busadd3Text.Text = regadd3Text.Text;
                //Busadd3Text.Enabled = false;
                BusaddstateText.Text = regaddstateText.Text;
                BusaddstateText.Enabled = false;

            }

            else
            {
                BusaddText.Enabled = true;
                BusaddText.Clear();
                Busadd2Text.Enabled = true;
                Busadd2Text.Clear();
                //Busadd3Text.Enabled = true;
                //Busadd3Text.Clear();
                BusaddstateText.Enabled = true;
               // BusaddstateText.Clear();
                BusaddstateText.Text = "";
              
            }
            


        }

        private void SectorCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            ISICCombo.Text = "";
            int elements = SectorCombo.SelectedIndex;

            if (elements == 0)
            {
                string[] s =  {"Accommodation","Food and beverage service activities"};
                this.ISICCombo.DataSource = s;
                secManAgr = false;
            }

            else if (elements == 13)
            {
                string[] s =  {"Mining of coal and lignite","Extraction of crude petroleum and natural gas","Mining of metal ores",
                                "Other mining and quarrying","Mining support service activities"};
                this.ISICCombo.DataSource = s;
                secManAgr = false;
            }

            else if (elements == 12)
            {
                string[] s =  {"Manufacture of food products","Manufacture of beverages","Manufacture of tobacco products",
                                  "Manufacture of textiles","Manufacture of wearing apparel",
                                  "Manufacture of leather and related products",
                "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials",
                "Manufacture of paper and paper products","Printing and reproduction of recorded media",
                "Manufacture of coke and refined petroleum products","Manufacture of chemicals and chemical products",
                "Manufacture of basic pharmaceutical products and pharmaceutical preparations",
                "Manufacture of rubber and plastics products","Manufacture of other non-metallic mineral products",
                "Manufacture of basic metals","Manufacture of fabricated metal products, except machinery and equipment",
                "Manufacture of computer, electronic and optical products", "Manufacture of electrical equipment",
                "Manufacture of machinery and equipment n.e.c.","Manufacture of motor vehicles, trailers and semi-trailers",
                "Manufacture of other transport equipment","Manufacture of furniture","Other manufacturing",
                "Repair and installation of machinery and equipment"};
                this.ISICCombo.DataSource = s;
                secManAgr = true;
            }

            else if (elements == 8)
            {
                string[] s = { "Electricity, gas, steam and air conditioning supply" };
                this.ISICCombo.DataSource = s;
                secManAgr = false;

            }

            else if (elements == 19)
            {
                string[] s = { "Water collection, treatment and supply","Sewerage",
                                 "Waste collection, treatment and disposal activities; materials recovery",
                                 "Remediation activities and other waste management services"};
                this.ISICCombo.DataSource = s;
                secManAgr = false;

            }

            else if (elements == 6)
            {
                string[] s = { "Construction of buildings","Civil engineering","Specialized construction activities"};
                this.ISICCombo.DataSource = s;
                secManAgr = false;

            }

            

            else if (elements == 20)
            {
                string[] s = { "Wholesale and retail trade and repair of motor vehicles and motorcycles",
                                 "Wholesale trade, except of motor vehicles and motorcycles",
                                 "Retail trade, except of motor vehicles and motorcycles"};
                this.ISICCombo.DataSource = s;
                secManAgr = false;

            }

            else if (elements == 18)
            {
                string[] s = { "Land transport and transport via pipelines","Water transport","Air transport",
                                 "Warehousing and support activities for transportation"," Postal and courier activities"};
                this.ISICCombo.DataSource = s;
                secManAgr = false;


            }

            else if (elements == 4)
            {
                string[] s = { "Crop and animal production, hunting and related service activities","Forestry and logging",
                                "Fishing and aquaculture"};
                this.ISICCombo.DataSource = s;
                secManAgr = true;
            }

            else if (elements == 11)
            {
             string[] s = { "Publishing Activities", 
                          "Motion picture, video and television programme production, sound recording and music publishing activities",
                          "Programming and broadcasting activities","Telecommunications",
                          "Computer programming, consultancy and related activities","Information service activities"};
             this.ISICCombo.DataSource = s;
             secManAgr = false;
            }

            else if (elements == 9)
            {
                string[] s = { "Financial service activities, except insurance and pension funding",
                                 "Insurance, reinsurance and pension funding, except compulsory social security",
                                 "Activities auxiliary to financial service and insurance activities" };
                this.ISICCombo.DataSource = s;
                secManAgr = false;
            }

            else if (elements == 17)
            {
                string[] s = { "Real estate activities" };
                this.ISICCombo.DataSource = s;
                secManAgr = false;
            }
            
            else if (elements == 15)
            {
                string[] s = { "Legal and accounting activities","Activities of head offices; management consultancy activities",
                                "Architectural and engineering activities; technical testing and analysis",
                                "Scientific research and development","Advertising and market research",
                                "Other professional, scientific and technical activities","Veterinary activities"};
                this.ISICCombo.DataSource = s;
                secManAgr = false;
            }

              else if (elements == 3)
            {
                string[] s = { "Rental and leasing activities","Employment activities",
                                 "Travel agency, tour operator, reservation service and related activities",
                                 "Security and investigation activities","Services to buildings and landscape activities",
                                 "Office administrative, office support and other business support activities"};
                this.ISICCombo.DataSource = s;
                secManAgr = false;
            }
              

             else if (elements == 16)
            {
                string[] s = { "Public administration and defence; compulsory social security"};
                this.ISICCombo.DataSource = s;
                secManAgr = false;

            }

            else if (elements == 7)
            {
                string[] s = { "Education" };
                this.ISICCombo.DataSource = s;
                secManAgr = false;

            }
              
            else if (elements == 10)
            {
                string[] s = { "Human health activities","Residential care activities",
                                 "Social work activities without accommodation" };
                this.ISICCombo.DataSource = s;
                secManAgr = false;

            }
            else if (elements == 5)
            {
                string[] s = { "Creative, arts and entertainment activities",
                                 "Libraries, archives, museums and other cultural activities",
                                 "Gambling and betting activities","Sports activities and amusement and recreation activities"};
                this.ISICCombo.DataSource = s;
                secManAgr = false;

            }

            else if (elements == 14)
            {
                string[] s = { "Activities of membership organizations","Repair of computers and personal and household goods",
                                 "Other personal service activities"};
                this.ISICCombo.DataSource = s;
                secManAgr = false;


            }
              
            else if (elements == 2)
            {
                string[] s = { "Activities of households as employers of domestic personnel",
                                 "Undifferentiated goods- and services-producing activities of private households for own use"};
                this.ISICCombo.DataSource = s;
                secManAgr = false;

            }

            else if (elements == 1)
            {
                string[] s = { "Activities of extraterritorial organizations and bodies" };
                this.ISICCombo.DataSource = s;
                secManAgr = false;


            }
            

           






            
            // ISICCombo.Items.Add(s);
            //this.ISICCombo.DataSource = s;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                CurConText.Text = curAudText.Text;
                ConAddText.Text = AudAddText.Text;
                ConAdd2Text.Text = AudAdd2Text.Text;
                ConAddstateText.Text = AudAddstateText.Text;
                ConPhone1Text.Text = AudPhone1Text.Text;
                ConPhone2Text.Text = AudPhone2Text.Text;
                CurConText.Enabled = false;
                ConAddText.Enabled = false;
                ConAdd2Text.Enabled = false;
                ConAddstateText.Enabled = false;
                ConPhone1Text.Enabled = false;
                ConPhone2Text.Enabled = false;

            }

            else

            {
                CurConText.Enabled = true;
                CurConText.Clear();
                ConAddText.Enabled = true;
                ConAddText.Clear();
                ConAdd2Text.Enabled = true;
                ConAdd2Text.Clear();
                ConAddstateText.Enabled = true;
                //ConAddstateText.Clear();
                ConPhone1Text.Enabled = true;
                ConPhone1Text.Clear();
                ConPhone2Text.Enabled = true;
                ConPhone2Text.Clear();
            
            
            }
        }

        private void AudAddText_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                ConAddText.Text = AudAddText.Text;
                ConAddText.Enabled = false;
                
            }

            else
            {
                ConAddText.Enabled = true;
                ConAddText.Clear();
            }


        }

        

        private void curAudText_TextChanged(object sender, EventArgs e)
        { 
            if(checkBox1.Checked == true)
            CurConText.Text = curAudText.Text;
        }

       

        private void AudPhone1Text_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            ConPhone1Text.Text = AudPhone1Text.Text;
        }

        private void AudPhone2Text_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            ConPhone2Text.Text = AudPhone2Text.Text;
        }

        private void regaddText_TextChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
                BusaddText.Text = regaddText.Text;
        }

        private void regadd3Text_TextChanged(object sender, EventArgs e)
        {
            //if (checkBox4.Checked == true)
                //Busadd3Text.Text = regadd3Text.Text;
        }

        private void regadd2Text_TextChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
                Busadd2Text.Text = regadd2Text.Text; 
        }

        private void regaddstateText_TextChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
                BusaddstateText.Text = regaddstateText.Text;
        }

        private void AudAdd2Text_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                ConAdd2Text.Text = AudAdd2Text.Text;
        }

        private void AudAddstateText_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                ConAddstateText.Text = AudAddstateText.Text;
        }

        private void GenTempButton_Click(object sender, EventArgs e)
        {
            companynamePNJ = taxpayerText.Text;
            tinPNJ = tinText.Text;
            addressPNJ = BusaddText.Text + " " + Busadd2Text.Text + " " + BusaddstateText.Text;
            yearend = YearEndcomboBox.Text;
            scheduleOfficer = textBox15.Text;
            scheduleOfficerRank = comboBox4.Text;
            supervisor = textBox16.Text;
            supervisorRank = comboBox5.Text;
            General_Template gentemplate = new General_Template();
            gentemplate.Show();
        }

       

        private void AudPhone1Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void AudPhone2Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void ConPhone1Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void ConPhone2Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void General_Templat6_Load(object sender, EventArgs e)
        {
      
            dateTimePicker3.MaxDate = dateTimePicker2.Value;
            YearEndcomboBox.Text = "31-Dec";
            comboBoxYear.Text = (DateTime.Now.Year -2).ToString();
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MMM-yyyy";

            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "dd-MMM-yyyy";

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "dd-MMM-yyyy";
            
            for (int i = 1950; i <= DateTime.Now.Year; i++)
                comboBoxYear.Items.Add(i+"");
            comboBoxYear.Items.Add("Yet to be Audited");
            comboBoxYear.Items.RemoveAt(0);
                
            
        }

        private void regaddstateText_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
                BusaddstateText.Text = regaddstateText.Text;
        }

        private void SectorCombo_TextChanged(object sender, EventArgs e)
        {
            char[] c = { ' ', ',', ';' };
            int itemsIndex = 0;
            foreach (string item in SectorCombo.Items)
            {
                String[] s = item.Split(c);
                List<String> mylist = new List<string>();
                foreach (string i in s)
                {
                    mylist.Add(i.ToLower());
                }
                if (mylist.Contains(SectorCombo.Text.ToLower()))
                {
                    SectorCombo.SelectedIndex = itemsIndex;
                }
                itemsIndex++;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void ConPhone1Text_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void ConPhone2Text_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox11_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void tinText_TextChanged(object sender, EventArgs e)
        {
           /* string str = tinText.Text;
            if (tinText.TextLength == 8 && tin) 
            {
                tinText.Text += "-";
            }
            tinText.Select(tinText.Text.Length, 0);*/
            
            
            
        }

        private void tinText_Leave(object sender, EventArgs e)
        {
            if (tinText.TextLength != 13 && tinText.Text !="")
            {
                MessageBox.Show("Please, enter a valid 13 character TIN", "Invalid TIN", MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                //tinText.Select(tinText.Text.Length, 0);
                //tinText.fo
                ActiveControl = tinText;
            }
        }

        private void tinText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 45 )
	        e.Handled = true;
            if (e.KeyChar == 45)
            {
                if ((sender as TextBox).Text.Contains("-"))
                {

                    e.Handled = true;
                }
            }
        }

        

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.TextLength != 11 && textBox11.Text!="")
            {
                MessageBox.Show("Please, enter a valid 11 digit Phone Number", "Invalid Phone", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                ActiveControl = textBox11;
            }
        }

        private void AudPhone1Text_Leave(object sender, EventArgs e)
        {
            if (AudPhone1Text.TextLength != 11 && AudPhone1Text.Text !="")
            {
                MessageBox.Show("Please, enter a valid 11 digit Phone Number", "Invalid Phone", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                ActiveControl = AudPhone1Text;
            }
            
        }


        private void ConPhone1Text_Leave_1(object sender, EventArgs e)
        {
            if (ConPhone1Text.TextLength != 11 && ConPhone1Text.Text != "")
            {
                MessageBox.Show("Please, enter a valid 11 digit Phone Number", "Invalid Phone", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                ActiveControl = ConPhone1Text;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MaxDate = DateTime.Today;
            dateTimePicker3.MinDate = dateTimePicker2.Value;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.MaxDate = DateTime.Today;
        }

       

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxYear.Text == "Yet to be Audited")
                textBox2.Visible = false;
            else
                textBox2.Visible = true;
                
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

       

       
    }
}

