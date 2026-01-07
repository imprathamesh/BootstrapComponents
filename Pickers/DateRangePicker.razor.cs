using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace BootstrapComponents.Pickers;

public partial class DateRangePicker
{
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    [Parameter] public DateTime? StartDate { get; set; }
    [Parameter] public DateTime? EndDate { get; set; }
    [Parameter] public EventCallback<DateTime?> StartDateChanged { get; set; }
    [Parameter] public EventCallback<DateTime?> EndDateChanged { get; set; }

    [Parameter] public DateTime? MinDate { get; set; } = DateTime.Today.AddYears(-50);
    [Parameter] public DateTime? MaxDate { get; set; } = DateTime.Today.AddYears(5);

    [Parameter] public bool TwoMonthView { get; set; } = true;
    [Parameter] public int StartYear { get; set; } = DateTime.Today.Year - 30;
    [Parameter] public int EndYear { get; set; } = DateTime.Today.Year;

    private bool IsOpen;
    private DateTime LeftMonth = DateTime.Today;
    private DateTime RightMonth => LeftMonth.AddMonths(1);
    private int CurrentYear;
    private int CurrentMonth;
    private DateTime? HoverDate;
    private static readonly string[] WeekDays =
    CultureInfo.CurrentCulture.DateTimeFormat
        .ShortestDayNames; // Sun → Sat

    protected override void OnInitialized()
    {
        CurrentYear = LeftMonth.Year;
        CurrentMonth = LeftMonth.Month;
    }

    private void Toggle() => IsOpen = !IsOpen;

    //private void PrevMonth()
    //{
    //    LeftMonth = LeftMonth.AddMonths(-1);
    //    CurrentYear = LeftMonth.Year;
    //}

    //private void NextMonth()
    //{
    //    LeftMonth = LeftMonth.AddMonths(1);
    //    CurrentYear = LeftMonth.Year; 
    //}
    private void PrevMonth()
    {
        LeftMonth = LeftMonth.AddMonths(-1);
        SyncSelectors();
    }

    private void NextMonth()
    {
        LeftMonth = LeftMonth.AddMonths(1);
        SyncSelectors();
    }
    private void SyncSelectors()
    {
        CurrentYear = LeftMonth.Year;
        CurrentMonth = LeftMonth.Month;
    }
    private void YearChanged(ChangeEventArgs e)
    {
        //LeftMonth = new DateTime(CurrentYear, LeftMonth.Month, 1);
        CurrentYear = int.Parse(e.Value!.ToString()!);
        UpdateLeftMonth();
    }

    private void MonthOrYearChanged(ChangeEventArgs e)
    {
        //LeftMonth = new DateTime(CurrentYear, CurrentMonth, 1);
        CurrentMonth = int.Parse(e.Value!.ToString()!);
        UpdateLeftMonth();
    }
    private void UpdateLeftMonth()
    {
        LeftMonth = new DateTime(CurrentYear, CurrentMonth, 1);
    }
    private async Task ApplyPreset(DateRangePreset preset)
    {
        var (start, end) = preset.GetRange();
        StartDate = Clamp(start);
        EndDate = Clamp(end);

        await StartDateChanged.InvokeAsync(StartDate);
        await EndDateChanged.InvokeAsync(EndDate);

        IsOpen = false;
    }

    private async Task Select(DateTime date)
    {
        if (!IsAllowed(date)) return;

        if (StartDate is null || EndDate is not null)
        {
            StartDate = date;
            EndDate = null;
            await StartDateChanged.InvokeAsync(StartDate);
            await EndDateChanged.InvokeAsync(null);
        }
        else if (date >= StartDate)
        {
            EndDate = date;
            await EndDateChanged.InvokeAsync(EndDate);
            IsOpen = false;
        }
        else
        {
            StartDate = date;
            await StartDateChanged.InvokeAsync(StartDate);
        }
    }

    private void Clear()
    {
        StartDate = null;
        EndDate = null;
        StartDateChanged.InvokeAsync(null);
        EndDateChanged.InvokeAsync(null);
    }

    private bool IsAllowed(DateTime d) =>
        (MinDate is null || d >= MinDate) &&
        (MaxDate is null || d <= MaxDate);

