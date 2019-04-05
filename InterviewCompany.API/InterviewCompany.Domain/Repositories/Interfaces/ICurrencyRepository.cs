using InterviewCompany.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCompany.Domain.Repositories.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<bool> UpdateAsync(Currency currency);
        Task InsertOneAsync(Currency currency);
    }
}
