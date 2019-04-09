using InterviewCompany.Domain.Model;
using InterviewCompany.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewCompany.Service.Tools
{
    public class InvoiceCalculator
    {
        private readonly ICurrencyRepository _currencyRepository;

        public InvoiceCalculator(ICurrencyRepository currencyRepository )
        {
            this._currencyRepository = currencyRepository;
        }

        public async Task<decimal> CalculateTotalAmount(InvoiceItem[] items)
        {
            var currencies = await _currencyRepository.GetAllAsync();
            var total = 0m;

            foreach (var item in items)
            {
                if (!item.CurrencyCode.Equals("USD"))
                {
                    var exchangeRate = currencies.First(c => c.Code.Equals(item.CurrencyCode)).ExchangeRate;
                    total += item.Quantity * item.UnitCost * exchangeRate;
                }
                else
                {
                    total += item.Quantity * item.UnitCost;
                }
            }

            return total;
        }

    }
}
