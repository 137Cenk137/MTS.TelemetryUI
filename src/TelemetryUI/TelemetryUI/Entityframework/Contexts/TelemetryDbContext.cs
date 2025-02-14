using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using Microsoft.EntityFrameworkCore;
using TelemetryUI.Entities;

namespace TelemetryUI.Entityframework.Context;

public  class TelemetryDbContext : DbContext
{
    public DbSet<Telemetry> Telemetries { get; set; }

    public TelemetryDbContext(DbContextOptions<TelemetryDbContext> options) : base(options)
    {
        
    }

    public TelemetryDbContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(optionsBuilder.IsConfigured){
            optionsBuilder.UseSqlite("Data Source=./TelemetryDbContext.db");
        }
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TelemetryDbContext).Assembly);
    }
}