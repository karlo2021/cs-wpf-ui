// NumberService.cs
//
// © 2022.

using BingoApp.Domain;
using BingoApp.Business.Infrastructure;
using BingoApp.Business.Service.Abstraction;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BingoApp.Business.Service.Implementation;

public class NumberService : INumberService
{
    private readonly IBingoAppDatabaseContext _bingoAppDatabaseContext;
    private readonly ITicketService _ticketService;
    public NumberService(IBingoAppDatabaseContext bingoAppDatabaseContext,
        ITicketService ticketService)
    {
        _bingoAppDatabaseContext = bingoAppDatabaseContext;
        _ticketService = ticketService;
    }
    public void CreateNumbers(string[] numbers, string ticketTitle)
    {
        ValidateNumbers(numbers);

        var ticket = _bingoAppDatabaseContext
            .Tickets
            .AsNoTracking()
            .Where(p => p.Title == ticketTitle)
            .FirstOrDefault();

        foreach (var number in numbers)
        {
            var Number = new Numbers(default(int), number, ticket!.Id);
            _bingoAppDatabaseContext.Numbers.Add(Number);
        }

        _bingoAppDatabaseContext.SaveChanges();
    }
    public IEnumerable<Numbers> GetNumbers(string title)
    {
        var ticket = _ticketService.GetTicketDetails(title);

        var numbers = _bingoAppDatabaseContext
            .Numbers
            .Where(p => p.TicketId == ticket.Id)
            .ToList();

        return numbers;
    }

    private void ValidateNumbers(string[] numbers)
    {
        if (numbers.Length != 3)
        {
            throw new ValidationException($"Ticket must contain 3 numbers!");
        }

        foreach (var number in numbers)
        {
            if (number.Length > 1)
            {
                throw new ValidationException($"Each ticket number must be under 10");
            }
        }
    }
}
