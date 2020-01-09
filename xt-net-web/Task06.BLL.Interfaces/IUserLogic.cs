﻿using System.Collections.Generic;
using Task06.Entities;

namespace Task06.BLL.Interfaces
{
    public interface IUserLogic
    {
        User Add(User user);

        User GetById(int id);

        IEnumerable<User> GetAll();

        void Remove(int id);
    }
}