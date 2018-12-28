using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LED_Service.Forms
{
    public partial class RegisterNg : Form
    {
        public string buttonClicked = "";

        public RegisterNg(string serial)
        {
            InitializeComponent();
            this.serial = serial;
            
        }

        string[] ngButtonNames = new string[] { "ngBrakLutowia", "ngBrakDiodyLed", "ngBrakResConn", "ngPrzesuniecieLed", "ngPrzesuniecieResConn", "ngZabrudzenieLed", "ngUszkodzenieMechaniczneLed", "ngUszkodzenieConn", "ngWadaFabrycznaDiody", "ngUszkodzonePcb", "ngWadaNaklejki", "ngSpalonyConn", "ngInne",  "ngTestElektryczny" };
        string[] scrapButtonNames = new string[] {  "scrapBrakLutowia", "scrapBrakDiodyLed", "scrapBrakResConn", "scrapPrzesuniecieLed", "scrapPrzesuniecieResConn", "scrapZabrudzenieLed", "scrapUszkodzenieMechaniczneLed", "scrapUszkodzenieConn", "scrapWadaFabrycznaDiody", "scrapUszkodzonePcb", "scrapWadaNaklejki", "scrapSpalonyConn", "scrapInne" };

        private void RegisterNg_Load(object sender, EventArgs e)
        {
            CreateWasteReasonButtons(ngButtonNames, scrapButtonNames);
            labelSerial.Text = serial;
        }

        private void CreateWasteReasonButtons(string[] ngButtons, string[] scrapButtons)
        {
            foreach (var ngButton in ngButtons)
            {
                Button btn = new Button();
                btn.Name = ngButton;
                btn.Text = ngButton;
                btn.Width = 120;
                btn.Margin = new Padding(3);
                btn.Height = 50;
                btn.ForeColor = Color.White;
                //btn.BackColor = Color.Red;
                btn.FlatStyle = FlatStyle.Flat;
                btn.MouseClick += btn_MouseClick;
                flowLayoutPanelNg.Controls.Add(btn);
            }

            foreach (var scrapButton in scrapButtons)
            {
                Button btn = new Button();
                btn.Name = scrapButton;
                btn.Text = scrapButton;
                btn.Width = 120;
                btn.Margin = new Padding(3);
                btn.Height = 50;
                btn.ForeColor = Color.White;
                //btn.BackColor = Color.Black;
                btn.FlatStyle = FlatStyle.Flat;
                btn.MouseClick += btn_MouseClick;
                flowLayoutPanelScrap.Controls.Add(btn);
            }
        }

        Button prevBtn = null;
        private readonly string serial;

        private void btn_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.Font = new Font(btn.Font, FontStyle.Bold);
            button1.Visible = true;

            if (prevBtn != null)
            {
                prevBtn.BackColor = prevBtn.Parent.BackColor;
                prevBtn.ForeColor = prevBtn.Parent.ForeColor;
                prevBtn.Font = new Font(prevBtn.Font, FontStyle.Regular);

            }
            prevBtn = btn;
            this.buttonClicked = btn.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonClicked!="")
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
