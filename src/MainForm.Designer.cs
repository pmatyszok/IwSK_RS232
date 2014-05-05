namespace IwSK_RS232
{
    partial class MainForm
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
            this.comPortsCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectPortButton = new System.Windows.Forms.Button();
            this.refreshComListBtn = new System.Windows.Forms.Button();
            this.userConsole = new System.Windows.Forms.RichTextBox();
            this.ATBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.parityCombo = new System.Windows.Forms.ComboBox();
            this.baudRateCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stopSignCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataBitsCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.handShakeCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.newLineCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DCDRadio = new System.Windows.Forms.RadioButton();
            this.RIRadio = new System.Windows.Forms.RadioButton();
            this.DSRRadio = new System.Windows.Forms.RadioButton();
            this.CTSRadio = new System.Windows.Forms.RadioButton();
            this.RTSRadio = new System.Windows.Forms.RadioButton();
            this.DTRRadio = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // comPortsCombo
            // 
            this.comPortsCombo.FormattingEnabled = true;
            this.comPortsCombo.Location = new System.Drawing.Point(338, 7);
            this.comPortsCombo.Name = "comPortsCombo";
            this.comPortsCombo.Size = new System.Drawing.Size(121, 21);
            this.comPortsCombo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port";
            // 
            // selectPortButton
            // 
            this.selectPortButton.Location = new System.Drawing.Point(384, 196);
            this.selectPortButton.Name = "selectPortButton";
            this.selectPortButton.Size = new System.Drawing.Size(75, 23);
            this.selectPortButton.TabIndex = 2;
            this.selectPortButton.Text = "Connect";
            this.selectPortButton.UseVisualStyleBackColor = true;
            this.selectPortButton.Click += new System.EventHandler(this.selectPortButton_Click);
            // 
            // refreshComListBtn
            // 
            this.refreshComListBtn.Location = new System.Drawing.Point(197, 5);
            this.refreshComListBtn.Name = "refreshComListBtn";
            this.refreshComListBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshComListBtn.TabIndex = 3;
            this.refreshComListBtn.Text = "Odśwież";
            this.refreshComListBtn.UseVisualStyleBackColor = true;
            this.refreshComListBtn.Click += new System.EventHandler(this.refreshComListBtn_Click);
            // 
            // userConsole
            // 
            this.userConsole.Location = new System.Drawing.Point(12, 105);
            this.userConsole.Name = "userConsole";
            this.userConsole.Size = new System.Drawing.Size(257, 96);
            this.userConsole.TabIndex = 4;
            this.userConsole.Text = "";
            // 
            // ATBtn
            // 
            this.ATBtn.Location = new System.Drawing.Point(197, 76);
            this.ATBtn.Name = "ATBtn";
            this.ATBtn.Size = new System.Drawing.Size(75, 23);
            this.ATBtn.TabIndex = 5;
            this.ATBtn.Text = "AT";
            this.ATBtn.UseVisualStyleBackColor = true;
            this.ATBtn.Click += new System.EventHandler(this.ATBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Parity";
            // 
            // parityCombo
            // 
            this.parityCombo.FormattingEnabled = true;
            this.parityCombo.Location = new System.Drawing.Point(338, 88);
            this.parityCombo.Name = "parityCombo";
            this.parityCombo.Size = new System.Drawing.Size(121, 21);
            this.parityCombo.TabIndex = 7;
            // 
            // baudRateCombo
            // 
            this.baudRateCombo.FormattingEnabled = true;
            this.baudRateCombo.Location = new System.Drawing.Point(338, 34);
            this.baudRateCombo.Name = "baudRateCombo";
            this.baudRateCombo.Size = new System.Drawing.Size(121, 21);
            this.baudRateCombo.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Baud rate ";
            // 
            // stopSignCombo
            // 
            this.stopSignCombo.FormattingEnabled = true;
            this.stopSignCombo.Location = new System.Drawing.Point(338, 115);
            this.stopSignCombo.Name = "stopSignCombo";
            this.stopSignCombo.Size = new System.Drawing.Size(121, 21);
            this.stopSignCombo.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Stop";
            // 
            // dataBitsCombo
            // 
            this.dataBitsCombo.FormattingEnabled = true;
            this.dataBitsCombo.Location = new System.Drawing.Point(338, 61);
            this.dataBitsCombo.Name = "dataBitsCombo";
            this.dataBitsCombo.Size = new System.Drawing.Size(121, 21);
            this.dataBitsCombo.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Data";
            // 
            // handShakeCombo
            // 
            this.handShakeCombo.FormattingEnabled = true;
            this.handShakeCombo.Location = new System.Drawing.Point(338, 142);
            this.handShakeCombo.Name = "handShakeCombo";
            this.handShakeCombo.Size = new System.Drawing.Size(121, 21);
            this.handShakeCombo.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Hand";
            // 
            // newLineCombo
            // 
            this.newLineCombo.FormattingEnabled = true;
            this.newLineCombo.Location = new System.Drawing.Point(338, 169);
            this.newLineCombo.Name = "newLineCombo";
            this.newLineCombo.Size = new System.Drawing.Size(121, 21);
            this.newLineCombo.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(283, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "NewLine";
            // 
            // DCDRadio
            // 
            this.DCDRadio.AutoSize = true;
            this.DCDRadio.Location = new System.Drawing.Point(10, 4);
            this.DCDRadio.Name = "DCDRadio";
            this.DCDRadio.Size = new System.Drawing.Size(48, 17);
            this.DCDRadio.TabIndex = 18;
            this.DCDRadio.TabStop = true;
            this.DCDRadio.Text = "DCD";
            this.DCDRadio.UseVisualStyleBackColor = true;
            // 
            // RIRadio
            // 
            this.RIRadio.AutoSize = true;
            this.RIRadio.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.RIRadio.Location = new System.Drawing.Point(6, 2);
            this.RIRadio.Name = "RIRadio";
            this.RIRadio.Size = new System.Drawing.Size(36, 17);
            this.RIRadio.TabIndex = 19;
            this.RIRadio.TabStop = true;
            this.RIRadio.Text = "RI";
            this.RIRadio.UseVisualStyleBackColor = true;
            // 
            // DSRRadio
            // 
            this.DSRRadio.AutoSize = true;
            this.DSRRadio.Cursor = System.Windows.Forms.Cursors.Default;
            this.DSRRadio.Location = new System.Drawing.Point(3, 3);
            this.DSRRadio.Name = "DSRRadio";
            this.DSRRadio.Size = new System.Drawing.Size(48, 17);
            this.DSRRadio.TabIndex = 20;
            this.DSRRadio.TabStop = true;
            this.DSRRadio.Text = "DSR";
            this.DSRRadio.UseVisualStyleBackColor = true;
            // 
            // CTSRadio
            // 
            this.CTSRadio.AutoSize = true;
            this.CTSRadio.Location = new System.Drawing.Point(9, 4);
            this.CTSRadio.Name = "CTSRadio";
            this.CTSRadio.Size = new System.Drawing.Size(46, 17);
            this.CTSRadio.TabIndex = 21;
            this.CTSRadio.TabStop = true;
            this.CTSRadio.Text = "CTS";
            this.CTSRadio.UseVisualStyleBackColor = true;
            // 
            // RTSRadio
            // 
            this.RTSRadio.AutoSize = true;
            this.RTSRadio.Location = new System.Drawing.Point(0, 0);
            this.RTSRadio.Name = "RTSRadio";
            this.RTSRadio.Size = new System.Drawing.Size(47, 17);
            this.RTSRadio.TabIndex = 22;
            this.RTSRadio.TabStop = true;
            this.RTSRadio.Text = "RTS";
            this.RTSRadio.UseVisualStyleBackColor = true;
            // 
            // DTRRadio
            // 
            this.DTRRadio.AutoSize = true;
            this.DTRRadio.Location = new System.Drawing.Point(8, 3);
            this.DTRRadio.Name = "DTRRadio";
            this.DTRRadio.Size = new System.Drawing.Size(48, 17);
            this.DTRRadio.TabIndex = 23;
            this.DTRRadio.TabStop = true;
            this.DTRRadio.Text = "DTR";
            this.DTRRadio.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DCDRadio);
            this.panel1.Location = new System.Drawing.Point(2, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 28);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RIRadio);
            this.panel2.Location = new System.Drawing.Point(66, 204);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(56, 26);
            this.panel2.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DSRRadio);
            this.panel3.Location = new System.Drawing.Point(128, 203);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(47, 28);
            this.panel3.TabIndex = 26;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.CTSRadio);
            this.panel4.Location = new System.Drawing.Point(181, 203);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(58, 29);
            this.panel4.TabIndex = 27;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.RTSRadio);
            this.panel5.Location = new System.Drawing.Point(9, 230);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(54, 25);
            this.panel5.TabIndex = 28;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.DTRRadio);
            this.panel6.Location = new System.Drawing.Point(58, 230);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(57, 28);
            this.panel6.TabIndex = 29;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 262);
            this.Controls.Add(this.newLineCombo);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.handShakeCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataBitsCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.stopSignCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.baudRateCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.parityCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ATBtn);
            this.Controls.Add(this.userConsole);
            this.Controls.Add(this.refreshComListBtn);
            this.Controls.Add(this.selectPortButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comPortsCombo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Name = "MainForm";
            this.Text = "IwSK - RS232";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comPortsCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectPortButton;
        private System.Windows.Forms.Button refreshComListBtn;
        private System.Windows.Forms.RichTextBox userConsole;
        private System.Windows.Forms.Button ATBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox parityCombo;
        private System.Windows.Forms.ComboBox baudRateCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox stopSignCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dataBitsCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox handShakeCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox newLineCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton DCDRadio;
        private System.Windows.Forms.RadioButton RIRadio;
        private System.Windows.Forms.RadioButton DSRRadio;
        private System.Windows.Forms.RadioButton CTSRadio;
        private System.Windows.Forms.RadioButton RTSRadio;
        private System.Windows.Forms.RadioButton DTRRadio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
    }
}

