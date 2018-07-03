using GameWork.Core.Audio.Clip;
using GameWork.Core.Models.Interfaces;

namespace GameWork.Core.Audio.MultiClip
{
    /// <summary>
    /// Stores the <see cref="AudioClipModel"/>s used by the <see cref="MultiClipContainer"/>.
    /// </summary>
	public class MultiClipContainerModel : IModel
	{
		public AudioClipModel[] Clips { get; set; }
	}
}