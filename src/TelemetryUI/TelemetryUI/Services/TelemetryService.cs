using System;
using System.IO.Ports;
using System.Text.Json;
using TelemetryUI.DTO;
using TelemetryUI.Entities;
using TelemetryUI.Entityframework.Context;


public class TelemetryService : IDisposable
{
    private SerialPort _serialPort;

    // Updated event: sends a TelemetryDTO object. Marked as nullable.
    public event Action<TelemetryDTO>? OnTelemetryReceived;

    // Cache the latest telemetry data
    public TelemetryDTO LatestTelemetry { get; private set; } = new TelemetryDTO();

    private readonly ILogger<TelemetryService> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public TelemetryService(ILogger<TelemetryService> logger, IServiceScopeFactory scopeFactory, string portName, int baundName = 9600)
    {
        _scopeFactory = scopeFactory;
        _serialPort = new SerialPort(portName, baundName)
        {
            ReadTimeout = 1000,
            NewLine = "\n"
        };
        _serialPort.DataReceived += SerialDataReceived;
        _logger = logger;
        _serialPort.Open();
    }

    private async void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            // Read one complete line from the serial port
            string data = _serialPort.ReadLine();
            _logger.LogInformation($"Raw data received: {data}");

            // Deserialize the JSON into a TelemetryDTO
            var telemetryData = Deserialize(data);
            LatestTelemetry = telemetryData;
            OnTelemetryReceived?.Invoke(telemetryData);

            // Save telemetry data to the database using a scoped DbContext:
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<TelemetryDbContext>();
                await dbContext.Telemetries.AddAsync(new Telemetry
                {
                    Id = Guid.NewGuid(),
                    Speed = telemetryData.Speed,
                    BatteryTemperature = telemetryData.BatteryTemperature,
                    TankTemperature = telemetryData.tankSicaklik, // using tankSicaklik as TankTemperature
                    BatteryRate = telemetryData.kalanEnerji,
                    BatteryVoltage = telemetryData.bataryaGerilim,
                    CreatedAt = telemetryData.Time.ToString()
                });
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in SerialDataReceived: {ex}");
        }
    }

    private TelemetryDTO Deserialize(string data)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            TelemetryDTO telemetry = JsonSerializer.Deserialize<TelemetryDTO>(data, options) ?? new TelemetryDTO();
            return telemetry;
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Deserialization error: {ex.Message}");
            return new TelemetryDTO();
        }
    }

    public void Dispose()
    {
        if (_serialPort != null && _serialPort.IsOpen)
        {
            _serialPort.Close();
        }
    }
}
