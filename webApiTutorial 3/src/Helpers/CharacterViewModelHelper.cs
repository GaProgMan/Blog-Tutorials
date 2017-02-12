using webApiTutorial.Models;
using webApiTutorial.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace webApiTutorial.Helpers
{
    public static class CharacterViewModelHelpers
    {
        public static CharacterViewModel ConvertToviewModel (Character dbModel)
        {
            return new CharacterViewModel
            {
                CharacterName = dbModel.CharacterName
            };;
        }

        public static List<CharacterViewModel> ConvertToViewModels(List<Character> dbModels)
        {
            return dbModels.Select(ch => ConvertToviewModel(ch)).ToList();
        }
    }
}