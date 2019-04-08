using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCompany.Service.Exceptions
{
    public class CurrencyAlreadyExistsException : Exception
    {
        private readonly string _message = "Currency with currency code {0} already exists.";

        public CurrencyAlreadyExistsException(string currencyCode)
        {
            CurrencyCode = currencyCode;
        }

        public override string Message => string.Format(_message, CurrencyCode);

        public string CurrencyCode { get; set; }
    }
}
