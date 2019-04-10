using InterviewCompany.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewCompany.Tests.Data
{
    public class InvoiceFixture
    {
        public AddInvoiceModel Invoice{ get; private set; }

        public InvoiceFixture()
        {
            Invoice = GenerateNewInvoiceModel();
        }

        public void SetNullCustomer()
        {
            Invoice.BillTo = null;
        }

        public void SetNullIssuer()
        {
            Invoice.Issuer = null;
        }

        public void SetNegativeUnitCost(int itemIndex)
        {
            if(itemIndex < Invoice.Items.Count())
            {
                Invoice.Items[itemIndex].UnitCost = -1;
            }
        }

        public void SetNegativeQuantity(int itemIndex)
        {
            if (itemIndex < Invoice.Items.Count())
            {
                Invoice.Items[itemIndex].Quantity = -1;
            }
        }

        public void SetEmptyCurrencyCode(int itemIndex)
        {
            if (itemIndex < Invoice.Items.Count())
            {
                Invoice.Items[itemIndex].CurrencyCode = string.Empty;
            }
        }

        public void SetTooLongCurrencyCode(int itemIndex)
        {
            if (itemIndex < Invoice.Items.Count())
            {
                Invoice.Items[itemIndex].CurrencyCode = "EURO";
            }
        }

        public void SetTooShortCurrencyCode(int itemIndex)
        {
            if (itemIndex < Invoice.Items.Count())
            {
                Invoice.Items[itemIndex].CurrencyCode = "EU";
            }
        }
        

        private AddInvoiceModel GenerateNewInvoiceModel()
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
                new InvoiceItem{ CurrencyCode = "CHF", UnitCost = 70.12m, Quantity = 0.87m, Amount = 61.0044m}
            };

            var invoiceModel = new AddInvoiceModel
            {
                BillTo = customer,
                Issuer = issuer,
                Items = items
            };

            return invoiceModel;
        }
    }
}
