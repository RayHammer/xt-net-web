using System.Collections.Generic;
using Task06.Entities;

namespace Task06.DAL.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);

        IEnumerable<User> GetAll();

        User GetById(int id);

        void Remove(int id);

        void Update(int id, User user);
    }
}