using System.Collections.Generic;
using Task06.Entities;

namespace Task06.BLL.Interfaces
{
    public interface IUserLogic
    {
        User Add(User user);

        void AddAward(int userId, Award award);

        IEnumerable<User> GetAll();

        IEnumerable<Award> GetAwardsFor(int id, IAwardLogic awards);

        User GetById(int id);

        void Remove(int id);

        void RemoveAward(int userId, Award award);

        void Update(int id, User user);
    }
}