using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InterviewCompany.Domain.Documents
{
    public class Currency : IValidatableObject
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime ExchangeRateDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ExchangeRate < 0)
                yield return new ValidationResult("Exchange rate cannot be lower than zero!");
            if (ExchangeRateDate > DateTime.Now)
                yield return new ValidationResult("Exchange rate date must be past!");
            if (string.IsNullOrEmpty(Code))
                yield return new ValidationResult("Currency Code cannot be empty!");
            if (Code.Length != 3)
                yield return new ValidationResult("Currency Code cannot must contain exectly 3 characters!");
        }
    }
}
