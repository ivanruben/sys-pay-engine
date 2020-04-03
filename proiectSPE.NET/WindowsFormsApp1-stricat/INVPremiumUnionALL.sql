CREATE VIEW [dbo].[INVPremiumUnionALL]
	AS select
	'Total Premium' as NrOfTxn,
	sum(NrOfTxn) as TotalNrOfTxn, 
	null as Chrg_Per_Item,
	sum(TxnAmount) as TotalTxnAmount,
	null as Chrg_Percentage,
	sum(CHRGAmount) as TotalCharge,
	TVA,
	null as Descriptions
from InvoiceDataPremiumCM

union all

select
	'Total Premium' as NrOfTxn,
	sum(NrOfTxn) as TotalNrOfTxn, 
	null as Chrg_Per_Item,
	sum(TxnAmount) as TotalTxnAmount,
	null as Chrg_Percentage,
	sum(CHRGAmount) as TotalCharge,
	TVA,
	null as Descriptions
from InvoiceDataPremiumAUTH

union all

select
	'Total Premium' as NrOfTxn,
	sum(NrOfTxn) as TotalNrOfTxn, 
	null as Chrg_Per_Item,
	sum(TxnAmount) as TotalTxnAmount,
	null as Chrg_Percentage,
	sum(CHRGAmount) as TotalCharge,
	TVA,
	null as Descriptions
from InvoiceDataPremiumLocality