using System;

namespace Task06.Entities
{
    public class User
    {
        public int Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public DateTime DateOfBirth
        {
            get; set;
        }

        public int Age
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            return $"{Id}, {Name}, {DateOfBirth.ToString("d")}";
        }
    }
}