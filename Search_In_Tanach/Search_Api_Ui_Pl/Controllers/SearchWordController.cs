using Microsoft.AspNetCore.Mvc;
using Search_Entities_Dto;
using Search_Logic_Bll;

namespace Search_Api_Ui_Pl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchWordController : ControllerBase
    {
        [HttpGet("byWord/{word}")]
        //The controler gets a word and send to function that returns the it's locations in the Tanach
        public List<Search_Result> GetWordLocations(string word)
        {
            class_BLL class_BLL = new class_BLL();
            return class_BLL.SearchWordInTanach(word);
        }
    
        [HttpGet("byNumber/{number}")]
        //The controler gets a number and send to function that returns the verses that the number (by text) exist in
        public List<string> GetNumberVerses(int number)
        {
            class_BLL class_BLL = new class_BLL();
            return class_BLL.SearchNumberInTanach(number);
        }
    }
}
//alt+shift+f