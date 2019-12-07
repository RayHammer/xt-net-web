using System;

namespace Task02
{
    class Employee : User
    {
        public Employee(string surname, string name,
            DateTime dateOfBirth, string job, int experience)
            : this(surname, name, "", dateOfBirth, job, experience)
        {
        }

        public Employee(string surname, string name, string middlename,
            DateTime dateOfBirth, string job, int experience)
            : base(surname, name, middlename, dateOfBirth)
        {
            Job = job;
            Experience = experience;
        }

        public string Job
        {
            get => job;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException();
                }
                job = value;
            }
        }

        public int Experience
        {
            get => experience;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                experience = value;
            }
        }

        private string job;
        private int experience;
    }
}
