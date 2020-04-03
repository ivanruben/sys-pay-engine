using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Models
{
    public class TransactionProcessing
    {
        public int Id { get; set; }
        public string Merchant_Id { get; set; }
        public string Event_Id { get; set; }
        public string Amount { get; set; }
        public string Transaction_Type { get; set; }
        public string Acquired { get; set; }
        public string Schema { get; set; }
        public string Authorised { get; set; }
        public string CaptureMethod { get; set; }
        public string Locality { get; set; }
        public string SchemaAbrev { get; set; }
        public string Electronic { get; set; }
        public string Txn_Currency { get; set; }
        public double FX_In { get; set; }
        public double FX_Out { get; set; }
        public string SettlementCurrency { get; set; }
        public DateTime? Creation_Data { get; set; }
        
       




    }
}
