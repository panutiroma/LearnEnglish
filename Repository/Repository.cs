using System;
using Domain;
using NHibernate;
using Repository.Interfaces;
using System.Collections.Generic;

namespace Repository
{
    public abstract class Repository : IRepository
    {
        protected readonly ISession _session = SessionGenerator.Instance.GetSession();

        public virtual void Save<TEntity>(TEntity entity) where TEntity : Entity
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);

                transaction.Commit();
            }
        }

        public virtual IList<T> GetAll<T>() where T : Entity
        {
            try
            {
                return _session.QueryOver<T>().List<T>();
            }
            catch (Exception)
            {
               return new List<T>();
            }
        }

        public virtual void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Delete(entity);

                transaction.Commit();
            }
        }
    }
}
