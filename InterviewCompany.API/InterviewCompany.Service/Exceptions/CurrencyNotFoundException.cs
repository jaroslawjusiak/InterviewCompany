using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCompany.Service.Exceptions
{
    public class CurrencyNotFoundException : Exception
    {
        private readonly string _message = "Currency with currency code {0} doesn't exists.";

        public CurrencyNotFoundException(string currencyCode)
        {
            CurrencyCode = currencyCode;
        }

        public override string Message => string.Format(_message, CurrencyCode);

        public string CurrencyCode { get; set; }
    }
}
