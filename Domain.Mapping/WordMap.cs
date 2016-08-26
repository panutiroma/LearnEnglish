using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class WordMap : EntityMap<Word>
    {
        public WordMap()
        {
            Map(x => x.Title).Not.Nullable();
            Map(x => x.UkPhonic);
            Map(x => x.UkPronunciationUrl);
            Map(x => x.UsPhonic);
            Map(x => x.UsPronunciationUrl);
            Map(x => x.Translation);
            Map(x => x.Level);
        } 
    }
}
