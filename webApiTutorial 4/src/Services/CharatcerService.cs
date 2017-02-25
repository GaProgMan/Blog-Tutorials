using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using webApiTutorial.DatabaseContexts;
using webApiTutorial.Models;

namespace webApiTutorial.Services 
{
  public class CharacterService : ICharacterService
  {
    private DwContext _dwContext;

    public CharacterService (DwContext dwContext)
    {
        _dwContext = dwContext;
    }

    public Character FindById (int id)
    {
        return BaseQuery()
            .FirstOrDefault(character => character.CharacterId == id);
    }

    public IEnumerable<Character> Search(string searchKey)
    {
      var blankSearchString = string.IsNullOrWhiteSpace(searchKey);

      var results = BaseQuery();

      if (!blankSearchString)
      {
        searchKey = searchKey.ToLower();
        results = results
            .Where(charatcer => charatcer.CharacterName.ToLower().Contains(searchKey));
      }
      
      return results.OrderBy(charatcer => charatcer.CharacterOrdinal);
    }

    private IEnumerable<Character> BaseQuery()
    {
      return _dwContext.Characters
        .AsNoTracking()
        .Include(character => character.BookCharacter)
        .ThenInclude(bookCharacter => bookCharacter.Book);
    }
  }
}