using System;
using System.Collections.Generic;

namespace Weather.Core.Models;

public partial class TempStatistic
{
    public double record_min { get; set; }
    public double record_max { get; set; }
    public double average_min { get; set; }
    public double average_max { get; set; }
    public double median { get; set; }
    public double mean { get; set; }
    public double p25 { get; set; }
    public double p75 { get; set; }
    public double st_dev { get; set; }
    public double num { get; set; }
}
