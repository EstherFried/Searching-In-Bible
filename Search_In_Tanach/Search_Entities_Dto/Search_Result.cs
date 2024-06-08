
namespace Search_Entities_Dto
{
    public class Search_Result
    {
        public string Book { get; set; }
        public string Parasha { get; set; }
        public string Chapter { get; set; }
        public string Verse { get; set; }

        public Search_Result(string book, string parasha, string chapter, string verse)
        {
            Book = book;
            Parasha = parasha;
            Chapter = chapter;
            Verse = verse;
        }
        public Search_Result() { }
        public override string ToString()
        {
            return "Book: " + Book + " Parasha: " + Parasha + " Chapter: " + Chapter + " Verse: " + Verse;
        }
    }
}
