using System;

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
            Surname = surname;
            Name = name;
            MiddleName = middlename;
            DateOfBirth = dateOfBirth;
        }

        public string Surname
        {
            get => surname;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Surname is empty");
                }
                surname = value;
            }
        }

        public string MiddleName
        {
            get; set;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("First name is empty");
                }
                name = value;
            }
        }

        public DateTime DateOfBirth
        {
            get; set;
        }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        public string FullName
        {
            get
            {
                if (MiddleName.Length == 0)
                {
                    return Name + " " + Surname;
                }
                else
                {
                    return Name + " " + MiddleName + " " + Surname;
                }
            }
        }

        private string name, surname;
    }
}
