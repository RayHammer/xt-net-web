using System;
using System.Collections.Generic;
using Task06.DAL.Interfaces;
using Task06.BLL.Interfaces;
using Task06.Entities;

namespace Task06.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao userDao;

        public UserLogic(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public User Add(User user)
        {
            if (user.Name.Length == 0)
            {
                throw new ArgumentException();
            }
            return userDao.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return userDao.GetAll();
        }

        public void Remove(int id)
        {
            userDao.Remove(id);
        }
    }
}