    private DateTime Clamp(DateTime d)
    {
        if (MinDate.HasValue && d < MinDate) return MinDate.Value;
        if (MaxDate.HasValue && d > MaxDate) return MaxDate.Value;
        return d;
    }
    private string RangeTooltip(DateTime d)
    {
        if (StartDate is null) return string.Empty;

        var end = EndDate ?? HoverDate;
        if (end is null) return string.Empty;

        return $"{StartDate:dd MMM yyyy} → {end:dd MMM yyyy}";
    }
    private RenderFragment BuildCalendar(DateTime month) => builder =>
    {
        var seq = 0;
        var first = new DateTime(month.Year, month.Month, 1);
        var start = first.AddDays(-(int)first.DayOfWeek);

        //builder.AddMarkupContent(seq++, $"<strong>{month:MMMM yyyy}</strong>");
        builder.OpenElement(seq++, "div");
        builder.AddAttribute(seq++, "class", "text-center fw-semibold mb-2");
        builder.AddContent(seq++, month.ToString("MMMM yyyy"));
        builder.CloseElement();

        /* Weekday header */
        builder.OpenElement(seq++, "div");
        builder.AddAttribute(seq++, "class", "row g-1 text-center fw-semibold small mb-1");

        foreach (var day in WeekDays)
        {
            builder.OpenElement(seq++, "div");
            builder.AddAttribute(seq++, "class", "col");
            builder.AddContent(seq++, day);
            builder.CloseElement();
        }

        builder.CloseElement(); // ✅ MISSING — closes weekday header row

        /* Dates grid */
        for (int w = 0; w < 6; w++)
        {
            builder.OpenElement(seq++, "div");
            builder.AddAttribute(seq++, "class", "row g-1");

            for (int d = 0; d < 7; d++)
            {
                var date = start.AddDays(w * 7 + d);

                builder.OpenElement(seq++, "div");
                builder.AddAttribute(seq++, "class", "col");

                builder.OpenElement(seq++, "button");
                builder.AddAttribute(seq++, "class", DayClass(date, month));
                builder.AddAttribute(seq++, "disabled", !IsAllowed(date));
                builder.AddAttribute(seq++, "onclick",
                    EventCallback.Factory.Create(this, () => Select(date)));

                builder.AddAttribute(seq++, "onmouseover",
  EventCallback.Factory.Create(this, () => HoverDate = date));

                builder.AddAttribute(seq++, "onmouseout",
                    EventCallback.Factory.Create(this, () => HoverDate = null));
                builder.AddAttribute(seq++, "title", RangeTooltip(date));

                builder.AddContent(seq++, date.Day);
                builder.CloseElement();

                builder.CloseElement();
            }

            builder.CloseElement();
        }
    };

    private string DayClass(DateTime d, DateTime month)
    {
        var css = "btn btn-sm w-100";

        if (d.Month != month.Month)
            return css + " btn-light disabled"; // overflow disabled

        if (StartDate == d || EndDate == d)
            return css + " btn-primary";

        if (StartDate.HasValue && EndDate.HasValue && d > StartDate && d < EndDate)
            return css + " btn-primary opacity-50";

        if (IsInPreviewRange(d))
            return css + " btn-primary opacity-50";

        return css + " btn-outline-secondary";
    }
    private bool IsInPreviewRange(DateTime d)
    {
        if (StartDate is null || EndDate is not null || HoverDate is null)
            return false;

        if (HoverDate < StartDate)
            return d >= HoverDate && d <= StartDate;

        return d >= StartDate && d <= HoverDate;
    }
    private static string Format(DateTime? d)
        => d?.ToString("yyyy-MM-dd") ?? "";
}



//public partial class DateRangePicker
//{
//    [Parameter] public DateTime? StartDate { get; set; }
//    [Parameter] public DateTime? EndDate { get; set; }
//    [Parameter] public EventCallback<DateTime?> StartDateChanged { get; set; }
//    [Parameter] public EventCallback<DateTime?> EndDateChanged { get; set; }

//    [Parameter] public DateTime? MinDate { get; set; }
//    [Parameter] public DateTime? MaxDate { get; set; }

//    private bool IsOpen;
//    private DateTime LeftMonth = DateTime.Today;
//    private DateTime RightMonth => LeftMonth.AddMonths(1);

//    private void Toggle() => IsOpen = !IsOpen;

//    private async Task ApplyPreset(DateRangePreset preset)
//    {
//        var (start, end) = preset.GetRange();

//        StartDate = Clamp(start);
//        EndDate = Clamp(end);

//        await StartDateChanged.InvokeAsync(StartDate);
//        await EndDateChanged.InvokeAsync(EndDate);

//        IsOpen = false;
//    }

//    private async Task Select(DateTime date)
//    {
//        if (!IsAllowed(date)) return;

//        if (StartDate is null || EndDate is not null)
//        {
//            StartDate = date;
//            EndDate = null;
//            await StartDateChanged.InvokeAsync(StartDate);
//            await EndDateChanged.InvokeAsync(null);
//        }
//        else if (date >= StartDate)
//        {
//            EndDate = date;
//            await EndDateChanged.InvokeAsync(EndDate);
//            IsOpen = false;
//        }
//        else
//        {
//            StartDate = date;
//            await StartDateChanged.InvokeAsync(StartDate);
//        }
//    }

//    private RenderFragment BuildCalendar(DateTime month) => builder =>
//    {
//        var seq = 0;
//        var first = new DateTime(month.Year, month.Month, 1);
//        var start = first.AddDays(-(int)first.DayOfWeek);

