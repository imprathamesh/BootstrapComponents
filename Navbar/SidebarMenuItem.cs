using Microsoft.AspNetCore.Components.Routing;

namespace BootstrapComponents.Navbar;


public class SidebarMenuItem : ISidebarMenuItem
{
    /// <summary>
    /// Title of link
    /// </summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Url of the link
    /// </summary>
    public string Url { get; set; } = "/";
    /// <summary>
    /// Bootstrap Icons class eg. bi bi-grid-1x2
    /// </summary>
    public string Icon { get; set; } = string.Empty;
    /// <summary>
    /// Display in mobile bottom navigation
    /// </summary>
    public bool MobileMenu { get; set; }
    /// <summary>
    /// Exact URL match or prefix match
    /// </summary>
    public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;
    /// <summary>
    /// Optional separator before this item
    /// </summary>
    public bool ShowSeparator { get; set; }
}
public class SidebarMenuItemGroup : ISidebarMenuItem
{
    /// <summary>
    /// Title of link
    /// </summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Bootstrap Icons class eg. bi bi-grid-1x2
    /// </summary>
    public string Icon { get; set; } = string.Empty;
    /// <summary>
    /// List of links under the group
    /// </summary>
    public List<SidebarMenuItem> Items { get; set; } = [];
}
public interface ISidebarMenuItem
{
    string Title { get; set; }
}