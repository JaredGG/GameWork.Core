using System.IO;

namespace GameWork.Core.IO.PlatformAdaptors
{
    /// <summary>
    /// Open file and return stream.
    /// </summary>
	public interface IFileLoader
	{
		Stream Load(string path);
	}
}