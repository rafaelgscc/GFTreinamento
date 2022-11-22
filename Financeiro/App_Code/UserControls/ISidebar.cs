/// <summary>
/// Summary description for UserControlsHelper
/// </summary>

namespace PROJETO
{
    public enum SidebarPositionEnum
    {
        Left = 1,
        Right = 2
    }

    public enum SidebarModeEnum
    {
        Inside = 1,
        Full = 2
    }
    public interface ISidebar
    {
        SidebarPositionEnum Position { get; set; }
        SidebarModeEnum Mode { get; set; }
        bool AutoOpen { get; set; }
        string Transition { get; set; }
        string Container { get; set; }
        string Opened { get; set; }
    }
}
