using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    internal class UserPatterns
    {
        public const int FirstnameLength = 50;
        public const int LastnameLength = 200;
        public const int LoginLength = 20;
        public const string FirstnamePattern = @"^[A-Z][a-z]*$|^[А-ЯЁ][а-яё]*$";
        public const string LastnamePattern = @"^[A-Z][a-z]*(?:-[A-Z][a-z]*)?$|^[А-ЯЁ][а-яё]*(?:-[А-ЯЁ][а-яё]*)?$";
        public const string EmailPattern = @"^[^\W_](?:[\w\-\.]*[^\W_])?@(?:[^\W_](?:[\w\-]*[^\W_])?\.){1,}[a-zA-Z]{2,6}$";
        public const string LoginPattern = @"^[a-z]*$";
    }
}
