﻿using System;
using System.Collections.Generic;

namespace Weather.Core.Models;

public partial class Statistic
{
    public double min { get; set; }
    public double max { get; set; }
    public double median { get; set; }
    public double mean { get; set; }
    public double p25 { get; set; }
    public double p75 { get; set; }
    public double st_dev { get; set; }
    public double num { get; set; }
}
