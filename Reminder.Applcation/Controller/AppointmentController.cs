using Microsoft.AspNetCore.Mvc;
using Reminder.Domain.Interfaces;

namespace Reminder.Application.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly ICalendlyService _calendlyService;

        public AppointmentController(ICalendlyService calendlyService)
        {
            _calendlyService = calendlyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentsAsync()
        {
            var result = await _calendlyService.GetAppointmentsAsync();
            return Ok(result);
        }
    }
}
