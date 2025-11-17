using System.ComponentModel.DataAnnotations;
using desafio_magalu.Enums;

namespace desafio_magalu.Dtos;

public class UpdateSchedulingDto
{
    [Required(ErrorMessage = "Informe a data e hora de envio")]
    public DateTime DateTimeOfSubmission { get; set; }
    
    [Required(ErrorMessage = "Informe o destinatário")]
    public string Recipient { get; set; }
    
    [Required(ErrorMessage = "Informe a mensagem a ser entregue")]
    public string Message { get; set; }
    
    [Required(ErrorMessage = "Informe o canal que a mensagem vai ser enviada")]
    public ChannelEnum Channel { get; set; }

    private StatsEnum Stats { get; set; }

    public void setStatus(StatsEnum stats)
    {
        this.Stats = stats;
    }

    public StatsEnum getStatus()
    {
        return this.Stats;
    }
}