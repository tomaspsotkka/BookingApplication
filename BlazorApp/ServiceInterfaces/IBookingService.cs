using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ServiceInterfaces;

public interface IBookingService
{
    Task<ActionResult<CreateBookingDto>> CreateBookingAsync(CreateBookingDto request);
}