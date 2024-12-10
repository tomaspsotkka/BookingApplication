using System.Collections;
using DTOs;

namespace BusinessLogic.Interfaces;

public interface IResourceLogic
{
    Task<ICollection> GetAllResourcesAsync(ResourceDto parameters);
}