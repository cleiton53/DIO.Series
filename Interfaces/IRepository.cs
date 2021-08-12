using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
         List<T> List();
         T FindById(int id);
         void Insert(T entidade);
         void Delete(int id);
         void Update(int id, T entidade);
         int NextId();
    }
}