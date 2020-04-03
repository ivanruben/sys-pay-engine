using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruben1
{
    public class SchemaDescriptionAndCode
    {
        public string SchemaDescription { get; set; }
        public string SchemaCode { get; set; }
    }
    public class Schema
    {
        private List<SchemaDescriptionAndCode> listScheme;
        public Schema()
        {
            listScheme = new List<SchemaDescriptionAndCode>();
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "MasterCard Cr Per", SchemaCode = "MCC1" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "MasterCard Business", SchemaCode = "MCC2" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "MasterCard Fleet", SchemaCode = "MCC3" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "MasterCard Corporate", SchemaCode = "MCC4" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "MasterCard Purchase", SchemaCode = "MCC5" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "MasterCard Signia", SchemaCode = "MCC6" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "MasterCard World", SchemaCode = "MCC7" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "MasterCard Comm", SchemaCode = "MCC8" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "MasterCard Cr Per", SchemaCode = "MCC9" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "MasterCardDr Com Int", SchemaCode = "MCD1" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "MasterCardDr Per Int", SchemaCode = "MCD2" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Dr MasterCard EEA", SchemaCode = "MCD3" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Debit MasterCard Per Int", SchemaCode = "MCD4" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Debit MasterCard Com Int", SchemaCode = "MCD5" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Maestro UK (DOM) Com", SchemaCode = "MCD6" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Maestro Intl Com", SchemaCode = "MCD7" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Maestro UK (DOM) Per", SchemaCode = "MCD8" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Maestro Intl Per", SchemaCode = "MCD9" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Debit MasterCard Com Int", SchemaCode = "MCD10" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Visa Elec Credit Personal", SchemaCode = "VIC1" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Visa Credit Personal", SchemaCode = "VIC2" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Visa Business", SchemaCode = "VIC3" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Visa Commerce", SchemaCode = "VIC4" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Visa Corporate", SchemaCode = "VIC5" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Visa Purchasing", SchemaCode = "VIC6" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Visa Electron Credit", SchemaCode = "VIC7" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Visa Debit Per", SchemaCode = "VID1" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Visa Dr Per Int", SchemaCode = "VID2" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Visa Debit Com", SchemaCode = "VID3" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Visa Dr Com Intl", SchemaCode = "VID4" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Visa Electron", SchemaCode = "VID5" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Visa Elec Per Int", SchemaCode = "VID6" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "All Star", SchemaCode = "ALLS" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "American Express", SchemaCode = "AMEX" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Diners Club/Discover", SchemaCode = "DCD" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Diners Discover", SchemaCode = "DD" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Diners International", SchemaCode = "DI" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Diners UK (Elavon)", SchemaCode = "DUK" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "LaSer", SchemaCode = "LASER" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "JCB", SchemaCode = "JCB" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "JCB UK", SchemaCode = "JCBUK" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "JCB ROI", SchemaCode = "JCBROI" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "JCB International", SchemaCode = "JCBI" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Keyfuels", SchemaCode = "KF" });
            listScheme.Add(new SchemaDescriptionAndCode { SchemaDescription = "Sears", SchemaCode = "STARS" });

        }

        public string this[string schemaDescription]
        {
            get
            {
                return listScheme.FirstOrDefault(sche => sche.SchemaDescription == schemaDescription).SchemaCode;
            }
            set
            {
                listScheme.FirstOrDefault(sche => sche.SchemaDescription == schemaDescription).SchemaCode = value;
            }

        }
    }
}
