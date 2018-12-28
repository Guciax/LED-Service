namespace LED_Service.Forms
{
    partial class RegisterNg
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelSerial = new System.Windows.Forms.Label();
            this.flowLayoutPanelNg = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelScrap = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelScrap, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelNg, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 100);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 350);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.labelSerial);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 1;
            // 
            // labelSerial
            // 
            this.labelSerial.AutoSize = true;
            this.labelSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSerial.Location = new System.Drawing.Point(12, 61);
            this.labelSerial.Name = "labelSerial";
            this.labelSerial.Size = new System.Drawing.Size(64, 26);
            this.labelSerial.TabIndex = 0;
            this.labelSerial.Text = "serial";
            // 
            // flowLayoutPanelNg
            // 
            this.flowLayoutPanelNg.BackColor = System.Drawing.Color.Red;
            this.flowLayoutPanelNg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelNg.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanelNg.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelNg.Name = "flowLayoutPanelNg";
            this.flowLayoutPanelNg.Size = new System.Drawing.Size(394, 344);
            this.flowLayoutPanelNg.TabIndex = 0;
            // 
            // flowLayoutPanelScrap
            // 
            this.flowLayoutPanelScrap.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanelScrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelScrap.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanelScrap.Location = new System.Drawing.Point(403, 3);
            this.flowLayoutPanelScrap.Name = "flowLayoutPanelScrap";
            this.flowLayoutPanelScrap.Size = new System.Drawing.Size(394, 344);
            this.flowLayoutPanelScrap.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(684, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 100);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Brak panelu w bazie danych, usupełnij przyczynę NG";
            // 
            // RegisterNg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "RegisterNg";
            this.Text = "RegisterNg";
            this.Load += new System.EventHandler(this.RegisterNg_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelScrap;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSerial;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}