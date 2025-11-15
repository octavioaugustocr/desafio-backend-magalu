using desafio_magalu.Dtos;
using desafio_magalu.Models;
using desafio_magalu.Repositories.Scheduling;

namespace desafio_magalu.Services.Scheduling;

public class SchedulingService : ISchedulingService
{
    private readonly ISchedulingRepository _schedulingRepository;

    public SchedulingService(ISchedulingRepository schedulingRepository)
    {
        _schedulingRepository = schedulingRepository;
    }

    public async Task<SchedulingModel> GetSchedulingById(int id)
    {
        return await _schedulingRepository.GetSchedulingById(id);
    }

    public async Task<List<SchedulingModel>> GetAllSchedulings()
    {
        return await _schedulingRepository.GetAllSchedulings();
    }

    public async Task<SchedulingModel> ScheduleMessage(CreateSchedulingDto createSchedulingDto)
    {
        return await _schedulingRepository.ScheduleMessage(createSchedulingDto);
    }

    public async Task<SchedulingModel> ChangeScheduling(int id, UpdateSchedulingDto updateSchedulingDto)
    {
        return await _schedulingRepository.ChangeScheduling(id, updateSchedulingDto);
    }

    public async Task<SchedulingModel> CancelScheduling(int id)
    {
        return await _schedulingRepository.CancelScheduling(id);
    }
}