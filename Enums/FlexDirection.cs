namespace BootstrapComponents.Enums;

public sealed class FlexDirection(string name, int value) : SmartList<FlexDirection>(name, value)
{
    public static readonly FlexDirection Row = new("row", 1);
    public static readonly FlexDirection Column = new("column", 2);
    public static readonly FlexDirection RowReverse = new("row-reverse", 3);
    public static readonly FlexDirection ColumnReverse = new("column-reverse", 4);
}
public sealed class JustifyContent(string name, int value) : SmartList<JustifyContent>(name, value)
{
    public static readonly JustifyContent Start = new("start", 1);
    public static readonly JustifyContent End = new("end", 2);
    public static readonly JustifyContent Center = new("center", 3);
    public static readonly JustifyContent Around = new("around", 4);
    public static readonly JustifyContent Between = new("between", 5);
}
public sealed class AlignContent(string name, int value) : SmartList<AlignContent>(name, value)
{
    public static readonly AlignContent Start = new("start", 1);
    public static readonly AlignContent End = new("end", 2);
    public static readonly AlignContent Center = new("center", 3);
    public static readonly AlignContent Around = new("around", 4);
    public static readonly AlignContent Between = new("between", 5);
}
public sealed class AlignItem(string name, int value) : SmartList<AlignItem>(name, value)
{
    public static readonly AlignItem Start = new("start", 1);
    public static readonly AlignItem End = new("end", 2);
    public static readonly AlignItem Center = new("center", 3);
    public static readonly AlignItem Baseline = new("baseline", 4);
    public static readonly AlignItem Stretch = new("stretch", 5);
}
public sealed class FlexWrap(string name, int value) : SmartList<FlexWrap>(name, value)
{
    public static readonly FlexWrap Wrap = new("wrap", 1);
    public static readonly FlexWrap NoWrap = new("nowrap", 2);
    public static readonly FlexWrap WrapReverse = new("wrap-reverse", 3);
}
public sealed class FlexShrink(string name, int value) : SmartList<FlexShrink>(name, value)
{
    public static readonly FlexShrink Zero = new("0", 0);
    public static readonly FlexShrink One = new("1", 1);
}
public sealed class FlexGrow(string name, int value) : SmartList<FlexGrow>(name, value)
{
    public static readonly FlexGrow Zero = new("0", 0);
    public static readonly FlexGrow One = new("1", 1);
}