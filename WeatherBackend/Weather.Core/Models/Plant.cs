using System;
using System.Collections.Generic;

namespace Weather.Core.Models;

public partial class Plant
{
    public long PlantId { get; set; }

    public string PlantName { get; set; } = null!;

    public string? PlantDescription { get; set; }

    public int WeatherTypeFk { get; set; }
}
