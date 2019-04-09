using InterviewCompany.Domain.Documents;
using InterviewCompany.Domain.Repositories.Interfaces;
using InterviewCompany.Service.Exceptions;
using InterviewCompany.Service.Validators;
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
        private readonly CurrencyValidator _validator;

        public CurrencyService (ICurrencyRepository currencyRepository)
        {
            this._currencyRepository = currencyRepository;
            _avaiableCurrencies = _currencyRepository.GetAll();
            _validator = new CurrencyValidator();
        }

        public List<Currency> GetAvailableCurrencies()
        {
            return _avaiableCurrencies;
        }

        public async Task<ValidationResult> InsertCurrencyAsync(Currency currency)
        {
            var validationResult = _validator.Validate(_avaiableCurrencies, CurrencyDbAction.Insert, currency);
            if (validationResult.Status == ValidationStatus.Error)
                return validationResult;

            await _currencyRepository.InsertOneAsync(currency);
            _avaiableCurrencies.Add(currency);
            return validationResult;
        }

        public async Task<ValidationResult> UpdateCurrencyAsync(Currency currency)
        {
            var validationResult = _validator.Validate(_avaiableCurrencies, CurrencyDbAction.Update, currency);

            if (validationResult.Status == ValidationStatus.Error)
                return validationResult;

            await _currencyRepository.UpdateAsync(currency);
            _avaiableCurrencies = await _currencyRepository.GetAllAsync();

            return validationResult;
        }
    }
}
