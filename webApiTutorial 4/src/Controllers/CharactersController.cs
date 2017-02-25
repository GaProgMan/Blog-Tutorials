using webApiTutorial.Helpers;
using webApiTutorial.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace webApiTutorial.Controllers
{
    [Route("/[controller]")]
    public class CharactersController : BaseController
    {
        private ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // Get/5
        [HttpGet("Get/{id}")]
        public JsonResult Get(int id)
        {
            var character = _characterService.FindById(id);
            if (character == null)
            {
                return ErrorResponse("Not found");
            }

            return SingleResult(CharacterViewModelHelpers.ConvertToviewModel(character));
        }

        [HttpGet("Search")]
        public JsonResult Search(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return ErrorResponse("Search string cannot be empty");
            }

            var characters = _characterService.Search(searchString);
            if(!characters.Any())
            {
                return ErrorResponse("Cannot find any characters with the provided search string");
            }

            return MultipleResults(CharacterViewModelHelpers.ConvertToViewModels(characters.ToList()));
        }
    }
}