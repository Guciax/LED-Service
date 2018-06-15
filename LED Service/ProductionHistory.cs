using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LED_Service
{
    class ProductionHistory
    {
        public static void AddModuleToHostory(string model, string serial, string oper, ref DataTable sourceTable)
        {
            if (sourceTable.Columns.Count < 1)
            {
                sourceTable.Columns.Add("Data");
                sourceTable.Columns.Add("Operator");
                sourceTable.Columns.Add("Model");
                sourceTable.Columns.Add("serial");
            }
            sourceTable.Rows.Add(DateTime.Now.ToString("dd-MM-yyyy HH:mm"), oper, model, serial);

            List<DataRow> rowsToRemove = new List<DataRow>();
            foreach (DataRow row in sourceTable.Rows)
            {
                DateTime date = DateTime.ParseExact(row["Data"].ToString(), "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                if (date<(DateTime.Now.AddDays(-1)))
                {
                    rowsToRemove.Add(row);
                }
            }

            foreach (DataRow row in rowsToRemove)
            {
                sourceTable.Rows.Remove(row);
            }
        }
    }
}
