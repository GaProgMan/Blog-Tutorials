using webApiTutorial.Models;
using webApiTutorial.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace webApiTutorial.Helpers
{
    public static class BookViewModelHelpers
    {
        public static BookViewModel ConvertToViewModel (Book dbModel)
        {
            var viewModel = new BookViewModel
            {
                BookOrdinal = dbModel.BookOrdinal,
                BookName = dbModel.BookName,
                BookIsbn10 = dbModel.BookIsbn10,
                BookIsbn13 = dbModel.BookIsbn13,
                BookDescription = dbModel.BookDescription,
            };

            foreach(var bc in dbModel.BookCharacter)
            {
                viewModel.Characters.Add(bc.Character.CharacterName ?? string.Empty);
            }

            return viewModel;
        }

        public static List<BookViewModel> ConvertToViewModels(List<Book> dbModel)
        {
            return dbModel.Select(book => ConvertToViewModel(book)).ToList();
        }
    }
}