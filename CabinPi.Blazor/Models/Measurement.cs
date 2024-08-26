using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace CabinPi.Blazor.Models
{
    public class Measurement
    {
        public DateTime Date { get; set; }
        public int? AbsorbTime { get; set; }
        public int? AmpHours { get; set; }
        public int? EqualizeTime { get; set; }
        public int? FloatTime { get; set; }
        public float? HighestVinputLog { get; set; }
        public float? IbattDisplay { get; set; }
        public int? NiteMinutesNoPwr { get; set; }
        public float? PvInputCurrent { get; set; }
        public float? VocLastMeasured { get; set; }
        public int? BatteryState { get; set; }
        public int? ChargeState { get; set; }
        public int? ClassicState { get; set; }
        public float? DispavgVbatt { get; set; }
        public float? DispavgVpv { get; set; }
        public float? kWHours { get; set; }
        public int? Watts { get; set; }
        public float? Case_C { get; set; }
        public float? Case_F { get; set; }
        public float? Ext_C { get; set; }
        public float? Ext_F { get; set; }
        public float? hPa { get; set; }
        public float? Humidity { get; set; }
        public float? inHg { get; set; }
        public float? Int_C { get; set; }
        public float? Int_F { get; set; }
        public bool? InverterOn { get; set; }
        public int? InverterMode { get; set; }
        public int? InverterFault { get; set; }
        public float? InverterVACOut { get; set; }
        public float? InverterAACOut { get; set; }

        public string BatteryStateDescription
        {
            get
            {
                switch (BatteryState)
                {
                    case 0: return "Resting";
                    case 3: return "Absorb";
                    case 4: return "Bulk MPPT";
                    case 5: return "Float";
                    case 6: return "Float MPPT";
                    case 7: return "Equalize";
                    case 10: return "Hyper VOC";
                    case 18: return "Equalize MPPT";
                    default: return "Unknown";
                }
            }

        }
    }
}
