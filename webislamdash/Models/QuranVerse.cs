using System.Collections.Generic;

namespace webislamdash.Models
{
    public class Ayah
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public Surah Surah { get; set; }
    }

    public class QuranPage
    {
        public int Number { get; set; }
        public List<Ayah> Ayahs { get; set; }
    }

    public class QuranApiResponse
    {
        public QuranPage Data { get; set; }
    }

    public class Surah
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string EnglishNameTranslation { get; set; }
        public string RevelationType { get; set; }
    }
}

