using Loqate.Errors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loqate
{
    /// <summary>
    /// Indicates an unsuccessfull API call.
    /// </summary>
    public class LoqateException : Exception
    {
        private int _statusCode;

        private LoqateError[] _errorTable;

        public LoqateException(int statusCode)
        {
            _statusCode = statusCode;
        }

        public LoqateException(int statusCode, LoqateError[] errors)
        {
            _statusCode = statusCode;
            _errorTable = errors;
        }

        public int StatusCode => _statusCode;

        public LoqateError[] ErrorTable => _errorTable;

    }
}
