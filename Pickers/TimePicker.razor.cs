using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BootstrapComponents.Pickers;

public partial class TimePicker
{
    bool isHourClicked = false;
    void GetHour(int id)
    {
        HourInput = id;
        isHourClicked = true;
    }
    void GetMinute(int id)
    {
        if (isHourClicked)
        {
            if (id == 60)
            {
                MinuteInput = 00;
            }
            else
            {
                MinuteInput = id;
            }
        }
        isHourClicked = false;
        Close();
    }

    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
    [Parameter] public TimeSpan? Value { get; set; }
    [Parameter] public EventCallback<TimeSpan?> ValueChanged { get; set; }
    [Parameter] public bool Is24Hour { get; set; } = false;
    bool IsOpen;
    bool IsAM = true;
    void Toggle() => IsOpen = !IsOpen;
    void Close() => IsOpen = false;

    int HourInput
    {
        get => Value?.Hours ?? 0;
        set => UpdateTime(value, MinuteInput);
    }

    int MinuteInput
    {
        get => Value?.Minutes ?? 0;
        set => UpdateTime(HourInput, value);
    }

    string DisplayTime
    {
        get
        {
            if (Value is null)
                return string.Empty;

            var dt = DateTime.Today.Add(Value.Value);

            return Is24Hour
                ? dt.ToString("HH:mm")
                : dt.ToString("hh:mm tt");
        }
    }
    protected override void OnParametersSet()
    {
        if (Value.HasValue && !Is24Hour)
            IsAM = Value.Value.Hours < 12;
    }



    void HandleKey(KeyboardEventArgs e)
    {
        if (e.Key == "Escape")
            IsOpen = false;
    }
    void UpdateTime(int hour, int minute)
    {
        minute = Math.Clamp(minute, 0, 59);

        if (Is24Hour)
        {
            hour = Math.Clamp(hour, 0, 23);
        }
        else
        {
            hour = Math.Clamp(hour, 1, 12);

            if (hour == 12) hour = 0;

            if (!IsAM) hour += 12;
        }

        Value = new TimeSpan(hour, minute, 0);

        ValueChanged.InvokeAsync(Value);
    }
    void SelectHour(int hour) => HourInput = hour;
    void SelectMinute(int minute) => MinuteInput = minute;

    void SetAmPm(bool am)
    {
        IsAM = am;
        UpdateTime(HourInput, MinuteInput);
    }

    void SetNow()
    {
        var now = DateTime.Now;
        Value = new TimeSpan(now.Hour, now.Minute, 0);
        ValueChanged.InvokeAsync(Value);
        IsOpen = false;
    }

    void Clear()
    {
        Value = null;
        ValueChanged.InvokeAsync(Value);
        IsOpen = false;
    }

}