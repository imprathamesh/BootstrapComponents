namespace BootstrapComponents.Enums;

public sealed class ColumnSize : SmartList<ColumnSize>
{
    public static readonly ColumnSize One = new("1", 1);
    public static readonly ColumnSize Two = new("2", 2);
    public static readonly ColumnSize Three = new("3", 3);
    public static readonly ColumnSize Four = new("4", 4);
    public static readonly ColumnSize Five = new("5", 5);
    public static readonly ColumnSize Six = new("6", 6);
    public static readonly ColumnSize Seven = new("7", 7);
    public static readonly ColumnSize Eight = new("8", 8);
    public static readonly ColumnSize Nine = new("9", 9);
    public static readonly ColumnSize Ten = new("10", 10);
    public static readonly ColumnSize Eleven = new("11", 11);
    public static readonly ColumnSize Twelve = new("12", 12);
    public ColumnSize(string name, int value) : base(name, value)
    {
    }
}
