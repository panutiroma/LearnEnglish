using System;

namespace Domain
{
    public class Word : Entity
    {
        #region public members

        //public virtual long Id { get; protected set; }
        public virtual string Title { get; set; }
        public virtual string UkPhonic { get; set; }
        public virtual string UkPronunciationUrl { get; set; }
        public virtual string UsPhonic { get; set; }
        public virtual string UsPronunciationUrl { get; set; }
        public virtual string Translation { get; set; }
        public virtual int Level { get; set; }

        public Word(string word, string ukPhonic, string ukPronunciationUrl, string usPhonic, string usPronunciationUrl, string translation, int level = 0)
        {
            Title = word;
            UkPhonic = ukPhonic;
            UkPronunciationUrl = ukPronunciationUrl;
            UsPhonic = usPhonic;
            UsPronunciationUrl = usPronunciationUrl;
            Translation = translation;
            Level = level;
        }
        public Word()
        {
        }

        public virtual Word EditWord(Word word)
        {
            UkPhonic = word.UkPhonic;
            UkPronunciationUrl = word.UkPronunciationUrl;
            UsPhonic = word.UsPhonic;
            UsPronunciationUrl = word.UsPronunciationUrl;
            Translation = word.Translation;

            return this;
        }

        #endregion
    }
}
