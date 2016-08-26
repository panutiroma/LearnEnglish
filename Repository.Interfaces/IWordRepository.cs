using Domain;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IWordRepository
    {
        IList<Word> GetAll();

        Word Get(long id);

        void Save(Word entity);

        void Delete(Word entity);
    }
}
