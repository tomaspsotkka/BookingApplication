using System.Collections;
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
    
    public Task<ICollection> GetAllResourcesAsync(ResourceDto parameters)
    {
        return resourceRepository.GetManyAsync(parameters);
    }
}