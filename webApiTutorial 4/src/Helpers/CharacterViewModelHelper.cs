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
            var viewModel =  new CharacterViewModel
            {
                CharacterName = dbModel.CharacterName
            };

            foreach (var book in dbModel.BookCharacter)
            {
                viewModel.Books.Add(book.Book.BookName ?? string.Empty);
            }

            return viewModel;
        }

        public static List<CharacterViewModel> ConvertToViewModels(List<Character> dbModels)
        {
            return dbModels.Select(ch => ConvertToviewModel(ch)).ToList();
        }
    }
}