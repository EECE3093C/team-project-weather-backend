using System;
using System.Collections.Generic;

namespace Weather.Core.Models;

public partial class WeatherResult
{
    public int Month { get; set; }
    public TempStatistic Temp { get; set; }
    public Statistic Pressure { get; set; }
    public Statistic Humidity { get; set; }
    public Statistic Wind { get; set; }
    public Statistic Precipitation { get; set; }
    public Statistic Clouds { get; set; }
    public double Sunshine_Hours { get; set; }
}

