using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Models
{
    public class Pricing
    {
        public int Id { get; set; }
        public string Merchant_Id { get; set; }
        public string Event_Id { get; set; }
        public string Schema { get; set; }
        public string Acquired { get; set; }
        public string Authorised { get; set; }
        public string CaptureMethod { get; set; }
        public string Locality { get; set; }
        public string Transaction_Type { get; set; }
        public string Amount { get; set; }
        public string FXCharge { get; set; }
        public string AcquiredCode { get; set; }
        public string A_PPI { get; set; }
        public string A_PPC { get; set; }
        public string A_PPCxFUND { get; set; }
        public string A_PPCxFUNDplusPPI { get; set; }
        public double AcqTVA { get; set; }
        public string PremiumCaptMeth_CD { get; set; }
        public string P_CM_PPI { get; set; }
        public string P_CM_PPC { get; set; }
        public string P_CM_PPCxFUND { get; set; }
        public string P_CM_PPCxFUNDplusPPI { get; set; }
        public string PremiumAuth_CD { get; set; }
        public string P_A_PPI { get; set; }
        public string P_A_PPC { get; set; }
        public string P_A_PPCxFUND { get; set; }
        public string P_A_PPCxFUNDplusPPI { get; set; }
        public string PremiumLocality_CD { get; set; }
        public string P_L_PPI { get; set; }
        public string P_L_PPC { get; set; }
        public string P_L_PPCxFUND { get; set; }
        public string P_L_PPCxFUNDplusPPI { get; set; }
        public double PremTVA { get; set; }
        public string CardProcessed_CD { get; set; }
        public string CP_PPI { get; set; }
        public string CP_PPC { get; set; }
        public string CP_PPCxFUND { get; set; }
        public string CP_PPCxFUNDplusPPI { get; set; }
        public double CardProcessTVA { get; set; }
        public string Misscellaneous_CD { get; set; }
        public string M_PPI { get; set; }
        public string M_PPC { get; set; }
        public double MiscellTVA { get; set; }
    }
}
