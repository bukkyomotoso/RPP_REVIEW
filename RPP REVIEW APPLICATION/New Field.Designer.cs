namespace RPP_REVIEW_APPLICATION
{
    partial class New_Field
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxAdditional = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxAdditional
            // 
            this.comboBoxAdditional.FormattingEnabled = true;
            this.comboBoxAdditional.Items.AddRange(new object[] {
            "Advert and public relation",
            "Capital Expenditure",
            "Exchange Loss",
            "Expenses on earning management fees",
            "Fines and Penalties",
            "Impairment loss",
            "Import Duty ",
            "Legal Expenses iro Tax appeal, stamp duties,offences, renewal,",
            "Loss on disposal of fixed asset",
            "Loss on disposal of investment",
            "Miscellaneous Expenses",
            "Payroll Tax Expenses",
            "Pre-Operational Expenses",
            "Provisions for Bad & Doubtful Debts",
            "Provisions for gratuity",
            "\"Recoverable sums under insurance on contract of indemnity",
            "\"",
            "Revesal of previously disallowed expenses into income",
            "Subscription",
            "Sum reserved out of profit",
            "Sundry Expenses",
            "Taxes/Tax expenses",
            "Undisclosed Income",
            "Withdrawal of capital"});
            this.comboBoxAdditional.Location = new System.Drawing.Point(3, 28);
            this.comboBoxAdditional.Name = "comboBoxAdditional";
            this.comboBoxAdditional.Size = new System.Drawing.Size(352, 21);
            this.comboBoxAdditional.TabIndex = 0;
            this.comboBoxAdditional.SelectedIndexChanged += new System.EventHandler(this.comboBoxAdditional_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the field you want to add";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(192, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // New_Field
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 136);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAdditional);
            this.Name = "New_Field";
            this.Text = "New_Field";
            this.Load += new System.EventHandler(this.New_Field_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAdditional;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}