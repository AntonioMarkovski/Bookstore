using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Service.Interfaces
{
    public interface IConvertingService
    {
        string ConvertIntegerToString(int intValue);
        string ConvertAnyToString<T>(T type);
    }
}
