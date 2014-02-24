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
            this.SuspendLayout();
            // 
            // comPortsCombo
            // 
            this.comPortsCombo.FormattingEnabled = true;
            this.comPortsCombo.Location = new System.Drawing.Point(44, 9);
            this.comPortsCombo.Name = "comPortsCombo";
            this.comPortsCombo.Size = new System.Drawing.Size(121, 21);
            this.comPortsCombo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port";
            // 
            // selectPortButton
            // 
            this.selectPortButton.Location = new System.Drawing.Point(197, 9);
            this.selectPortButton.Name = "selectPortButton";
            this.selectPortButton.Size = new System.Drawing.Size(75, 23);
            this.selectPortButton.TabIndex = 2;
            this.selectPortButton.Text = "Wybierz port";
            this.selectPortButton.UseVisualStyleBackColor = true;
            this.selectPortButton.Click += new System.EventHandler(this.selectPortButton_Click);
            // 
            // refreshComListBtn
            // 
            this.refreshComListBtn.Location = new System.Drawing.Point(197, 32);
            this.refreshComListBtn.Name = "refreshComListBtn";
            this.refreshComListBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshComListBtn.TabIndex = 3;
            this.refreshComListBtn.Text = "Odśwież";
            this.refreshComListBtn.UseVisualStyleBackColor = true;
            this.refreshComListBtn.Click += new System.EventHandler(this.refreshComListBtn_Click);
            // 
            // userConsole
            // 
            this.userConsole.Location = new System.Drawing.Point(15, 105);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ATBtn);
            this.Controls.Add(this.userConsole);
            this.Controls.Add(this.refreshComListBtn);
            this.Controls.Add(this.selectPortButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comPortsCombo);
            this.Name = "MainForm";
            this.Text = "IwSK - RS232";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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
    }
}

