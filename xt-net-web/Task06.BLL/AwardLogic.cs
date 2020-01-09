using System;
using System.Collections.Generic;
using Task06.BLL.Interfaces;
using Task06.DAL.Interfaces;
using Task06.Entities;

namespace Task06.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDao awardDao;

        public AwardLogic(IAwardDao awardDao)
        {
            this.awardDao = awardDao;
        }

        public Award Add(Award award)
        {
            if (award.Title.Length == 0)
            {
                throw new ArgumentException();
            }
            return awardDao.Add(award);
        }

        public IEnumerable<Award> GetAll()
        {
            return awardDao.GetAll();
        }

        public Award GetById(int id)
        {
            return awardDao.GetById(id);
        }

        public void Remove(int id)
        {
            awardDao.Remove(id);
        }
    }
}