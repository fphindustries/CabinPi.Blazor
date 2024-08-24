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

        public async Task<Measurement> GetMostRecentMeasurement()
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
                AbsorbTime = reader.GetInt32("AbsorbTime"),
                AmpHours = reader.GetInt32("AmpHours"),
                EqualizeTime = reader.GetInt32("EqualizeTime"),
                FloatTime = reader.GetInt32("FloatTime"),
                HighestVinputLog = reader.GetFloat("HighestVinputLog"),
                IbattDisplay = reader.GetFloat("IbattDisplay"),
                NiteMinutesNoPwr = reader.GetInt32("NiteMinutesNoPwr"),
                PvInputCurrent = reader.GetFloat("PvInputCurrent"),
                VocLastMeasured = reader.GetFloat("VocLastMeasured"),
                BatteryState = reader.GetInt32("BatteryState"),
                ChargeState = reader.GetInt32("ChargeState"),
                ClassicState = reader.GetInt32("ClassicState"),
                DispavgVbatt = reader.GetFloat("DispavgVbatt"),
                DispavgVpv = reader.GetFloat("DispavgVpv"),
                kWHours = reader.GetFloat("kWHours"),
                Watts = reader.GetInt32("Watts"),
                Case_C = reader.GetFloat("Case_C"),
                Case_F = reader.GetFloat("Case_F"),
                Ext_C = reader.GetFloat("Ext_C"),
                Ext_F = reader.GetFloat("Ext_F"),
                hPa = reader.GetFloat("hPa"),
                Humidity = reader.GetFloat("Humidity"),
                inHg = reader.GetFloat("inHg"),
                Int_C = reader.GetFloat("Int_C"),
                Int_F = reader.GetFloat("Int_F"),
                InverterOn = reader.IsDBNull("InverterOn") ? false : reader.GetBoolean("InverterOn"),
                InverterMode = reader.IsDBNull("InverterMode") ? null : reader.GetInt32("InverterMode"),
                InverterFault = reader.IsDBNull("InverterFault") ? null : reader.GetInt32("InverterFault"),
                InverterVACOut = reader.IsDBNull("InverterVACOut") ? null : reader.GetFloat("InverterVACOut"),
                InverterAACOut = reader.IsDBNull("InverterAACOut") ? null : reader.GetFloat("InverterAACOut"),
            };
        }
    }
}
