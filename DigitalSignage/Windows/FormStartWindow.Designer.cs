namespace DigitalSignage.Windows
{
    partial class FormStartWindow
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
            this.buttonInitialize = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.marker = new System.Windows.Forms.Label();
            this.labelV = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonInitialize
            // 
            this.buttonInitialize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonInitialize.Location = new System.Drawing.Point(12, 159);
            this.buttonInitialize.Name = "buttonInitialize";
            this.buttonInitialize.Size = new System.Drawing.Size(91, 40);
            this.buttonInitialize.TabIndex = 0;
            this.buttonInitialize.Text = "Initialize";
            this.buttonInitialize.UseVisualStyleBackColor = true;
            this.buttonInitialize.Click += new System.EventHandler(this.buttonInitialize_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStart.Location = new System.Drawing.Point(109, 159);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(161, 40);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Play/Pause";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(276, 159);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 40);
            this.button3.TabIndex = 2;
            this.button3.Text = "Settings";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // marker
            // 
            this.marker.AutoSize = true;
            this.marker.Location = new System.Drawing.Point(9, 212);
            this.marker.Name = "marker";
            this.marker.Size = new System.Drawing.Size(63, 13);
            this.marker.TabIndex = 3;
            this.marker.Text = "Aether Corp";
            // 
            // labelV
            // 
            this.labelV.AutoSize = true;
            this.labelV.Location = new System.Drawing.Point(336, 212);
            this.labelV.Name = "labelV";
            this.labelV.Size = new System.Drawing.Size(37, 13);
            this.labelV.TabIndex = 4;
            this.labelV.Text = "v1.0.0";
            // 
            // FormStartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 234);
            this.Controls.Add(this.labelV);
            this.Controls.Add(this.marker);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonInitialize);
            this.MinimizeBox = false;
            this.Name = "FormStartWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DigitalSignage";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormStartWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInitialize;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label marker;
        private System.Windows.Forms.Label labelV;
    }
}