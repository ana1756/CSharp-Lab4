using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Exceptions
{
    public class BirthDateInFutureException : Exception
    {
        public BirthDateInFutureException(string message)
            : base(message) { }
    }

    public class BirthDateInPastException : Exception
    {
        public BirthDateInPastException(string message)
            : base(message) { }
    }

    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message)
            : base(message) { }
    }
}
