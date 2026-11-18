namespace BootstrapComponents.Navbar;

using Microsoft.AspNetCore.Components.Routing;

/// <summary>
/// A primary item displayed in the sidebar rail.
/// It can optionally contain sections and groups in the submenu.
/// </summary>
public class BarItem
{
    /// <summary>
    /// Primary sidebar item.
    /// </summary>
    public NavSideBarItem Item { get; set; } = new();

    /// <summary>
    /// Sections displayed in the submenu.
    /// </summary>
    public List<NavSideBarSection> Sections { get; set; } = [];
}


/// <summary>
/// A section in the sidebar submenu.
/// Example: Dashboard Types, Report Summaries, Business Intelligence.
/// </summary>
public class NavSideBarSection
{
    /// <summary>
    /// Section title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Groups contained in this section.
    /// </summary>
    public List<NavSideBarItem> Links { get; set; } = [];
    public List<NavSideBarItemGroup> Groups { get; set; } = [];
}


/// <summary>
/// A group containing navigation links.
/// Example: Executive Summary, Operations Dashboard.
/// </summary>
public class NavSideBarItemGroup
{
    /// <summary>
    /// Group title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Bootstrap Icons class.
    /// Example: bi bi-calendar3
    /// </summary>
    public string Icon { get; set; } = string.Empty;

    /// <summary>
    /// Links contained in the group.
    /// </summary>
    public List<NavSideBarItem> Items { get; set; } = [];
}


/// <summary>
/// A navigation link.
/// </summary>
public class NavSideBarItem
{
    /// <summary>
    /// Title of the link.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// URL of the link.
    /// </summary>
    public string Url { get; set; } = "/";

    /// <summary>
    /// Bootstrap Icons class.
    /// Example: bi bi-grid-1x2
    /// </summary>
    public string Icon { get; set; } = string.Empty;

    /// <summary>
    /// Display in mobile bottom navigation.
    /// </summary>
    public bool MobileMenu { get; set; }

    /// <summary>
    /// Exact URL match or prefix match.
    /// </summary>
    public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;

    /// <summary>
    /// Display a separator before this item.
    /// </summary>
    public bool ShowSeparator { get; set; }

    /// <summary>
    /// Indicates whether this item is active.
    /// </summary>
    public bool IsActive { get; set; }
}