using Domain;
using NHibernate;
using Repository.Interfaces;
using System.Collections.Generic;
using System;

namespace Repository
{
    public class WordRepository : Repository, IWordRepository
    {
        public void Delete(Word entity)
        {
            base.Delete(entity);
        }


        public IList<Word> GetAll()
        {
            return base.GetAll<Word>();
        }

        public void Save(Word entity)
        {
            base.Save(entity);
        }


        public Word Get(long id)
        {
            return _session.QueryOver<Word>().Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
