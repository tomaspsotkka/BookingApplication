using System.Collections;
using DTOs;
using Entities;

namespace RepositoryContracts;

public interface IResourceRepository
{
    Task<ICollection> GetManyAsync(ResourceDto parameters);
    Task<Resource> GetResourceByIdAsync(int id);
}