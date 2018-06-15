using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED_Service
{
    class SaveRecord
    {
        //Data,Operator,Model,SerialNo,OpisNaprawy,NaprawianyKomponent,WynikNaprawy
        public SaveRecord(string oper, string model, string serialNo, string jobDescription, string compRef, string result)
        {
            Oper = oper;
            Model = model;
            SerialNo = serialNo;
            JobDescription = jobDescription;
            CompRef = compRef;
            Result = result;
        }

        public string Oper { get; }
        public string Model { get; }
        public string SerialNo { get; }
        public string JobDescription { get; }
        public string CompRef { get; }
        public string Result { get; }
    }
}
