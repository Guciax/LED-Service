using LED_Service.Data_Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LED_Service
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LviAdded(ListViewItem itm)
        {
            //do something with the added item 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewHistory.DataSource = historyTable;
            comboBoxOperator.Items.Clear();
            comboBoxOperator.Items.AddRange(SqlOperations.GetListOfOperators());
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

        private void ReadPcbQr()
        {
            testData = SqlOperations.GetMeasurementsForPcb(textBoxPcbQr.Text);
            if (testData.Rows.Count > 0 & textBoxPcbQr.Text.Trim()!="")
            {
                string lot = testData.Rows[0]["wip_entity_name"].ToString();
                currentLotInfo = SqlOperations.GetLotInfo(lot);
                visInspInfo = SqlOperations.GetVisualInspectionInfo(lot);

                labelLotInfo.Text =
                    "Dane zlecenia:" + Environment.NewLine
                    + "Nr zlecenia:" + lot + Environment.NewLine
                    + "Model:" + currentLotInfo.Model + Environment.NewLine
                    + "Kitting data: " + currentLotInfo.StartDate + Environment.NewLine
                    + "Koniec zl: " + currentLotInfo.EndDate + Environment.NewLine
                    + "Ilość wykonana: " + currentLotInfo.ManufacturedQty;

                labelLedInfo.Text =
                    "Dane LED: " + Environment.NewLine
                    + "LED: " + currentLotInfo.LedFamily + Environment.NewLine
                    + "RankA: " + currentLotInfo.RankA + Environment.NewLine
                    + "RankB: " + currentLotInfo.RankB;

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

                labelTestInfo.Text =
                    "Dane testu: " + Environment.NewLine
                    + "Wynik testu: " + testResult + Environment.NewLine
                    + ngType;

                labelViInfo.Text =
                    "Dane kontroli wzrokowej: " + Environment.NewLine
                    + "Wynik: " + viResult;
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
            if (compName != "" & operationName != "" & refId!="" & !ListViewLocked())
            {
                ListViewItem newItem = new ListViewItem(refId);
                newItem.SubItems.Add(compName);
                newItem.SubItems.Add(operationName);

                listViewOperations.Items.Add(newItem);

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
        }

        private void butAddScrap_Click(object sender, EventArgs e)
        {
            ListViewItem newItem = new ListViewItem("");
            newItem.SubItems.Add("");
            newItem.SubItems.Add("SCRAP - nie kwalifikuje się do naprawy.");
            listViewOperations.Items.Add(newItem);
            LockListView(true);
        }

        private void butAddDamaged_Click(object sender, EventArgs e)
        {
            ListViewItem newItem = new ListViewItem("");
            newItem.SubItems.Add("");
            newItem.SubItems.Add("SCRAP - uszkodzenie podczas naprawy.");
            listViewOperations.Items.Add(newItem);
            LockListView(true);
        }

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            if (listViewOperations.SelectedItems.Count > 0) 
                listViewOperations.Items.RemoveAt(listViewOperations.Items.IndexOf(listViewOperations.SelectedItems[0]));
        }

        private void buttonSaveToDb_Click(object sender, EventArgs e)
        {
            if (AllDataCorrect())
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

                SqlOperations.SaveRecordToDb(listToSave);
                comboBoxOperator.Items.Clear();
                comboBoxOperator.Items.AddRange(SqlOperations.GetListOfOperators());
                CleanUpForm();
                textBoxPcbQr.Focus();
            }
        }

        private void CleanUpForm()
        {
            textBoxPcbQr.Text = "";
            comboBoxOperator.Text = "";
            listViewOperations.Items.Clear();
            textBoxCompRef.Text = "";
            checkBoxLabelReapplied.Checked = false;
            labelLotInfo.Text = "";
            labelLedInfo.Text = "";

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
            if (currentLotInfo == null) result = false;
            if (comboBoxOperator.Text == "") result = false;
            if (listViewOperations.Items.Count == 0) result = false;

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
    }
}
