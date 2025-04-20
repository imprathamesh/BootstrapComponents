namespace BootstrapComponents.Enums;
public sealed class ModalSize : SmartList<ModalSize>
{
    public static readonly ModalSize Small = new("sm", 1);
    public static readonly ModalSize Medium = new("md", 2);
    public static readonly ModalSize Large = new("lg", 3);
    public static readonly ModalSize ExtraLarge = new("xl", 4);
    public static readonly ModalSize FullScreen = new("fullscreen", 5);
    public ModalSize(string name, int value) : base(name, value)
    {

    }
}
