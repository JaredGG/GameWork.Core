using System.Collections.Generic;

namespace GameWork.Core.Audio.MultiClip
{
    /// <summary>
    /// Facilitates the construction of <see cref="MultiClipContainer"/>s.
    /// </summary>
	public class MultiClipContainerFactory
	{
		private readonly Dictionary<string, MultiClipContainerModel> _models = new Dictionary<string, MultiClipContainerModel>();

		public void AddModel(string id, MultiClipContainerModel model)
		{
			_models[id] = model;
		}

		public MultiClipContainer Create(string id)
		{
			return new MultiClipContainer(_models[id]);
		}
	}
}