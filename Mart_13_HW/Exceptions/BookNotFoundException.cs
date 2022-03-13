using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_13_HW.Exceptions
{
    class BookNotFoundException : Exception
    {
        public BookNotFoundException(string ex) : base(ex) { }
    }
}
