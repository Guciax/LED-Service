namespace LED_Service
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxOperator = new System.Windows.Forms.ComboBox();
            this.buttonViDetails = new System.Windows.Forms.Button();
            this.buttonTestDetails = new System.Windows.Forms.Button();
            this.labelViInfo = new System.Windows.Forms.Label();
            this.labelTestInfo = new System.Windows.Forms.Label();
            this.labelLedInfo = new System.Windows.Forms.Label();
            this.labelLotInfo = new System.Windows.Forms.Label();
            this.textBoxPcbQr = new System.Windows.Forms.TextBox();
            this.listViewOperations = new System.Windows.Forms.ListView();
            this.colRef = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnComp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonDeleteSelected = new System.Windows.Forms.Button();
            this.buttonSaveToDb = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.butAddDamaged = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.butAddOperation = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.butAddModuleOK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxLabelReapplied = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.butAddScrap = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxComp = new System.Windows.Forms.GroupBox();
            this.radioButtonOther = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCompRef = new System.Windows.Forms.TextBox();
            this.radioButtonRes = new System.Windows.Forms.RadioButton();
            this.radioButtonConn = new System.Windows.Forms.RadioButton();
            this.radioButtonLED = new System.Windows.Forms.RadioButton();
            this.groupBoxOperation = new System.Windows.Forms.GroupBox();
            this.radioButtonPcbCleaning = new System.Windows.Forms.RadioButton();
            this.radioButtonWrongComp = new System.Windows.Forms.RadioButton();
            this.radioButtonSolderAdded = new System.Windows.Forms.RadioButton();
            this.radioButtonDamagedComp = new System.Windows.Forms.RadioButton();
            this.radioButtonMissingComp = new System.Windows.Forms.RadioButton();
            this.radioButtonShiftedComp = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.timerKeyboardDelay = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButtonMaskRepair = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBoxComp.SuspendLayout();
            this.groupBoxOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxOperator);
            this.panel1.Controls.Add(this.buttonViDetails);
            this.panel1.Controls.Add(this.buttonTestDetails);
            this.panel1.Controls.Add(this.labelViInfo);
            this.panel1.Controls.Add(this.labelTestInfo);
            this.panel1.Controls.Add(this.labelLedInfo);
            this.panel1.Controls.Add(this.labelLotInfo);
            this.panel1.Controls.Add(this.textBoxPcbQr);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panel1.ForeColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(334, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1455, 371);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(2, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "PCB QR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(2, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Operator:";
            // 
            // comboBoxOperator
            // 
            this.comboBoxOperator.FormattingEnabled = true;
            this.comboBoxOperator.Location = new System.Drawing.Point(2, 75);
            this.comboBoxOperator.Name = "comboBoxOperator";
            this.comboBoxOperator.Size = new System.Drawing.Size(166, 28);
            this.comboBoxOperator.TabIndex = 7;
            // 
            // buttonViDetails
            // 
            this.buttonViDetails.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonViDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonViDetails.Location = new System.Drawing.Point(10, 284);
            this.buttonViDetails.Name = "buttonViDetails";
            this.buttonViDetails.Size = new System.Drawing.Size(86, 27);
            this.buttonViDetails.TabIndex = 6;
            this.buttonViDetails.Text = "szczegóły";
            this.buttonViDetails.UseVisualStyleBackColor = false;
            this.buttonViDetails.Click += new System.EventHandler(this.buttonViDetails_Click);
            // 
            // buttonTestDetails
            // 
            this.buttonTestDetails.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonTestDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonTestDetails.Location = new System.Drawing.Point(308, 285);
            this.buttonTestDetails.Name = "buttonTestDetails";
            this.buttonTestDetails.Size = new System.Drawing.Size(79, 24);
            this.buttonTestDetails.TabIndex = 5;
            this.buttonTestDetails.Text = "szczegóły";
            this.buttonTestDetails.UseVisualStyleBackColor = false;
            this.buttonTestDetails.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelViInfo
            // 
            this.labelViInfo.AutoSize = true;
            this.labelViInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelViInfo.Location = new System.Drawing.Point(6, 314);
            this.labelViInfo.Name = "labelViInfo";
            this.labelViInfo.Size = new System.Drawing.Size(219, 24);
            this.labelViInfo.TabIndex = 4;
            this.labelViInfo.Text = "Dane kontroli wzrokowej:";
            // 
            // labelTestInfo
            // 
            this.labelTestInfo.AutoSize = true;
            this.labelTestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTestInfo.Location = new System.Drawing.Point(304, 314);
            this.labelTestInfo.Name = "labelTestInfo";
            this.labelTestInfo.Size = new System.Drawing.Size(104, 24);
            this.labelTestInfo.TabIndex = 3;
            this.labelTestInfo.Text = "Dane testu:";
            // 
            // labelLedInfo
            // 
            this.labelLedInfo.AutoSize = true;
            this.labelLedInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLedInfo.Location = new System.Drawing.Point(304, 123);
            this.labelLedInfo.Name = "labelLedInfo";
            this.labelLedInfo.Size = new System.Drawing.Size(101, 24);
            this.labelLedInfo.TabIndex = 2;
            this.labelLedInfo.Text = "Dane LED:";
            // 
            // labelLotInfo
            // 
            this.labelLotInfo.AutoSize = true;
            this.labelLotInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLotInfo.Location = new System.Drawing.Point(6, 123);
            this.labelLotInfo.Name = "labelLotInfo";
            this.labelLotInfo.Size = new System.Drawing.Size(135, 24);
            this.labelLotInfo.TabIndex = 1;
            this.labelLotInfo.Text = "Dane zlecenia:";
            // 
            // textBoxPcbQr
            // 
            this.textBoxPcbQr.Location = new System.Drawing.Point(2, 21);
            this.textBoxPcbQr.Name = "textBoxPcbQr";
            this.textBoxPcbQr.Size = new System.Drawing.Size(166, 26);
            this.textBoxPcbQr.TabIndex = 0;
            this.textBoxPcbQr.TextChanged += new System.EventHandler(this.textBoxPcbQr_TextChanged);
            this.textBoxPcbQr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // listViewOperations
            // 
            this.listViewOperations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRef,
            this.columnComp,
            this.colOperation});
            this.listViewOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewOperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listViewOperations.FullRowSelect = true;
            this.listViewOperations.Location = new System.Drawing.Point(0, 34);
            this.listViewOperations.Name = "listViewOperations";
            this.listViewOperations.Size = new System.Drawing.Size(328, 210);
            this.listViewOperations.TabIndex = 1;
            this.listViewOperations.UseCompatibleStateImageBehavior = false;
            this.listViewOperations.View = System.Windows.Forms.View.Details;
            // 
            // colRef
            // 
            this.colRef.Text = "Ref";
            // 
            // columnComp
            // 
            this.columnComp.Text = "Komponent";
            this.columnComp.Width = 80;
            // 
            // colOperation
            // 
            this.colOperation.Text = "Naprawa";
            this.colOperation.Width = 250;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel4.Controls.Add(this.buttonDeleteSelected);
            this.panel4.Controls.Add(this.buttonSaveToDb);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(328, 34);
            this.panel4.TabIndex = 3;
            // 
            // buttonDeleteSelected
            // 
            this.buttonDeleteSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDeleteSelected.Location = new System.Drawing.Point(168, 0);
            this.buttonDeleteSelected.Name = "buttonDeleteSelected";
            this.buttonDeleteSelected.Size = new System.Drawing.Size(160, 34);
            this.buttonDeleteSelected.TabIndex = 9;
            this.buttonDeleteSelected.Text = "Usuń zaznaczone";
            this.buttonDeleteSelected.UseVisualStyleBackColor = true;
            this.buttonDeleteSelected.Click += new System.EventHandler(this.buttonDeleteSelected_Click);
            // 
            // buttonSaveToDb
            // 
            this.buttonSaveToDb.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonSaveToDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSaveToDb.Location = new System.Drawing.Point(0, 0);
            this.buttonSaveToDb.Name = "buttonSaveToDb";
            this.buttonSaveToDb.Size = new System.Drawing.Size(168, 34);
            this.buttonSaveToDb.TabIndex = 8;
            this.buttonSaveToDb.Text = "Zakończ i zapisz";
            this.buttonSaveToDb.UseVisualStyleBackColor = true;
            this.buttonSaveToDb.Click += new System.EventHandler(this.buttonSaveToDb_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.butAddOperation);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.checkBoxLabelReapplied);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.groupBoxComp);
            this.panel5.Controls.Add(this.groupBoxOperation);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panel5.Location = new System.Drawing.Point(3, 253);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(328, 609);
            this.panel5.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.butAddDamaged);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panel8.Location = new System.Drawing.Point(0, 502);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(326, 35);
            this.panel8.TabIndex = 7;
            // 
            // butAddDamaged
            // 
            this.butAddDamaged.Location = new System.Drawing.Point(261, 4);
            this.butAddDamaged.Name = "butAddDamaged";
            this.butAddDamaged.Size = new System.Drawing.Size(60, 23);
            this.butAddDamaged.TabIndex = 8;
            this.butAddDamaged.Text = "Dodaj";
            this.butAddDamaged.UseVisualStyleBackColor = true;
            this.butAddDamaged.Click += new System.EventHandler(this.butAddDamaged_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(257, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Uszkodzenie podczas naprawy - Scrap.";
            // 
            // butAddOperation
            // 
            this.butAddOperation.Location = new System.Drawing.Point(262, 424);
            this.butAddOperation.Name = "butAddOperation";
            this.butAddOperation.Size = new System.Drawing.Size(64, 23);
            this.butAddOperation.TabIndex = 7;
            this.butAddOperation.Text = "Dodaj";
            this.butAddOperation.UseVisualStyleBackColor = true;
            this.butAddOperation.Click += new System.EventHandler(this.butAddOperation_Click);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.butAddModuleOK);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panel6.Location = new System.Drawing.Point(0, 537);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(326, 35);
            this.panel6.TabIndex = 5;
            // 
            // butAddModuleOK
            // 
            this.butAddModuleOK.Location = new System.Drawing.Point(261, 4);
            this.butAddModuleOK.Name = "butAddModuleOK";
            this.butAddModuleOK.Size = new System.Drawing.Size(60, 23);
            this.butAddModuleOK.TabIndex = 8;
            this.butAddModuleOK.Text = "Dodaj";
            this.butAddModuleOK.UseVisualStyleBackColor = true;
            this.butAddModuleOK.Click += new System.EventHandler(this.butAddModuleOK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Naprawa nie potrzebna, wybrób OK";
            // 
            // checkBoxLabelReapplied
            // 
            this.checkBoxLabelReapplied.AutoSize = true;
            this.checkBoxLabelReapplied.Location = new System.Drawing.Point(8, 397);
            this.checkBoxLabelReapplied.Name = "checkBoxLabelReapplied";
            this.checkBoxLabelReapplied.Size = new System.Drawing.Size(293, 21);
            this.checkBoxLabelReapplied.TabIndex = 6;
            this.checkBoxLabelReapplied.Text = "Podczas naprawy odklejana była naklejka.";
            this.checkBoxLabelReapplied.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.butAddScrap);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panel7.Location = new System.Drawing.Point(0, 572);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(326, 35);
            this.panel7.TabIndex = 6;
            // 
            // butAddScrap
            // 
            this.butAddScrap.Location = new System.Drawing.Point(261, 4);
            this.butAddScrap.Name = "butAddScrap";
            this.butAddScrap.Size = new System.Drawing.Size(60, 23);
            this.butAddScrap.TabIndex = 8;
            this.butAddScrap.Text = "Dodaj";
            this.butAddScrap.UseVisualStyleBackColor = true;
            this.butAddScrap.Click += new System.EventHandler(this.butAddScrap_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(249, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nie kwalifikuje się do naprawy - Scrap.";
            // 
            // groupBoxComp
            // 
            this.groupBoxComp.Controls.Add(this.radioButtonOther);
            this.groupBoxComp.Controls.Add(this.radioButton1);
            this.groupBoxComp.Controls.Add(this.label9);
            this.groupBoxComp.Controls.Add(this.label8);
            this.groupBoxComp.Controls.Add(this.textBoxCompRef);
            this.groupBoxComp.Controls.Add(this.radioButtonRes);
            this.groupBoxComp.Controls.Add(this.radioButtonConn);
            this.groupBoxComp.Controls.Add(this.radioButtonLED);
            this.groupBoxComp.Location = new System.Drawing.Point(8, 264);
            this.groupBoxComp.Name = "groupBoxComp";
            this.groupBoxComp.Size = new System.Drawing.Size(317, 127);
            this.groupBoxComp.TabIndex = 5;
            this.groupBoxComp.TabStop = false;
            this.groupBoxComp.Text = "Komponent";
            // 
            // radioButtonOther
            // 
            this.radioButtonOther.Location = new System.Drawing.Point(6, 96);
            this.radioButtonOther.Name = "radioButtonOther";
            this.radioButtonOther.Size = new System.Drawing.Size(146, 22);
            this.radioButtonOther.TabIndex = 11;
            this.radioButtonOther.TabStop = true;
            this.radioButtonOther.Text = "Inny";
            this.radioButtonOther.UseVisualStyleBackColor = true;
            this.radioButtonOther.CheckedChanged += new System.EventHandler(this.radioButtonLED_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(171, 11);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(146, 22);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "???";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(147, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "(np. 1A lub J1 lub CON1 )";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(183, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Opis";
            // 
            // textBoxCompRef
            // 
            this.textBoxCompRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxCompRef.Location = new System.Drawing.Point(226, 69);
            this.textBoxCompRef.Name = "textBoxCompRef";
            this.textBoxCompRef.Size = new System.Drawing.Size(49, 26);
            this.textBoxCompRef.TabIndex = 7;
            // 
            // radioButtonRes
            // 
            this.radioButtonRes.Location = new System.Drawing.Point(6, 72);
            this.radioButtonRes.Name = "radioButtonRes";
            this.radioButtonRes.Size = new System.Drawing.Size(146, 22);
            this.radioButtonRes.TabIndex = 6;
            this.radioButtonRes.TabStop = true;
            this.radioButtonRes.Tag = "R";
            this.radioButtonRes.Text = "Rezystor";
            this.radioButtonRes.UseVisualStyleBackColor = true;
            this.radioButtonRes.CheckedChanged += new System.EventHandler(this.radioButtonLED_CheckedChanged);
            // 
            // radioButtonConn
            // 
            this.radioButtonConn.Location = new System.Drawing.Point(6, 48);
            this.radioButtonConn.Name = "radioButtonConn";
            this.radioButtonConn.Size = new System.Drawing.Size(146, 22);
            this.radioButtonConn.TabIndex = 5;
            this.radioButtonConn.TabStop = true;
            this.radioButtonConn.Tag = "Conn";
            this.radioButtonConn.Text = "Złączka";
            this.radioButtonConn.UseVisualStyleBackColor = true;
            this.radioButtonConn.CheckedChanged += new System.EventHandler(this.radioButtonLED_CheckedChanged);
            // 
            // radioButtonLED
            // 
            this.radioButtonLED.Location = new System.Drawing.Point(6, 24);
            this.radioButtonLED.Name = "radioButtonLED";
            this.radioButtonLED.Size = new System.Drawing.Size(146, 22);
            this.radioButtonLED.TabIndex = 4;
            this.radioButtonLED.TabStop = true;
            this.radioButtonLED.Tag = "D";
            this.radioButtonLED.Text = "Dioda LED";
            this.radioButtonLED.UseVisualStyleBackColor = true;
            this.radioButtonLED.CheckedChanged += new System.EventHandler(this.radioButtonLED_CheckedChanged);
            // 
            // groupBoxOperation
            // 
            this.groupBoxOperation.Controls.Add(this.radioButtonMaskRepair);
            this.groupBoxOperation.Controls.Add(this.radioButton2);
            this.groupBoxOperation.Controls.Add(this.radioButtonPcbCleaning);
            this.groupBoxOperation.Controls.Add(this.radioButtonWrongComp);
            this.groupBoxOperation.Controls.Add(this.radioButtonSolderAdded);
            this.groupBoxOperation.Controls.Add(this.radioButtonDamagedComp);
            this.groupBoxOperation.Controls.Add(this.radioButtonMissingComp);
            this.groupBoxOperation.Controls.Add(this.radioButtonShiftedComp);
            this.groupBoxOperation.Location = new System.Drawing.Point(7, 26);
            this.groupBoxOperation.Name = "groupBoxOperation";
            this.groupBoxOperation.Size = new System.Drawing.Size(317, 232);
            this.groupBoxOperation.TabIndex = 4;
            this.groupBoxOperation.TabStop = false;
            this.groupBoxOperation.Text = "Rodzaj naprawy";
            // 
            // radioButtonPcbCleaning
            // 
            this.radioButtonPcbCleaning.Location = new System.Drawing.Point(6, 141);
            this.radioButtonPcbCleaning.Name = "radioButtonPcbCleaning";
            this.radioButtonPcbCleaning.Size = new System.Drawing.Size(255, 22);
            this.radioButtonPcbCleaning.TabIndex = 5;
            this.radioButtonPcbCleaning.TabStop = true;
            this.radioButtonPcbCleaning.Text = "Czyszczenie PCB";
            this.radioButtonPcbCleaning.UseVisualStyleBackColor = true;
            this.radioButtonPcbCleaning.CheckedChanged += new System.EventHandler(this.radioButtonPcbCleaning_CheckedChanged);
            // 
            // radioButtonWrongComp
            // 
            this.radioButtonWrongComp.Location = new System.Drawing.Point(6, 117);
            this.radioButtonWrongComp.Name = "radioButtonWrongComp";
            this.radioButtonWrongComp.Size = new System.Drawing.Size(255, 22);
            this.radioButtonWrongComp.TabIndex = 4;
            this.radioButtonWrongComp.TabStop = true;
            this.radioButtonWrongComp.Text = "Pomylony komponent - wymiana.";
            this.radioButtonWrongComp.UseVisualStyleBackColor = true;
            // 
            // radioButtonSolderAdded
            // 
            this.radioButtonSolderAdded.Location = new System.Drawing.Point(6, 21);
            this.radioButtonSolderAdded.Name = "radioButtonSolderAdded";
            this.radioButtonSolderAdded.Size = new System.Drawing.Size(146, 22);
            this.radioButtonSolderAdded.TabIndex = 0;
            this.radioButtonSolderAdded.TabStop = true;
            this.radioButtonSolderAdded.Text = "Dodanie lutowia";
            this.radioButtonSolderAdded.UseVisualStyleBackColor = true;
            // 
            // radioButtonDamagedComp
            // 
            this.radioButtonDamagedComp.Location = new System.Drawing.Point(6, 93);
            this.radioButtonDamagedComp.Name = "radioButtonDamagedComp";
            this.radioButtonDamagedComp.Size = new System.Drawing.Size(255, 22);
            this.radioButtonDamagedComp.TabIndex = 3;
            this.radioButtonDamagedComp.TabStop = true;
            this.radioButtonDamagedComp.Text = "Uszkodzony komponent - wymiana.";
            this.radioButtonDamagedComp.UseVisualStyleBackColor = true;
            // 
            // radioButtonMissingComp
            // 
            this.radioButtonMissingComp.Location = new System.Drawing.Point(6, 45);
            this.radioButtonMissingComp.Name = "radioButtonMissingComp";
            this.radioButtonMissingComp.Size = new System.Drawing.Size(334, 22);
            this.radioButtonMissingComp.TabIndex = 1;
            this.radioButtonMissingComp.TabStop = true;
            this.radioButtonMissingComp.Text = "Brak komponentu - dodanie.";
            this.radioButtonMissingComp.UseVisualStyleBackColor = true;
            // 
            // radioButtonShiftedComp
            // 
            this.radioButtonShiftedComp.Location = new System.Drawing.Point(6, 69);
            this.radioButtonShiftedComp.Name = "radioButtonShiftedComp";
            this.radioButtonShiftedComp.Size = new System.Drawing.Size(325, 22);
            this.radioButtonShiftedComp.TabIndex = 2;
            this.radioButtonShiftedComp.TabStop = true;
            this.radioButtonShiftedComp.Text = "Przesunięty, obrócony komponent - naprawa.";
            this.radioButtonShiftedComp.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Naprawa";
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.AllowUserToAddRows = false;
            this.dataGridViewHistory.AllowUserToDeleteRows = false;
            this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistory.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewHistory.Location = new System.Drawing.Point(334, 371);
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.Size = new System.Drawing.Size(1018, 494);
            this.dataGridViewHistory.TabIndex = 8;
            // 
            // timerKeyboardDelay
            // 
            this.timerKeyboardDelay.Interval = 300;
            this.timerKeyboardDelay.Tick += new System.EventHandler(this.timerKeyboardDelay_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 455F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 865);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listViewOperations);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 244);
            this.panel2.TabIndex = 5;
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(6, 189);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(255, 22);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Inne";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButtonMaskRepair
            // 
            this.radioButtonMaskRepair.Location = new System.Drawing.Point(6, 165);
            this.radioButtonMaskRepair.Name = "radioButtonMaskRepair";
            this.radioButtonMaskRepair.Size = new System.Drawing.Size(255, 22);
            this.radioButtonMaskRepair.TabIndex = 7;
            this.radioButtonMaskRepair.TabStop = true;
            this.radioButtonMaskRepair.Text = "Naprawa maski";
            this.radioButtonMaskRepair.UseVisualStyleBackColor = true;
            this.radioButtonMaskRepair.CheckedChanged += new System.EventHandler(this.radioButtonPcbCleaning_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1789, 865);
            this.Controls.Add(this.dataGridViewHistory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Naprawa LED";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBoxComp.ResumeLayout(false);
            this.groupBoxComp.PerformLayout();
            this.groupBoxOperation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelViInfo;
        private System.Windows.Forms.Label labelTestInfo;
        private System.Windows.Forms.Label labelLedInfo;
        private System.Windows.Forms.Label labelLotInfo;
        private System.Windows.Forms.TextBox textBoxPcbQr;
        private System.Windows.Forms.Button buttonTestDetails;
        private System.Windows.Forms.Button buttonViDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxOperator;
        private System.Windows.Forms.ListView listViewOperations;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.CheckBox checkBoxLabelReapplied;
        private System.Windows.Forms.GroupBox groupBoxComp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxCompRef;
        private System.Windows.Forms.RadioButton radioButtonRes;
        private System.Windows.Forms.RadioButton radioButtonConn;
        private System.Windows.Forms.RadioButton radioButtonLED;
        private System.Windows.Forms.GroupBox groupBoxOperation;
        private System.Windows.Forms.RadioButton radioButtonSolderAdded;
        private System.Windows.Forms.RadioButton radioButtonDamagedComp;
        private System.Windows.Forms.RadioButton radioButtonMissingComp;
        private System.Windows.Forms.RadioButton radioButtonShiftedComp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonSaveToDb;
        private System.Windows.Forms.Button butAddOperation;
        private System.Windows.Forms.Button butAddModuleOK;
        private System.Windows.Forms.Button butAddScrap;
        private System.Windows.Forms.Button butAddDamaged;
        private System.Windows.Forms.ColumnHeader colRef;
        private System.Windows.Forms.ColumnHeader colOperation;
        private System.Windows.Forms.Button buttonDeleteSelected;
        private System.Windows.Forms.ColumnHeader columnComp;
        private System.Windows.Forms.RadioButton radioButtonOther;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButtonPcbCleaning;
        private System.Windows.Forms.RadioButton radioButtonWrongComp;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.Timer timerKeyboardDelay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonMaskRepair;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

