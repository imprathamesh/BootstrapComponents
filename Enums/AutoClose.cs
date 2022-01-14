using Ardalis.SmartEnum;
namespace BootstrapComponents.Enums;

public sealed class AutoClose : SmartEnum<AutoClose>
{
    public static readonly AutoClose True = new("true", 1);
    public static readonly AutoClose False = new("false", 2);
    public static readonly AutoClose Outside = new("outside", 3);
    public static readonly AutoClose Inside = new("inside", 4);

    public AutoClose(string name, int value) : base(name, value)
    {
    }
}

