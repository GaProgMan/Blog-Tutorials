using System.Collections.Generic;
using webApiTutorial.Models;

namespace webApiTutorial.Services 
{
  public interface ICharacterService
  {
    // Search and Get
    Character FindById (int id);
    IEnumerable<Character> Search(string searchKey);
  }
}