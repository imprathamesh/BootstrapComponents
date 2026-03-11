namespace BootstrapComponents.Calendar
{
    public class CalendarEvent
    {
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Meta { get; set; }
        public string? Color { get; set; } = "var(--bs-primary)";
        public string? Status { get; set; }
    }

    public enum CalendarViewType
    {
        Month,
        Week,
        Day,
        List,
        FourDays
    }
}
