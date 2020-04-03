Create VIEW [dbo].InvoiceDataPremiumLocality
AS 

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