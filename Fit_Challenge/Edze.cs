using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fit_Challenge;

public partial class Edze
{
    public int EdzesId { get; set; }

    public string SportAg { get; set; } = null!;

    public string SportFajta { get; set; } = null!;

    public string? Leiras { get; set; }

    [DataType(DataType.Date)]
    public DateTime? Datum { get; set; }

    //[DisplayFormat(DataFormatString = "{0:D2}:{1:D2}")]
    public TimeSpan? KezdIdopont { get; set; }

    //[DisplayFormat(DataFormatString = "{0:D2}:{1:D2}")]
    public TimeSpan? VegIdopont { get; set; }

    public bool ElvegzettE { get; set; }

    public bool ToroltE { get; set; }

    public bool KotelezoE { get; set; }

    public int? EdzesPerc { get; set; }
}
