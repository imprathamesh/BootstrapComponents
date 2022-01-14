using Ardalis.SmartEnum;
namespace BootstrapComponents.Enums;

public sealed class ButtonSize : SmartEnum<ButtonSize>
{
    public static readonly ButtonSize Small = new("sm", 2);
    public static readonly ButtonSize Medium = new("md", 3);
    public static readonly ButtonSize Large = new("lg", 4);

    public ButtonSize(string name, int value) : base(name, value)
    {
    }
}