//        builder.OpenElement(seq++, "div");
//        builder.AddContent(seq++, $"<strong>{month:MMMM yyyy}</strong>");

//        for (int w = 0; w < 6; w++)
//        {
//            builder.OpenElement(seq++, "div");
//            builder.AddAttribute(seq++, "class", "row g-1");

//            for (int d = 0; d < 7; d++)
//            {
//                var date = start.AddDays(w * 7 + d);

//                builder.OpenElement(seq++, "div");
//                builder.AddAttribute(seq++, "class", "col");

//                builder.OpenElement(seq++, "button");
//                builder.AddAttribute(seq++, "class", DayClass(date, month));
//                builder.AddAttribute(seq++, "disabled", !IsAllowed(date));
//                builder.AddAttribute(seq++, "onclick",
//                    EventCallback.Factory.Create(this, () => Select(date)));
//                builder.AddContent(seq++, date.Day);
//                builder.CloseElement();

//                builder.CloseElement();
//            }

//            builder.CloseElement();
//        }

//        builder.CloseElement();
//    };

//    private bool IsAllowed(DateTime d) =>
//        (MinDate is null || d >= MinDate) &&
//        (MaxDate is null || d <= MaxDate);

//    private DateTime Clamp(DateTime d)
//    {
//        if (MinDate.HasValue && d < MinDate) return MinDate.Value;
//        if (MaxDate.HasValue && d > MaxDate) return MaxDate.Value;
//        return d;
//    }

//    private string DayClass(DateTime d, DateTime month)
//    {
//        var css = "btn btn-sm w-100";

//        if (d.Month != month.Month) return css + " btn-light disabled";
//        if (StartDate == d || EndDate == d) return css + " btn-primary";
//        if (StartDate.HasValue && EndDate.HasValue && d > StartDate && d < EndDate)
//            return css + " btn-primary opacity-50";

//        return css + " btn-outline-secondary";
//    }

//    private static string Format(DateTime? d)
//        => d?.ToString("yyyy-MM-dd") ?? "";
//}

//public partial class DateRangePicker
//{
//    [Parameter] public DateTime? StartDate { get; set; }
//    [Parameter] public DateTime? EndDate { get; set; }
//    [Parameter] public EventCallback<DateTime?> StartDateChanged { get; set; }
//    [Parameter] public EventCallback<DateTime?> EndDateChanged { get; set; }

//    private DateTime CurrentMonth = DateTime.Today;

//    private static readonly string[] WeekDays =
//        CultureInfo.CurrentCulture.DateTimeFormat
//            .ShortestDayNames;

//    private List<List<CalendarDay>> Calendar = new();

//    protected override void OnInitialized()
//        => BuildCalendar();

//    private void PrevMonth()
//    {
//        CurrentMonth = CurrentMonth.AddMonths(-1);
//        BuildCalendar();
//    }

//    private void NextMonth()
//    {
//        CurrentMonth = CurrentMonth.AddMonths(1);
//        BuildCalendar();
//    }

//    private async Task SelectDate(DateTime date)
//    {
//        if (StartDate is null || EndDate is not null)
//        {
//            StartDate = date;
//            EndDate = null;
//            await StartDateChanged.InvokeAsync(StartDate);
//            await EndDateChanged.InvokeAsync(null);
//        }
//        else if (date >= StartDate)
//        {
//            EndDate = date;
//            await EndDateChanged.InvokeAsync(EndDate);
//        }
//        else
//        {
//            StartDate = date;
//            await StartDateChanged.InvokeAsync(StartDate);
//        }
//    }

//    private void BuildCalendar()
//    {
//        Calendar.Clear();

//        var firstDay = new DateTime(CurrentMonth.Year, CurrentMonth.Month, 1);
//        var start = firstDay.AddDays(-(int)firstDay.DayOfWeek);

//        for (int w = 0; w < 6; w++)
//        {
//            var week = new List<CalendarDay>();

//            for (int d = 0; d < 7; d++)
//            {
//                var date = start.AddDays(w * 7 + d);

//                week.Add(new CalendarDay
//                {
//                    Date = date,
//                    IsCurrentMonth = date.Month == CurrentMonth.Month
//                });
//            }

//            Calendar.Add(week);
//        }
//    }

//    private string GetDayClass(CalendarDay day)
//    {
//        var css = "btn btn-sm w-100";

//        if (!day.IsCurrentMonth)
//            return css + " btn-light disabled";

//        if (StartDate == day.Date)
//            return css + " btn-primary";

//        if (EndDate == day.Date)
//            return css + " btn-primary";

//        if (StartDate.HasValue && EndDate.HasValue &&
//            day.Date > StartDate && day.Date < EndDate)
//            return css + " btn-primary opacity-50";

//        return css + " btn-outline-secondary";
//    }

//    private sealed class CalendarDay
//    {
//        public DateTime Date { get; set; }
//        public bool IsCurrentMonth { get; set; }
//    }
//}
