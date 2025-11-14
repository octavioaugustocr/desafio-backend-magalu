using desafio_magalu.Dtos;
using desafio_magalu.Services.Scheduling;
using Microsoft.AspNetCore.Mvc;

namespace desafio_magalu.Controllers;

[ApiController]
[Route("magalu/v1/")]
public class SchedulingController : ControllerBase
{
    private readonly ISchedulingService _schedulingService;

    public SchedulingController(ISchedulingService schedulingService)
    {
        _schedulingService = schedulingService;
    }
    
    [HttpGet("scheduling/{id}")]
    public async Task<IActionResult> GetSchedulingById(int id)
    {
        return Ok(await _schedulingService.GetSchedulingById(id));
    }

    [HttpGet]
    [Route("schedulings")]
    public async Task<IActionResult> GetAllSchedulings()
    {
        return Ok(await _schedulingService.GetAllSchedulings());
    }

    [HttpPost]
    [Route("scheduling")]
    public async Task<IActionResult> ScheduleMessage(CreateSchedulingDto createSchedulingDto)
    {
        return Ok(await _schedulingService.ScheduleMessage(createSchedulingDto));
    }
}