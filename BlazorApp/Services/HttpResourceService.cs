using System.Collections;
using System.Text.Json;
using BlazorApp.Components.Pages;
using BlazorApp.ServiceInterfaces;
using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Services;

public class HttpResourceService : IResourceService
{
    private readonly HttpClient client;

    public HttpResourceService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<ICollection<Resource>> GetManyResourcesAsync(string? name = null, int? quantity = null)
    {
        string uri = "Resources/resources";
        if (!string.IsNullOrEmpty(name))
        {
            uri += $"?name={name}";
        }

        if (quantity.HasValue)
        {
            uri += string.IsNullOrEmpty(name) ? $"?quantity={quantity}" : $"&quantity={quantity}";
        }

        HttpResponseMessage response = await client.GetAsync(uri);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Resource> resources = JsonSerializer.Deserialize<ICollection<Resource>>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return resources;
    }
}