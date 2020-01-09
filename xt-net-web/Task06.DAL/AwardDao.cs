using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Task06.DAL.Interfaces;
using Task06.Entities;

namespace Task06.DAL
{
    public class AwardDao : IAwardDao
    {
        private static readonly string dbPath = Environment.CurrentDirectory + @"\awards.db";
        private static readonly IDictionary<int, Award> awardDb = LoadDatabase();

        public Award Add(Award award)
        {
            var lastId = awardDb.Keys.Count > 0
                ? awardDb.Keys.Max()
                : 0;

            award.Id = lastId + 1;
            awardDb.Add(award.Id, award);
            SaveDatabase(awardDb);
            return award;
        }

        public IEnumerable<Award> GetAll()
        {
            return awardDb.Values;
        }

        public Award GetById(int id)
        {
            return awardDb[id];
        }

        public void Remove(int id)
        {
            if (awardDb.Remove(id))
            {
                SaveDatabase(awardDb);
            }
        }

        private static IDictionary<int, Award> LoadDatabase()
        {
            var db = new Dictionary<int, Award>();
            if (!File.Exists(dbPath))
            {
                return db;
            }
            string[] data = File.ReadAllLines(dbPath);
            foreach (var entry in data)
            {
                string[] entryInfo = entry.Split(',');
                var award = new Award()
                {
                    Id = int.Parse(entryInfo[0]),
                    Title = entryInfo[1],
                };
                db.Add(award.Id, award);
            }
            return db;
        }

        private static void SaveDatabase(IDictionary<int, Award> db)
        {
            var data = new StringBuilder();
            foreach (var award in db.Values)
            {
                data.Append(award.Id).Append(',').
                    Append(award.Title).Append(',').
                    Append(Environment.NewLine);
            }
            File.WriteAllText(dbPath, data.ToString());
        }
    }
}