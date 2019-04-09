using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCompany.Tests.Data
{
    public class CurrencyValidatorData
    {
        public static IEnumerable<object[]> ExistingCurrency
        {
            get
            {
                yield return new object[] { "EUR", "Euro", 0.886552m, new DateTime(2029,4,9,12,45,0)};
            }
        }

        public static IEnumerable<object[]> NonExisitngCurrency
        {
            get
            {
                yield return new object[] { "IRR", "Iranian Rial", 42106.479615m, new DateTime(2029, 4, 9, 12, 45, 0) };
            }
        }
    }
}
