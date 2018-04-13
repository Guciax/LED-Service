using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED_Service.Data_Structures
{
    public class LotInfo
    {
        //Nr_Zlecenia_Produkcyjnego,NC12_wyrobu,Ilosc_wyrobu_zlecona,Data_Poczatku_Zlecenia,Data_Konca_Zlecenia,RankA,RankB,MRM
        public LotInfo(string lotNumber, string model, Int32 manufacturedQty, string startDate, string endDate, string RankA, string rankB, string MRM, string ledFamily)
        {
            LotNumber = lotNumber;
            Model = model;
            ManufacturedQty = manufacturedQty;
            StartDate = startDate;
            EndDate = endDate;
            this.RankA = RankA;
            RankB = rankB;
            this.MRM = MRM;
            LedFamily = ledFamily;
        }

        public string LotNumber { get; }
        public string Model { get; }
        public int ManufacturedQty { get; }
        public string StartDate { get; }
        public string EndDate { get; }
        public string RankA { get; }
        public string RankB { get; }
        public string MRM { get; }
        public string LedFamily { get; }
    }
}
