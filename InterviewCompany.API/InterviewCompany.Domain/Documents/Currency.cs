using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCompany.Domain.Documents
{
    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime ExchangeRateDate { get; set; }
    }
}
