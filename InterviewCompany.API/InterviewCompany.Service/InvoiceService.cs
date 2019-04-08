using AutoMapper;
using InterviewCompany.Domain.Documents;
using InterviewCompany.Domain.Model;
using InterviewCompany.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCompany.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, ICurrencyRepository currencyRepository, IMapper mapper)
        {
            this._invoiceRepository = invoiceRepository;
            this._currencyRepository = currencyRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _invoiceRepository.GetAllAsync();
        }

        public async Task<Invoice> GetByNumberAsync(string number)
        {
            return await _invoiceRepository.GetByNumberAsync(number);
        }

        public async Task<Invoice> InsertOneAsync(AddInvoiceModel invoiceModel)
        {
            var invoice = _mapper.Map<Invoice>(invoiceModel);
            invoice.Number = await GenerateInvoiceNumberAsync();
            invoice.TotalAmount = CalculateTotalAmount(invoice.Items);

            throw new NotImplementedException();
        }

        public async Task<bool> RemoveOneAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        #region Private members

        private async Task<int> GenerateInvoiceNumberAsync()
        {
            var lastInvoiceNumber = await _invoiceRepository.GetLastInvoiceNumberAsync();
            return ++lastInvoiceNumber;
        }

        private decimal CalculateTotalAmount(InvoiceItem[] items)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
