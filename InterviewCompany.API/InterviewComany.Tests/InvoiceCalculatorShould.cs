using InterviewCompany.Domain.Documents;
using InterviewCompany.Domain.Model;
using InterviewCompany.Service.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Moq;
using InterviewCompany.Domain.Repositories.Interfaces;
using InterviewCompany.Domain.Repositories;

namespace InterviewCompany.Tests
{
    public class InvoiceCalculatorShould
    {
        private readonly ITestOutputHelper _output;
        private InvoiceCalculator _sut;
        private Invoice _invoice;

        public InvoiceCalculatorShould(ITestOutputHelper output)
        {
            _output = output;
            Initialize();
        }

        [Fact]
        public async Task ReturnExpectedTotalAmount()
        {
            var totalAmount = await _sut.CalculateTotalAmount(_invoice.Items);
            _output.WriteLine($"Expected total amount value is {_invoice.TotalAmount}");
            _output.WriteLine($"Calculated total amount value is {totalAmount}");

            Assert.Equal(_invoice.TotalAmount, totalAmount, 4);
        }

        #region Initialization

        private void Initialize()
        {
            InitializeInvoice();
            InitializeSut();
        }

        private void InitializeSut()
        {
            var mockRepository = new Mock<ICurrencyRepository>();
            var resultList = new List <Currency>
            {
                new Currency { Code = "USD", Name = "Euro", ExchangeRate = 1, ExchangeRateDate = new DateTime(2019, 4, 9, 12, 45, 0) },
                new Currency { Code = "EUR", Name = "British Pound", ExchangeRate = 0.886552m, ExchangeRateDate = new DateTime(2019, 4, 9, 12, 45, 0) },
                new Currency { Code = "CHF", Name = "Swiss Franc", ExchangeRate = 0.998312m, ExchangeRateDate = new DateTime(2019, 4, 9, 12, 45, 0) },
                new Currency { Code = "RUB", Name = "Russian Ruble", ExchangeRate = 64.767361m, ExchangeRateDate = new DateTime(2019, 4, 9, 13, 40, 0) }
            };
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(resultList);
            _sut = new InvoiceCalculator(mockRepository.Object);
        }

        private void InitializeInvoice()
        {
            var customer = new Customer
            {
                City = "Paris",
                Country = "France",
                Name = "Customer Company"
            };

            var issuer = new Customer
            {
                City = "Madrit",
                Country = "Spain",
                Name = "Issuer Company"
            };

            var items = new InvoiceItem[]
            {
                new InvoiceItem{ CurrencyCode = "USD", UnitCost = 2.43m, Quantity = 6, Amount = 14.58m},
                new InvoiceItem{ CurrencyCode = "EUR", UnitCost = 0.71m, Quantity = 4, Amount = 2.84m},
                new InvoiceItem{ CurrencyCode = "CHF", UnitCost = 70.12m, Quantity = 0.87m, Amount = 61.0044m},
                new InvoiceItem{ CurrencyCode = "RUB", UnitCost = 15.11m, Quantity = 120m, Amount = 242.4m}
            };

            _invoice = new Invoice
            {
                BillTo = customer,
                Issuer = issuer,
                IssueDate = DateTime.Now,
                Items = items,
                Number = 1,
                TotalAmount = 106.8865539m
            };
        }
        #endregion
    }
}
