using desafio_magalu.Data;
using desafio_magalu.Dtos;
using desafio_magalu.Enums;
using desafio_magalu.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace desafio_magalu.Repositories.Scheduling;

public class SchedulingRepository : ISchedulingRepository
{
    private readonly AppDbContext _appDbContext;

    public SchedulingRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    private bool ValidationsScheduleMessage(CreateSchedulingDto createSchedulingDto)
    {
        if (createSchedulingDto.DateTimeOfSubmission < DateTime.Now) return false;
        
        return true;
    }

    public async Task<SchedulingModel> GetSchedulingById(int id)
    {
        return await _appDbContext.Schedulings.FindAsync(id);
    }

    public async Task<List<SchedulingModel>> GetAllSchedulings()
    {
        return await _appDbContext.Schedulings.ToListAsync();
    }

    public async Task<SchedulingModel> ScheduleMessage(CreateSchedulingDto createSchedulingDto)
    {
        if (!ValidationsScheduleMessage(createSchedulingDto)) return null;
        
        var schedulingModel = new SchedulingModel()
        {
            DateTimeOfSubmission = createSchedulingDto.DateTimeOfSubmission,
            Recipient = createSchedulingDto.Recipient,
            Message = createSchedulingDto.Message,
            Channel = createSchedulingDto.Channel,
            Stats = StatsEnum.Scheduled
        };

        await _appDbContext.Schedulings.AddAsync(schedulingModel);
        await _appDbContext.SaveChangesAsync();
        
        return schedulingModel;
    }
}