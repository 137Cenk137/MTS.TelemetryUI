using System;
using System.IO;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.Extensions.Logging;

public class FileService
{
    private readonly ILogger<FileService> _logger;
    private readonly string _filePath;

    public FileService(ILogger<FileService> logger)
    {
        _logger = logger;
        // Create a unique file name based on the current UTC date/time.
        _filePath = Path.Combine(AppContext.BaseDirectory, $"{DateTime.UtcNow:yyyy-MM-dd_HH-mm-ss}-TelemetryData.csv");
        if(!File.Exists(_filePath)){
                CreateOrOverwriteCsvFile();
            }
    }

    public void CreateOrOverwriteCsvFile()
    {
        try
        {
            using (var writer = new StreamWriter(_filePath, false))
            {
                // Write CSV header row. Adjust headers as needed.
                writer.WriteLine("Time,Speed,BatteryTemperature,TankTemperature,BatteryVoltage,BatteryRate");
            }
            _logger.LogInformation($"CSV file created/overwritten at {_filePath}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating CSV file: {ex}");
        }
    }
    public void SaveRow(string csvRow)
    {
        try
        {
            
            using (var writer = new StreamWriter(_filePath,append: true))
            {
                writer.WriteLine(csvRow);
                
            }
            _logger.LogInformation("Row appended to CSV file.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error appending row to CSV file: {ex}");
        }
    }
}
