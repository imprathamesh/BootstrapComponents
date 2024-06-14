namespace BootstrapComponents.Pagination;
public class TablePagination
{
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int Total { get; set; } = 0;
    public int Length { get => Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(Total) / PageSize)); }
}
