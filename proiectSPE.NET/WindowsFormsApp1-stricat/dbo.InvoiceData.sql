CREATE VIEW [dbo].InvoiceData
AS 

SELECT  p.AcquiredCode as ACode,
		COUNT(p.Event_Id) as NrOfTxn, 
		p.A_PPI as A_PPI, 
		SUM(p.Amount) as TxnAmount, 
		p.A_PPC as A_PPC, 
		sum(p.A_PPCxFUNDplusPPI) as CHRGAmount,
		'ruben' as MyName
FROM Pricings p
WHERE AcquiredCode is not null and AcquiredCode != '' 
GROUP BY AcquiredCode, A_PPC, A_PPI