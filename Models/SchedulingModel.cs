using System.ComponentModel.DataAnnotations;
using desafio_magalu.Enums;

namespace desafio_magalu.Models;

public class SchedulingModel
{
    [Key]
    public int IdScheduling { get; set; }
    public DateTime DateTimeOfSubmission { get; set; }
    public string Recipient { get; set; }
    public string Message { get; set; }
    public ChannelEnum Channel { get; set; }
    public StatsEnum Stats { get; set; }
}