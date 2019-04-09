using InterviewCompany.Domain.Documents;
using InterviewCompany.Domain.Repositories.Interfaces;
using InterviewCompany.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewCompany.Service
{
    public class CurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private List<Currency> _avaiableCurrencies;

        public CurrencyService (ICurrencyRepository currencyRepository)
        {
            this._currencyRepository = currencyRepository;
            _avaiableCurrencies = _currencyRepository.GetAll();
        }

        public async Task InsertCurrency(Currency currency)
        {
            if (_avaiableCurrencies.Any(c=>c.Code.Equals(currency.Code)))
                throw new CurrencyAlreadyExistsException(currency.Code);

            await _currencyRepository.InsertOneAsync(currency);
            _avaiableCurrencies.Add(currency);
        }

        public async Task UpdateCurrency(Currency currency)
        {
            var dbCurrency = _avaiableCurrencies.FirstOrDefault(c => c.Code.Equals(currency.Code));

            if (dbCurrency == null)
                throw new CurrencyNotFoundException(currency.Code);

            if (currency.ExchangeRateDate <= dbCurrency.ExchangeRateDate || currency.ExchangeRateDate > DateTime.Now)
                throw new InvalidCurrencyExchangeRateDateException(currency.ExchangeRateDate);

            await _currencyRepository.UpdateAsync(currency);
            _avaiableCurrencies = await _currencyRepository.GetAllAsync();
        }
    }
}
