using desafio_magalu.Models;
using Microsoft.EntityFrameworkCore;

namespace desafio_magalu.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<SchedulingModel> Schedulings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SchedulingModel>(entity => entity.HasKey(s => s.IdScheduling));
    }
}