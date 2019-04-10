using InterviewCompany.Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCompany.Service.ResponseModel
{
    public class InvoiceInsertResponse
    {
        public InvoiceInsertResponse()
        {
            ValidationResult = new ValidationResult();
        }

        public int InvoiceNumber { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
