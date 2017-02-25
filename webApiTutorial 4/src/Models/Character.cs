using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace webApiTutorial.Models
{
  public class Character : IAuditable
  {
    public int CharacterId { get; set; }

    public string CharacterName { get; set; }
    public int CharacterOrdinal { get;set; }

    public virtual ICollection<BookCharacter> BookCharacter { get; set; } = new Collection<BookCharacter>();
  }
}