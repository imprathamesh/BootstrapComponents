using BootstrapComponents.Enums;

namespace BootstrapComponents.Calendar;

public sealed class Time : SmartList<Time>
{
    public static readonly Time AM1200 = new("12:00 AM", 1);
    public static readonly Time AM1230 = new("12:30 AM", 2);
    public static readonly Time AM0100 = new("01:00 AM", 3);
    public static readonly Time AM0130 = new("01:30 AM", 4);
    public static readonly Time AM0200 = new("02:00 AM", 5);
    public static readonly Time AM0230 = new("02:30 AM", 6);
    public static readonly Time AM0300 = new("03:00 AM", 7);
    public static readonly Time AM0330 = new("03:30 AM", 8);
    public static readonly Time AM0400 = new("04:00 AM", 9);
    public static readonly Time AM0430 = new("04:30 AM", 10);
    public static readonly Time AM0500 = new("05:00 AM", 11);
    public static readonly Time AM0530 = new("05:30 AM", 12);
    public static readonly Time AM0600 = new("06:00 AM", 13);
    public static readonly Time AM0630 = new("06:30 AM", 14);
    public static readonly Time AM0700 = new("07:00 AM", 15);
    public static readonly Time AM0730 = new("07:30 AM", 16);
    public static readonly Time AM0800 = new("08:00 AM", 17);
    public static readonly Time AM0830 = new("08:30 AM", 18);
    public static readonly Time AM0900 = new("09:00 AM", 19);
    public static readonly Time AM0930 = new("09:30 AM", 20);
    public static readonly Time AM1000 = new("10:00 AM", 21);
    public static readonly Time AM1030 = new("10:30 AM", 22);
    public static readonly Time AM1100 = new("11:00 AM", 23);
    public static readonly Time AM1130 = new("11:30 AM", 24);
    public static readonly Time PM1200 = new("12:00 PM", 25);
    public static readonly Time PM1230 = new("12:30 PM", 26);
    public static readonly Time PM0100 = new("01:00 PM", 27);
    public static readonly Time PM0130 = new("01:30 PM", 28);
    public static readonly Time PM0200 = new("02:00 PM", 29);
    public static readonly Time PM0230 = new("02:30 PM", 30);
    public static readonly Time PM0300 = new("03:00 PM", 31);
    public static readonly Time PM0330 = new("03:30 PM", 32);
    public static readonly Time PM0400 = new("04:00 PM", 33);
    public static readonly Time PM0430 = new("04:30 PM", 34);
    public static readonly Time PM0500 = new("05:00 PM", 35);
    public static readonly Time PM0530 = new("05:30 PM", 36);
    public static readonly Time PM0600 = new("06:00 PM", 37);
    public static readonly Time PM0630 = new("06:30 PM", 38);
    public static readonly Time PM0700 = new("07:00 PM", 39);
    public static readonly Time PM0730 = new("07:30 PM", 40);
    public static readonly Time PM0800 = new("08:00 PM", 41);
    public static readonly Time PM0830 = new("08:30 PM", 42);
    public static readonly Time PM0900 = new("09:00 PM", 43);
    public static readonly Time PM0930 = new("09:30 PM", 44);
    public static readonly Time PM1000 = new("10:00 PM", 45);
    public static readonly Time PM1030 = new("10:30 PM", 46);
    public static readonly Time PM1100 = new("11:00 PM", 47);
    public static readonly Time PM1130 = new("11:30 PM", 48);
    public Time(string name, int value) : base(name, value)
    {
    }
}
