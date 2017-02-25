using webApiTutorial.Helpers;
using webApiTutorial.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace webApiTutorial.Controllers
{
    [Route("/[controller]")]
    public class BooksController : BaseController
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // Get/5
        [HttpGet("Get/{id}")]
        public JsonResult GetByOrdinal(int id)
        {
            var book = _bookService.FindByOrdinal(id);
            if (book == null)
            {
                return ErrorResponse("Not found");
            }

            return SingleResult(BookViewModelHelpers.ConvertToViewModel(book));
        }

        [HttpGet("Search")]
        public JsonResult Search(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return ErrorResponse("Search string cannot be empty");
            }

            var books = _bookService.Search(searchString);

            if (!books.Any())
            {
                return ErrorResponse("Cannot find any books with the provided search string");
            }

            return MultipleResults(BookViewModelHelpers.ConvertToViewModels(books.ToList()));
        }
    }
}