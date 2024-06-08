using Search_Entities_Dto;
using Search_Logic_Bll;

class_BLL class_BLL = new class_BLL();
Search_Result search_Result = new Search_Result();

Console.WriteLine("Choose search type: 'W' for word search or 'N' for number search");
string userChoice = Console.ReadLine();

if (userChoice.ToUpper() == "W")
{
    Console.WriteLine("Enter a word to search:");
    string wordToSearch = Console.ReadLine();
    List<Search_Result> results = class_BLL.SearchWordInTanach(wordToSearch);
    foreach (Search_Result result in results)
    {
        Console.WriteLine(result.ToString());
    }
}
else if (userChoice.ToUpper() == "N")
{
    Console.WriteLine("Enter a number to search:");
    int numberToSearch;
    if (int.TryParse(Console.ReadLine(), out numberToSearch))
    {
        List<string> words = class_BLL.SearchNumberInTanach(numberToSearch);
        foreach(string word in words)
        {
            Console.WriteLine(word);
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}
else
{
    Console.WriteLine("Invalid choice. Please choose 'W' or 'N'.");
}
