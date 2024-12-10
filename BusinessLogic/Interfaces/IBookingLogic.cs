using System.Runtime.InteropServices.JavaScript;
using DTOs;

namespace BusinessLogic.Interfaces;

public interface IBookingLogic
{
    Task<CreateBookingDto> CreateBookingAsync(CreateBookingDto request);
}