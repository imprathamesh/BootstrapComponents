using Ardalis.SmartEnum;
namespace BootstrapComponents.Enums;
public sealed class TextAlign : SmartEnum<TextAlign>
{
    public static readonly TextAlign Start = new("start", 1);
    public static readonly TextAlign Center = new("center", 2);
    public static readonly TextAlign End = new("end", 3);


    public TextAlign(string name, int value) : base(name, value)
    {
    }
}

