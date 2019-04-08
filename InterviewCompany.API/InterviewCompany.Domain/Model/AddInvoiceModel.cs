using InterviewCompany.Domain.Documents;
using InterviewCompany.Domain.Model;
using InterviewCompany.Domain.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InterviewCompany.Domain.Model
{
    public class AddInvoiceModel
    {
        [Required()]
        public Customer BillTo { get; set; }
        [Required()]
        public Customer Issuer { get; set; }
        [InvoiceItemValidation]
        [Required()]
        public InvoiceItem[] Items { get; set; }
    }
}
