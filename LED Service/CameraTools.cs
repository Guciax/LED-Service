using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LED_Service
{
    class CameraTools
    {
        public FilterInfoCollection CaptureDevice { get; private set; }

        public static string CheckDeviceMonikerString(FilterInfoCollection CaptureDevice)
        {
            string result = "";
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            List<string> devices = new List<string>();
            foreach (FilterInfo dev in CaptureDevice)
            {
                devices.Add(dev.MonikerString);
            }
            string deviceFromSettings = AppSettings.GetSettings("deviceMonikerString");

            if (devices.Contains(deviceFromSettings))
            {
                return deviceFromSettings;
            }

            else
            {
                using (SettingsForm setF = new SettingsForm(CaptureDevice))
                {
                    if (setF.ShowDialog() == DialogResult.OK)
                    {
                        return setF.deviceMonikerString;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }
    }
}
