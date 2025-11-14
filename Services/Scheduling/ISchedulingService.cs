using desafio_magalu.Dtos;
using desafio_magalu.Models;

namespace desafio_magalu.Services.Scheduling;

public interface ISchedulingService
{
    Task<SchedulingModel> ScheduleMessage(CreateSchedulingDto createSchedulingDto);
}