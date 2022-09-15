namespace LibHYPERION;

public class Sensor
{
    /// <summary>
    /// DateTime of the last Successful sensor reading
    /// </summary>
    private DateTime LastSuccessfulRead { get; set; }

    /// <summary>
    /// DateTime of the last attempted reading.
    /// </summary>
    private DateTime LastAttemptedReading { get; set; }

    /// <summary>
    /// Value of the last sensor reading 
    /// </summary>
    private string SensorValue { get; set; }

    /// <summary>
    /// Name of the sensor
    /// </summary>
    private string SensorName { get; set; }
    private string FormattedReading { get; set; }


    /// <summary>
    /// API Endpoint of sensor to be read
    /// ie Temp to get Temperature
    /// </summary>
    private string Endpoint;

    /// <summary>
    /// Unit of the reading, i.e ℃ for celsius.
    /// </summary>
    private string Unit;

    public Sensor(string sensorName, string endpoint, string unit)
    {
        SensorName = sensorName;
        Endpoint = endpoint;
        Unit = unit;
    }

    public async void Read()
    {
        try
        {
            SensorValue = await new HttpClient().GetStringAsync(Info.ServerURL + Endpoint);
            LastSuccessfulRead = DateTime.Now;
            LastAttemptedReading = LastSuccessfulRead;
            FormattedReading = $"{SensorName}: {SensorValue} {Unit}";
        }
        catch
        {
            SensorValue = "Error";
            FormattedReading = "Error";
        }
    }
}