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
    }
}
