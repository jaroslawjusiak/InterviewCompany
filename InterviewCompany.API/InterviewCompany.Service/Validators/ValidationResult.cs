using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewCompany.Service.Validators
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            ErrorMessages = new List<string>();
        }

        public List<string> ErrorMessages { get; set; }
        public ValidationStatus Status
        {
            get
            {
                return ErrorMessages.Any() ? ValidationStatus.Error : ValidationStatus.Success;
            }
        }
    }
}
