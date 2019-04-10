using AutoMapper;
using InterviewCompany.Domain.Documents;
using InterviewCompany.Domain.Model;
using InterviewCompany.Domain.Repositories.Interfaces;
using InterviewCompany.Service.ResponseModel;
using InterviewCompany.Service.Tools;
using InterviewCompany.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewCompany.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;
        private readonly InvoiceCalculator _calculator;

        public InvoiceService(IInvoiceRepository invoiceRepository, ICurrencyRepository currencyRepository, IMapper mapper, InvoiceCalculator calculator)
        {
            this._invoiceRepository = invoiceRepository;
            this._currencyRepository = currencyRepository;
            this._mapper = mapper;
            this._calculator = calculator;
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _invoiceRepository.GetAllAsync();
        }

        public async Task<Invoice> GetByNumberAsync(int number)
        {
            return await _invoiceRepository.GetByNumberAsync(number);
        }

        public async Task<InvoiceInsertResponse> InsertOneAsync(AddInvoiceModel invoiceModel)
        {
            var invoiceValidator = new InvoiceValidator(_currencyRepository);
            var response = await invoiceValidator.ValidateInvoiceCurrencies(invoiceModel);

            if (response.ValidationResult.Status == ValidationStatus.Error)
                return await Task.FromResult(response);

            var invoice = _mapper.Map<Invoice>(invoiceModel);
            invoice.Number = await GenerateInvoiceNumberAsync();
            invoice.TotalAmount = await _calculator.CalculateTotalAmount(invoice.Items);
            await _invoiceRepository.InsertOneAsync(invoice);
            response.InvoiceNumber = invoice.Number;

            return await Task.FromResult(response);
        }

        public async Task<bool> RemoveOneAsync(int number)
        {
               return await _invoiceRepository.RemoveOneAsync(number);
        }

        #region Private members

        private async Task<int> GenerateInvoiceNumberAsync()
        {
            var lastInvoiceNumber = await _invoiceRepository.GetLastInvoiceNumberAsync();
            return ++lastInvoiceNumber;
        }

        

        #endregion
    }
}
