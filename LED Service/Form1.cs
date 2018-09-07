using AForge.Video;
using AForge.Video.DirectShow;
using LED_Service.Data_Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LED_Service
{
    public partial class Form1 : Form
    {
        FilterInfoCollection CaptureDevice;
        VideoCaptureDevice FinalFrame;
        string deviceMonikerString = "";
        Bitmap camFrameBitmap;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewHistory.DataSource = historyTable;
            comboBoxOperator.Items.Clear();
            comboBoxOperator.Items.AddRange(SqlOperations.GetListOfOperators());
            var screen = Screen.FromControl(this).Bounds;
            this.Height = screen.Height;
            this.Width = screen.Width / 2;
            currentLotInfo = new LotInfo("", "", 0, "", "", "", "", "", "");

            FinalFrame = new VideoCaptureDevice();
            deviceMonikerString = CameraTools.CheckDeviceMonikerString(CaptureDevice);
            ProductionHistory.LoadHistoryFromTextFile(ref historyTable);
        }

        DataTable testData = new DataTable();
        DataTable visInspInfo = new DataTable();
        DataTable historyTable = new DataTable();
        LotInfo currentLotInfo = null;

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ReadPcbQr();
            }
        }

        private List<Image> TryGetFailureImages(string lot, string serial, string date)
        {
            List<Image> result = new List<Image>();
            var path = Path.Combine(@"P:\Kontrola_Wzrokowa", date, lot);
            
            DirectoryInfo dirNfo = new DirectoryInfo(path);
            if (!dirNfo.Exists) return new List<Image>();
            var files = dirNfo.GetFiles();

            foreach (var file in files)
            {
                if (file.Name.Split('_')[0] == serial)
                {
                    result.Add(Image.FromFile(file.FullName));
                }
            }

            return result;
        }

        private void ReadPcbQr()
        {
            testData = SqlOperations.GetMeasurementsForPcb(textBoxPcbQr.Text);
            if (testData.Rows.Count > 0 & textBoxPcbQr.Text.Trim()!="")
            {
                string lot = testData.Rows[0]["wip_entity_name"].ToString();
                currentLotInfo = SqlOperations.GetLotInfo(lot);
                visInspInfo = SqlOperations.GetVisualInspectionInfo(lot);

                if (visInspInfo.Rows.Count > 0)
                {
                    var date = DateTime.ParseExact(visInspInfo.Rows[0]["Data_czas"].ToString(), "dd.MM.yyyy HH:mm:ss", CultureInfo.CurrentCulture);
                    //Data_czas 03.04.2018 07:11:00
                    var images = TryGetFailureImages(lot, textBoxPcbQr.Text, date.ToString("dd-MM-yyyy"));

                    if (images.Count>0)
                    {
                        buttonFailureImages.Tag = images;
                        buttonFailureImages.Visible = true;
                    }
                    else
                    {
                        buttonFailureImages.Visible = false;
                    }

                        }
                labelLotItem.Text = 
                    "Nr zlecenia:" + Environment.NewLine
                    + "Model:" + Environment.NewLine
                    + "Kitting data: " + Environment.NewLine
                    + "Koniec zl: " + Environment.NewLine
                    + "Ilość wykonana: ";

                labelLotValue.Text =
                     lot + Environment.NewLine
                    +  currentLotInfo.Model + Environment.NewLine
                    +  currentLotInfo.StartDate + Environment.NewLine
                    +  currentLotInfo.EndDate + Environment.NewLine
                    + currentLotInfo.ManufacturedQty;

                labelLedItem.Text =
                     "LED: "  + Environment.NewLine
                    + "RankA: "  + Environment.NewLine
                    + "RankB: " ;
                labelLedValue.Text =
                      currentLotInfo.LedFamily + Environment.NewLine
                    + currentLotInfo.RankA + Environment.NewLine
                    + currentLotInfo.RankB;

                string testResult = "";
                string ngType = "";
                string viResult = "OK";
                foreach (DataRow row in testData.Rows)
                {
                    //serial_no,inspection_time,tester_id,wip_entity_id,wip_entity_name,program_id,result,ng_type,lm,lm_w,sdcm,cri,cct,v,i,w,x,y,r9,bin,lx,retest,module_num,lm1_gain,x1_offset,y1_offset,vf1_offset,cri1_offset,cct1_offset,lm1_master,x1_master,y1_master,vf1_master,cri1_master,cct1_master,hi_pot,light_on,optical,result_int FROM tb_tester_measurements
                    if (testResult != "OK")
                    {
                        testResult = row["result"].ToString();
                    }
                    if (row["result"].ToString() == "NGV")
                    {
                        viResult = "NG";
                    }
                }

                if (testResult == "NG")
                {
                    foreach (DataRow row in testData.Rows)
                    {
                        ngType += row["ng_type"].ToString() + ", ";
                    }
                    ngType = "Przyczyna NG: " + ngType;
                }

                labelTestItem.Text =
                    "Wynik: " + Environment.NewLine + ngType;

                labelTestValue.Text =
                    testResult + Environment.NewLine;
                    

                labelViItem.Text =
                    "Wynik: ";
                labelViValue.Text =
                     viResult;
            }
            else
            {
                labelLotInfo.Text = "";
                labelLedInfo.Text = "";
                labelTestInfo.Text = "";

                labelViInfo.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testDetails testForm = new testDetails(testData);
            testForm.ShowDialog();
        }

        private void buttonViDetails_Click(object sender, EventArgs e)
        {
            DataTable rotatedTable = new DataTable();
            rotatedTable.Columns.Add("Pole");
            rotatedTable.Columns.Add("Wartość");

            if (visInspInfo.Rows.Count > 0) 
            {
                for (int c = 0; c < visInspInfo.Columns.Count; c++)
                {
                    rotatedTable.Rows.Add(visInspInfo.Columns[c].ColumnName, visInspInfo.Rows[0][c].ToString());
                }
            }
            testDetails testForm = new testDetails(rotatedTable);
            testForm.ShowDialog();
        }

        private string GetOperationName()
        {
            foreach (RadioButton radio in groupBoxOperation.Controls.OfType<RadioButton>())
            {
                if (radio.Checked) return radio.Text.ToString();
            }
            return "";
        }

        private string GetCompnName()
        {
            foreach (RadioButton radio in groupBoxComp.Controls.OfType<RadioButton>())
            {
                if (radio.Checked) return radio.Text.ToString();
            }
            return "";
        }

        private void LockListView(bool state)
        {
            listViewOperations.Tag = state;
        }

        private bool ListViewLocked()
        {
            bool state = Convert.ToBoolean(listViewOperations.Tag);

            return state;
        }

        private void butAddOperation_Click(object sender, EventArgs e)
        {
            string compName = GetCompnName();
            string operationName = GetOperationName();
            string refId = textBoxCompRef.Text;
            if (compName != "" & operationName != "" & refId != "" & !ListViewLocked()) 
            {
                ListViewItem newItem = new ListViewItem(refId);
                newItem.SubItems.Add(compName);
                newItem.SubItems.Add(operationName);

                listViewOperations.Items.Add(newItem);
                listViewOperations.BackColor = Color.White;

                foreach (RadioButton radio in groupBoxComp.Controls.OfType<RadioButton>())
                {
                    radio.Checked = false;
                }

                foreach (RadioButton radio in groupBoxOperation.Controls.OfType<RadioButton>())
                {
                    radio.Checked = false;
                }
                textBoxCompRef.Text = "";
            }
        }

        private void butAddModuleOK_Click(object sender, EventArgs e)
        {
            ListViewItem newItem = new ListViewItem("");
            newItem.SubItems.Add("");
            newItem.SubItems.Add("Moduł OK - bez naprawy.");
            listViewOperations.Items.Add(newItem);
            listViewOperations.BackColor = Color.White;

        }

        private void butAddScrap_Click(object sender, EventArgs e)
        {
            ListViewItem newItem = new ListViewItem("");
            newItem.SubItems.Add("");
            newItem.SubItems.Add("SCRAP - nie kwalifikuje się do naprawy.");
            listViewOperations.Items.Add(newItem);
            listViewOperations.BackColor = Color.White;

            LockListView(true);
        }

        private void butAddDamaged_Click(object sender, EventArgs e)
        {
            ListViewItem newItem = new ListViewItem("");
            newItem.SubItems.Add("");
            newItem.SubItems.Add("SCRAP - uszkodzenie podczas naprawy.");
            listViewOperations.Items.Add(newItem);
            listViewOperations.BackColor = Color.White;

            LockListView(true);
        }

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            if (listViewOperations.SelectedItems.Count > 0) 
                listViewOperations.Items.RemoveAt(listViewOperations.Items.IndexOf(listViewOperations.SelectedItems[0]));

            bool unlock = true;
            foreach (ListViewItem item in listViewOperations.Items)
            {
                if (item.Text.ToUpper().Contains("SCRAP")) unlock = false;
            }
            if(unlock)
            {
                LockListView(false);
            }
        }

        private void buttonSaveToDb_Click(object sender, EventArgs e)
        {
            if (AllDataCorrect())
            {
                using (TakePhotoForm photoForm = new TakePhotoForm(deviceMonikerString, textBoxPcbQr.Text))
                {
                    if (photoForm.ShowDialog() == DialogResult.OK)
                    {
                        ProductionHistory.AddModuleToHostory(currentLotInfo.Model, textBoxPcbQr.Text, comboBoxOperator.Text, ref historyTable);
                        foreach (DataGridViewColumn col in dataGridViewHistory.Columns)
                        {
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                        List<SaveRecord> listToSave = new List<SaveRecord>();

                        foreach (ListViewItem item in listViewOperations.Items)
                        {
                            string oper = comboBoxOperator.Text;
                            string model = currentLotInfo.Model;
                            string serialNo = textBoxPcbQr.Text;
                            string jobDescription = item.SubItems[2].Text;
                            string compRef = item.SubItems[0].Text;
                            string result = "OK";

                            if (jobDescription.Contains("SCRAP"))
                            {
                                result = "NG";
                            }
                            SaveRecord saveLine = new SaveRecord(oper, model, serialNo, jobDescription, compRef, result);
                            listToSave.Add(saveLine);
                        }

                        LockListView(false);
                        SqlOperations.SaveRecordToDb(listToSave);
                        comboBoxOperator.Items.Clear();
                        comboBoxOperator.Items.AddRange(SqlOperations.GetListOfOperators());
                        CleanUpForm();
                        textBoxPcbQr.Focus();
                    }
                }
                    
            }
        }

        private void CleanUpForm()
        {
            textBoxPcbQr.Text = "";
            comboBoxOperator.Text = "";
            listViewOperations.Items.Clear();
            textBoxCompRef.Text = "";
            checkBoxLabelReapplied.Checked = false;
            labelLotValue.Text = "";
            labelLedValue.Text = "";
            labelTestValue.Text = "";
            labelViValue.Text = "";

            currentLotInfo = new LotInfo("", "", 0, "", "", "", "", "", "");

            foreach (RadioButton rdo in groupBoxOperation.Controls.OfType<RadioButton>())
            {
                rdo.Checked = false;
            }

            foreach (RadioButton rdo in groupBoxComp.Controls.OfType<RadioButton>())
            {
                rdo.Checked = false;
            }
        }

        private bool AllDataCorrect()
        {
            bool result = true;
           // if (currentLotInfo == null) result = false;
            if (comboBoxOperator.Text == "")
            {
                result = false;
                comboBoxOperator.BackColor = Color.Red;
            }

            if (listViewOperations.Items.Count == 0)
            {
                result = false;
                listViewOperations.BackColor = Color.Red;
            }

            if (textBoxPcbQr.Text=="")
            {
                result = false;
                textBoxPcbQr.BackColor = Color.Red;
            }

            return result;
        }

        private void radioButtonLED_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioChecked = (RadioButton)sender;
            if (radioChecked.Tag != null)
            {
                textBoxCompRef.Text = radioChecked.Tag.ToString();
                textBoxCompRef.Focus();
                if (textBoxCompRef.Text.Length > 0)
                {
                    textBoxCompRef.SelectionStart = textBoxCompRef.Text.Length; // add some logic if length is 0
                    textBoxCompRef.SelectionLength = 0;
                }
            }
            else
            {
                textBoxCompRef.Text = "";
            }
        }


        private void textBoxPcbQr_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPcbQr.Text=="")
            {
                CleanUpForm();
            }
            if (textBoxPcbQr.BackColor==Color.Red & textBoxPcbQr.Text!="")
            {
                textBoxPcbQr.BackColor = Color.White;
            }
        }

        private void timerKeyboardDelay_Tick(object sender, EventArgs e)
        {
            ReadPcbQr();
            timerKeyboardDelay.Enabled = false;
        }

        private void radioButtonPcbCleaning_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMaskRepair.Checked || radioButtonPcbCleaning.Checked)
            {
                radioButtonOther.Checked = true;
                textBoxCompRef.Text = "PCB";
            }
            else
            {
                textBoxCompRef.Text = "";
                radioButtonOther.Checked = false ;
            }
        }

        private void comboBoxOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOperator.BackColor == Color.Red & comboBoxOperator.Text!="")
            {
                comboBoxOperator.BackColor = Color.White;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            textBoxCompRef.Text += btn.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBoxCompRef.Text.Length>0)
            {
                textBoxCompRef.Text = textBoxCompRef.Text.Substring(0, textBoxCompRef.Text.Length - 1);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBoxCompRef.Text = "";
        }

        private void textBoxCompRef_Enter(object sender, EventArgs e)
        {
            Point locationOnForm = textBoxCompRef.FindForm().PointToClient(textBoxCompRef.Parent.PointToScreen(textBoxCompRef.Location));
            panelKeyboard.Visible = true;
            panelKeyboard.Location = new Point(locationOnForm.X, locationOnForm.Y + textBoxCompRef.Height);
            panelKeyboard.Parent = this;
            panelKeyboard.BringToFront();
            timerVirtualKeyboard.Enabled = true;
        }

        bool mouseBeenOnceOnKeyboard = false;
        private void timerVirtualKeyboard_Tick(object sender, EventArgs e)
        {
            var mousePoint = this.PointToClient(Cursor.Position);
            Point PanellocationOnForm = panelKeyboard.FindForm().PointToClient(panelKeyboard.Parent.PointToScreen(panelKeyboard.Location));
            Rectangle keyboardRectangle = new Rectangle(PanellocationOnForm, panelKeyboard.Size);
            if (!keyboardRectangle.Contains(mousePoint) & mouseBeenOnceOnKeyboard)
            {
                panelKeyboard.Visible = false;
                timerVirtualKeyboard.Enabled = false;
                mouseBeenOnceOnKeyboard = false;
            }
            if (keyboardRectangle.Contains(mousePoint))
            {
                mouseBeenOnceOnKeyboard = true;
            }
        }

        private void buttonFailureImages_Click(object sender, EventArgs e)
        {
            if (buttonFailureImages.Tag != null)
            {
                List<Image> imgList = (List<Image>)buttonFailureImages.Tag;
                if (imgList.Count>0)
                {
                    ShowFailureImages imgForm = new ShowFailureImages(imgList);
                    imgForm.ShowDialog();
                }
            }
        }
    }
}
