using InterviewCompany.Domain.Documents;
using InterviewCompany.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace InterviewCompany.Domain.ValidationAttributes
{
    public class InvoiceItemValidation : ValidationAttribute {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var items = (InvoiceItem[])value;

            foreach(var item in items)
            {
                var itemValidationResults = Validate(item);

                if (itemValidationResults.Any())
                    return new ValidationResult(itemValidationResults.First().ErrorMessage);
            }

            return ValidationResult.Success;
        }

        private List<ValidationResult> Validate(InvoiceItem item)
        {
            var validationResults = new List<ValidationResult>();

            if (item.UnitCost < 0)
                validationResults.Add(new ValidationResult("Unit cost cannot be lower than zero!"));
            if (item.Quantity < 0)
                validationResults.Add(new ValidationResult("Quantity cannot be lower than zero!"));
            if (string.IsNullOrEmpty(item.CurrencyCode))
                validationResults.Add(new ValidationResult("Currency code cannot be empty!"));
            if (item.CurrencyCode.Length != 3)
                validationResults.Add(new ValidationResult("Currency code cannot must contain exectly 3 characters!"));

            return validationResults;
        }
    }
}
