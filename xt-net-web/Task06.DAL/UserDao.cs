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
        private static IDictionary<int, User> userDb;
        private static string dbPath;

        public UserDao()
            : this(Environment.CurrentDirectory + @"\users.db")
        {
        }

        public UserDao(string path)
        {
            dbPath = path;
            userDb = LoadDatabase();
        }

        public User Add(User user)
        {
            var lastId = userDb.Keys.Count > 0
                ? userDb.Keys.Max()
                : 0;

            user.Id = lastId + 1;
            userDb.Add(user.Id, user);
            SaveDatabase(userDb);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return userDb.Values;
        }

        public User GetById(int id)
        {
            return userDb[id];
        }

        public void Remove(int id)
        {
            if (userDb.Remove(id))
            {
                SaveDatabase(userDb);
            }
        }

        public void Update(int id, User user)
        {
            user.Id = id;
            userDb[id] = user;
            SaveDatabase(userDb);
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

        private static void SaveDatabase(IDictionary<int, User> db)
        {
            var data = new StringBuilder();
            foreach (var user in db.Values)
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