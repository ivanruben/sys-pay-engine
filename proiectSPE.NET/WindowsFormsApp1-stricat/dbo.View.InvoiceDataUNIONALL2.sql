CREATE VIEW [dbo].InvoiceDataUNIONALL
AS 

SELECT  p.AcquiredCode as ChrgCode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.A_PPI as Chrg_Per_Item, 
		round(SUM(p.Amount),2) as TxnAmount, 
		p.A_PPC as Chrg_Percentage, 
		round(sum(p.A_PPCxFUNDplusPPI),2) as CHRGAmount,
		p.AcqTVA as TVA,
		co.Descriptions
FROM Pricings p
left outer join Contracts co on AcquiredCode= co.ChargeCodes and co.MerchanID =p.Merchant_Id
WHERE AcquiredCode is not null and AcquiredCode != '' 
GROUP BY AcquiredCode, A_PPC, A_PPI,AcqTVA,co.Descriptions

UNION ALL

select
	'Total Acquired' as NrOfTxn,
	sum(NrOfTxn) as TotalNrOfTxn, 
	null as Chrg_Per_Item,
	round(sum(TxnAmount),2) as TotalTxnAmount,
	null as Chrg_Percentage,
	round(sum(CHRGAmount),2) as TotalCharge,
	Tva,
	null as Descriptions
from InvoiceDataCardAcq

UNION ALL

SELECT  p.CardProcessed_CD as ChrgCode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.CP_PPI as Chrg_Per_Item, 
		round(sum(p.Amount),2) as TxnAmount, 
		p.CP_PPC as Chrg_Percentage, 
		round(sum(p.CP_PPCxFUNDplusPPI),2) as CHRGAmount,
		p.CardProcessTVA as TVA,
		co.Descriptions
FROM Pricings p
left outer join Contracts co on CardProcessed_CD= co.ChargeCodes and co.MerchanID =p.Merchant_Id
WHERE CardProcessed_CD is not null and CardProcessed_CD != '' 
GROUP BY CardProcessed_CD, CP_PPI, CP_PPC, CardProcessTVA, co.Descriptions

UNION ALL

select
	'Total CardProcessed' as NrOfTxn,
	sum(NrOfTxn) as TotalNrOfTxn, 
	null as Chrg_Per_Item,
	round(sum(TxnAmount),2) as TotalTxnAmount,
	null as Chrg_Percentage,
	round(sum(CHRGAmount),2) as TotalCharge,
	TVA,
	null as Descriptions
from InvoiceDataCardProcessed

UNION ALL

SELECT  p.PremiumCaptMeth_CD as ChrgCode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.P_CM_PPI as Chrg_Per_Item, 
		round(sum(p.Amount),2) as TxnAmount, 
		p.P_CM_PPC as Chrg_Percentage, 
		round(sum(p.P_CM_PPCxFUNDplusPPI),2) as CHRGAmount,
		p.PremTVA as TVA,
		co.Descriptions
FROM Pricings p
left outer join Contracts co on PremiumCaptMeth_CD= co.ChargeCodes and co.MerchanID =p.Merchant_Id
WHERE PremiumCaptMeth_CD is not null and PremiumCaptMeth_CD != '' 
GROUP BY PremiumCaptMeth_CD, P_CM_PPI, P_CM_PPC, PremTva, co.Descriptions

UNION ALL


SELECT  p.PremiumAuth_CD as ChrgCode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.P_A_PPI as Chrg_Per_Item, 
		round(sum(p.Amount),2) as TxnAmount, 
		p.P_A_PPC as Chrg_Percentage,
		round(sum(p.P_A_PPCxFUNDplusPPI),2) as CHRGAmount,
		p.PremTVA as TVA,
		co.Descriptions
FROM Pricings p
left outer join Contracts co on PremiumAuth_CD= co.ChargeCodes and co.MerchanID =p.Merchant_Id
WHERE PremiumAuth_CD is not null and PremiumAuth_CD != '' 
GROUP BY PremiumAuth_CD, P_A_PPI, P_A_PPC, p.PremTVA,co.Descriptions

UNION ALL

SELECT  p.PremiumLocality_CD as ChrgCode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.P_L_PPI as Chrg_Per_Item, 
		round(sum(p.Amount),2) as TxnAmount, 
		p.P_L_PPC as Chrg_Percentage, 
		round(sum(p.P_L_PPCxFUNDplusPPI),2) as CHRGAmount,
		p.PremTVA as TVA,
		co.Descriptions
FROM Pricings p
left outer join Contracts co on PremiumLocality_CD= co.ChargeCodes and co.MerchanID =p.Merchant_Id
WHERE PremiumLocality_CD is not null and PremiumLocality_CD != '' 
GROUP BY PremiumLocality_CD, P_L_PPI, P_L_PPC, p.PremTVA, co.Descriptions

UNION ALL

select
	'Total Premium' as NrOfTxn,
	null as TotalNrOfTxn, 
	null as Chrg_Per_Item,
	null as TotalTxnAmount,
	null as Chrg_Percentage,
	round(sum(TotalCharge),2) as TotalCharge,
	TVA,
	null as Descriptions
from INVPremiumUnionALL

UNION ALL


SELECT  p.Misscellaneous_CD as ChrgCode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.M_PPI as Chrg_Per_Item, 
		round(sum(p.M_PPC),2) as TxnAmount, 
		p.M_PPC as Chrg_Percentage, 
		round(sum(p.M_PPI),2) as CHRGAmount,
		p.MiscellTVA as TVA,
		co.Descriptions
FROM Pricings p
left outer join Contracts co on Misscellaneous_CD= co.ChargeCodes and co.MerchanID =p.Merchant_Id
WHERE Misscellaneous_CD is not null and Misscellaneous_CD != '' 
GROUP BY Misscellaneous_CD, M_PPI, M_PPC,MiscellTVA, co.Descriptions

UNION ALL

select
	'Total Miscellaneous' as NrOfTxn,
	null as TotalNrOfTxn, 
	null as Chrg_Per_Item,
	null as TotalTxnAmount,
	null as Chrg_Percentage,
	round(sum(TxnAmount),2) as TotalCharge,
	TVA,
	null as Descriptions
from InvoiceDataMiscellaneous
