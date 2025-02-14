

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelemetryUI.Entities;

namespace TelemetryUI.Entityframework.Configurations;

public class TelemtryConfiguratios : IEntityTypeConfiguration<Telemetry>
{
    public void Configure(EntityTypeBuilder<Telemetry> builder)
    {
        builder.HasKey(x => x.Id);
    }
}