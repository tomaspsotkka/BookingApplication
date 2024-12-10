using DTOs;

namespace BusinessLogic.Interfaces;

public interface IResourceLogic
{
    Task<IEnumerable<ResourceDto>> GetAllResourcesAsync();
}