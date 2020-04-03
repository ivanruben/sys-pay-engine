CREATE VIEW [dbo].[InvoiceDataTAX_ALL]
	AS 

select CHRGAmount,  (select distinct tva from InvoiceDataUNIONALL where ChrgCode like 'A%')TVA,

'Card Acquired Total TVA' as Detail
from InvoiceDataUNIONALL where ChrgCode  = 'Total Acquired'

union all

select CHRGAmount,  (select distinct tva from InvoiceDataUNIONALL where ChrgCode like 'C%')TVA,

'Card Processed Total TVA' as Detail
from InvoiceDataUNIONALL where ChrgCode = 'Total CardProcessed'

union all

select CHRGAmount,  (select distinct tva from InvoiceDataUNIONALL where ChrgCode like 'P%')TVA,

'Premium Total TVA' as Detail
from InvoiceDataUNIONALL where ChrgCode = 'Total Premium'

union all

select CHRGAmount,  (select distinct tva from InvoiceDataUNIONALL where ChrgCode like 'M%')TVA,

'Miscellaneous Total TVA' as Detail
from InvoiceDataUNIONALL where ChrgCode  = 'Total Miscellaneous'