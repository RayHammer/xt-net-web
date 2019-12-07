using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Task02
    {
        public static void Round()
        {
            var round = new Round(x: 3, y: 4, r: 5);
            Console.WriteLine(round.ToString());
            Console.WriteLine("Circumference = " + round.Circumference);
            Console.WriteLine("Area = " + round.Area);
            float x = 0, y = 0;
            Console.WriteLine("Intersection with X = " + x +
                ", Y = " + y + ": " + round.IntersectsWithPoint(x, y));
        }

        public static void Triangle()
        {
            var triangle = new Triangle(3, 4, 5);
            Console.WriteLine("Perimeter = " + triangle.Perimeter);
            Console.WriteLine("Area = " + triangle.Area);
        }

        public static void User()
        {
            var user = new User("Kondratyev", "Yegor", new DateTime(1998, 11, 4));
            Console.WriteLine(user.FullName);
            Console.WriteLine(user.DateOfBirth);
            Console.WriteLine(user.Age);
        }

        public static void MyString()
        {
            var mystring = new MyString();
            mystring += "Hello";
            Console.WriteLine(mystring);
            var mystring1 = new MyString("World");
            Console.WriteLine(mystring1);
            var resString = mystring + ' ';
            resString += mystring1;
            Console.WriteLine(resString);
        }

        public static void Employee()
        {
            var employee = new Employee("Kondratyev", "Yegor", new DateTime(1998, 11, 4), "programmer", 3);
            Console.WriteLine(employee.FullName);
            Console.WriteLine(employee.DateOfBirth);
            Console.WriteLine(employee.Age);
            Console.WriteLine(employee.Job);
            Console.WriteLine(employee.Experience);
        }

        public static void Ring()
        {
            var ring = new Ring(0, 0, 5, 10);
            Console.WriteLine(ring.ToString());
            Console.WriteLine("Circumference = " + ring.Circumference);
            Console.WriteLine("Area = " + ring.Area);
            float x = 0, y = 0;
            Console.WriteLine("Intersection with X = " + x +
                ", Y = " + y + ": " + ring.IntersectsWithPoint(x, y));
        }

        public static void VectorGraphicsEditor()
        {
            var editor = new VGEditor();
            editor.Run();
        }
    }
}
