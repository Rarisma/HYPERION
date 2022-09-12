namespace LibHYPERION;

public class Sensor
{
    private bool IsConnected { get; set; }
    private DateTime LastSuccessfulRead { get; set; }
    private decimal LastReading { get; set; }
    private string SensorName { get; set; }
    private string Endpoint { get; set; }
    public string Unit;

    public Sensor(string sensorName, string endpoint, string unit)
    {
        SensorName = sensorName;
        Endpoint = endpoint;
        Unit = unit;
    }

    public void Read()
    {
        
    }
}