// TicketService.cs
//
// © 2022.

using BingoApp.Business.Infrastructure;
using BingoApp.Business.Service.Abstraction;
using BingoApp.Domain;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BingoApp.Business.Service.Implementation;

public class TicketService : ITicketService
{
    private readonly IBingoAppDatabaseContext _bingoAppDatabaseContext;
    public TicketService(IBingoAppDatabaseContext bingoAppDatabaseContext)
    {
        _bingoAppDatabaseContext = bingoAppDatabaseContext;
    }
    public void CreateTicker(Ticket ticket)
    {
        ValidateTicketTitle(title: ticket.Title);

        _bingoAppDatabaseContext.Tickets.Add(ticket);
        _bingoAppDatabaseContext.SaveChanges();
    }
    public Ticket GetTicketDetails(string title)
    {
        var ticket = _bingoAppDatabaseContext
            .Tickets
            .AsNoTracking()
            .Where(p => p.Title == title)
            .FirstOrDefault();

        return ticket is null ? throw new Exception("Tikcet not found!") : ticket; 
    }
    public IEnumerable<Ticket> GetTickets()
    {
        var tickets = _bingoAppDatabaseContext
            .Tickets
            .ToList();

        return tickets;
    }

    private void ValidateTicketTitle(string title)
    {
        if (string.IsNullOrEmpty(title))
        {
            throw new ValidationException($"Title can't be empty");
        }

        if (title.Length > Ticket.MaxTitleLength)
        {
            throw new ValidationException($"Title can't be longer than {Ticket.MaxTitleLength}");
        }
    }
}
