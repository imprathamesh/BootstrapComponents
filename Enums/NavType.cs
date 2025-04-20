namespace BootstrapComponents.Enums
{
    public sealed class NavType : SmartList<NavType>
    {
        public static readonly NavType Pill = new("pills", 1);
        public static readonly NavType Tab = new("tabs", 2);
        public static readonly NavType Underline = new("underline", 3);


        public NavType(string name, int value) : base(name, value)
        {
        }
    }
}
