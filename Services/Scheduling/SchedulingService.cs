using desafio_magalu.Dtos;
using desafio_magalu.Enums;
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
    
    private bool ValidationsScheduleMessage(CreateSchedulingDto createSchedulingDto)
    {
        return createSchedulingDto.DateTimeOfSubmission >= DateTime.Now;
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
        if (!ValidationsScheduleMessage(createSchedulingDto)) return null;
        
        return await _schedulingRepository.ScheduleMessage(createSchedulingDto);
    }

    public async Task<SchedulingModel> ChangeScheduling(int id, UpdateSchedulingDto updateSchedulingDto)
    {
        var existingScheduling = await _schedulingRepository.GetSchedulingById(id);
        if (existingScheduling == null) return null;
        
        if (updateSchedulingDto.DateTimeOfSubmission > existingScheduling.DateTimeOfSubmission)
            updateSchedulingDto.setStatus(StatsEnum.Postponed);
        else
            updateSchedulingDto.setStatus(StatsEnum.Edited);
        
        return await _schedulingRepository.ChangeScheduling(id, updateSchedulingDto);
    }

    public async Task<SchedulingModel> CancelScheduling(int id)
    {
        return await _schedulingRepository.CancelScheduling(id);
    }

    public async Task<string> DeleteScheduling(int id)
    {
        return await _schedulingRepository.DeleteScheduling(id);
    }
}