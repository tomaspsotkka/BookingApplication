using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ServiceInterfaces;

public interface IResourceService
{
    Task<IEnumerable<ResourceDto>> GetManyResourcesAsync(string? nameContains = null, int? quantity = null);
}