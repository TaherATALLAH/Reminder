using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reminder.Infrastructure.Entity;

namespace Reminder.Application.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatController : ControllerBase
    {
        private readonly ReminderDbContext _dbContext;

        public CandidatController(ReminderDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandidats()
        {
            var candidats = await _dbContext.Candidats.ToListAsync();
            return Ok(candidats);
        }
    }
}
