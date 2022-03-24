// ITicketService.cs
//
// © 2022.

using BingoApp.Domain;

namespace BingoApp.Business.Service.Abstraction;

public interface ITicketService
{
    void CreateTicker(Ticket ticket);
    Ticket GetTicketDetails(string title);
    IEnumerable<Ticket> GetTickets();
}
