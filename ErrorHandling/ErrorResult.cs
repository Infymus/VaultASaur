using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaultASaur.ErrorHandling
{
    public class tErrorResult
    {
        public bool errorResult = false;
        public string errorMessage = "";
        public int AsInteger;
        public string AsString;
        public bool AsBoolean;
        public long AsLong;
        public double AsDouble;
        public DateTime AsDateTime;
        public bool NewDataBase = false;
    }
}
