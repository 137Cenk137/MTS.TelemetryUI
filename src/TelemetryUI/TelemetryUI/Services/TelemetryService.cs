using System;
using System.IO.Ports;
using System.Threading.Tasks;

public class TelemetryService : IDisposable
{
    private SerialPort _serialPort;
    public event Action<string> OnDataReceived;

    public TelemetryService(string portName, int baudRate = 9600)
    {
        _serialPort = new SerialPort(portName, baudRate);
        _serialPort.DataReceived += SerialDataReceived;
        _serialPort.Open();
    }

    private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        try {
            string data = _serialPort.ReadLine();
            // Notify subscribers (UI components) of new data
            OnDataReceived?.Invoke(data);
        } catch (Exception ex) {
            // Handle exceptions (e.g., log the error)
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
