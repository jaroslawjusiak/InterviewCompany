using InterviewCompany.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Linq;


namespace InterviewCompany.Service.Validators
{
    public class CurrencyValidator
    {
        private ValidationResult _result = new ValidationResult();

        public ValidationResult Validate(List<Currency> avaiableCurrencies, CurrencyDbAction action, Currency currency)
        {
            switch (action)
            {
                case CurrencyDbAction.Insert:
                    {
                        if (avaiableCurrencies.Any(c => c.Code.Equals(currency.Code)))
                            _result.ErrorMessages.Add($"Currency with currency code {currency.Code} already exists.");
                        return _result;
                    }

                case CurrencyDbAction.Update:
                    {
                        var dbCurrency = avaiableCurrencies.FirstOrDefault(c => c.Code.Equals(currency.Code));

                        if (dbCurrency == null)
                            _result.ErrorMessages.Add($"Currency with currency code {currency.Code} doesn't exists.");

                        if (currency.ExchangeRateDate <= dbCurrency.ExchangeRateDate || currency.ExchangeRateDate > DateTime.Now)
                            _result.ErrorMessages.Add($"Currency exchange rate date {currency.ExchangeRateDate} is invalid.");

                        return _result;
                    }
                default:
                    return _result;
            }


            throw new NotImplementedException();
        }

    }

    

}
