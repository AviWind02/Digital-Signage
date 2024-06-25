using System.Windows.Forms;

namespace DigitalSignage.Windows
{
    partial class FormSettingWindow
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
            this.components = new System.ComponentModel.Container();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxDelay = new System.Windows.Forms.ComboBox();
            this.comboBoxVideoRate = new System.Windows.Forms.ComboBox();
            this.comboBoxPPTRate = new System.Windows.Forms.ComboBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonSaveValues = new System.Windows.Forms.Button();
            this.buttonLoadValues = new System.Windows.Forms.Button();
            this.textBoxCounterPerVideo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCounterPerPPT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPowerPointRate = new System.Windows.Forms.TextBox();
            this.textBoxSlideDelay = new System.Windows.Forms.TextBox();
            this.textBoxImageRate = new System.Windows.Forms.TextBox();
            this.textBoxVideoRate = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonOpenLogs = new System.Windows.Forms.Button();
            this.buttonSaveLogs = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonOpenTxtFile = new System.Windows.Forms.Button();
            this.textSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.textBox9);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.textBox8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.textBox7);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Location = new System.Drawing.Point(289, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(220, 150);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Directory Stuff";
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(6, 121);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(101, 23);
            this.button8.TabIndex = 39;
            this.button8.Text = "Reset Directory";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(113, 121);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(101, 23);
            this.button7.TabIndex = 35;
            this.button7.Text = "Open Directory";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button_OpenDirectory);
            // 
            // textBox9
            // 
            this.textBox9.Enabled = false;
            this.textBox9.Location = new System.Drawing.Point(117, 91);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(36, 20);
            this.textBox9.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(114, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "# of Images";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "# of PPT";
            // 
            // textBox8
            // 
            this.textBox8.Enabled = false;
            this.textBox8.Location = new System.Drawing.Point(61, 91);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(36, 20);
            this.textBox8.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "# Videos";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(6, 19);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(208, 20);
            this.textBox7.TabIndex = 34;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(6, 45);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(208, 23);
            this.button4.TabIndex = 34;
            this.button4.Text = "Set Directory";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(9, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(36, 20);
            this.textBox1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxDelay);
            this.groupBox3.Controls.Add(this.comboBoxVideoRate);
            this.groupBox3.Controls.Add(this.comboBoxPPTRate);
            this.groupBox3.Controls.Add(this.buttonReset);
            this.groupBox3.Controls.Add(this.buttonSaveValues);
            this.groupBox3.Controls.Add(this.buttonLoadValues);
            this.groupBox3.Controls.Add(this.textBoxCounterPerVideo);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxCounterPerPPT);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 150);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Slide Change Config";
            // 
            // comboBoxDelay
            // 
            this.comboBoxDelay.FormattingEnabled = true;
            this.comboBoxDelay.Items.AddRange(new object[] {
            "Fast - x2.5",
            "Normal - x5",
            "Slow - x10"});
            this.comboBoxDelay.Location = new System.Drawing.Point(66, 70);
            this.comboBoxDelay.Name = "comboBoxDelay";
            this.comboBoxDelay.Size = new System.Drawing.Size(76, 21);
            this.comboBoxDelay.TabIndex = 45;
            this.comboBoxDelay.SelectedIndexChanged += new System.EventHandler(this.comboBoxDelay_SelectedIndexChanged);
            // 
            // comboBoxVideoRate
            // 
            this.comboBoxVideoRate.FormattingEnabled = true;
            this.comboBoxVideoRate.Items.AddRange(new object[] {
            "High",
            "Moderate",
            "Low"});
            this.comboBoxVideoRate.Location = new System.Drawing.Point(70, 44);
            this.comboBoxVideoRate.Name = "comboBoxVideoRate";
            this.comboBoxVideoRate.Size = new System.Drawing.Size(72, 21);
            this.comboBoxVideoRate.TabIndex = 43;
            this.comboBoxVideoRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxVideoRate_SelectedIndexChanged);
            // 
            // comboBoxPPTRate
            // 
            this.comboBoxPPTRate.FormattingEnabled = true;
            this.comboBoxPPTRate.Items.AddRange(new object[] {
            "High",
            "Moderate",
            "Low"});
            this.comboBoxPPTRate.Location = new System.Drawing.Point(66, 17);
            this.comboBoxPPTRate.Name = "comboBoxPPTRate";
            this.comboBoxPPTRate.Size = new System.Drawing.Size(76, 21);
            this.comboBoxPPTRate.TabIndex = 42;
            this.comboBoxPPTRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxPPTRate_SelectedIndexChanged);
            // 
            // buttonReset
            // 
            this.buttonReset.Enabled = false;
            this.buttonReset.Location = new System.Drawing.Point(3, 121);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(96, 23);
            this.buttonReset.TabIndex = 37;
            this.buttonReset.Text = "Reset Values";
            this.toolTip2.SetToolTip(this.buttonReset, "This button will reset the values to their default settings.");
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // buttonSaveValues
            // 
            this.buttonSaveValues.Location = new System.Drawing.Point(105, 121);
            this.buttonSaveValues.Name = "buttonSaveValues";
            this.buttonSaveValues.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveValues.TabIndex = 36;
            this.buttonSaveValues.Text = "Set Values";
            this.toolTip2.SetToolTip(this.buttonSaveValues, "This button will set the values and save them.");
            this.buttonSaveValues.UseVisualStyleBackColor = true;
            this.buttonSaveValues.Click += new System.EventHandler(this.buttonSaveValues_Click);
            // 
            // buttonLoadValues
            // 
            this.buttonLoadValues.Location = new System.Drawing.Point(186, 121);
            this.buttonLoadValues.Name = "buttonLoadValues";
            this.buttonLoadValues.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadValues.TabIndex = 35;
            this.buttonLoadValues.Text = "Load Values";
            this.toolTip2.SetToolTip(this.buttonLoadValues, "This button will load the values if they are not already loaded.");
            this.buttonLoadValues.UseVisualStyleBackColor = true;
            this.buttonLoadValues.Click += new System.EventHandler(this.buttonLoadValues_Click);
            // 
            // textBoxCounterPerVideo
            // 
            this.textBoxCounterPerVideo.Location = new System.Drawing.Point(222, 35);
            this.textBoxCounterPerVideo.Name = "textBoxCounterPerVideo";
            this.textBoxCounterPerVideo.Size = new System.Drawing.Size(36, 20);
            this.textBoxCounterPerVideo.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Slide Delay";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Video Rate";
            // 
            // textBoxCounterPerPPT
            // 
            this.textBoxCounterPerPPT.Location = new System.Drawing.Point(222, 13);
            this.textBoxCounterPerPPT.Name = "textBoxCounterPerPPT";
            this.textBoxCounterPerPPT.Size = new System.Drawing.Size(36, 20);
            this.textBoxCounterPerPPT.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Counter PPT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "PPT Rate";
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "";
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(148, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Counter Video";
            // 
            // textBoxPowerPointRate
            // 
            this.textBoxPowerPointRate.Location = new System.Drawing.Point(19, 359);
            this.textBoxPowerPointRate.Name = "textBoxPowerPointRate";
            this.textBoxPowerPointRate.Size = new System.Drawing.Size(36, 20);
            this.textBoxPowerPointRate.TabIndex = 34;
            this.toolTip2.SetToolTip(this.textBoxPowerPointRate, "This box is editable and shows the probability that a PowerPoint will appear.");
            this.textBoxPowerPointRate.Visible = false;
            this.textBoxPowerPointRate.TextChanged += new System.EventHandler(this.textBoxPowerPointRate_TextChanged);
            // 
            // textBoxSlideDelay
            // 
            this.textBoxSlideDelay.Location = new System.Drawing.Point(19, 437);
            this.textBoxSlideDelay.Name = "textBoxSlideDelay";
            this.textBoxSlideDelay.Size = new System.Drawing.Size(36, 20);
            this.textBoxSlideDelay.TabIndex = 31;
            this.toolTip2.SetToolTip(this.textBoxSlideDelay, "This is the delay between each slide in seconds.");
            this.textBoxSlideDelay.Visible = false;
            // 
            // textBoxImageRate
            // 
            this.textBoxImageRate.Location = new System.Drawing.Point(19, 411);
            this.textBoxImageRate.Name = "textBoxImageRate";
            this.textBoxImageRate.ReadOnly = true;
            this.textBoxImageRate.Size = new System.Drawing.Size(36, 20);
            this.textBoxImageRate.TabIndex = 30;
            this.toolTip2.SetToolTip(this.textBoxImageRate, "This box is not editable, and the chance is based on the power and video rate.");
            this.textBoxImageRate.Visible = false;
            // 
            // textBoxVideoRate
            // 
            this.textBoxVideoRate.Location = new System.Drawing.Point(19, 385);
            this.textBoxVideoRate.Name = "textBoxVideoRate";
            this.textBoxVideoRate.Size = new System.Drawing.Size(36, 20);
            this.textBoxVideoRate.TabIndex = 29;
            this.toolTip2.SetToolTip(this.textBoxVideoRate, "This box is editable and shows the probability that a Video will appear.");
            this.textBoxVideoRate.Visible = false;
            this.textBoxVideoRate.TextChanged += new System.EventHandler(this.textBoxVideoRate_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonOpenLogs);
            this.groupBox2.Controls.Add(this.buttonSaveLogs);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Location = new System.Drawing.Point(12, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logging";
            // 
            // buttonOpenLogs
            // 
            this.buttonOpenLogs.Location = new System.Drawing.Point(6, 19);
            this.buttonOpenLogs.Name = "buttonOpenLogs";
            this.buttonOpenLogs.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenLogs.TabIndex = 37;
            this.buttonOpenLogs.Text = "Open Logs";
            this.buttonOpenLogs.UseVisualStyleBackColor = true;
            this.buttonOpenLogs.Click += new System.EventHandler(this.buttonOpenLogs_Click);
            // 
            // buttonSaveLogs
            // 
            this.buttonSaveLogs.Enabled = false;
            this.buttonSaveLogs.Location = new System.Drawing.Point(183, 19);
            this.buttonSaveLogs.Name = "buttonSaveLogs";
            this.buttonSaveLogs.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveLogs.TabIndex = 36;
            this.buttonSaveLogs.Text = "Save Logs";
            this.buttonSaveLogs.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(87, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 23);
            this.button6.TabIndex = 35;
            this.button6.Text = "Close Console";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.buttonOpenTxtFile);
            this.groupBox1.Controls.Add(this.textSpeedComboBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(298, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Footer";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(113, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 47);
            this.button2.TabIndex = 41;
            this.button2.Text = "Set Footer Text File";
            this.toolTip2.SetToolTip(this.button2, "This button will set the footer text. To edit it, use the open footer text file.");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonSetFooterText_Click);
            // 
            // buttonOpenTxtFile
            // 
            this.buttonOpenTxtFile.Location = new System.Drawing.Point(6, 76);
            this.buttonOpenTxtFile.Name = "buttonOpenTxtFile";
            this.buttonOpenTxtFile.Size = new System.Drawing.Size(92, 47);
            this.buttonOpenTxtFile.TabIndex = 40;
            this.buttonOpenTxtFile.Text = "Open Footer Text File";
            this.toolTip2.SetToolTip(this.buttonOpenTxtFile, "This will open and create the footer file used in the code if needed.");
            this.buttonOpenTxtFile.UseVisualStyleBackColor = true;
            this.buttonOpenTxtFile.Click += new System.EventHandler(this.buttonOpenTxtFile_Click);
            // 
            // textSpeedComboBox
            // 
            this.textSpeedComboBox.Enabled = false;
            this.textSpeedComboBox.FormattingEnabled = true;
            this.textSpeedComboBox.Location = new System.Drawing.Point(74, 23);
            this.textSpeedComboBox.Name = "textSpeedComboBox";
            this.textSpeedComboBox.Size = new System.Drawing.Size(121, 21);
            this.textSpeedComboBox.TabIndex = 5;
            this.textSpeedComboBox.SelectedIndexChanged += new System.EventHandler(this.textSpeedComboBox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Text Speed";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(269, 75);
            this.button1.TabIndex = 41;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Day Type";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "CUSTOM MESSAGE",
            "RED",
            "AMBER",
            "GREEN"});
            this.comboBox1.Location = new System.Drawing.Point(74, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 43;
            // 
            // FormSettingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 304);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxPowerPointRate);
            this.Controls.Add(this.textBoxSlideDelay);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.textBoxImageRate);
            this.Controls.Add(this.textBoxVideoRate);
            this.Controls.Add(this.groupBox3);
            this.Name = "FormSettingWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSettingWindow";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormSettingWindow_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxPowerPointRate;
        private System.Windows.Forms.TextBox textBoxCounterPerVideo;
        private System.Windows.Forms.TextBox textBoxCounterPerPPT;
        private System.Windows.Forms.TextBox textBoxSlideDelay;
        private System.Windows.Forms.TextBox textBoxImageRate;
        private System.Windows.Forms.TextBox textBoxVideoRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonOpenLogs;
        private System.Windows.Forms.Button buttonSaveLogs;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOpenTxtFile;
        private System.Windows.Forms.ComboBox textSpeedComboBox;
        private System.Windows.Forms.Label label10;
        private ToolTip toolTip1;
        private Button button1;
        private Button buttonReset;
        private Button buttonSaveValues;
        private Button buttonLoadValues;
        private Button button2;
        private ToolTip toolTip2;
        private ComboBox comboBoxDelay;
        private ComboBox comboBoxVideoRate;
        private ComboBox comboBoxPPTRate;
        private ComboBox comboBox1;
        private Label label3;
    }
}