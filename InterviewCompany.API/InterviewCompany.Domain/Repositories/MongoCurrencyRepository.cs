using InterviewCompany.Domain.Documents;
using InterviewCompany.Domain.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCompany.Domain.Repositories
{
    public class MongoCurrencyRepository : ICurrencyRepository
    {
        private readonly MongoDbContext _context;

        public MongoCurrencyRepository(MongoDbContext context)
        {
            this._context = context;
        }

        public List<Currency> GetAll()
        {
            return _context.Currencies.Find(_ => true).ToList();
        }

        public async Task<List<Currency>> GetAllAsync()
        {
            return await _context.Currencies.Find(_ => true).ToListAsync();
        }

        public async Task InsertOneAsync(Currency currency)
        {
            try
            {
                //TODO: Dodac sprawdzenie czy waluta o zadanym kodzi już istnieje przed dodaniem nowej
                await _context.Currencies.InsertOneAsync(currency);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateAsync(Currency currency)
        {
            //TODO: Dodac sprawdzenie czy waluta istnieje i czy nowa data jest swiezsza od poprzedniej.
            var filter = Builders<Currency>.Filter.Eq(c => c.Code, currency.Code);
            var update = Builders<Currency>.Update
                            .Set(c => c.ExchangeRate, currency.ExchangeRate)
                            .Set(c => c.ExchangeRateDate, currency.ExchangeRateDate);

            try
            {
                UpdateResult actionResult
                    = await _context.Currencies.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
