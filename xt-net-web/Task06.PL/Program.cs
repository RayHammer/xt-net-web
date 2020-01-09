using System;
using Task06.BLL;
using Task06.BLL.Interfaces;
using Task06.DAL;
using Task06.Entities;

namespace Task06.PL
{
    internal class Program
    {
        private readonly static char[] separator = { ' ' };

        private static void Main(string[] args)
        {
            IUserLogic logic = new UserLogic(new UserDao());

            bool isRunning = true;
            while (isRunning)
            {
                string command = ReadInput();
                string[] commandArgs = command.Split(separator,
                    StringSplitOptions.RemoveEmptyEntries);

                switch (commandArgs[0].ToLower())
                {
                case "add":
                    logic.Add(new User()
                    {
                        Name = ReadInput("Name"),
                        DateOfBirth = DateTime.Parse(ReadInput("Date of birth"))
                    });
                    break;
                case "remove":
                    logic.Remove(int.Parse(commandArgs[1]));
                    break;
                case "list":
                    foreach (var entry in logic.GetAll())
                    {
                        WriteLine(entry.ToString());
                    }
                    break;
                case "exit":
                    isRunning = false;
                    break;
                }
            }
        }

        private static string ReadInput(string q = "")
        {
            Console.Write(q + "> ");
            return Console.ReadLine();
        }

        private static void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}