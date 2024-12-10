using BusinessLogic.Interfaces;
using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingLogic bookingLogic;

    public BookingsController(IBookingLogic bookingLogic)
    {
        this.bookingLogic = bookingLogic;
    }

    [HttpPost]
    public async Task<ActionResult<CreateBookingDto>> CreateBooking([FromBody] CreateBookingDto request)
    {
        try
        {
            CreateBookingDto dto = await bookingLogic.CreateBookingAsync(request);
            return Created("/Bookings/", dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    } 
    

}