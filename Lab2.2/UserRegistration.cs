using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogNamespace
{
    internal class UserRegistration
    {
        private string _firstname;
        private string _lastname;
        private string _login;
        private string _email;
        private int _id;
        private string _password;
        private DateTime _dateOfRegistration;
        public Random rand = new Random();
        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                if (value.Length <= UserPatterns.FirstnameLength && Regex.IsMatch(value, UserPatterns.FirstnamePattern))
                {
                    _firstname = value;
                }
                else
                {
                    throw new UserException(UserException.errorMessage);
                }
            }
        }
        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                if (value.Length <= UserPatterns.LastnameLength && Regex.IsMatch(value, UserPatterns.LastnamePattern))
                {
                    _lastname = value;
                }
                else
                {
                    throw new UserException(UserException.errorMessage);
                }
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                if (value.Length <= UserPatterns.LoginLength && Regex.IsMatch(value, UserPatterns.LoginPattern))
                {
                    _firstname = value;
                }
                else
                {
                    throw new UserException(UserException.errorMessage);
                }
            }
        }
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = rand.Next();
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value is not null)
                {
                    _password = value;
                }
                else
                {
                    throw new UserException(UserException.errorMessage);
                }
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (Regex.IsMatch(value, UserPatterns.EmailPattern))
                {
                    _email = value;
                }
                else
                {
                    throw new UserException(UserException.errorMessage);
                }
            }
        }
        public DateTime DateOfRegistration
        {
            get
            {
                return _dateOfRegistration;
            }
            set
            {
                _dateOfRegistration = DateTime.Now;
            }
        }
    }
}
