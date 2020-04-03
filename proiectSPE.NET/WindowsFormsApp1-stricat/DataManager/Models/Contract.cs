using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string ChargeCodes { get; set; }
        public string PPI { get; set; }
        public string PPC { get; set; }
        public string MerchanID { get; set; }
        public string Descriptions { get; set; }
        /*  public string M2ChargeCodes { get; set; }
          public string M2PPI { get; set; }
          public string M2PPC { get; set; }
          public string M2MerchanID { get; set; }*/
    }
}
