using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapComponents
{
    public class SidebarItem
    {
        public string Text { get; set; } = string.Empty;

        public string Icon { get; set; } = string.Empty;

        public string? Href { get; set; }

        public string? Tooltip { get; set; }

        public bool IsActive { get; set; }

        public bool IsDivider { get; set; }

        public List<SidebarItem> Children { get; set; } = [];
    }
    public class SidebarGroup
    {
        public string Title { get; set; } = string.Empty;

        public List<SidebarItem> Items { get; set; } = [];
    }
}
