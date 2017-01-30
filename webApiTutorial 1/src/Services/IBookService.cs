using System.Collections.Generic;
using webApiTutorial.Models;

namespace webApiTutorial.Services 
{
  public interface IBookService
  {
    // Search and Get
    Book FindByOrdinal (int id);
    IEnumerable<Book> Search(string searchKey);
  }
}