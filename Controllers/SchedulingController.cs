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