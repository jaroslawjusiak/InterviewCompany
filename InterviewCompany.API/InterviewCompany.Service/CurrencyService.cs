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

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            this._currencyRepository = currencyRepository;
        }

        public async Task InsertCurrency(Currency currency)
        {
            //if (_currencyRepository. .Any(c=>c.Code.Equals(currency.Code)))
            //    throw new CurrencyAlreadyExistsException(currency.Code);

            //await _currencyRepository.InsertOneAsync(currency);
            //_systemCurrency.AvaiableCurrencies.Add(currency);
            throw new NotImplementedException();
        }

        public async Task UpdateCurrency(Currency currency)
        {
            //if (!_systemCurrency.AvaiableCurrencies.Any(c => c.Code.Equals(currency.Code)))
            //    throw new CurrencyNotFoundException(currency.Code);

            //await _currencyRepository.UpdateAsync(currency);
            //_systemCurrency.Update(currency);
            throw new NotImplementedException();
        }
    }
}
