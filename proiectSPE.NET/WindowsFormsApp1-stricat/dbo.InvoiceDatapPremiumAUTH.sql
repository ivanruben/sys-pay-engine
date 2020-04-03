Create VIEW [dbo].InvoiceDataPremiumCM
AS 

SELECT  p.PremiumCaptMeth_CD as ChrgCode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.P_CM_PPI as Chrg_Per_Item, 
		SUM(p.Amount) as TxnAmount, 
		p.P_CM_PPC as Chrg_Percentage, 
		sum(p.CP_PPCxFUNDplusPPI) as CHRGAmount,
		co.Descriptions
FROM Pricings p
left outer join Contracts co on PremiumCaptMeth_CD= co.ChargeCodes and co.MerchanID ='MERCH00001'
WHERE PremiumCaptMeth_CD is not null and PremiumCaptMeth_CD != '' 
GROUP BY PremiumCaptMeth_CD, P_CM_PPI, P_CM_PPC,co.Descriptions