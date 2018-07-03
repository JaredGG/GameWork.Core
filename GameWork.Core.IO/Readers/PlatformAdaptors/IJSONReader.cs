using System.IO;
using GameWork.Core.Models.Interfaces;

namespace GameWork.Core.IO.Readers.PlatformAdaptors
{
    /// <summary>
    /// Read JSON from stream.
    /// </summary>
	public interface IJsonReader
	{
		TModel ConstructModel<TModel>(Stream stream) where TModel : IModel;
	}
}