using InterviewCompany.Domain.Documents;
using InterviewCompany.Domain.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCompany.Domain.Repositories
{
    public class MongoInvoiceRepository : IInvoiceRepository
    {
        private readonly MongoDbContext _context;

        public MongoInvoiceRepository(MongoDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            try
            {
                return await _context.Invoices
                        .Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<Invoice> GetByNumberAsync(int number)
        {
            try
            {
                return await _context.Invoices
                        .Find(i => i.Number == number).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<int> GetLastInvoiceNumberAsync()
        {
            if(_context.Invoices.Find(_ => true).Any())
            {
                var projection = Builders<Invoice>.Projection.Include("Number");
                var x = await _context.Invoices
                        .Find(_ => true).Project(projection).FirstOrDefaultAsync();


                var lastInvoice  = await _context.Invoices
                        .Find(_ => true)
                        .SortByDescending(i => i.Number).FirstOrDefaultAsync();
                return lastInvoice.Number;
            }

            return 0;
        }

        public async Task InsertOneAsync(Invoice invoice)
        {
            await _context.Invoices.InsertOneAsync(invoice);
        }

        public async Task<bool> RemoveOneAsync(int number)
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Invoices.DeleteOneAsync(
                        Builders<Invoice>.Filter.Eq("Number", number));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
