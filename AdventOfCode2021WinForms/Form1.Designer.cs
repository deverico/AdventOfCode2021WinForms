namespace AdventOfCode2021WinForms
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.daysListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.simpleDataRadioButton = new System.Windows.Forms.RadioButton();
            this.fullDataRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Solve";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(139, 68);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(649, 364);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // daysListBox
            // 
            this.daysListBox.FormattingEnabled = true;
            this.daysListBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11"});
            this.daysListBox.Location = new System.Drawing.Point(13, 12);
            this.daysListBox.Name = "daysListBox";
            this.daysListBox.Size = new System.Drawing.Size(120, 420);
            this.daysListBox.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fullDataRadioButton);
            this.groupBox1.Controls.Add(this.simpleDataRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(139, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 50);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // simpleDataRadioButton
            // 
            this.simpleDataRadioButton.AutoSize = true;
            this.simpleDataRadioButton.Location = new System.Drawing.Point(15, 19);
            this.simpleDataRadioButton.Name = "simpleDataRadioButton";
            this.simpleDataRadioButton.Size = new System.Drawing.Size(56, 17);
            this.simpleDataRadioButton.TabIndex = 0;
            this.simpleDataRadioButton.TabStop = true;
            this.simpleDataRadioButton.Text = "Simple";
            this.simpleDataRadioButton.UseVisualStyleBackColor = true;
            // 
            // fullDataRadioButton
            // 
            this.fullDataRadioButton.AutoSize = true;
            this.fullDataRadioButton.Location = new System.Drawing.Point(98, 20);
            this.fullDataRadioButton.Name = "fullDataRadioButton";
            this.fullDataRadioButton.Size = new System.Drawing.Size(41, 17);
            this.fullDataRadioButton.TabIndex = 1;
            this.fullDataRadioButton.TabStop = true;
            this.fullDataRadioButton.Text = "Full";
            this.fullDataRadioButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.daysListBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListBox daysListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton fullDataRadioButton;
        private System.Windows.Forms.RadioButton simpleDataRadioButton;
    }
}

