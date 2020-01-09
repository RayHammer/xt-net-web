using System;
using System.Collections.Generic;
using System.IO;
using Task06.DAL.Interfaces;

namespace Task06.DAL
{
    internal class UserAwardTableDao : IUserAwardTableDao
    {
        private static readonly string filePath = Environment.CurrentDirectory + @"\users-awards.rel";
        private static readonly char[] separator = { ',' };
        private static readonly IDictionary<int, IList<int>> table = LoadTable();

        public void Add(int userId, int awardId)
        {
            if (!table.ContainsKey(userId))
            {
                table[userId] = new List<int>();
            }
            table[userId].Add(awardId);
            SaveTable(table);
        }

        public void Clear(int userId)
        {
            table[userId].Clear();
            table.Remove(userId);
            SaveTable(table);
        }

        public IEnumerable<int> GetAwardIdsFor(int userId)
        {
            return table[userId];
        }

        public void Remove(int userId, int awardId)
        {
            if (!table.ContainsKey(userId))
            {
                return;
            }

            table[userId].Remove(awardId);
            if (table[userId].Count == 0)
            {
                Clear(userId);
            }
            else
            {
                SaveTable(table);
            }
        }

        private static IDictionary<int, IList<int>> LoadTable()
        {
            var table = new Dictionary<int, IList<int>>();
            if (!File.Exists(filePath))
            {
                return table;
            }
            using (StreamReader reader = File.OpenText(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var userId = int.Parse(reader.ReadLine());
                    table[userId] = new List<int>();
                    string[] awardIds = reader.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var str in awardIds)
                    {
                        table[userId].Add(int.Parse(str));
                    }
                }
                reader.Close();
            }
            return table;
        }

        private static void SaveTable(IDictionary<int, IList<int>> table)
        {
            using (StreamWriter writer = File.CreateText(filePath))
            {
                foreach (var userId in table.Keys)
                {
                    writer.WriteLine(userId);
                    foreach (var awardId in table[userId])
                    {
                        writer.Write(awardId);
                        writer.WriteLine(separator[0]);
                    }
                    writer.WriteLine();
                }
                writer.Close();
            }
        }
    }
}