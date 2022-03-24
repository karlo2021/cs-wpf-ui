// Numbers.cs
//
// © 2022.

namespace BingoApp.Domain;

public class Numbers
{
    public int Id { get; private set; }
    public string Value { get; set; }
    public Ticket Ticket { get; set; }
    public int? TicketId { get; set; }
    public Numbers(int id, string value, int? ticketId)
    {
        Id = id;
        Value = value;
        TicketId = ticketId;
    }
}
