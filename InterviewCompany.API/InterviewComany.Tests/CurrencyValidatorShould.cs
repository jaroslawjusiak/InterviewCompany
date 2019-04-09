using InterviewCompany.Domain.Documents;
using InterviewCompany.Service.Validators;
using InterviewCompany.Tests.Data;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace InterviewCompany.Tests
{
    public class CurrencyValidatorShould
    {
        private readonly ITestOutputHelper _output;
        private readonly CurrencyValidator _validator;
        private List<Currency> _availableCurrencies;

        public CurrencyValidatorShould(ITestOutputHelper output)
        {
            _output = output;
            _validator = new CurrencyValidator();
            Initialize();
        }

        [Theory]
        [MemberData(nameof(CurrencyValidatorData.Currencies), MemberType = typeof(CurrencyValidatorData))]
        public void NotAllowAddExistingCurrency(string code, string name, decimal exchangeRate, DateTime exchangeRateDate)
        {
            var currency = new Currency { Code = code, Name = name, ExchangeRate = exchangeRate, ExchangeRateDate = exchangeRateDate };
            var validationStatus = _validator.Validate(_availableCurrencies, CurrencyDbAction.Insert, currency).Status;

            Assert.True(validationStatus == ValidationStatus.Error);
        }


        private void Initialize()
        {
            _availableCurrencies = 
                new List<Currency>
                {
                    new Currency{Code = "EUR", Name = "Euro", ExchangeRate = 0.886552m, ExchangeRateDate = new DateTime(2019,4,9,12,45,0) },
                    new Currency{Code = "GBP", Name = "British Pound", ExchangeRate = 0.765535m, ExchangeRateDate = new DateTime(2019,4,9,12,45,0) },
                    new Currency{Code = "CHF", Name = "Swiss Franc", ExchangeRate = 0.998312m, ExchangeRateDate = new DateTime(2019,4,9,12,45,0) },
                    new Currency{Code = "RUB", Name = "Russian Ruble", ExchangeRate = 64.767361m, ExchangeRateDate = new DateTime(2019,4,9,13,40,0) }
                };
        }
    }
}
