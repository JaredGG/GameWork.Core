using System;
using GameWork.Core.Audio.Fade.Interfaces;
using GameWork.Core.Audio.Clip;

namespace GameWork.Core.Audio.Fade
{
    /// <summary>
    /// An implementation of <see cref="IAudioFadeState"/> that linearly fades multiple <see cref="AudioClipModel"/>s at the same time.
    /// </summary>
	public class AudioMultiFadeState : IAudioFadeState
	{
	    private readonly AudioFadeModel[] _audioFadeModels;
        private AudioFadeModel _currentModel;
	    private float _completedDurations;
	    private float _elapsedTime;

        public AudioClipModel Clip { get; }

        public bool IsComplete => _completedDurations + _currentModel.Duration <= _elapsedTime;

	    public float Volume => Math.MathF.Lerp(_currentModel.StartVolume,
	        _currentModel.TargetVolume,
	        (_elapsedTime - _completedDurations) / _currentModel.Duration);

	    public float TargetVolume => _currentModel.TargetVolume;

	    public float Duration => _currentModel.Duration;

	    public AudioMultiFadeState(AudioClipModel clip, params AudioFadeModel[] audioFadeModels)
		{
			Clip = clip;

		    _audioFadeModels = audioFadeModels;
            _currentModel = audioFadeModels[0];
        }

		public void Tick(float deltaTime)
        {
            _elapsedTime += deltaTime;

	        var nextModelIndex = Array.IndexOf(_audioFadeModels, _currentModel) + 1;

            while (_completedDurations + _currentModel.Duration < _elapsedTime)
            {
                if (nextModelIndex < _audioFadeModels.Length)
                {
                    _completedDurations += _currentModel.Duration;
                    _currentModel = _audioFadeModels[nextModelIndex];
                    nextModelIndex++;
                }
                else
                {
                    break;
                }
            }
	    }	
	}
}