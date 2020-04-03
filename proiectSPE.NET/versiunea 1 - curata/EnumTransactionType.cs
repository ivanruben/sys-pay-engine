using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruben1
{
    enum enumTransactionType
    {
        Purchase = 0,
        CashAdvance = 1,
        PWCB = 2,
        Refund = 10,
        OCT = 11,
        QuasiCash = 12
    }

    enum enumCaptureMethode
    {
        magneticStripe = 1,
        MOTOsecure = 2,
        MOTONonSecure = 3,
        eCommerce = 4,
        eCommerceNonSecure = 5,
        Paper = 6,
        PANKeyEntry = 7,
        Contactless = 8,
        OfflinePin = 9,
        FallbackToPaper = 10,
        InteractiveVoice = 11,
        OnlineChip = 12,
        OfflineChip = 13
    }

    enum enumLocality
    {
        Domestic = 4,
        Intra_regional = 3,
        Inter_regional = 1
    }

    enum enumSchema
    {
        [Description("MCC1")] MasterCardCrPer,
        [Description("MCC2")] MasterCardBusiness,
        [Description("MCC3")] MasterCardFleet,
        [Description("MCC4")] MasterCardCorporate,
        [Description("MCC5")] MasterCardPurchase,
        [Description("MCC6")] MasterCardSignia,
        [Description("MCC7")] MasterCardWorld,
        [Description("MCC8")] MasterCardComm,
        [Description("MCD1")] MasterCardDrComInt,
        [Description("MCD2")] MasterCardDrPerInt,
        [Description("MCD3")] DrMasterCardEEA,
        [Description("MCD4")] DebitMasterCardPerInt,
        [Description("MCD5")] DebitMasterCardComInt,
        [Description("MCD6")] MaestroUKCom,
        [Description("MCD7")] MaestroIntlCom,
        [Description("MCD8")] MaestroUKPer,
        [Description("MCD9")] MaestroIntlPer,
        [Description("VIC1")] VisaElecCreditPersonal,
        [Description("VIC2")] VisaCreditPersonal,
        [Description("VIC3")] VisaBusiness,
        [Description("VIC4")] VisaCommerce,
        [Description("VIC5")] VisaCorporate,
        [Description("VIC6")] VisaPurchasing,
        [Description("VIC7")] VisaElectronCredit,
        [Description("VID1")] VisaDebitPer,
        [Description("VID2")] VisaDrPerInt,
        [Description("VID3")] VisaDebitCom,
        [Description("VID4")] VisaDrComIntl,
        [Description("VID5")] VisaElectron,
        [Description("VID6")] VisaElecPerInt,
        [Description("ALLS")] AllStar,
        [Description("AMEX")] AmericanExpress,
        [Description("DCD")] DinersClubDiscover,
        [Description("DD")] DinersDiscover,
        [Description("DI")] DinersInternational,
        [Description("DUK")] DinersUK,
        [Description("LASER")] LaSer,
        [Description("JCB")] JCB,
        [Description("JCBUK")] JCBUK,
        [Description("JCBROI")] JCBROI,
        [Description("JCBI")] JCBInternational,
        [Description("KF")] Keyfuels,
        [Description("STARS")] Sears,
    }

    enum enumSchemaAbrev
        {
        [Description("MC")] MasterCardCrPer,
        [Description("MC")] MasterCardBusiness,
        [Description("MC")] MasterCardFleet,
        [Description("MC")] MasterCardCorporate,
        [Description("MC")] MasterCardPurchase,
        [Description("MC")] MasterCardSignia,
        [Description("MC")] MasterCardWorld,
        [Description("MC")] MasterCardComm,
        [Description("MC")] MasterCardDrComInt,
        [Description("MC")] MasterCardDrPerInt,
        [Description("MC")] DrMasterCardEEA,
        [Description("MC")] DebitMasterCardPerInt,
        [Description("MC")] DebitMasterCardComInt,
        [Description("MC")] MaestroUKCom,
        [Description("MC")] MaestroIntlCom,
        [Description("MC")] MaestroUKPer,
        [Description("MC")] MaestroIntlPer,
        [Description("VI")] VisaElecCreditPersonal,
        [Description("VI")] VisaCreditPersonal,
        [Description("VI")] VisaBusiness,
        [Description("VI")] VisaCommerce,
        [Description("VI")] VisaCorporate,
        [Description("VI")] VisaPurchasing,
        [Description("VI")] VisaElectronCredit,
        [Description("VI")] VisaDebitPer,
        [Description("VI")] VisaDrPerInt,
        [Description("VI")] VisaDebitCom,
        [Description("VI")] VisaDrComIntl,
        [Description("VI")] VisaElectron,
        [Description("VI")] VisaElecPerInt,
        [Description("AL")] AllStar,
        [Description("AM")] AmericanExpress,
        [Description("DC")] DinersClubDiscover,
        [Description("DD")] DinersDiscover,
        [Description("DI")] DinersInternational,
        [Description("DU")] DinersUK,
        [Description("JC")] JCB,
        [Description("JC")] JCBUK,
        [Description("JC")] JCBROI,
        [Description("JC")] JCBInternational,
        [Description("KF")] Keyfuels,
        [Description("ST")] Sears,
        }
}
