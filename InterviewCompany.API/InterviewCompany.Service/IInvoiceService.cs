using InterviewCompany.Domain.Documents;
using InterviewCompany.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCompany.Service
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice> GetByNumberAsync(string number);
        Task<Invoice> InsertOneAsync(AddInvoiceModel invoice);
        Task<bool> RemoveOneAsync(Guid id);
    }
}
