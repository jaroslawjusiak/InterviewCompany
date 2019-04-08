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

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            this._invoiceRepository = invoiceRepository;
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _invoiceRepository.GetAllAsync();
        }

        public async Task<Invoice> GetByNumberAsync(string number)
        {
            throw new NotImplementedException();
        }

        public async Task InsertOneAsync(AddInvoiceModel invoice)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveOneAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
