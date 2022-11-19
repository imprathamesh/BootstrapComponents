using Ardalis.SmartEnum;
namespace BootstrapComponents.Enums;

public sealed class ShowUpto : SmartEnum<ShowUpto>
{
    public readonly static ShowUpto Show10 = new("10 Items", 10);
    public readonly static ShowUpto Show25 = new("25 Items", 25);
    public readonly static ShowUpto Show50 = new("50 Items", 50);
    public ShowUpto(string name, int value) : base(name, value)
    {
    }
}
