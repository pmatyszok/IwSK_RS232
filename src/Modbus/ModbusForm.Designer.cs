namespace IwSK_RS232.Modbus
{
    partial class ModbusForm
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
            this.masterSlaveComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.masterPanel = new System.Windows.Forms.Panel();
            this.commandNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.adressNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ArgumentsTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.transactionTimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IncomingRichTextBox = new System.Windows.Forms.RichTextBox();
            this.frameTimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.masterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commandNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adressNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTimeoutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameTimeoutNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // masterSlaveComboBox
            // 
            this.masterSlaveComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.masterSlaveComboBox.FormattingEnabled = true;
            this.masterSlaveComboBox.Items.AddRange(new object[] {
            "Master",
            "Slave"});
            this.masterSlaveComboBox.Location = new System.Drawing.Point(131, 26);
            this.masterSlaveComboBox.Name = "masterSlaveComboBox";
            this.masterSlaveComboBox.Size = new System.Drawing.Size(121, 21);
            this.masterSlaveComboBox.TabIndex = 0;
            this.masterSlaveComboBox.SelectedIndexChanged += new System.EventHandler(this.masterSlaveComboBox_SelectedIndexChanged);
            this.masterSlaveComboBox.SelectedValueChanged += new System.EventHandler(this.masterSlaveComboBox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Master / Slave:";
            // 
            // masterPanel
            // 
            this.masterPanel.Controls.Add(this.label6);
            this.masterPanel.Controls.Add(this.frameTimeoutNumericUpDown);
            this.masterPanel.Controls.Add(this.IncomingRichTextBox);
            this.masterPanel.Controls.Add(this.label5);
            this.masterPanel.Controls.Add(this.label4);
            this.masterPanel.Controls.Add(this.transactionTimeoutNumericUpDown);
            this.masterPanel.Controls.Add(this.sendButton);
            this.masterPanel.Controls.Add(this.ArgumentsTextBox);
            this.masterPanel.Controls.Add(this.label3);
            this.masterPanel.Controls.Add(this.commandNumericUpDown);
            this.masterPanel.Controls.Add(this.label2);
            this.masterPanel.Controls.Add(this.adressNumericUpDown);
            this.masterPanel.Location = new System.Drawing.Point(35, 70);
            this.masterPanel.Name = "masterPanel";
            this.masterPanel.Size = new System.Drawing.Size(355, 348);
            this.masterPanel.TabIndex = 2;
            // 
            // commandNumericUpDown
            // 
            this.commandNumericUpDown.Location = new System.Drawing.Point(245, 9);
            this.commandNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.commandNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.commandNumericUpDown.Name = "commandNumericUpDown";
            this.commandNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.commandNumericUpDown.TabIndex = 2;
            this.commandNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adress:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // adressNumericUpDown
            // 
            this.adressNumericUpDown.Location = new System.Drawing.Point(70, 9);
            this.adressNumericUpDown.Maximum = new decimal(new int[] {
            247,
            0,
            0,
            0});
            this.adressNumericUpDown.Name = "adressNumericUpDown";
            this.adressNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.adressNumericUpDown.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Command:";
            // 
            // ArgumentsTextBox
            // 
            this.ArgumentsTextBox.Location = new System.Drawing.Point(25, 50);
            this.ArgumentsTextBox.Name = "ArgumentsTextBox";
            this.ArgumentsTextBox.Size = new System.Drawing.Size(242, 20);
            this.ArgumentsTextBox.TabIndex = 4;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(280, 47);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 5;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // transactionTimeoutNumericUpDown
            // 
            this.transactionTimeoutNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.transactionTimeoutNumericUpDown.Location = new System.Drawing.Point(176, 86);
            this.transactionTimeoutNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.transactionTimeoutNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.transactionTimeoutNumericUpDown.Name = "transactionTimeoutNumericUpDown";
            this.transactionTimeoutNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.transactionTimeoutNumericUpDown.TabIndex = 6;
            this.transactionTimeoutNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Transaction time-out";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ms";
            // 
            // IncomingRichTextBox
            // 
            this.IncomingRichTextBox.Location = new System.Drawing.Point(25, 126);
            this.IncomingRichTextBox.Name = "IncomingRichTextBox";
            this.IncomingRichTextBox.Size = new System.Drawing.Size(307, 141);
            this.IncomingRichTextBox.TabIndex = 9;
            this.IncomingRichTextBox.Text = "";
            // 
            // frameTimeoutNumericUpDown
            // 
            this.frameTimeoutNumericUpDown.Location = new System.Drawing.Point(245, 290);
            this.frameTimeoutNumericUpDown.Name = "frameTimeoutNumericUpDown";
            this.frameTimeoutNumericUpDown.Size = new System.Drawing.Size(71, 20);
            this.frameTimeoutNumericUpDown.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Frame chars time-out:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // ModbusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 443);
            this.Controls.Add(this.masterPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.masterSlaveComboBox);
            this.Name = "ModbusForm";
            this.Text = "Modbus";
            this.masterPanel.ResumeLayout(false);
            this.masterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commandNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adressNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTimeoutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameTimeoutNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox masterSlaveComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel masterPanel;
        private System.Windows.Forms.NumericUpDown commandNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown adressNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown frameTimeoutNumericUpDown;
        private System.Windows.Forms.RichTextBox IncomingRichTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown transactionTimeoutNumericUpDown;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox ArgumentsTextBox;
        private System.Windows.Forms.Label label3;
    }
}