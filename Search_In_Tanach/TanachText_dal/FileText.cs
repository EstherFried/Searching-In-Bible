using System.Text.Json;
using System.IO;
namespace TanachText_dal
{
    public class FileText
    {
        //The function returns the Tanach text as string from local text file
        public string GetTanachText()
        {
            try
            {
                string filePath = """C:\Users\user\Documents\שנה ב\C#\Search_In_Tanach_Project\Search_In_Tanach\TanachText_dal\bin\Debug\net7.0\tora.txt""";
                string fileAsText = File.ReadAllText(filePath);
                return fileAsText;
            }
            catch (Exception ex) 
            {
                throw new Exception("Exception: File Not Found");
            }
        }

        //The function returns the number's dictionary as string matrix from local JSON file
        public string[][] ReadNumDictJSONFile()
        {
            try
            {
                string path = """C:\Users\user\Documents\שנה ב\C#\Search_In_Tanach_Project\Search_In_Tanach\TanachText_dal\bin\Debug\net7.0\tanach.json""";
                string numDictJSON = File.ReadAllText(path);

                //parse the JSON object to string
                //For each number there is an array of string contains the number as text in several shapes
                string[][] strDictNum = JsonSerializer.Deserialize<string[][]>(numDictJSON);

                return strDictNum;
            }
            catch
            {
                throw new Exception("Exception: File Not Found");
            }
        }
    }
}

