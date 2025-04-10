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
                Station_Id = 1,
                Value_min = -50,
                Value_max = 50,
            }),
            [2] = (new Sensor
            {
                Id = 2,
                Station_Id = 1,
                Value_min = -50,
                Value_max = 50,
            }),
            [3] = (new Sensor
            {
                Id = 3,
                Station_Id = 1,
                Value_min = -50,
                Value_max = 50,
            }),
            [4] = (new Sensor
            {
                Id = 4,
                Station_Id = 1,
                Value_min = -50,
                Value_max = 50,
            }),
            [5] = (new Sensor
            {
                Id = 5,
                Station_Id = 1,
                Value_min = -50,
                Value_max = 50,
            }),
            [6] = (new Sensor
            {
                Id = 6,
                Station_Id = 1,
                Value_min = -50,
                Value_max = 50,
            }),
            [7] = (new Sensor
            {
                Id = 7,
                Station_Id = 1,
                Value_min = -50,
                Value_max = 50,
            }),
            [8] = (new Sensor
            {
                Id = 8,
                Station_Id = 1,
                Value_min = -50,
                Value_max = 50,
            }),
            [9] = (new Sensor
            {
                Id = 9,
                Station_Id = 1,
                Value_min = -50,
                Value_max = 50,
            }),
            [10] = (new Sensor
            {
                Id = 10,
                Station_Id = 1,
                Value_min = -50,
                Value_max = 50,
            }),
            [11] = (new Sensor
            {
                Id = 11,
                Station_Id = 1,
                Value_min = -50,
                Value_max = 50,
            }),
            [12] = (new Sensor
            {
                Id = 12,
                Station_Id = 1,
                Value_min = -50,
                Value_max = 50,
            }),

            [21] = (new Sensor
            {
                Id = 21,
                Station_Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),
            [22] = (new Sensor
            {
                Id = 22,
                Station_Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),
            [23] = (new Sensor
            {
                Id = 23,
                Station_Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),
            [24] = (new Sensor
            {
                Id = 24,
                Station_Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),
            [25] = (new Sensor
            {
                Id = 25,
                Station_Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),
            [26] = (new Sensor
            {
                Id = 26,
                Station_Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),
            [27] = (new Sensor
            {
                Id = 27,
                Station_Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),
            [28] = (new Sensor
            {
                Id = 28,
                Station_Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),
            [29] = (new Sensor
            {
                Id = 29,
                Station_Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),
            [30] = (new Sensor
            {
                Id = 30,
                Station_Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),
            [31] = (new Sensor
            {
                Id = 31,
                Station_Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),
            [32] = (new Sensor
            {
                Id = 32,
                Station_Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),
            [33] = (new Sensor
            {
                Id = 33,
                Station_Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),

            [41] = (new Sensor
            {
                Id = 41,
                Station_Id = 3,
                Value_min = -50,
                Value_max = 50,
            }),
            [42] = (new Sensor
            {
                Id = 42,
                Station_Id = 3,
                Value_min = -50,
                Value_max = 50,
            }),
            [43] = (new Sensor
            {
                Id = 43,
                Station_Id = 3,
                Value_min = -50,
                Value_max = 50,
            }),
            [44] = (new Sensor
            {
                Id = 44,
                Station_Id = 3,
                Value_min = -50,
                Value_max = 50,
            }),
            [45] = (new Sensor
            {
                Id = 45,
                Station_Id = 3,
                Value_min = -50,
                Value_max = 50,
            }),
            [46] = (new Sensor
            {
                Id = 46,
                Station_Id = 3,
                Value_min = -50,
                Value_max = 50,
            }),
            [47] = (new Sensor
            {
                Id = 47,
                Station_Id = 3,
                Value_min = -50,
                Value_max = 50,
            }),

            [103] = (new Sensor
            {
                Id = 103,
                Station_Id = 7,
                Value_min = -50,
                Value_max = 50,
            }),
            [104] = (new Sensor
            {
                Id = 104,
                Station_Id = 7,
                Value_min = 0,
                Value_max = 100,
            }),
            [105] = (new Sensor
            {
                Id = 105,
                Station_Id = 7,
                Value_min = 700,
                Value_max = 900,
            }),
            [106] = (new Sensor
            {
                Id = 106,
                Station_Id = 7,
                Value_min = 0,
                Value_max = 360,
            }),
            [107] = (new Sensor
            {
                Id = 107,
                Station_Id = 7,
                Value_min = 0,
                Value_max = 15,
            }),
            [108] = (new Sensor
            {
                Id = 108,
                Station_Id = 7,
                GraduationString = "2424.24*x",
                Value_min = 0,
                Value_max = 600,
            }),
        };
        public static Dictionary<int, Station> AllStations { get; } = new Dictionary<int, Station> { 
            [1] = new(),
            [2] = new(),
            [3] = new(),
            [4] = new(),
            [5] = new(),
            [6] = new(),
            [7] = new(),
        };
        public static Dictionary<int, Order> Graduation(Dictionary<int, Order> _lastData)
        {
            foreach (var (_key, _value) in _lastData)
            {
                if (_lastData.TryGetValue(_key, out var _bool))
                {
                        var exp = new NCalc.Expression(AllSensors[_key].GraduationString);
                        exp.Parameters["x"] = _lastData[_key].Value_of_m;
                        _value.Value_of_m = (double)exp.Evaluate();
                }
            }
            return _lastData;
        }
        public static void PreparationSensorData(Dictionary<int, Order> _lastData)
        {
            foreach (var (_key, _value) in AllSensors)
            {
                if (_lastData.TryGetValue(_key, out var _valueOrder))
                {
                    if (_value.Value_min < _valueOrder.Value_of_m && _valueOrder.Value_of_m < _value.Value_max)
                    {
                        _value.Alert = AlertColor.Success;
                        _value.Icon = IconName.CheckCircleFill;
                    }
                    else if (_value.Value_min <= _valueOrder.Value_of_m || _valueOrder.Value_of_m >= _value.Value_max)
                    {
                        _value.Alert = AlertColor.Warning;
                        _value.Icon = IconName.ExclamationCircleFill;
                    }
                    _value.Value_of_m = _valueOrder.Value_of_m;
                    _value.Disconnected = false;
                }
                else
                {
                    _value.Alert = AlertColor.Danger;
                    _value.Icon = IconName.XCircleFill;
                    _value.Value_of_m = 0;
                    _value.Disconnected = true;
                }
                    AllStations[AllSensors[_key].Station_Id].Alert = (IconColor)_value.Alert;
                    AllStations[AllSensors[_key].Station_Id].Icon = _value.Icon;
            }
        }
    }

}
