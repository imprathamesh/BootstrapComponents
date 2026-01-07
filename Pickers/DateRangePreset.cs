using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BootstrapComponents.Enums;

namespace BootstrapComponents.Pickers;

public sealed class DateRangePreset : SmartList<DateRangePreset>
{
    public static readonly DateRangePreset Today =
        new(nameof(Today), 1, () =>
        {
            var d = DateTime.Today;
            return (d, d);
        });

    public static readonly DateRangePreset Last7Days =
        new("Last 7 Days", 2, () =>
        {
            var end = DateTime.Today;
            return (end.AddDays(-6), end);
        });

    public static readonly DateRangePreset Last30Days =
        new("Last 30 Days", 3, () =>
        {
            var end = DateTime.Today;
            return (end.AddDays(-29), end);
        });

    public static readonly DateRangePreset Last3Months =
        new("Last 3 Months", 4, () =>
        {
            var end = DateTime.Today;
            return (end.AddMonths(-3).AddDays(1), end);
        });

    public static readonly DateRangePreset Last6Months =
        new("Last 6 Months", 5, () =>
        {
            var end = DateTime.Today;
            return (end.AddMonths(-6).AddDays(1), end);
        });
    public static readonly DateRangePreset LastYear =
        new("Last Year", 5, () =>
        {
            var end = DateTime.Today;
            return (end.AddMonths(-12).AddDays(1), end);
        });

    private readonly Func<(DateTime start, DateTime end)> _range;

    private DateRangePreset(string name, int value,
        Func<(DateTime, DateTime)> range) : base(name, value)
        => _range = range;

    public (DateTime start, DateTime end) GetRange() => _range();
}
