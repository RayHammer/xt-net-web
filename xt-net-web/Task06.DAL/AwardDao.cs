﻿using System;
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
        private static IDictionary<int, Award> awardDb;
        private static string dbPath;

        public AwardDao()
            : this(Environment.CurrentDirectory + @"\awards.db")
        {
        }

        public AwardDao(string path)
        {
            dbPath = path;
            awardDb = LoadDatabase();
        }

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

        public void Update(int id, Award award)
        {
            award.Id = id;
            awardDb[id] = award;
            SaveDatabase(awardDb);
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
                    ImageSource = null
                };
                if (entryInfo.Length > 2)
                {
                    award.ImageSource = entryInfo[2];
                }
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
                    Append(award.Title).Append(',');
                data.Append(award.ImageSource);
                data.Append(Environment.NewLine);
            }
            File.WriteAllText(dbPath, data.ToString());
        }
    }
}