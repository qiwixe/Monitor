using BlazorBootstrap;

namespace hybr.Shared.Services
{
    public class SensorData()
    {
        public static Dictionary<int, Sensor> AllSensors { get; } =
        new Dictionary<int, Sensor>
        {
            [1] = (new Sensor
            {
                Id = 1,
                Value_min = -50,
                Value_max = 50,
            }),
            [2] = (new Sensor
            {
                Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),
            [3] = (new Sensor
            {
                Id = 3,
                Value_min = -50,
                Value_max = 50,
            }),
            [4] = (new Sensor
            {
                Id = 4,
                Value_min = -50,
                Value_max = 50,
            }),
            [5] = (new Sensor
            {
                Id = 5,
                Value_min = -50,
                Value_max = 50,
            }),
            [6] = (new Sensor
            {
                Id = 6,
                Value_min = -50,
                Value_max = 50,
            }),
            [7] = (new Sensor
            {
                Id = 7,
                Value_min = -50,
                Value_max = 50,
            }),
            [8] = (new Sensor
            {
                Id = 8,
                Value_min = -50,
                Value_max = 50,
            }),
            [9] = (new Sensor
            {
                Id = 9,
                Value_min = -50,
                Value_max = 50,
            }),
            [10] = (new Sensor
            {
                Id = 10,
                Value_min = -50,
                Value_max = 50,
            }),
            [11] = (new Sensor
            {
                Id = 11,
                Value_min = -50,
                Value_max = 50,
            }),
            [12] = (new Sensor
            {
                Id = 12,
                Value_min = -50,
                Value_max = 50,
            }),

            [103] = (new Sensor
            {
                Id = 103,
                Value_min = -50,
                Value_max = 50,
            }),
            [104] = (new Sensor
            {
                Id = 104,
                Value_min = 0,
                Value_max = 100,
            }),
            [105] = (new Sensor
            {
                Id = 105,
                Value_min = 700,
                Value_max = 900,
            }),
            [106] = (new Sensor
            {
                Id = 106,
                Value_min = 0,
                Value_max = 360,
            }),
            [107] = (new Sensor
            {
                Id = 107,
                Value_min = 0,
                Value_max = 15,
            }),
            [108] = (new Sensor
            {
                Id = 108,
                Value_min = 0,
                Value_max = 600,
            })
        };
        public static void PreparationSensorData(Dictionary<int, Order> _lastData)
        {
            foreach (var (_key, _value) in SensorData.AllSensors)
            {
                if (_lastData.TryGetValue(_key, out var _bool))
                {
                    if (_value.Value_min < _lastData[_key].Value_of_m && _lastData[_key].Value_of_m < _value.Value_max)
                    {
                        _value.Alert = AlertColor.Success;
                        _value.Icon = IconName.CheckCircleFill;
                    }
                    else if (_value.Value_min == _lastData[_key].Value_of_m || _lastData[_key].Value_of_m == _value.Value_max)
                    {
                        _value.Alert = AlertColor.Warning;
                        _value.Icon = IconName.ExclamationCircleFill;
                    }
                    else
                    {
                        _value.Alert = AlertColor.Danger;
                        _value.Icon = IconName.XCircleFill;
                    }
                    _value.Value_of_m = _lastData[_key].Value_of_m;
                    _value.Disconnected = false;
                }
                else
                {
                    _value.Alert = AlertColor.Danger;
                    _value.Icon = IconName.XCircleFill;
                    _value.Value_of_m = 0;
                    _value.Disconnected = true;
                }
            }
        }
    }

}
