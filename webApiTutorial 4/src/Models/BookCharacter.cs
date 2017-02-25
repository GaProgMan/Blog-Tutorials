namespace webApiTutorial.Models
{
    public class BookCharacter : IAuditable
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public int CharacterId {get; set; }
        public virtual Character Character { get; set; }
    }
}