using System.Collections.Generic;
using Task06.Entities;

namespace Task06.BLL.Interfaces
{
    public interface IAwardLogic
    {
        Award Add(Award award);

        IEnumerable<Award> GetAll();

        Award GetById(int id);

        void Remove(int id);

        void Update(int id, Award award);
    }
}