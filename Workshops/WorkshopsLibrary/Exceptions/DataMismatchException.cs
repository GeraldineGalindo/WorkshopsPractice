using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workshops.Exceptions
{
    public class DataMismatchException : Exception
    {
        public DataMismatchException(string message) : base(message)
        {

        }
    }
}
