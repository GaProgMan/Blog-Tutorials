using webApiTutorial.Services;
using Microsoft.AspNetCore.Mvc;

namespace webApiTutorial.Controllers
{
    [Route("/[controller]")]
    public class BooksController : Controller
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

            return Json(new {
                Success = false,
                Result = new {
                    id = book.BookId,
                    ordinal = book.BookOrdinal,
                    name = book.BookName,
                    isbn10 = book.BookIsbn10,
                    isbn13 = book.BookIsbn13,
                    description = book.BookDescription
                }
            });
        }

        protected JsonResult ErrorResponse(string message = "Not Found")
        {
            return Json (new {
                Success = false,
                Result = message
            });
        }
    }
}