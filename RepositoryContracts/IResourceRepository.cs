using Entities;

namespace RepositoryContracts;

public interface IResourceRepository
{
    IQueryable<Resource> GetMany();
}