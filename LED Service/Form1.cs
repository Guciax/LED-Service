using LED_Service.Data_Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        DataTable testData = new DataTable();
        DataTable visInspInfo = new DataTable();
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                testData = SqlOperations.GetMeasurementsForPcb(textBox1.Text);
                if (testData.Rows.Count>0)
                {
                    string lot = testData.Rows[0]["wip_entity_name"].ToString();
                    LotInfo lotInfo = SqlOperations.GetLotInfo(lot);
                    visInspInfo = SqlOperations.GetVisualInspectionInfo(lot);

                    labelLotInfo.Text = 
                        "Dane zlecenia:" + Environment.NewLine
                        + "Model :" + lotInfo.Model + Environment.NewLine
                        + "Początek zl.: " + lotInfo.StartDate + Environment.NewLine
                        + "Koniec zl.: " + lotInfo.EndDate + Environment.NewLine
                        + "Ilość: " + lotInfo.ManufacturedQty;

                    labelLedInfo.Text =
                        "Dane LED: " + Environment.NewLine
                        + "LED: " + lotInfo.LedFamily + Environment.NewLine
                        + "RankA: " + lotInfo.RankA + Environment.NewLine
                        + "RankB: " + lotInfo.RankB;

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

                    if (testResult=="NG")
                    {
                        foreach (DataRow row in testData.Rows)
                        {
                            ngType += row["ng_type"].ToString()+", ";
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
    }
}
