namespace BootstrapComponents.Enums;

public sealed class PlaceHolderSize : SmartList<PlaceHolderSize>
{
    public static readonly PlaceHolderSize ExtraSmall = new("xl", 1);
    public static readonly PlaceHolderSize Small = new("sm", 2);
    public static readonly PlaceHolderSize Medium = new("md", 3);
    public static readonly PlaceHolderSize Large = new("lg", 4);

    public PlaceHolderSize(string name, int value) : base(name, value)
    {
    }
}

