using Ardalis.SmartEnum;

namespace BootstrapComponents.Enums;

public sealed class Size : SmartEnum<Size>
{
    public static readonly Size ExtraSmall = new("xs", 1);
    public static readonly Size Small = new("sm", 2);
    public static readonly Size Medium = new("md", 3);
    public static readonly Size Large = new("lg", 4);
    public static readonly Size ExtraLarge = new("xl", 5);
    public static readonly Size ExtraExtraLarge = new("xxl", 6);
    public Size(string name, int value) : base(name, value)
    {
    }
}

