namespace webApiTutorial.Models
{
  public class Book
  {
    public int BookId { get; set; }
    public int BookOrdinal { get; set; }
    public string BookName { get; set; }
    public string BookIsbn10 { get; set; }
    public string BookIsbn13 { get; set; }
    public string BookDescription { get; set; }
  }
}