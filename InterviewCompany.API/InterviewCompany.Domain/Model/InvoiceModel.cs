using InterviewCompany.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCompany.Domain.Model
{
    public class AddInvoiceModel
    {
        public DateTime IssueDate { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public InvoiceItem[] Items { get; set; }
    }
}
