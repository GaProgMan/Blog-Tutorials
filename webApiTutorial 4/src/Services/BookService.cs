using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using webApiTutorial.DatabaseContexts;
using webApiTutorial.Models;

namespace webApiTutorial.Services 
{
  public class BookService : IBookService
  {
    private DwContext _dwContext;

    public BookService (DwContext dwContext)
    {
        _dwContext = dwContext;
    }

    public Book FindByOrdinal (int id)
    {
        return BaseQuery()
            .FirstOrDefault(book => book.BookOrdinal == id);
    }

    public IEnumerable<Book> Search(string searchKey)
    {
      var blankSearchString = string.IsNullOrWhiteSpace(searchKey);

      var results = BaseQuery();

      if (!blankSearchString)
      {
        searchKey = searchKey.ToLower();
        results = results
            .Where(book => book.BookName.ToLower().Contains(searchKey)
                || book.BookDescription.ToLower().Contains(searchKey)
                || book.BookIsbn10.ToLower().Contains(searchKey)
                || book.BookIsbn13.ToLower().Contains(searchKey));
      }
      
      return results.OrderBy(book => book.BookOrdinal);
    }

    private IEnumerable<Book> BaseQuery()
    {
      return _dwContext.Books
        .AsNoTracking()
        .Include(book => book.BookCharacter)
        .ThenInclude(BookCharacter => BookCharacter.Character);
    }
  }
}