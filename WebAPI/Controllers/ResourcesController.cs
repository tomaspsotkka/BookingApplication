using System.Collections;
using BusinessLogic.Interfaces;
using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ResourcesController : ControllerBase
{
    private readonly IResourceLogic resourceLogic;

    public ResourcesController(IResourceLogic resourceLogic)
    {
        this.resourceLogic = resourceLogic;
    }

    [HttpGet("resources")]
    public async Task<ActionResult<ICollection>> GetManyResourcesAsync([FromQuery] string? name, [FromQuery] int? quantity)
    {
        try
        {
            ResourceDto parameters = new(name, quantity);
            ICollection resources = await resourceLogic.GetAllResourcesAsync(parameters);
            
            return Ok(resources);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

}