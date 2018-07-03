using GameWork.Core.Audio.Clip;
using GameWork.Core.Utilities;

namespace GameWork.Core.Audio.MultiClip
{
    /// <summary>
    /// A container of <see cref="AudioClipModel"/>s that provides different ways and orders of accessing the individual items.
    /// </summary>
	public class MultiClipContainer
	{
		private readonly MultiClipContainerModel _model;

		private int _previousIndex = int.MinValue;

		public MultiClipContainer(MultiClipContainerModel model)
		{
			_model = model;
		}

		public AudioClipModel GetRandom()
		{
			var randomIndex = RandomUtil.Next(_model.Clips.Length);
			return _model.Clips[randomIndex];
		}

		public AudioClipModel GetDifferentRandom()
		{
			var randomIndex = RandomUtil.Next(_model.Clips.Length);

			if(_previousIndex == randomIndex)
			{
				randomIndex = (randomIndex + 1) % _model.Clips.Length;
			}

		    _previousIndex = randomIndex;

			return _model.Clips[randomIndex];
		}

	    public AudioClipModel GetNext()
	    {
	        _previousIndex = (_previousIndex + 1) % _model.Clips.Length;
	        return _model.Clips[_previousIndex];
	    }
	}
}