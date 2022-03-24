// NotFoundException.cs
//
// © 2022.

namespace BingoApp.Business.Exceptions;
public class NotFoundException : Exception
{
    public NotFoundException(string? message)
        : base(message)
    {
    }
}
