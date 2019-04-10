using InterviewCompany.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCompany.Domain.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice> GetByNumberAsync(int number);
        Task InsertOneAsync(Invoice invoice);
        Task<bool> RemoveOneAsync(int number);
        Task<int> GetLastInvoiceNumberAsync();
    }
}
