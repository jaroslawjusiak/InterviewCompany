using InterviewCompany.Domain.Model;
using InterviewCompany.Domain.Repositories.Interfaces;
using InterviewCompany.Service.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewCompany.Service.Validators
{
    public class InvoiceValidator
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly string _errorMessage = "Invoice item contains not supported currency!";
        private readonly InvoiceInsertResponse _response = new InvoiceInsertResponse();

        public InvoiceValidator(ICurrencyRepository currencyRepository)
        {
            this._currencyRepository = currencyRepository;
        }


        public async Task<InvoiceInsertResponse> ValidateInvoiceCurrencies(AddInvoiceModel invoice)
        {
            var availableCurrencies = await _currencyRepository.GetAllAsync();
            
            var invoiceCurrencyCodes = invoice.Items.Select(i => i.CurrencyCode).Distinct().ToList();
            var availableCurrencyCodes = availableCurrencies.Select(c => c.Code).ToList();
            var intersect = availableCurrencyCodes.Intersect<string>(invoiceCurrencyCodes);

            if (intersect.Count() != invoiceCurrencyCodes.Count())
                _response.ValidationResult.ErrorMessages.Add(_errorMessage);
            
            return await Task.FromResult(_response);
        }
    }
}
