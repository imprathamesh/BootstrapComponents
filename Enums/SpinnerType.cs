using Ardalis.SmartEnum;
namespace BootstrapComponents.Enums;
public sealed class SpinnerType : SmartEnum<SpinnerType>
{
    public static readonly SpinnerType Border = new("border", 1);
    public static readonly SpinnerType Grow = new("grow", 2);


    public SpinnerType(string name, int value) : base(name, value)
    {
    }
}

