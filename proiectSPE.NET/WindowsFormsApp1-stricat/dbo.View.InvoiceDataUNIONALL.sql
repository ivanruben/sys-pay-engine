CREATE VIEW [dbo].InvoiceDataUNIONALL
AS 

SELECT  p.AcquiredCode as ChrgCode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.A_PPI as Chrg_Per_Item, 
		SUM(p.Amount) as TxnAmount, 
		p.A_PPC as Chrg_Percentage, 
		sum(p.A_PPCxFUNDplusPPI) as CHRGAmount,
		co.Descriptions
FROM Pricings p
left outer join Contracts co on AcquiredCode= co.ChargeCodes and co.MerchanID ='MERCH00001'
WHERE AcquiredCode is not null and AcquiredCode != '' 
GROUP BY AcquiredCode, A_PPC, A_PPI,co.Descriptions

UNION ALL

SELECT  p.CardProcessed_CD as ChrgCode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.CP_PPI as Chrg_Per_Item, 
		SUM(p.Amount) as TxnAmount, 
		p.CP_PPC as Chrg_Percentage, 
		sum(p.CP_PPCxFUNDplusPPI) as CHRGAmount,
		co.Descriptions
FROM Pricings p
left outer join Contracts co on CardProcessed_CD= co.ChargeCodes and co.MerchanID ='MERCH00001'
WHERE CardProcessed_CD is not null and CardProcessed_CD != '' 
GROUP BY CardProcessed_CD, CP_PPI, CP_PPC,co.Descriptions

UNION ALL

SELECT  p.PremiumCaptMeth_CD as ChrgCode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.P_CM_PPI as Chrg_Per_Item, 
		SUM(p.Amount) as TxnAmount, 
		p.P_CM_PPC as Chrg_Percentage, 
		sum(p.P_CM_PPCxFUNDplusPPI) as CHRGAmount,
		co.Descriptions
FROM Pricings p
left outer join Contracts co on PremiumCaptMeth_CD= co.ChargeCodes and co.MerchanID ='MERCH00001'
WHERE PremiumCaptMeth_CD is not null and PremiumCaptMeth_CD != '' 
GROUP BY PremiumCaptMeth_CD, P_CM_PPI, P_CM_PPC,co.Descriptions

UNION ALL

SELECT  p.PremiumAuth_CD as ChrgCode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.P_A_PPI as Chrg_Per_Item, 
		SUM(p.Amount) as TxnAmount, 
		p.P_A_PPC as Chrg_Percentage, 
		sum(p.P_A_PPCxFUNDplusPPI) as CHRGAmount,
		co.Descriptions
FROM Pricings p
left outer join Contracts co on PremiumAuth_CD= co.ChargeCodes and co.MerchanID ='MERCH00001'
WHERE PremiumAuth_CD is not null and PremiumAuth_CD != '' 
GROUP BY PremiumAuth_CD, P_A_PPI, P_A_PPC,co.Descriptions

UNION ALL

SELECT  p.PremiumLocality_CD as ChrgCode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.P_L_PPI as Chrg_Per_Item, 
		SUM(p.Amount) as TxnAmount, 
		p.P_L_PPC as Chrg_Percentage, 
		sum(p.P_L_PPCxFUNDplusPPI) as CHRGAmount,
		co.Descriptions
FROM Pricings p
left outer join Contracts co on PremiumLocality_CD= co.ChargeCodes and co.MerchanID ='MERCH00001'
WHERE PremiumLocality_CD is not null and PremiumLocality_CD != '' 
GROUP BY PremiumLocality_CD, P_L_PPI, P_L_PPC,co.Descriptions

UNION ALL


SELECT  p.Misscellaneous_CD as ChrgCode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.M_PPI as Chrg_Per_Item, 
		SUM(p.Amount) as TxnAmount, 
		p.M_PPI as Chrg_Percentage, 
		sum(p.M_PPI) as CHRGAmount,
		co.Descriptions
FROM Pricings p
left outer join Contracts co on Misscellaneous_CD= co.ChargeCodes and co.MerchanID ='MERCH00001'
WHERE Misscellaneous_CD is not null and Misscellaneous_CD != '' 
GROUP BY Misscellaneous_CD, M_PPI, co.Descriptions