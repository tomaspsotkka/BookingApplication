using BusinessLogic.Interfaces;
using DTOs;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace BusinessLogic.Logic;

public class ResourceLogic : IResourceLogic
{
    private readonly IResourceRepository resourceRepository;

    public ResourceLogic(IResourceRepository resourceRepository)
    {
        this.resourceRepository = resourceRepository;
    }
    
    public async Task<IEnumerable<ResourceDto>> GetAllResourcesAsync()
    {
        var resources = await resourceRepository.GetMany().ToListAsync();
        var resourceDtos = resources.Select(resource => new ResourceDto
        {
            Id = resource.Id,
            Name = resource.Name,
            Quantity = resource.Quantity
        });

        return await Task.FromResult(resourceDtos);
    }
}