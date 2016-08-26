using Domain;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IRepository
    {
        void Save<TEntity>(TEntity entity) where TEntity : Entity;
        
        IList<T> GetAll<T>() where T : Entity;

        void Delete<TEntity>(TEntity entity) where TEntity : Entity;
    }
}
