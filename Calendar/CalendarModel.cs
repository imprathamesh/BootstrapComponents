namespace BootstrapComponents.Calendar
{
    public record CalendarEvent(
    DateTime Date,
    string Title,
    string? Subtitle = null,
    string? Meta = null,
    string? Color = null,
    string? Status = null
);

    public enum CalendarViewType
    {
        Month,
        Week,
        Day,
        List
    }

}
