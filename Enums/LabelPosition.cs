using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapComponents.Enums;

public sealed class LabelPosition(string name, int value) : SmartList<LabelPosition>(name, value)
{
    public static readonly LabelPosition Floating = new("floating-label", 1);
    public static readonly LabelPosition Top = new("top", 2);
    public static readonly LabelPosition Left = new("left", 3);
    public static readonly LabelPosition None = new("none", 4);
}