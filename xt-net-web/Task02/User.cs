using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class User
    {
        public User(string surname, string name, DateTime dateOfBirth)
            : this(surname, name, "", dateOfBirth)
        {
        }

        public User(string surname, string name, string middlename, DateTime dateOfBirth)
        {
            if (surname.Length == 0)
            {
                throw new ArgumentException("Surname is empty");
            }
            if (name.Length == 0)
            {
                throw new ArgumentException("First name is empty");
            }
            this.surname = surname;
            this.name = name;
            this.middlename = middlename;
            this.dateOfBirth = dateOfBirth;
        }

        public string FullName
        {
            get
            {
                if (middlename.Length == 0)
                {
                    return name + " " + surname;
                }
                else
                {
                    return name + " " + middlename + " " + surname;
                }
            }
        }

        public string DateOfBirth
        {
            get
            {
                return dateOfBirth.ToString();
            }
        }

        private string surname, name, middlename;
        private DateTime dateOfBirth;
    }
}
