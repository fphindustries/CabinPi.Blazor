using CabinPi.Blazor.Models;
using MySqlConnector;
using System.Data;

namespace CabinPi.Blazor.Services
{
    public class DataService
    {
        private readonly MySqlDataSource _dataSource;

        public DataService(MySqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<Measurement?> GetMostRecentMeasurement()
        {
            await using var connection = await _dataSource.OpenConnectionAsync();
            await using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM measurements ORDER BY Date DESC LIMIT 1";
            await using var reader = await command.ExecuteReaderAsync();
            if (!await reader.ReadAsync())
            {
                return null;
            }

            return new Measurement
            {
                Date = reader.GetDateTime("Date"),
                AbsorbTime = reader.Get<int?>("AbsorbTime"),
                AmpHours = reader.Get<int?>("AmpHours"),
                EqualizeTime = reader.Get<int?>("EqualizeTime"),
                FloatTime = reader.Get<int?>("FloatTime"),
                HighestVinputLog = reader.Get<float?>("HighestVinputLog"),
                IbattDisplay = reader.Get<float?>("IbattDisplay"),
                NiteMinutesNoPwr = reader.Get<int?>("NiteMinutesNoPwr"),
                PvInputCurrent = reader.Get<float?>("PvInputCurrent"),
                VocLastMeasured = reader.Get<float?>("VocLastMeasured"),
                BatteryState = reader.Get<int?>("BatteryState"),
                ChargeState = reader.Get<int?>("ChargeState"),
                ClassicState = reader.Get<int?>("ClassicState"),
                DispavgVbatt = reader.Get<float?>("DispavgVbatt"),
                DispavgVpv = reader.Get<float?>("DispavgVpv"),
                kWHours = reader.Get<float?>("kWHours"),
                Watts = reader.Get<int?>("Watts"),
                Case_C = reader.Get<float?>("Case_C"),
                Case_F = reader.Get<float?>("Case_F"),
                Ext_C = reader.Get<float?>("Ext_C"),
                Ext_F = reader.Get<float?>("Ext_F"),
                hPa = reader.Get<float?>("hPa"),
                Humidity = reader.Get<float?>("Humidity"),
                inHg = reader.Get<float?>("inHg"),
                Int_C = reader.Get<float?>("Int_C"),
                Int_F = reader.Get<float?>("Int_F"),
                InverterOn = reader.IsDBNull("InverterOn") ? false : reader.GetBoolean("InverterOn"),
                InverterMode =  reader.Get<int?>("InverterMode"),
                InverterFault =  reader.Get<int?>("InverterFault"),
                InverterVACOut = reader.Get<float?>("InverterVACOut"),
                InverterAACOut = reader.Get<float?>("InverterAACOut"),
            };
        }
    }
}
