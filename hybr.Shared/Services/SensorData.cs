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

            [21] = (new Sensor
            {
                Id = 21,
                Value_min = -50,
                Value_max = 50,
            }),
            [22] = (new Sensor
            {
                Id = 22,
                Value_min = -50,
                Value_max = 50,
            }),
            [23] = (new Sensor
            {
                Id = 23,
                Value_min = -50,
                Value_max = 50,
            }),
            [24] = (new Sensor
            {
                Id = 24,
                Value_min = -50,
                Value_max = 50,
            }),
            [25] = (new Sensor
            {
                Id = 25,
                Value_min = -50,
                Value_max = 50,
            }),
            [26] = (new Sensor
            {
                Id = 26,
                Value_min = -50,
                Value_max = 50,
            }),
            [27] = (new Sensor
            {
                Id = 27,
                Value_min = -50,
                Value_max = 50,
            }),
            [28] = (new Sensor
            {
                Id = 28,
                Value_min = -50,
                Value_max = 50,
            }),
            [29] = (new Sensor
            {
                Id = 29,
                Value_min = -50,
                Value_max = 50,
            }),
            [30] = (new Sensor
            {
                Id = 30,
                Value_min = -50,
                Value_max = 50,
            }),
            [31] = (new Sensor
            {
                Id = 31,
                Value_min = -50,
                Value_max = 50,
            }),
            [32] = (new Sensor
            {
                Id = 32,
                Value_min = -50,
                Value_max = 50,
            }),
            [33] = (new Sensor
            {
                Id = 33,
                Value_min = -50,
                Value_max = 50,
            }),

            [41] = (new Sensor
            {
                Id = 41,
                Value_min = -50,
                Value_max = 50,
            }),
            [42] = (new Sensor
            {
                Id = 42,
                Value_min = -50,
                Value_max = 50,
            }),
            [43] = (new Sensor
            {
                Id = 43,
                Value_min = -50,
                Value_max = 50,
            }),
            [44] = (new Sensor
            {
                Id = 44,
                Value_min = -50,
                Value_max = 50,
            }),
            [45] = (new Sensor
            {
                Id = 45,
                Value_min = -50,
                Value_max = 50,
            }),
            [46] = (new Sensor
            {
                Id = 46,
                Value_min = -50,
                Value_max = 50,
            }),
            [47] = (new Sensor
            {
                Id = 47,
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
