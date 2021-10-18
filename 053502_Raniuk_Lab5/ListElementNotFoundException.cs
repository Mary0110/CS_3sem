using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053502_Raniuk_Lab5
{
    class ListElementNotFoundException: Exception
    {
        public ListElementNotFoundException()
        {
        }

        public ListElementNotFoundException(string message)
            : base(message)
        {
        }

        public ListElementNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
