namespace TelemetryUI.DTO;

public sealed class TelemetryDTO 
{
    public double Speed { get; set; }
    public double BatteryTemperature { get; set; }
    public double TankTemperature { get; set; }
    public  double BatteryVoltage { get; set; }
    public int  BatteryRate { get; set; }
    public string Time { get; set; }
   
}