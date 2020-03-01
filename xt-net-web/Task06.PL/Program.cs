using System;
using Task06.BLL;
using Task06.BLL.Interfaces;
using Task06.DAL;
using Task06.Entities;
using Task11.DAL;

namespace Task06.PL
{
    internal class Program
    {
        private readonly static char[] separator = { ' ' };

        private static IAwardLogic awardLogic;
        private static IUserLogic userLogic;

        private static void Main(string[] args)
        {
            userLogic = new UserLogic(new SqlUserDao(), new SqlUserAwardTableDao());
            awardLogic = new AwardLogic(new SqlAwardDao());

            while (ProcessInput())
            {
            }
        }

        private static bool ProcessInput()
        {
            string command = ReadInput();
            string[] commandArgs = command.Split(separator,
                StringSplitOptions.RemoveEmptyEntries);

            switch (commandArgs[0].ToLower())
            {
            case "add":
                switch (commandArgs[1].ToLower())
                {
                case "user":
                    userLogic.Add(new User()
                    {
                        Name = ReadInput("Name"),
                        DateOfBirth = DateTime.Parse(ReadInput("Date of birth"))
                    });
                    break;

                case "award":
                    awardLogic.Add(new Award()
                    {
                        Title = ReadInput("Title")
                    });
                    break;

                default:
                    WriteLine("Usage: add <user/award>");
                    break;
                }
                break;

            case "remove":
                switch (commandArgs[1].ToLower())
                {
                case "user":
                    userLogic.Remove(int.Parse(commandArgs[2]));
                    break;

                case "award":
                    awardLogic.Remove(int.Parse(commandArgs[2]));
                    break;

                default:
                    WriteLine("Usage: remove <user/award>");
                    break;
                }
                break;

            case "list":
                switch (commandArgs[1].ToLower())
                {
                case "users":
                    foreach (var entry in userLogic.GetAll())
                    {
                        WriteLine(entry.ToString());
                        foreach (var award in userLogic.GetAwardsFor(entry.Id, awardLogic))
                        {
                            Write(" - ");
                            WriteLine(award.ToString());
                        }
                    }
                    break;

                case "awards":
                    foreach (var entry in awardLogic.GetAll())
                    {
                        WriteLine(entry.ToString());
                    }
                    break;

                default:
                    WriteLine("Usage: list <users/awards>");
                    break;
                }
                break;

            case "award":
                switch (commandArgs[1].ToLower())
                {
                case "assign":
                    userLogic.AddAward(int.Parse(commandArgs[2]),
                        awardLogic.GetById(int.Parse(commandArgs[3])));
                    break;

                case "revoke":
                    userLogic.RemoveAward(int.Parse(commandArgs[2]),
                        awardLogic.GetById(int.Parse(commandArgs[3])));
                    break;

                default:
                    WriteLine("Usage: award <assign/revoke> (userId) (awardId)");
                    break;
                }
                break;

            case "exit":
                return false;
            }
            return true;
        }

        private static string ReadInput(string q = "")
        {
            Console.Write(q + "> ");
            return Console.ReadLine();
        }

        private static void Write(string value)
        {
            Console.Write(value);
        }

        private static void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}