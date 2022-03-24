// INumberService.cs
//
// © 2022.

using BingoApp.Domain;

namespace BingoApp.Business.Service.Abstraction;

public interface INumberService
{
    void CreateNumbers(string[] numbers, string ticketTitle);
    IEnumerable<Numbers> GetNumbers(string title);
}
