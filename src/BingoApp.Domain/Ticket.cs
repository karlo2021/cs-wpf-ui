namespace BingoApp.Domain;
public class Ticket
{
    public int Id { get; private set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public Ticket(int id, string title, DateTime date)
    {
        Id = id;
        Title = title;
        Date = date;
    }
    public const int MaxTitleLength = 10;
}
