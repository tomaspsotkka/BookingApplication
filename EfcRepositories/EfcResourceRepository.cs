using System.Collections;
using DTOs;
using Entities;
using RepositoryContracts;

namespace EfcRepositories;

public class EfcResourceRepository : IResourceRepository
{

    private readonly AppContext ctx;

    public EfcResourceRepository(AppContext ctx)
    {
        this.ctx = ctx;
    }
    
    public Task<ICollection> GetManyAsync(ResourceDto parameters)
    {
        IQueryable<Resource> query = ctx.Resources.AsQueryable();
        if (!string.IsNullOrEmpty(parameters.Name))
        {
            query = query.Where(q => q.Name.ToLower().Contains(parameters.Name.ToLower()));
        }

        if (parameters.Quantity != null)
        {
            query = query.Where(q => q.Quantity == parameters.Quantity);
        }

        List<Resource> resources = query.ToList();
        return Task.FromResult<ICollection>(resources);
    }

    public async Task<Resource> GetResourceByIdAsync(int id)
    {
        Resource? resource = await ctx.Resources.FindAsync(id);
        return resource;
    }
}