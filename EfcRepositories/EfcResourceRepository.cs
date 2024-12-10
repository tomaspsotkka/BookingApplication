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
    
    public IQueryable<Resource> GetMany()
    {
        return ctx.Resources.AsQueryable();
    }

    public async Task<Resource> GetResourceByIdAsync(int id)
    {
        Resource? resource = await ctx.Resources.FindAsync(id);
        return resource;
    }
}