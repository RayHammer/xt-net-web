using System.Collections.Generic;

namespace Task06.DAL.Interfaces
{
    public interface IUserAwardTableDao
    {
        void Add(int userId, int awardId);

        void Clear(int userId);

        IEnumerable<int> GetAwardIdsFor(int userId);

        void Remove(int userId, int awardId);
    }
}