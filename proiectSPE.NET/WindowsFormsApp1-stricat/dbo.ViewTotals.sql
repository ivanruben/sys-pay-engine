CREATE VIEW [dbo].[Totals]
	AS 
select 
	'1' AS ID,
	round(sum(VAT_TAX_Applyed),2) as Totals,
	'Total VAT Amount' as Detail
from InvoiceDataTAX_ALL

Union all

select 
	'2' as ID,
	round(sum(TxnAmount),2) as Totals,
	'FUND BILL Amount' as Detail
from InvoiceDataTAX_ALL where Section = 'Total Acquired'

Union all

select 
	'1' as ID,
	round(sum(CHRGAmount),2) as Totals,
	'CHRG BILL Amount' as Detail
from InvoiceDataTAX_ALL



