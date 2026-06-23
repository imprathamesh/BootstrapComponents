using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapComponents.Charts;

public class DoughnutSegment
{
    public string Label { get; set; } = string.Empty;

    public decimal Value { get; set; }

    public string Color { get; set; } = "#0d6efd";
}
