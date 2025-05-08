using BlazorBootstrap;

namespace hybr.Shared.Services
{
    public class SensorData()
    {
        public static Dictionary<int, Order> Graduation(Dictionary<int, Order> _lastData)
        {
            foreach (var (_key, _value) in _lastData)
            {
                if (_lastData.TryGetValue(_key, out var _bool))
                {
                        var exp = new NCalc.Expression(ValueSettings.Sensors[_key].GraduationString);
                        exp.Parameters["x"] = _lastData[_key].Value_of_m;
                        _value.Value_of_m = (double)exp.Evaluate();
                }
            }
            return _lastData;
        }
        public static void PreparationSensorData(Dictionary<int, Order> _lastData)
        {
            foreach (var (_key, _value) in ValueSettings.Sensors)
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
                ValueSettings.Stations[ValueSettings.Sensors[_key].Station_Id].Alert = (IconColor)_value.Alert;
                ValueSettings.Stations[ValueSettings.Sensors[_key].Station_Id].Icon = _value.Icon;
            }
        }
    }

}
