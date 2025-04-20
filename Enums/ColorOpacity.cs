namespace BootstrapComponents.Enums;
public sealed class ColorOpacity : SmartList<ColorOpacity>
{
    public static readonly ColorOpacity Ten = new("10", 1);
    public static readonly ColorOpacity TwentyFive = new("25", 2);
    public static readonly ColorOpacity Fifty = new("50", 3);
    public static readonly ColorOpacity SeventyFive = new("75", 4);

    public ColorOpacity(string name, int value) : base(name, value)
    {
    }
}

