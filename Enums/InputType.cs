namespace BootstrapComponents.Enums;

public sealed class InputType(string name, int value) : SmartList<InputType>(name, value)
{
    public static readonly InputType Text = new("text", 1);
    public static readonly InputType Email = new("email", 2);
    public static readonly InputType Password = new("password", 3);
}