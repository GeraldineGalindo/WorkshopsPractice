using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workshops.Exceptions
{
    public class EmptyCollectionException : Exception
    {
        public EmptyCollectionException(string message) : base(message)
        {
                
        }
    }
}
