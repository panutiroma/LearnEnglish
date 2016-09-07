namespace LearnEnglish.Models.Dto
{
    public class WordDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        //public string Phonic { get; set; }
        //public string PronunciationUrl { get; set; }
        //public string Translation { get; set; }
        //public int Level { get; set; }

        //public WordDto(long id, string word, string phonic, string pronunciationUrl, string translation, int level = 0)
        //{
        //    Id = id;
        //    Title = word;
        //    Phonic = phonic;
        //    PronunciationUrl = pronunciationUrl;
        //    Translation = translation;
        //    Level = level;
        //}

        public WordDto(long id, string word)
        {
            Id = id;
            Title = word;
        }

        public WordDto()
        {
        }
    }
}