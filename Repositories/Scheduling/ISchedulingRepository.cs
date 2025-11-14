using desafio_magalu.Dtos;
using desafio_magalu.Models;

namespace desafio_magalu.Repositories.Scheduling;

public interface ISchedulingRepository
{
    Task<List<SchedulingModel>> GetAllSchedulings();
    Task<SchedulingModel> ScheduleMessage(CreateSchedulingDto createSchedulingDto);
}