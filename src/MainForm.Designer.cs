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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PINGBtn = new System.Windows.Forms.Button();
            this.modBusCheckBox = new System.Windows.Forms.CheckBox();
            this.customlinetext = new System.Windows.Forms.TextBox();
            this.customnewline = new System.Windows.Forms.CheckBox();
            this.sendtext = new System.Windows.Forms.TextBox();
            this.sendbutton = new System.Windows.Forms.Button();
            this.newLineCombo = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.DTRRadio = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.RTSRadio = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DCDRadio = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.handShakeCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataBitsCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stopSignCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.baudRateCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.parityCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ATBtn = new System.Windows.Forms.Button();
            this.userConsole = new System.Windows.Forms.RichTextBox();
            this.refreshComListBtn = new System.Windows.Forms.Button();
            this.selectPortButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comPortsCombo = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RIRadio = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DSRRadio = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.CTSRadio = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SlaveRadioButton = new System.Windows.Forms.RadioButton();
            this.MasterRadioButton = new System.Windows.Forms.RadioButton();
            this.MasterSlaveGroupBox = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.transactionTimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.adressNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.commandNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.IncomingRichTextBox = new System.Windows.Forms.RichTextBox();
            this.outcomingRichTextBox = new System.Windows.Forms.RichTextBox();
            this.frameTimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.amountOfRetransmNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.MasterSlaveGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTimeoutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adressNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameTimeoutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountOfRetransmNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(646, 433);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PINGBtn);
            this.tabPage1.Controls.Add(this.modBusCheckBox);
            this.tabPage1.Controls.Add(this.customlinetext);
            this.tabPage1.Controls.Add(this.customnewline);
            this.tabPage1.Controls.Add(this.sendtext);
            this.tabPage1.Controls.Add(this.sendbutton);
            this.tabPage1.Controls.Add(this.newLineCombo);
            this.tabPage1.Controls.Add(this.panel6);
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.handShakeCombo);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.dataBitsCombo);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.stopSignCombo);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.baudRateCombo);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.parityCombo);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.ATBtn);
            this.tabPage1.Controls.Add(this.userConsole);
            this.tabPage1.Controls.Add(this.refreshComListBtn);
            this.tabPage1.Controls.Add(this.selectPortButton);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.comPortsCombo);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(638, 407);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "RS232";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PINGBtn
            // 
            this.PINGBtn.Location = new System.Drawing.Point(203, 50);
            this.PINGBtn.Name = "PINGBtn";
            this.PINGBtn.Size = new System.Drawing.Size(60, 23);
            this.PINGBtn.TabIndex = 64;
            this.PINGBtn.Text = "PING";
            this.PINGBtn.UseVisualStyleBackColor = true;
            this.PINGBtn.Click += new System.EventHandler(this.PINGBtn_Click);
            // 
            // modBusCheckBox
            // 
            this.modBusCheckBox.AutoSize = true;
            this.modBusCheckBox.Location = new System.Drawing.Point(384, 267);
            this.modBusCheckBox.Name = "modBusCheckBox";
            this.modBusCheckBox.Size = new System.Drawing.Size(64, 17);
            this.modBusCheckBox.TabIndex = 59;
            this.modBusCheckBox.Text = "Modbus";
            this.modBusCheckBox.UseVisualStyleBackColor = true;
            this.modBusCheckBox.CheckedChanged += new System.EventHandler(this.modBusCheckBox_CheckedChanged);
            // 
            // customlinetext
            // 
            this.customlinetext.Location = new System.Drawing.Point(405, 241);
            this.customlinetext.Name = "customlinetext";
            this.customlinetext.Size = new System.Drawing.Size(121, 20);
            this.customlinetext.TabIndex = 63;
            // 
            // customnewline
            // 
            this.customnewline.AutoSize = true;
            this.customnewline.Location = new System.Drawing.Point(384, 248);
            this.customnewline.Name = "customnewline";
            this.customnewline.Size = new System.Drawing.Size(15, 14);
            this.customnewline.TabIndex = 62;
            this.customnewline.UseVisualStyleBackColor = true;
            // 
            // sendtext
            // 
            this.sendtext.Location = new System.Drawing.Point(67, 310);
            this.sendtext.Name = "sendtext";
            this.sendtext.Size = new System.Drawing.Size(175, 20);
            this.sendtext.TabIndex = 61;
            // 
            // sendbutton
            // 
            this.sendbutton.Location = new System.Drawing.Point(254, 307);
            this.sendbutton.Name = "sendbutton";
            this.sendbutton.Size = new System.Drawing.Size(75, 23);
            this.sendbutton.TabIndex = 60;
            this.sendbutton.Text = "Send";
            this.sendbutton.UseVisualStyleBackColor = true;
            this.sendbutton.Click += new System.EventHandler(this.sendbutton_Click_1);
            // 
            // newLineCombo
            // 
            this.newLineCombo.FormattingEnabled = true;
            this.newLineCombo.Location = new System.Drawing.Point(405, 214);
            this.newLineCombo.Name = "newLineCombo";
            this.newLineCombo.Size = new System.Drawing.Size(121, 21);
            this.newLineCombo.TabIndex = 52;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.DTRRadio);
            this.panel6.Location = new System.Drawing.Point(131, 270);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(52, 25);
            this.panel6.TabIndex = 58;
            // 
            // DTRRadio
            // 
            this.DTRRadio.AutoSize = true;
            this.DTRRadio.Location = new System.Drawing.Point(3, 3);
            this.DTRRadio.Name = "DTRRadio";
            this.DTRRadio.Size = new System.Drawing.Size(48, 17);
            this.DTRRadio.TabIndex = 23;
            this.DTRRadio.TabStop = true;
            this.DTRRadio.Text = "DTR";
            this.DTRRadio.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.RTSRadio);
            this.panel5.Location = new System.Drawing.Point(67, 270);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(61, 25);
            this.panel5.TabIndex = 57;
            // 
            // RTSRadio
            // 
            this.RTSRadio.AutoSize = true;
            this.RTSRadio.Location = new System.Drawing.Point(10, 3);
            this.RTSRadio.Name = "RTSRadio";
            this.RTSRadio.Size = new System.Drawing.Size(47, 17);
            this.RTSRadio.TabIndex = 22;
            this.RTSRadio.TabStop = true;
            this.RTSRadio.Text = "RTS";
            this.RTSRadio.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DCDRadio);
            this.panel1.Location = new System.Drawing.Point(67, 243);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(61, 28);
            this.panel1.TabIndex = 53;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(350, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "NewLine";
            // 
            // handShakeCombo
            // 
            this.handShakeCombo.FormattingEnabled = true;
            this.handShakeCombo.Location = new System.Drawing.Point(405, 187);
            this.handShakeCombo.Name = "handShakeCombo";
            this.handShakeCombo.Size = new System.Drawing.Size(121, 21);
            this.handShakeCombo.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(366, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Hand";
            // 
            // dataBitsCombo
            // 
            this.dataBitsCombo.FormattingEnabled = true;
            this.dataBitsCombo.Location = new System.Drawing.Point(405, 106);
            this.dataBitsCombo.Name = "dataBitsCombo";
            this.dataBitsCombo.Size = new System.Drawing.Size(121, 21);
            this.dataBitsCombo.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(366, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Data";
            // 
            // stopSignCombo
            // 
            this.stopSignCombo.FormattingEnabled = true;
            this.stopSignCombo.Location = new System.Drawing.Point(405, 160);
            this.stopSignCombo.Name = "stopSignCombo";
            this.stopSignCombo.Size = new System.Drawing.Size(121, 21);
            this.stopSignCombo.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Stop";
            // 
            // baudRateCombo
            // 
            this.baudRateCombo.FormattingEnabled = true;
            this.baudRateCombo.Location = new System.Drawing.Point(405, 79);
            this.baudRateCombo.Name = "baudRateCombo";
            this.baudRateCombo.Size = new System.Drawing.Size(121, 21);
            this.baudRateCombo.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Baud rate ";
            // 
            // parityCombo
            // 
            this.parityCombo.FormattingEnabled = true;
            this.parityCombo.Location = new System.Drawing.Point(405, 133);
            this.parityCombo.Name = "parityCombo";
            this.parityCombo.Size = new System.Drawing.Size(121, 21);
            this.parityCombo.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Parity";
            // 
            // ATBtn
            // 
            this.ATBtn.Location = new System.Drawing.Point(269, 50);
            this.ATBtn.Name = "ATBtn";
            this.ATBtn.Size = new System.Drawing.Size(60, 23);
            this.ATBtn.TabIndex = 40;
            this.ATBtn.Text = "AT";
            this.ATBtn.UseVisualStyleBackColor = true;
            this.ATBtn.Click += new System.EventHandler(this.ATBtn_Click);
            // 
            // userConsole
            // 
            this.userConsole.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userConsole.Location = new System.Drawing.Point(70, 79);
            this.userConsole.Name = "userConsole";
            this.userConsole.Size = new System.Drawing.Size(257, 162);
            this.userConsole.TabIndex = 39;
            this.userConsole.Text = "";
            // 
            // refreshComListBtn
            // 
            this.refreshComListBtn.Location = new System.Drawing.Point(369, 285);
            this.refreshComListBtn.Name = "refreshComListBtn";
            this.refreshComListBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshComListBtn.TabIndex = 38;
            this.refreshComListBtn.Text = "Refresh";
            this.refreshComListBtn.UseVisualStyleBackColor = true;
            this.refreshComListBtn.Click += new System.EventHandler(this.refreshComListBtn_Click);
            // 
            // selectPortButton
            // 
            this.selectPortButton.Location = new System.Drawing.Point(451, 284);
            this.selectPortButton.Name = "selectPortButton";
            this.selectPortButton.Size = new System.Drawing.Size(75, 23);
            this.selectPortButton.TabIndex = 37;
            this.selectPortButton.Text = "Connect";
            this.selectPortButton.UseVisualStyleBackColor = true;
            this.selectPortButton.Click += new System.EventHandler(this.selectPortButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(373, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Port";
            // 
            // comPortsCombo
            // 
            this.comPortsCombo.FormattingEnabled = true;
            this.comPortsCombo.Location = new System.Drawing.Point(405, 52);
            this.comPortsCombo.Name = "comPortsCombo";
            this.comPortsCombo.Size = new System.Drawing.Size(121, 21);
            this.comPortsCombo.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RIRadio);
            this.panel2.Location = new System.Drawing.Point(131, 244);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(52, 26);
            this.panel2.TabIndex = 54;
            // 
            // RIRadio
            // 
            this.RIRadio.AutoSize = true;
            this.RIRadio.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.RIRadio.Location = new System.Drawing.Point(3, 3);
            this.RIRadio.Name = "RIRadio";
            this.RIRadio.Size = new System.Drawing.Size(36, 17);
            this.RIRadio.TabIndex = 19;
            this.RIRadio.TabStop = true;
            this.RIRadio.Text = "RI";
            this.RIRadio.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DSRRadio);
            this.panel3.Location = new System.Drawing.Point(186, 243);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(56, 28);
            this.panel3.TabIndex = 55;
            // 
            // DSRRadio
            // 
            this.DSRRadio.AutoSize = true;
            this.DSRRadio.Cursor = System.Windows.Forms.Cursors.Default;
            this.DSRRadio.Location = new System.Drawing.Point(3, 4);
            this.DSRRadio.Name = "DSRRadio";
            this.DSRRadio.Size = new System.Drawing.Size(48, 17);
            this.DSRRadio.TabIndex = 20;
            this.DSRRadio.TabStop = true;
            this.DSRRadio.Text = "DSR";
            this.DSRRadio.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.CTSRadio);
            this.panel4.Location = new System.Drawing.Point(243, 243);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(58, 28);
            this.panel4.TabIndex = 56;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.amountOfRetransmNumUpDown);
            this.tabPage2.Controls.Add(this.MessageTextBox);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.frameTimeoutNumericUpDown);
            this.tabPage2.Controls.Add(this.outcomingRichTextBox);
            this.tabPage2.Controls.Add(this.IncomingRichTextBox);
            this.tabPage2.Controls.Add(this.commandNumericUpDown);
            this.tabPage2.Controls.Add(this.adressNumericUpDown);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.MasterSlaveGroupBox);
            this.tabPage2.Controls.Add(this.transactionTimeoutNumericUpDown);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(638, 407);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MODBUS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(167, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 13);
            this.label16.TabIndex = 45;
            this.label16.Text = "Sent:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(167, 159);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 44;
            this.label15.Text = "Received:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(488, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 55);
            this.button1.TabIndex = 41;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(170, 291);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "Message:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 329);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Command:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 283);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Receiver address:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Timeout(s):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(451, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(181, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Time spacing between characters[s]:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(448, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Amount of retransmissions:";
            // 
            // SlaveRadioButton
            // 
            this.SlaveRadioButton.AutoSize = true;
            this.SlaveRadioButton.Location = new System.Drawing.Point(86, 19);
            this.SlaveRadioButton.Name = "SlaveRadioButton";
            this.SlaveRadioButton.Size = new System.Drawing.Size(52, 17);
            this.SlaveRadioButton.TabIndex = 24;
            this.SlaveRadioButton.TabStop = true;
            this.SlaveRadioButton.Text = "Slave";
            this.SlaveRadioButton.UseVisualStyleBackColor = true;
            // 
            // MasterRadioButton
            // 
            this.MasterRadioButton.AutoSize = true;
            this.MasterRadioButton.Location = new System.Drawing.Point(6, 19);
            this.MasterRadioButton.Name = "MasterRadioButton";
            this.MasterRadioButton.Size = new System.Drawing.Size(57, 17);
            this.MasterRadioButton.TabIndex = 23;
            this.MasterRadioButton.TabStop = true;
            this.MasterRadioButton.Text = "Master";
            this.MasterRadioButton.UseVisualStyleBackColor = true;
            // 
            // MasterSlaveGroupBox
            // 
            this.MasterSlaveGroupBox.Controls.Add(this.SlaveRadioButton);
            this.MasterSlaveGroupBox.Controls.Add(this.MasterRadioButton);
            this.MasterSlaveGroupBox.Location = new System.Drawing.Point(18, 6);
            this.MasterSlaveGroupBox.Name = "MasterSlaveGroupBox";
            this.MasterSlaveGroupBox.Size = new System.Drawing.Size(138, 56);
            this.MasterSlaveGroupBox.TabIndex = 46;
            this.MasterSlaveGroupBox.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(145, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "ms";
            // 
            // transactionTimeoutNumericUpDown
            // 
            this.transactionTimeoutNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.transactionTimeoutNumericUpDown.Location = new System.Drawing.Point(18, 88);
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
            this.transactionTimeoutNumericUpDown.TabIndex = 25;
            this.transactionTimeoutNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // adressNumericUpDown
            // 
            this.adressNumericUpDown.Location = new System.Drawing.Point(18, 299);
            this.adressNumericUpDown.Maximum = new decimal(new int[] {
            247,
            0,
            0,
            0});
            this.adressNumericUpDown.Name = "adressNumericUpDown";
            this.adressNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.adressNumericUpDown.TabIndex = 47;
            // 
            // commandNumericUpDown
            // 
            this.commandNumericUpDown.Location = new System.Drawing.Point(18, 346);
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
            this.commandNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.commandNumericUpDown.TabIndex = 48;
            this.commandNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // IncomingRichTextBox
            // 
            this.IncomingRichTextBox.Location = new System.Drawing.Point(166, 186);
            this.IncomingRichTextBox.Name = "IncomingRichTextBox";
            this.IncomingRichTextBox.Size = new System.Drawing.Size(268, 88);
            this.IncomingRichTextBox.TabIndex = 49;
            this.IncomingRichTextBox.Text = "";
            // 
            // outcomingRichTextBox
            // 
            this.outcomingRichTextBox.Location = new System.Drawing.Point(166, 68);
            this.outcomingRichTextBox.Name = "outcomingRichTextBox";
            this.outcomingRichTextBox.Size = new System.Drawing.Size(268, 88);
            this.outcomingRichTextBox.TabIndex = 50;
            this.outcomingRichTextBox.Text = "";
            // 
            // frameTimeoutNumericUpDown
            // 
            this.frameTimeoutNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.frameTimeoutNumericUpDown.Location = new System.Drawing.Point(454, 186);
            this.frameTimeoutNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.frameTimeoutNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.frameTimeoutNumericUpDown.Name = "frameTimeoutNumericUpDown";
            this.frameTimeoutNumericUpDown.Size = new System.Drawing.Size(110, 20);
            this.frameTimeoutNumericUpDown.TabIndex = 51;
            this.frameTimeoutNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(570, 193);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 13);
            this.label17.TabIndex = 52;
            this.label17.Text = "ms";
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(166, 321);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(268, 20);
            this.MessageTextBox.TabIndex = 53;
            // 
            // amountOfRetransmNumUpDown
            // 
            this.amountOfRetransmNumUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.amountOfRetransmNumUpDown.Location = new System.Drawing.Point(451, 46);
            this.amountOfRetransmNumUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.amountOfRetransmNumUpDown.Name = "amountOfRetransmNumUpDown";
            this.amountOfRetransmNumUpDown.Size = new System.Drawing.Size(110, 20);
            this.amountOfRetransmNumUpDown.TabIndex = 54;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 431);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "IwSK - RS232";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.MasterSlaveGroupBox.ResumeLayout(false);
            this.MasterSlaveGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTimeoutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adressNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameTimeoutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountOfRetransmNumUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button PINGBtn;
        private System.Windows.Forms.CheckBox modBusCheckBox;
        private System.Windows.Forms.TextBox customlinetext;
        private System.Windows.Forms.CheckBox customnewline;
        private System.Windows.Forms.TextBox sendtext;
        private System.Windows.Forms.Button sendbutton;
        private System.Windows.Forms.ComboBox newLineCombo;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton DTRRadio;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton RTSRadio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton DCDRadio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox handShakeCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox dataBitsCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox stopSignCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox baudRateCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox parityCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ATBtn;
        private System.Windows.Forms.RichTextBox userConsole;
        private System.Windows.Forms.Button refreshComListBtn;
        private System.Windows.Forms.Button selectPortButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comPortsCombo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton RIRadio;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton DSRRadio;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton CTSRadio;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton SlaveRadioButton;
        private System.Windows.Forms.RadioButton MasterRadioButton;
        private System.Windows.Forms.GroupBox MasterSlaveGroupBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown transactionTimeoutNumericUpDown;
        private System.Windows.Forms.NumericUpDown adressNumericUpDown;
        private System.Windows.Forms.NumericUpDown commandNumericUpDown;
        private System.Windows.Forms.RichTextBox outcomingRichTextBox;
        private System.Windows.Forms.RichTextBox IncomingRichTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown frameTimeoutNumericUpDown;
        private System.Windows.Forms.NumericUpDown amountOfRetransmNumUpDown;
        private System.Windows.Forms.TextBox MessageTextBox;


    }
}

