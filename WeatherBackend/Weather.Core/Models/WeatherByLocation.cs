using System;
using System.Collections.Generic;

namespace Weather.Core.Models;

public partial class WeatherByLocation
{
    public int Cod { get; set; }
    public int City_Id { get; set; }
    public double CalcTime { get; set; }
    public WeatherResult Result { get; set; }
}