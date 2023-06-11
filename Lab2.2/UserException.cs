using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogNamespace
{
    public class UserException : Exception
    {
        public const string errorMessage = "Не соответствует требованиям";
        public UserException(string message)
            : base(message) { }
    }
}
