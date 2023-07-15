using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomTestRail.Core.Exeptions
{
    internal class DriverNotSupportedExeption : Exception
    {
        public DriverNotSupportedExeption(string browser) : base(String.Format("Browser %s not supported", browser)) { }
    }
}
