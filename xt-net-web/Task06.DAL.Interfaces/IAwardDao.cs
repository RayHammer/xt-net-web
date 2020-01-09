using System.Collections.Generic;
using Task06.Entities;

namespace Task06.DAL.Interfaces
{
    public interface IAwardDao
    {
        Award Add(Award award);

        IEnumerable<Award> GetAll();

        Award GetById(int id);

        void Remove(int id);
    }
}