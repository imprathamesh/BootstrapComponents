using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace BootstrapComponents.Pickers;

public partial class DatePicker
{
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    [Parameter] public DateTime? Value { get; set; }
    [Parameter] public EventCallback<DateTime?> ValueChanged { get; set; }
    [Parameter] public int StartYear { get; set; } = DateTime.Today.Year - 30;
    [Parameter] public int EndYear { get; set; } = DateTime.Today.Year;
    [Parameter] public DateTime? MinDate { get; set; } = DateTime.Today.AddYears(-50);
    [Parameter] public DateTime? MaxDate { get; set; } = DateTime.Today.AddYears(5);
    bool IsOpen;

    // ✅ Single source of truth
    DateTime CurrentMonth;
    int currentMonth;
    int currentYear;

    protected override void OnInitialized()
    {
        var baseDate = Value ?? DateTime.Today;
        CurrentMonth = new DateTime(baseDate.Year, baseDate.Month, 1);
        SelectedDate = Value?.Date;
        currentYear = CurrentMonth.Year;
        currentMonth = CurrentMonth.Month;
    }
    private void MonthChanged(ChangeEventArgs e)
    {
        //LeftMonth = new DateTime(CurrentYear, CurrentMonth, 1);
        currentMonth = int.Parse(e.Value!.ToString()!);
        UpdateLeftMonth();
    }
    private void YearChanged(ChangeEventArgs e)
    {
        //LeftMonth = new DateTime(CurrentYear, LeftMonth.Month, 1);
        currentYear = int.Parse(e.Value!.ToString()!);
        UpdateLeftMonth();
    }
    private void UpdateLeftMonth()
    {
        CurrentMonth = new DateTime(currentYear, currentMonth, 1);
    }
    string DisplayValue =>
        Value.HasValue ? Value.Value.ToString("dd MMM yyyy") : string.Empty;

    void Toggle() => IsOpen = !IsOpen;
    void Close() => IsOpen = false;

    void PrevMonth()
    {
        CurrentMonth = CurrentMonth.AddMonths(-1);
        SyncSelectors();
    }

    void NextMonth()
    {
        CurrentMonth = CurrentMonth.AddMonths(1);
        SyncSelectors();
    }
    private void SyncSelectors()
    {
        currentYear = CurrentMonth.Year;
        currentMonth = CurrentMonth.Month;
    }
    async Task Clear()
    {
        SelectedDate = null;
        Value = null;
        await ValueChanged.InvokeAsync(null);
        Close();
    }

    async Task SelectDate(DateTime date)
    {
        SelectedDate = date.Date;
        Value = SelectedDate;
        await ValueChanged.InvokeAsync(Value);
        Close();
    }

    /* ---------------- CALENDAR ---------------- */

    private static readonly string[] WeekDays =
        CultureInfo.CurrentCulture.DateTimeFormat.ShortestDayNames;

    private RenderFragment BuildCalendar(DateTime month) => builder =>
    {
        var seq = 0;
        var first = new DateTime(month.Year, month.Month, 1);
        var start = first.AddDays(-(int)first.DayOfWeek);

        /* Month header */
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

        builder.CloseElement();

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
                builder.AddAttribute(seq++, "type", "button");
                builder.AddAttribute(seq++, "class", DayClass(date, month));
                builder.AddAttribute(seq++, "disabled", date.Month != month.Month);
                builder.AddAttribute(seq++, "onclick",
                    EventCallback.Factory.Create(this, () => SelectDate(date)));

                builder.AddContent(seq++, date.Day);
                builder.CloseElement(); // button

                builder.CloseElement(); // col
            }

            builder.CloseElement(); // row
        }
    };

    DateTime? SelectedDate;

    string DayClass(DateTime date, DateTime month)
    {
        var cls = "btn btn-sm w-100 ";

        if (date.Month != month.Month)
            cls += "text-muted ";

        if (SelectedDate == date.Date)
            cls += "btn-primary";
        else
            cls += "btn-light";

        return cls;
    }
    async Task SelectToday()
    {
        var today = DateTime.Today;

        SelectedDate = today;
        CurrentMonth = new DateTime(today.Year, today.Month, 1);

        Value = today;
        await ValueChanged.InvokeAsync(Value);
        Close();
    }

}
