namespace TelemetryUI.DTO;

public sealed class TelemetryDTO 
{
    public long Time { get; set; }  // Changed from string to long
    public double Speed { get; set; }
    public double BatteryTemperature { get; set; }
    public double tankSicaklik { get; set; }
    public double bataryaGerilim { get; set; }
    public int kalanEnerji { get; set; }
}