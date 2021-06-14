using Bookstore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Service
{
    public class ConvertingService : IConvertingService
    {
        public string ConvertIntegerToString(int intValue)
        {
            string result = intValue.ToString();
            return result;
        }

        #region Helper Functions
        private int ConvertStringToInt(string stringValue)
        {
            int result = int.Parse(stringValue);
            return result;
        }

        public string ConvertAnyToString<T>(T type)
        {
            var result = type.ToString();
            return result;
        }
        #endregion

    }
}
