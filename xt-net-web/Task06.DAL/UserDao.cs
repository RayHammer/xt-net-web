using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Task06.DAL.Interfaces;
using Task06.Entities;

namespace Task06.DAL
{
    public class UserDao : IUserDao
    {
        private static readonly string dbPath = Environment.CurrentDirectory + @"\users.db";
        private static readonly IDictionary<int, User> userDb = LoadDatabase();

        public User Add(User user)
        {
            var lastId = userDb.Keys.Count > 0
                ? userDb.Keys.Max()
                : 0;

            user.Id = lastId + 1;
            userDb.Add(user.Id, user);
            SaveDatabase();
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return userDb.Values;
        }

        public void Remove(int id)
        {
            if (userDb.Remove(id))
            {
                SaveDatabase();
            }
        }

        private static IDictionary<int, User> LoadDatabase()
        {
            var db = new Dictionary<int, User>();
            if (!File.Exists(dbPath))
            {
                return db;
            }
            string[] data = File.ReadAllLines(dbPath);
            foreach (var entry in data)
            {
                string[] entryInfo = entry.Split(',');
                var user = new User()
                {
                    Id = int.Parse(entryInfo[0]),
                    Name = entryInfo[1],
                    DateOfBirth = DateTime.Parse(entryInfo[2])
                };
                db.Add(user.Id, user);
            }
            return db;
        }

        private void SaveDatabase()
        {
            var data = new StringBuilder();
            foreach (var user in GetAll())
            {
                data.Append(user.Id).Append(',').
                    Append(user.Name).Append(',').
                    Append(user.DateOfBirth.ToString()).
                    Append(Environment.NewLine);
            }
            File.WriteAllText(dbPath, data.ToString());
        }
    }
}