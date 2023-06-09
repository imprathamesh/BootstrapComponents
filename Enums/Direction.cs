using Ardalis.SmartEnum;

namespace BootstrapComponents.Enums
{
    public sealed class Direction : SmartEnum<Direction>
    {
        public static readonly Direction Start = new("start", 1);
        public static readonly Direction End = new("end", 2);
        public static readonly Direction Top = new("top", 3);
        public static readonly Direction Bottom = new("bottom", 4);

        public Direction(string name, int value) : base(name, value)
        {
        }
    }
}
