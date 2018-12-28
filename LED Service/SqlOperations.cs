using LED_Service.Data_Structures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED_Service
{
    class SqlOperations
    {

        public static void SaveRecordToDb(List<SaveRecord> saveData)
        {
            using (SqlConnection openCon = new SqlConnection(@"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;"))
            {
                string save = "INSERT into tb_NaprawaLED_Karta_Pracy (Data,Operator,Model,SerialNo,OpisNaprawy,NaprawianyKomponent,WynikNaprawy) VALUES (@Data,@Operator,@Model,@SerialNo,@OpisNaprawy,@NaprawianyKomponent,@WynikNaprawy)";
                using (SqlCommand querySave = new SqlCommand(save))
                {
                    querySave.Connection = openCon;
                    openCon.Open();
                    foreach (var item in saveData)
                    {
                        querySave.Parameters.Clear();
                        querySave.Parameters.Add("@Data", SqlDbType.SmallDateTime).Value = DateTime.Now;
                        querySave.Parameters.Add("@Operator", SqlDbType.NVarChar).Value = item.Oper;
                        querySave.Parameters.Add("@Model", SqlDbType.NVarChar).Value = item.Model; ;
                        querySave.Parameters.Add("@SerialNo", SqlDbType.NVarChar).Value = item.SerialNo; ;
                        querySave.Parameters.Add("@OpisNaprawy", SqlDbType.NVarChar).Value = item.JobDescription; ;
                        querySave.Parameters.Add("@NaprawianyKomponent", SqlDbType.NVarChar).Value = item.CompRef; ;
                        querySave.Parameters.Add("@WynikNaprawy", SqlDbType.NVarChar).Value = item.Result; ;
                        querySave.ExecuteNonQuery();
                    }
                }
            }
        }

        public static string[] GetListOfOperators()
        {
            HashSet<string> result = new HashSet<string>();

            DataTable sqlTable = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = String.Format(@"SELECT Operator FROM tb_NaprawaLED_Karta_Pracy;");

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(sqlTable);

            foreach (DataRow row in sqlTable.Rows)
            {
                result.Add(row["Operator"].ToString());
            }

            return result.ToArray();
        }

        public static DataTable GetVisualInspectionInfo(string lot)
        {
            DataTable sqlTableLot = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = String.Format(@"SELECT Data_czas,Operator,iloscDobrych,numerZlecenia,ngBrakLutowia,ngBrakDiodyLed,ngBrakResConn,ngPrzesuniecieLed,ngPrzesuniecieResConn,ngZabrudzenieLed,ngUszkodzenieMechaniczneLed,ngUszkodzenieConn,ngWadaFabrycznaDiody,ngUszkodzonePcb,ngWadaNaklejki,ngSpalonyConn,ngInne,scrapBrakLutowia,scrapBrakDiodyLed,scrapBrakResConn,scrapPrzesuniecieLed,scrapPrzesuniecieResConn,scrapZabrudzenieLed,scrapUszkodzenieMechaniczneLed,scrapUszkodzenieConn,scrapWadaFabrycznaDiody,scrapUszkodzonePcb,scrapWadaNaklejki,scrapSpalonyConn,scrapInne,ngTestElektryczny FROM MES.dbo.tb_Kontrola_Wizualna_Karta_Pracy WHERE numerZlecenia = @lot;");
            command.Parameters.AddWithValue("@lot", lot);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(sqlTableLot);

            return sqlTableLot;
        }

        public static DataTable GetMeasurementsForPcb(string pcbSerial)
        {
            DataTable sqlTableLot = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = String.Format(@"SELECT serial_no,inspection_time,tester_id,wip_entity_id,wip_entity_name,program_id,result,ng_type,lm,lm_w,sdcm,cri,cct,v,i,w,x,y,r9,bin,lx,retest,module_num,lm1_gain,x1_offset,y1_offset,vf1_offset,cri1_offset,cct1_offset,lm1_master,x1_master,y1_master,vf1_master,cri1_master,cct1_master,hi_pot,light_on,optical,result_int FROM tb_tester_measurements WHERE serial_no = @serial ORDER BY inspection_time DESC;");
            command.Parameters.AddWithValue("@serial", pcbSerial);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(sqlTableLot);

            return sqlTableLot;
        }

        public static string GetLedFamily(string lot)
        {
            DataTable sqlTableLot = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = String.Format(@"SELECT NrZlecenia,KoncowkiLED FROM tb_SMT_Karta_Pracy WHERE NrZlecenia = @lot;");
            command.Parameters.AddWithValue("@lot", lot);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(sqlTableLot);
            string result = "Brak danych";
            if (sqlTableLot.Rows.Count>0)
            {
                string[] splitString = sqlTableLot.Rows[0]["KoncowkiLED"].ToString().Split(':');
                result = splitString[1];
            }
            
            return result;
        }

        public static LotInfo GetLotInfo(string lot)
        {
            DataTable sqlTableLot = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = String.Format(@"SELECT Nr_Zlecenia_Produkcyjnego,NC12_wyrobu,Ilosc_wyrobu_zlecona,Data_Poczatku_Zlecenia,Data_Konca_Zlecenia,RankA,RankB,MRM FROM tb_Zlecenia_produkcyjne WHERE Nr_Zlecenia_Produkcyjnego=@lot;");
            command.Parameters.AddWithValue("@lot", lot);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(sqlTableLot);

            string lotNumber = "";
            string model = "";
            Int32 manufacturedQty = 0;
            string startDate = "";
            string endDate = "";
            string rankA = "";
            string rankB = "";
            string mrm = "";
            string ledFamily = "";



            if (sqlTableLot.Rows.Count > 0)
            {
                 //lotNumber = sqlTableLot.Rows[0]["Nr_Zlecenia_Produkcyjnego"].ToString();
                 model = sqlTableLot.Rows[0]["NC12_wyrobu"].ToString();
                 manufacturedQty = Int32.Parse(sqlTableLot.Rows[0]["Ilosc_wyrobu_zlecona"].ToString());
                 startDate = sqlTableLot.Rows[0]["Data_Poczatku_Zlecenia"].ToString();
                 endDate = sqlTableLot.Rows[0]["Data_Konca_Zlecenia"].ToString();
                 rankA = sqlTableLot.Rows[0]["RankA"].ToString();
                 rankB = sqlTableLot.Rows[0]["RankB"].ToString();
                 mrm = sqlTableLot.Rows[0]["MRM"].ToString();

                ledFamily = GetLedFamily(lot);
            }
            return new LotInfo(lot, model, manufacturedQty, startDate, endDate, rankA, rankB, mrm, ledFamily);
        }

        public static void RegisterNgPcbToMes(string serial, string ngType)
        {
            string[] splitted = serial.Split('_');
            string orderNo = "";
            if (splitted.Length > 1)
            {
                orderNo = splitted[splitted.Length - 2];
            }
            using (SqlConnection openCon = new SqlConnection(@"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;"))
            {
                string save = "INSERT into tb_tester_measurements (serial_no,inspection_time,tester_id,wip_entity_id,wip_entity_name,program_id,result,ng_type) VALUES (@serial_no,@inspection_time,@tester_id,@wip_entity_id,@wip_entity_name,@program_id,@result,@ng_type)";
                using (SqlCommand querySave = new SqlCommand(save))
                {
                    querySave.Connection = openCon;
                    querySave.Parameters.Add("@serial_no", SqlDbType.NVarChar).Value = serial;
                    querySave.Parameters.Add("@inspection_time", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    querySave.Parameters.Add("@tester_id", SqlDbType.TinyInt).Value = 0;
                    querySave.Parameters.Add("@wip_entity_id", SqlDbType.Int).Value = 0;
                    querySave.Parameters.Add("@wip_entity_name", SqlDbType.NVarChar).Value = orderNo;
                    querySave.Parameters.Add("@program_id", SqlDbType.Int).Value = 0;
                    querySave.Parameters.Add("@result", SqlDbType.NVarChar).Value = "NG";
                    querySave.Parameters.Add("@ng_type", SqlDbType.NVarChar).Value = ngType;
                    openCon.Open();
                    querySave.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetNgRowsFromMeasurementTable(string serial)
        {
            DataTable sqlTableLot = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = String.Format(@"SELECT serial_no,inspection_time,tester_id,rework_result FROM tb_tester_measurements WHERE serial_no = @serial ORDER BY inspection_time DESC;");
            command.Parameters.AddWithValue("@serial", serial);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(sqlTableLot);

            return sqlTableLot;
        }

        public static void UpdateReworkResultToNgTable(string serial, string result, DateTime reworkDate)
        {
            string connectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE MES.dbo.tb_NG_tracking SET rework_result=@result, rework_datetime=@date WHERE serial_no = @serial";

                command.Parameters.AddWithValue("@result", result);
                command.Parameters.AddWithValue("@date", reworkDate);
                command.Parameters.AddWithValue("@serial", serial);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static bool CheckNgTableForSerial(string serial)
        {
            DataTable sqlTableLot = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = String.Format(@"SELECT serial_no FROM tb_NG_tracking WHERE serial_no=@serial;");
            command.Parameters.AddWithValue("@serial", serial);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(sqlTableLot);

            return sqlTableLot.Rows.Count > 0;
        }

        public static void InsertPcbToNgTable(string pcbSerial, string result, string ngReason)
        {
            using (SqlConnection openCon = new SqlConnection(@"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;"))
            {
                openCon.Open();
                    string save = "INSERT into tb_NG_tracking (serial_no, result, ng_type, datetime) VALUES (@serial_no, @result, @ng_type, @datetime)";
                    using (SqlCommand querySave = new SqlCommand(save))
                    {
                        querySave.Connection = openCon;
                        querySave.Parameters.Add("@serial_no", SqlDbType.NVarChar).Value = pcbSerial;
                        querySave.Parameters.Add("@result", SqlDbType.NVarChar).Value = result;
                        querySave.Parameters.Add("@ng_type", SqlDbType.NVarChar).Value = ngReason;
                        querySave.Parameters.Add("@datetime", SqlDbType.SmallDateTime).Value = DateTime.Now;
                        querySave.ExecuteNonQuery();
                    }
            }
        }

        public static Dictionary<string, List<string>> GetNgScrapColumns()
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            result.Add("NG", new List<string>());
            result.Add("SCRAP", new List<string>());
            DataTable sqlTableLot = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = String.Format(@"SELECT * FROM MES.dbo.tb_Kontrola_Wizualna_Karta_Pracy WHERE 1=2");
            var columns = new List<string>();
            using (var dr = command.ExecuteReader())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    columns.Add(dr.GetName(i));
                }
            }

            

            foreach (var col in columns)
            {
                if (col.StartsWith("ng"))
                {
                    result["NG"].Add(col.Replace("ng", ""));
                }
                else
                {
                    result["SCRAP"].Add(col.Replace("scrap", ""));
                }
            }
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //adapter.Fill(sqlTableLot);

            return result;
        }
    }
}
