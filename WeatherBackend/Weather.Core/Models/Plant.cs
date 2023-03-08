using System;
using System.Collections.Generic;

namespace Weather.Core.Models;

public partial class Plant
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int WeatherTypeFk { get; set; }
}
