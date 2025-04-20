namespace BootstrapComponents.Enums;

public abstract class SmartList<TEnum> where TEnum : SmartList<TEnum>
{
    public string Name { get; }
    public int Value { get; }

    protected SmartList(string name, int value)
    {
        Name = name;
        Value = value;
    }

    private static IReadOnlyList<TEnum> _allItems;

    public static IReadOnlyList<TEnum> List()
    {
        if (_allItems != null)
            return _allItems;

        _allItems = typeof(TEnum)
            .GetFields(System.Reflection.BindingFlags.Public |
                       System.Reflection.BindingFlags.Static |
                       System.Reflection.BindingFlags.DeclaredOnly)
            .Where(f => f.FieldType == typeof(TEnum))
            .Select(f => (TEnum)f.GetValue(null)!)
            .ToList();

        return _allItems;
    }

    public static TEnum FromName(string name, bool ignoreCase = false)
    {
        var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        return List().FirstOrDefault(x => x.Name.Equals(name, comparison));
    }

    public static TEnum FromValue(int value)
    {
        return List().FirstOrDefault(x => x.Value == value);
    }

    public override string ToString() => Name;
}
