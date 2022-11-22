/// <summary>
/// Summary description for UserControlsHelper
/// </summary>

namespace PROJETO
{
    public enum HeaderPositionEnum
    {
        Fixed = 1,
        Dynamic = 2
    }
    public interface IHeader
    {
        HeaderPositionEnum Position { get; set; }
        string Transition { get; set; }
        string Container { get; set; }
    }
}
