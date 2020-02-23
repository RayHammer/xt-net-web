using System;
using System.Collections.Generic;
using Task06.BLL.Interfaces;
using Task06.DAL.Interfaces;
using Task06.Entities;

namespace Task06.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserAwardTableDao userAwardTableDao;
        private readonly IUserDao userDao;

        public UserLogic(IUserDao userDao, IUserAwardTableDao userAwardTableDao)
        {
            this.userDao = userDao;
            this.userAwardTableDao = userAwardTableDao;
        }

        public User Add(User user)
        {
            if (user.Name.Length == 0)
            {
                throw new ArgumentException();
            }
            return userDao.Add(user);
        }

        public void AddAward(int userId, Award award)
        {
            if (GetById(userId) == null && award == null)
            {
                throw new InvalidOperationException();
            }
            userAwardTableDao.Add(userId, award.Id);
        }

        public IEnumerable<User> GetAll()
        {
            return userDao.GetAll();
        }

        public IEnumerable<int> GetAwardIdsFor(int id)
        {
            return userAwardTableDao.GetAwardIdsFor(id);
        }

        public IEnumerable<Award> GetAwardsFor(int id, IAwardLogic awards)
        {
            var awardList = new List<Award>();
            var awardIds = GetAwardIdsFor(id);
            if (awardIds == null)
            {
                return awardList;
            }
            foreach (var i in awardIds)
            {
                awardList.Add(awards.GetById(i));
            }
            return awardList;
        }

        public User GetById(int id)
        {
            return userDao.GetById(id);
        }

        public void Remove(int id)
        {
            userDao.Remove(id);
            userAwardTableDao.Clear(id);
        }

        public void Update(int id, User user)
        {
            if (userDao.GetById(id) == null || user.Name.Length == 0)
            {
                throw new InvalidOperationException();
            }
            userDao.Update(id, user);
        }

        public void RemoveAward(int userId, Award award)
        {
            if (userDao.GetById(userId) == null && award == null)
            {
                throw new InvalidOperationException();
            }
            userAwardTableDao.Remove(userId, award.Id);
        }
    }
}