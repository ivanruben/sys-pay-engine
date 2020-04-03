CREATE VIEW [dbo].PricingEventUNIONALL
AS 
SELECT  p.Event_Id as Event_Id,
		p.AcquiredCode as ChrgCode,
		p.Amount as TxnAmount,
		p.A_PPC as Chrg_Percentage, 
		p.A_PPI as Chrg_Per_Item,
		p.A_PPCxFUNDplusPPI as CHRGAmount
FROM Pricings p
WHERE AcquiredCode is not null and AcquiredCode != '' 
--GROUP BY AcquiredCode, A_PPC, A_PPI

UNION ALL

SELECT  p.Event_Id as Event_Id,
		p.PremiumCaptMeth_CD as ChrgCode,
		p.Amount as TxnAmount,
		p.P_CM_PPC as Chrg_Percentage, 
		p.P_CM_PPI as Chrg_Per_Item,
		p.P_CM_PPCxFUNDplusPPI as CHRGAmount
FROM Pricings p
WHERE PremiumCaptMeth_CD is not null and PremiumCaptMeth_CD != '' 
--GROUP BY CardProcessed_CD, P_CM_PPC, P_CM_PPI

UNION ALL

SELECT  p.Event_Id as Event_Id,
		p.PremiumAuth_CD as ChrgCode,
		p.Amount as TxnAmount,
		p.P_A_PPC as Chrg_Percentage, 
		p.P_A_PPI as Chrg_Per_Item,
		p.P_A_PPCxFUNDplusPPI as CHRGAmount
FROM Pricings p
WHERE PremiumAuth_CD is not null and PremiumAuth_CD != '' 
--GROUP BY PremiumAuth_CD, P_A_PPC, P_A_PPI

UNION ALL

SELECT  p.Event_Id as Event_Id,
		p.PremiumLocality_CD as ChrgCode,
		p.Amount as TxnAmount,
		p.P_L_PPC as Chrg_Percentage, 
		p.P_L_PPI as Chrg_Per_Item,
		p.P_L_PPCxFUNDplusPPI as CHRGAmount
FROM Pricings p
WHERE PremiumLocality_CD is not null and PremiumLocality_CD != '' 
--GROUP BY PremiumLocality_CD, P_L_PPC, P_L_PPI

UNION ALL

SELECT  p.Event_Id as Event_Id,
		p.CardProcessed_CD as ChrgCode,
		p.Amount as TxnAmount,
		p.CP_PPC as Chrg_Percentage, 
		p.CP_PPI as Chrg_Per_Item,
		p.CP_PPCxFUNDplusPPI as CHRGAmount
FROM Pricings p
WHERE CardProcessed_CD is not null and CardProcessed_CD != '' 
--GROUP BY CardProcessed_CD, CP_PPC, CP_PPI

UNION ALL

SELECT  p.Event_Id as Event_Id,
		p.Misscellaneous_CD as ChrgCode,
		p.Amount as TxnAmount,
		p.M_PPI as Chrg_Percentage, 
		p.M_PPI as Chrg_Per_Item,
		p.M_PPI as CHRGAmount
FROM Pricings p
WHERE Misscellaneous_CD is not null and Misscellaneous_CD != '' 
--GROUP BY Misscellaneous_CD, M_PPI