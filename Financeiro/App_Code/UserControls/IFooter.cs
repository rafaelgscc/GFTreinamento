/// <summary>
/// Summary description for UserControlsHelper
/// </summary>

namespace PROJETO
{
    public enum FooterPositionEnum
    {
        Fixed = 1,
        Dynamic = 2
    }
	public interface IFooter
    {
        FooterPositionEnum Position { get; set; }
        string Transition { get; set; }
        string Container { get; set; }
    }
}
