using System.Text.Json;
using BlazorApp.ServiceInterfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Services;

public class HttpBookingService : IBookingService
{

    private readonly HttpClient client;

    public HttpBookingService(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<ActionResult<CreateBookingDto>> CreateBookingAsync(CreateBookingDto request)
    {
        HttpResponseMessage httpResponse = await client.PostAsJsonAsync("bookings", request);
        string response = await httpResponse.Content.ReadAsStringAsync();
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }

        return JsonSerializer.Deserialize<CreateBookingDto>(response,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
}