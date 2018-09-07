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
            sourceTable.Rows.Add(DateTime.Now.ToString("dd-MM-yyyy HH:mm"), oper, model, serial);

            List<DataRow> rowsToRemove = new List<DataRow>();
            foreach (DataRow row in sourceTable.Rows)
            {
                DateTime date = DateTime.ParseExact(row["Data"].ToString(), "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                if (date < (DateTime.Now.AddDays(-1)))
                {
                    rowsToRemove.Add(row);
                }
            }

            foreach (DataRow row in rowsToRemove)
            {
                sourceTable.Rows.Remove(row);
            }

            SaveTableToTextFile(sourceTable, "History.txt");
        }

        private static void SaveTableToTextFile(DataTable table, string filePath)
        {
            List<string> fileLines = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                fileLines.Add(string.Join(";", row.ItemArray));
            }
            System.IO.File.WriteAllLines(filePath, fileLines.ToArray());
        }

        public static void LoadHistoryFromTextFile(ref DataTable sourceTable)
        {
            if (sourceTable.Columns.Count < 1)
            {
                sourceTable.Columns.Add("Data");
                sourceTable.Columns.Add("Operator");
                sourceTable.Columns.Add("Model");
                sourceTable.Columns.Add("serial");
            }

            if (System.IO.File.Exists("History.txt"))
            {
                string[] fileLines = System.IO.File.ReadAllLines("History.txt");
                foreach (var line in fileLines)
                {
                    string[] splittedLine = line.Split(';');
                    sourceTable.Rows.Add(splittedLine[0], splittedLine[1], splittedLine[2], splittedLine[3]);
                }
            }
        }
    }
}
