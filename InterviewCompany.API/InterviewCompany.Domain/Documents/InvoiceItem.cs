using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCompany.Domain.Documents
{
    public class InvoiceItem
    {
        public string Description { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}
