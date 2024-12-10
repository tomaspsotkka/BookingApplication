using System.Collections;
using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ServiceInterfaces;

public interface IResourceService
{
    Task<ICollection<Resource>> GetManyResourcesAsync(string? name = null, int? quantity = null);
}