using InterviewCompany.Domain.Documents;
using InterviewCompany.Domain.Model;
using InterviewCompany.Service.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCompany.Service
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice> GetByNumberAsync(int number);
        Task<InvoiceInsertResponse> InsertOneAsync(AddInvoiceModel invoice);
        Task<bool> RemoveOneAsync(int number);
    }
}
