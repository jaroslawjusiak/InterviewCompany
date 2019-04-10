using AutoMapper;
using InterviewCompany.Domain.Documents;
using InterviewCompany.Domain.Model;
using InterviewCompany.Domain.Repositories.Interfaces;
using InterviewCompany.Service.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewCompany.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly InvoiceCalculator _calculator;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper, InvoiceCalculator calculator)
        {
            this._invoiceRepository = invoiceRepository;
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

        public async Task<int> InsertOneAsync(AddInvoiceModel invoiceModel)
        {
            var invoice = _mapper.Map<Invoice>(invoiceModel);
            invoice.Number = await GenerateInvoiceNumberAsync();
            invoice.TotalAmount = await _calculator.CalculateTotalAmount(invoice.Items);
            await _invoiceRepository.InsertOneAsync(invoice);

            return invoice.Number;
        }

        public async Task<bool> RemoveOneAsync(Guid id)
        {
               return await _invoiceRepository.RemoveOneAsync(id);
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
