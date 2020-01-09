using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Task07
{
    internal class Task07
    {
        public void DateExistance(string input)
        {
            var regex = new Regex(@"(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-([0-9][0-9][0-9][0-9])");
            Console.WriteLine(regex.IsMatch(input));
        }

        public void HtmlReplacer(string input)
        {
            var regex = new Regex(@"</?[a-z]+.*?>");
            Console.WriteLine(regex.Replace(input, "_"));
        }

        public void EmailFinder(string input)
        {
            var regex = new Regex(@"\b[A-Za-z0-9](?:[A-Za-z0-9\-\._]*[A-Za-z0-9])?@[A-Za-z0-9](?:[A-Za-z0-9\-]*[A-Za-z0-9])?\.[A-Za-z]{2,6}\b");
            foreach (Match match in regex.Matches(input))
            {
                Console.WriteLine(match.Value);
            }
        }

        public void NumberValidator(string input)
        {
            var regexNormal = new Regex(@"(?:0|-?[1-9][0-9]*)(?:\.[0-9]*[1-9])?");
            var regexScientific = new Regex(@"(?:0|-?[1-9][0-9]*)(?:\.[0-9]*[1-9])?e(?:0|-?[1-9][0-9]*)");
            if (regexScientific.Match(input).Value == input)
            {
                Console.WriteLine("This is a number in scientific notation.");
            }
            else if (regexNormal.Match(input).Value == input)
            {
                Console.WriteLine("This is a number in normal notation.");
            }
            else
            {
                Console.WriteLine("This is not a number.");
            }
        }

        public void TimeCounter(string input)
        {
            var regex = new Regex(@"\b(1?[0-9]|2[0-3]):([0-5][0-9])\b");
            Console.WriteLine($"In the following string there are {regex.Matches(input).Count} timestamps.");
        }
    }
}