using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCompany.Tests.Data
{
    public class CurrencyValidatorData
    {
        public static IEnumerable<object[]> Currencies
        {
            get
            {
                yield return new object[] { "EUR", "Euro", 0.886552m, new DateTime(2019,4,9,12,45,0)};
                yield return new object[] { "JPY", "Japanese Yen", 111.023276m, new DateTime(2020,4,9,12,45,0)};
            }
        }
    }
}
