using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCompany.Service.Exceptions
{
    public class InvalidCurrencyExchangeRateDateException : Exception
    {
        private readonly string _message = "Currency exchange rate date {0} is invalid.";

        public InvalidCurrencyExchangeRateDateException(DateTime exchangedDate)
        {
            ExchangeDate = exchangedDate;
        }

        public override string Message => string.Format(_message, ExchangeDate);

        public DateTime ExchangeDate { get; set; }
    }
}
