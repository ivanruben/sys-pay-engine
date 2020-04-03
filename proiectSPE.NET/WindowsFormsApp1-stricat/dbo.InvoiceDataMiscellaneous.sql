Create VIEW [dbo].InvoiceDataMiscellaneous
AS 

SELECT  p.Misscellaneous_CD as ChrgCode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.M_PPI as Chrg_Per_Item, 
		--SUM(p.Amount) as TxnAmount, 
		--p.M_PPC as Chrg_Percentage, 
		--sum(p.P_L_PPCxFUNDplusPPI) as CHRGAmount,
		co.Descriptions
FROM Pricings p
left outer join Contracts co on Misscellaneous_CD= co.ChargeCodes and co.MerchanID ='MERCH00001'
WHERE Misscellaneous_CD is not null and Misscellaneous_CD != '' 
GROUP BY Misscellaneous_CD, M_PPI, co.Descriptions