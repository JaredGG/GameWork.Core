using GameWork.Core.Audio.Clip;

namespace GameWork.Core.Audio.Fade.Interfaces
{
    /// <summary>
    /// An individual Audio Clip Fade used by the <see cref="AudioController"/>.
    /// </summary>
	public interface IAudioFadeState
	{
	    AudioClipModel Clip { get; }

	    bool IsComplete { get; }

		float Volume { get; }

        float TargetVolume { get; }

        float Duration { get; }

	    void Tick(float deltaTime);
	}
}