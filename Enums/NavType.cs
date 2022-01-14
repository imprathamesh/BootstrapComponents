
using Ardalis.SmartEnum;

namespace BootstrapComponents.Enums
{
    public sealed class NavType : SmartEnum<NavType>
    {
        public static readonly NavType Pill = new("pills", 1);
        public static readonly NavType Tab = new("tabs", 2);


        public NavType(string name, int value) : base(name, value)
        {
        }
    }
}
