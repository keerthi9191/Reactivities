using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivitiesController : ControllerBase
{
    private readonly DataContext _context;
    public ActivitiesController(DataContext context)//dependency injection  meabs injecting datacontext to the controller
    {
        _context = context;
    }
    
    [HttpGet()]// api/activities
    public IEnumerable<Activity> GetActivities()
    {
        IEnumerable<Activity> activities= _context.Activities.ToList<Activity>();
        return activities;
    }

    [HttpGet("{id}")]// api/activities/frdgjhjbj-fcgcgh
    public Activity GetSingleActivity(Guid id)
    {
        Activity activity= _context.Activities
                            .Where(a=>a.Id== id)
                            .FirstOrDefault<Activity>();
        return activity;
    }
}
