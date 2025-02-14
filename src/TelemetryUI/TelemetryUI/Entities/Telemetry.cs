namespace TelemetryUI.Entities;

public class Telemetry 
{

    public Guid Id { get; set; }
    public double Speed { get; set; }
    public double BatteryTemperature { get; set; }
    public double TankTemperature { get; set; }
    public  double BatteryVoltage { get; set; }
    public int  BatteryRate { get; set; }
    public string CreatedAt { get; set; }

}