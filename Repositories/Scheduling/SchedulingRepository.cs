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

    public async Task<SchedulingModel> ChangeScheduling(int id, UpdateSchedulingDto updateSchedulingDto)
    {
        var schedulingModel = await _appDbContext.Schedulings.FindAsync(id);
        if (schedulingModel == null) return null;
        
        schedulingModel.DateTimeOfSubmission = updateSchedulingDto.DateTimeOfSubmission;
        schedulingModel.Recipient = updateSchedulingDto.Recipient;
        schedulingModel.Message = updateSchedulingDto.Message;
        schedulingModel.Channel = updateSchedulingDto.Channel;
        schedulingModel.Stats = updateSchedulingDto.getStatus();

        _appDbContext.Schedulings.Update(schedulingModel);
        await _appDbContext.SaveChangesAsync();

        return schedulingModel;
    }

    public async Task<SchedulingModel> CancelScheduling(int id)
    {
        var schedulingModel = await _appDbContext.Schedulings.FindAsync(id);
        if (schedulingModel == null) return null;

        schedulingModel.Stats = StatsEnum.Canceled;
        
        _appDbContext.Schedulings.Update(schedulingModel);
        await _appDbContext.SaveChangesAsync();

        return schedulingModel;
    }

    public async Task<string> DeleteScheduling(int id)
    {
        var schedulingModel = await _appDbContext.Schedulings.FindAsync(id);
        if (schedulingModel is null) return $"Não foi encontrado agendamento de mensagem com o ID {id}!";

        _appDbContext.Schedulings.Remove(schedulingModel);
        await _appDbContext.SaveChangesAsync();

        return $"Agendamento de mensagem com ID {id} excluido com sucesso!";
    }
}