using Ardalis.SmartEnum;
namespace BootstrapComponents.Enums;

public sealed class ShadowSize : SmartEnum<ShadowSize>
{
    public static readonly ShadowSize Small = new ShadowSize("sm", 1);
    public static readonly ShadowSize Medium = new ShadowSize("", 2);
    public static readonly ShadowSize Large = new ShadowSize("lg", 3);
    public static readonly ShadowSize None = new ShadowSize("none", 4);
    public ShadowSize(string name, int value) : base(name, value)
    {
    }
}

