using Ardalis.SmartEnum;
namespace BootstrapComponents.Enums;

public sealed class Color : SmartEnum<Color>
{
    public static readonly Color Danger = new("danger", 1);
    public static readonly Color Dark = new("dark", 2);
    public static readonly Color Info = new("info", 3);
    public static readonly Color Light = new("light", 4);
    public static readonly Color Primary = new("primary", 5);
    public static readonly Color Secondary = new("secondary", 6);
    public static readonly Color Success = new("success", 7);
    public static readonly Color Warning = new("warning", 8);
    public static readonly Color White = new("white", 9);
    public static readonly Color Body = new("body", 10);
    public static readonly Color Transparent = new("transparent", 11);

    public Color(string name, int value) : base(name, value)
    {
    }
}

