using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_13_HW.Exceptions
{
    class SameBookIsAlreadyAddedExpection : Exception
    {
        public SameBookIsAlreadyAddedExpection(string ex) : base(ex) { }
    }
}
