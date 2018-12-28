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
    public partial class testDetails : Form
    {
        private readonly DataTable testSourceTable;

        public testDetails(DataTable testSourdeTable)
        {
            InitializeComponent();
            this.testSourceTable = testSourdeTable;
        }

        private void testDetails_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = testSourceTable;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}
