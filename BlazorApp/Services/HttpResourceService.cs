using System.Text.Json;
using BlazorApp.Components.Pages;
using BlazorApp.ServiceInterfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Services;

public class HttpResourceService : IResourceService
{
    private readonly HttpClient client;

    public HttpResourceService(HttpClient client)
    {
        this.client = client;
    }

    /*public async Task<IEnumerable<ResourceDto>> GetManyResourcesAsync()
    {
        var resources = await client.GetFromJsonAsync<IEnumerable<ResourceDto>>("Resources/all");
        return new <IEnumerable<ResourceDto>>(resources!);
    }*/

    public async Task<IEnumerable<ResourceDto>> GetManyResourcesAsync(string? nameContains = null, int? quantity = null)
    {
        string uri = "/resources";
        if (!string.IsNullOrEmpty(nameContains))
        {
            uri += $"?name={nameContains}";
        }

        if (quantity.HasValue)
        {
            uri += string.IsNullOrEmpty(nameContains) ? $"?quantity={quantity}" : $"&quantity={quantity}";
        }

        HttpResponseMessage response = await client.GetAsync(uri);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        IEnumerable<ResourceDto> resources = JsonSerializer.Deserialize<IEnumerable<ResourceDto>>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return resources;
    }
}