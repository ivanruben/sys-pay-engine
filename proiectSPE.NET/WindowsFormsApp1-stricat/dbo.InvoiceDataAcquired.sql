Create VIEW [dbo].InvoiceDataAcquired
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