using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED_Service.Data_Structures
{
    public class ImageTag
    {
        public ImageTag(string result, string serial, string reason)
        {
            Result = result;
            Serial = serial;
            Reason = reason;
        }

        public string Result { get; }
        public string Serial { get; }
        public string Reason { get; }
    }
}
