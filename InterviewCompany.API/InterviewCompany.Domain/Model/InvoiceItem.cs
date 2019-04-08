using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InterviewCompany.Domain.Model
{
    public class InvoiceItem : IValidatableObject
    {
        public string Description { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UnitCost < 0)
                yield return new ValidationResult("Unit cost cannot be lower than zero!");
            if (Quantity < 0)
                yield return new ValidationResult("Quantity cannot be lower than zero!");
            if(string.IsNullOrEmpty(CurrencyCode))
                yield return new ValidationResult("CurrencyCode cannot be empty!");
            if (CurrencyCode.Length != 3)
                yield return new ValidationResult("CurrencyCode cannot must contain exectly 3 characters!");
        }

    }
}
