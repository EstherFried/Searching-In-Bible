using Search_Entities_Dto;
using TanachText_dal;

namespace Search_Logic_Bll
{
    public class class_BLL
    { 
        //The fonction returns all the locations of the word for search
        //If the word is not exist- returns an empty object
        public List<Search_Result> SearchWordInTanach(string word)
        {
            
            FileText class_DAL = new FileText();

            List<Search_Result> search_Results = new List<Search_Result>();
            string tanachText = class_DAL.GetTanachText();

            string book = "";
            string parasha = "";
            string chapter = "";
            string vers = "";
            string[] lines = tanachText.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                string[] wordsInLine = lines[i].Split(" ");
                for (int j = 0; j < wordsInLine.Length; j++)
                {
                    if (wordsInLine[j].Contains("^"))
                    {
                        parasha = wordsInLine[j + 1].Trim() + " " + wordsInLine[j + 2].Trim();
                        j += 2;
                    }
                    else if (wordsInLine[j].Contains("~"))
                    {
                        book = wordsInLine[j + 1].Trim();
                        chapter = wordsInLine[j + 2].Trim();
                        j += 2;
                    }
                    else if (wordsInLine[j].Contains("!"))
                    {
                        vers = wordsInLine[j + 1].Trim();
                    }
                    if (wordsInLine[j] == word)
                    {
                        Search_Result result = new Search_Result(book, parasha, chapter, vers);
                        search_Results.Add(result);
                    }
                }
            }
            return search_Results;
            
        }

        //The fonction returns all the verses that the number exist in
        //If the number is not exist- returns an empty object
        public List<string> SearchNumberInTanach(int number)
        {
            FileText class_DAL = new FileText();
            string[][] strDictNum = class_DAL.ReadNumDictJSONFile();
            char[] letters = { 'מ', 'ש', 'ה', 'ו', 'כ', 'ל', 'ב' };
            List<string> listToSearch = new List<string>();
            List<string> resultList = new List<string>();

            foreach (string strNum in strDictNum[number])
            {
                listToSearch.Add(strNum);
                foreach(char c in letters)
                {
                    listToSearch.Add(c + strNum);
                }
            }

            string tanachText = class_DAL.GetTanachText();
            string[] lines = tanachText.Split('\n');

            foreach (string word in listToSearch)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] wordsInLine = lines[i].Split(" ");
                    for (int j = 0; j < wordsInLine.Length; j++)
                    {
                        if (wordsInLine[j] == word)
                        {
                            resultList.Add(lines[i].Trim());
                        }
                    }
                }
            }
            return resultList;
        }
    }
}
