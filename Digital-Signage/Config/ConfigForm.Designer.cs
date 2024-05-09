using System.Windows.Forms;

namespace Digital_Signage.Config
{
    partial class ConfigForm
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
            this.lbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOpenTxtFile = new System.Windows.Forms.Button();
            this.labelCustomTextSpeedScroll = new System.Windows.Forms.Label();
            this.textBoxCustomTextSpeedScroll = new System.Windows.Forms.TextBox();
            this.textSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonOpenLogs = new System.Windows.Forms.Button();
            this.buttonSaveLogs = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxPowerPointRate = new System.Windows.Forms.TextBox();
            this.textBoxCounterPerVideo = new System.Windows.Forms.TextBox();
            this.textBoxCounterPerPPT = new System.Windows.Forms.TextBox();
            this.textBoxSlideDelay = new System.Windows.Forms.TextBox();
            this.textBoxImageRate = new System.Windows.Forms.TextBox();
            this.textBoxVideoRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSaveValues = new System.Windows.Forms.Button();
            this.buttonLoadValues = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonPlayPause = new System.Windows.Forms.Button();
            this.button_install = new System.Windows.Forms.Button();
            this.Tag = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(0, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(100, 23);
            this.lbl.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonOpenTxtFile);
            this.groupBox1.Controls.Add(this.labelCustomTextSpeedScroll);
            this.groupBox1.Controls.Add(this.textBoxCustomTextSpeedScroll);
            this.groupBox1.Controls.Add(this.textSpeedComboBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(298, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Footer";
            // 
            // buttonOpenTxtFile
            // 
            this.buttonOpenTxtFile.Location = new System.Drawing.Point(6, 76);
            this.buttonOpenTxtFile.Name = "buttonOpenTxtFile";
            this.buttonOpenTxtFile.Size = new System.Drawing.Size(199, 47);
            this.buttonOpenTxtFile.TabIndex = 40;
            this.buttonOpenTxtFile.Text = "Open Footer Text File";
            this.buttonOpenTxtFile.UseVisualStyleBackColor = true;
            this.buttonOpenTxtFile.Click += new System.EventHandler(this.buttonOpenTxtFile_Click);
            // 
            // labelCustomTextSpeedScroll
            // 
            this.labelCustomTextSpeedScroll.AutoSize = true;
            this.labelCustomTextSpeedScroll.Location = new System.Drawing.Point(6, 54);
            this.labelCustomTextSpeedScroll.Name = "labelCustomTextSpeedScroll";
            this.labelCustomTextSpeedScroll.Size = new System.Drawing.Size(103, 13);
            this.labelCustomTextSpeedScroll.TabIndex = 36;
            this.labelCustomTextSpeedScroll.Text = "Text Speed Custom ";
            this.toolTip1.SetToolTip(this.labelCustomTextSpeedScroll, "This is the percentage rate that indicates the chance of a PowerPoint presentatio" +
        "n playing after a video or slide.");
            this.labelCustomTextSpeedScroll.Visible = false;
            // 
            // textBoxCustomTextSpeedScroll
            // 
            this.textBoxCustomTextSpeedScroll.Enabled = false;
            this.textBoxCustomTextSpeedScroll.Location = new System.Drawing.Point(108, 50);
            this.textBoxCustomTextSpeedScroll.Name = "textBoxCustomTextSpeedScroll";
            this.textBoxCustomTextSpeedScroll.Size = new System.Drawing.Size(87, 20);
            this.textBoxCustomTextSpeedScroll.TabIndex = 35;
            this.textBoxCustomTextSpeedScroll.Visible = false;
            this.textBoxCustomTextSpeedScroll.TextChanged += new System.EventHandler(this.textBoxCustomTextSpeedScroll_TextChanged);
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
            this.toolTip1.SetToolTip(this.label10, "This is the percentage rate that indicates the chance of a PowerPoint presentatio" +
        "n playing after a video or slide.");
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxPowerPointRate);
            this.groupBox3.Controls.Add(this.textBoxCounterPerVideo);
            this.groupBox3.Controls.Add(this.textBoxCounterPerPPT);
            this.groupBox3.Controls.Add(this.textBoxSlideDelay);
            this.groupBox3.Controls.Add(this.textBoxImageRate);
            this.groupBox3.Controls.Add(this.textBoxVideoRate);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.buttonSaveValues);
            this.groupBox3.Controls.Add(this.buttonLoadValues);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 150);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Slide Change Config";
            // 
            // textBoxPowerPointRate
            // 
            this.textBoxPowerPointRate.Location = new System.Drawing.Point(70, 19);
            this.textBoxPowerPointRate.Name = "textBoxPowerPointRate";
            this.textBoxPowerPointRate.Size = new System.Drawing.Size(36, 20);
            this.textBoxPowerPointRate.TabIndex = 34;
            this.textBoxPowerPointRate.TextChanged += new System.EventHandler(this.textBoxPowerPointRate_TextChanged);
            // 
            // textBoxCounterPerVideo
            // 
            this.textBoxCounterPerVideo.Location = new System.Drawing.Point(186, 41);
            this.textBoxCounterPerVideo.Name = "textBoxCounterPerVideo";
            this.textBoxCounterPerVideo.Size = new System.Drawing.Size(36, 20);
            this.textBoxCounterPerVideo.TabIndex = 33;
            // 
            // textBoxCounterPerPPT
            // 
            this.textBoxCounterPerPPT.Location = new System.Drawing.Point(186, 19);
            this.textBoxCounterPerPPT.Name = "textBoxCounterPerPPT";
            this.textBoxCounterPerPPT.Size = new System.Drawing.Size(36, 20);
            this.textBoxCounterPerPPT.TabIndex = 32;
            // 
            // textBoxSlideDelay
            // 
            this.textBoxSlideDelay.Location = new System.Drawing.Point(70, 97);
            this.textBoxSlideDelay.Name = "textBoxSlideDelay";
            this.textBoxSlideDelay.Size = new System.Drawing.Size(36, 20);
            this.textBoxSlideDelay.TabIndex = 31;
            // 
            // textBoxImageRate
            // 
            this.textBoxImageRate.Location = new System.Drawing.Point(70, 71);
            this.textBoxImageRate.Name = "textBoxImageRate";
            this.textBoxImageRate.ReadOnly = true;
            this.textBoxImageRate.Size = new System.Drawing.Size(36, 20);
            this.textBoxImageRate.TabIndex = 30;
            // 
            // textBoxVideoRate
            // 
            this.textBoxVideoRate.Location = new System.Drawing.Point(70, 45);
            this.textBoxVideoRate.Name = "textBoxVideoRate";
            this.textBoxVideoRate.Size = new System.Drawing.Size(36, 20);
            this.textBoxVideoRate.TabIndex = 29;
            this.textBoxVideoRate.TextChanged += new System.EventHandler(this.textBoxVideoRate_TextChanged);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "";
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Counter Video";
            this.toolTip1.SetToolTip(this.label6, "This is the maximum counter limit. It tracks how many slides have been displayed " +
        "before it plays another video.");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Counter PPT";
            this.toolTip1.SetToolTip(this.label5, "This is the maximum counter limit. It tracks how many slides have been displayed " +
        "before it plays another PowerPoint.");
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(3, 121);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Reset Values";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Slide Delay";
            this.toolTip1.SetToolTip(this.label4, "Delay between slides: This includes all types of slides, such as PowerPoint prese" +
        "ntations and videos");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Image Rate";
            this.toolTip1.SetToolTip(this.label3, "The chance of an image displaying is based on the set rates for PowerPoint presen" +
        "tations and videos.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Video Rate";
            this.toolTip1.SetToolTip(this.label2, "This percentage rate determines the likelihood of a video playing following anoth" +
        "er media type.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "PPT Rate";
            this.toolTip1.SetToolTip(this.label1, "This is the percentage rate that indicates the chance of a PowerPoint presentatio" +
        "n playing after a video or slide.");
            // 
            // buttonSaveValues
            // 
            this.buttonSaveValues.Location = new System.Drawing.Point(105, 121);
            this.buttonSaveValues.Name = "buttonSaveValues";
            this.buttonSaveValues.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveValues.TabIndex = 1;
            this.buttonSaveValues.Text = "Save Values";
            this.buttonSaveValues.UseVisualStyleBackColor = true;
            this.buttonSaveValues.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoadValues
            // 
            this.buttonLoadValues.Location = new System.Drawing.Point(186, 121);
            this.buttonLoadValues.Name = "buttonLoadValues";
            this.buttonLoadValues.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadValues.TabIndex = 0;
            this.buttonLoadValues.Text = "Load Values";
            this.buttonLoadValues.UseVisualStyleBackColor = true;
            this.buttonLoadValues.Click += new System.EventHandler(this.buttonLoad_Click);
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
            this.toolTip1.SetToolTip(this.label9, "This is the percentage rate that indicates the chance of a PowerPoint presentatio" +
        "n playing after a video or slide.");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "# of PPT";
            this.toolTip1.SetToolTip(this.label8, "This is the percentage rate that indicates the chance of a PowerPoint presentatio" +
        "n playing after a video or slide.");
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
            this.toolTip1.SetToolTip(this.label7, "This is the percentage rate that indicates the chance of a PowerPoint presentatio" +
        "n playing after a video or slide.");
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonPlayPause);
            this.groupBox5.Controls.Add(this.button_install);
            this.groupBox5.Controls.Add(this.Tag);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Location = new System.Drawing.Point(12, 222);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(271, 75);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Misc";
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.Enabled = false;
            this.buttonPlayPause.Location = new System.Drawing.Point(226, 18);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(39, 35);
            this.buttonPlayPause.TabIndex = 42;
            this.buttonPlayPause.Text = "Play";
            this.buttonPlayPause.UseVisualStyleBackColor = true;
            // 
            // button_install
            // 
            this.button_install.Location = new System.Drawing.Point(7, 38);
            this.button_install.Name = "button_install";
            this.button_install.Size = new System.Drawing.Size(170, 31);
            this.button_install.TabIndex = 41;
            this.button_install.Text = "Init Digital Signage ";
            this.button_install.UseVisualStyleBackColor = true;
            this.button_install.Click += new System.EventHandler(this.button_install_Click);
            // 
            // Tag
            // 
            this.Tag.AutoSize = true;
            this.Tag.Location = new System.Drawing.Point(183, 56);
            this.Tag.Name = "Tag";
            this.Tag.Size = new System.Drawing.Size(82, 13);
            this.Tag.TabIndex = 40;
            this.Tag.Text = "Avi Was Here :)";
            this.toolTip1.SetToolTip(this.Tag, "This is the percentage rate that indicates the chance of a PowerPoint presentatio" +
        "n playing after a video or slide.");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(204, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "HotKey To Open/Close Config: CTRL + X";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 304);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConfigForm";
            this.Text = "Digital Signage";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonLoadValues;
        private System.Windows.Forms.Button buttonSaveValues;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Label lbl;
        private TextBox textBoxCounterPerPPT;
        private TextBox textBoxSlideDelay;
        private TextBox textBoxImageRate;
        private TextBox textBoxVideoRate;
        private TextBox textBoxCounterPerVideo;
        private ToolTip toolTip1;
        private TextBox textBox7;
        private Button button4;
        private Button button6;
        private TextBox textBox9;
        private Label label9;
        private Label label8;
        private TextBox textBox8;
        private Label label7;
        private TextBox textBoxPowerPointRate;
        private Button buttonSaveLogs;
        private Button button8;
        private Button button7;
        private ComboBox textSpeedComboBox;
        private Label label10;
        private TextBox textBoxCustomTextSpeedScroll;
        private Label labelCustomTextSpeedScroll;
        private Button buttonOpenTxtFile;
        private Button buttonOpenLogs;
        private Label Tag;
        private Button button_install;
        private Button buttonPlayPause;
        private Label label11;
    }
}