namespace BootstrapComponents.Enums;

public sealed class ShadowSize : SmartList<ShadowSize>
{
    public static readonly ShadowSize Small = new("sm", 1);
    public static readonly ShadowSize Medium = new("md", 2);
    public static readonly ShadowSize Large = new("lg", 3);
    public static readonly ShadowSize None = new("none", 4);
    public ShadowSize(string name, int value) : base(name, value)
    {
    }
}

