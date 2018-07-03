using GameWork.Core.Audio.Clip;
using GameWork.Core.Audio.Fade.Interfaces;
using GameWork.Core.Math;

namespace GameWork.Core.Audio.Fade
{
    /// <summary>
    /// A default implementation of <see cref="IAudioFadeState"/> that applies a linear fade.
    /// </summary>
	public class AudioFadeState : IAudioFadeState
	{
	    private readonly AudioFadeModel _model;

	    private float _elapsedTime;

        public AudioClipModel Clip { get; }

        public bool IsComplete => _model.Duration <= _elapsedTime;

	    public float Volume => MathF.Lerp(_model.StartVolume, _model.TargetVolume, _elapsedTime / _model.Duration);

	    public float TargetVolume => _model.TargetVolume;

	    public float Duration => _model.Duration;

	    public AudioFadeState(AudioClipModel clip, float startVolume, float targetVolume, float duration)
		{
			Clip = clip;
		    _model = new AudioFadeModel(startVolume, targetVolume, duration);
		}

        public void Tick(float deltaTime)
        {
            _elapsedTime += deltaTime;
        }
    }
}