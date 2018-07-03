namespace GameWork.Core.Audio.PlatformAdaptors
{
    /// <summary>
    /// To be overridden by the platform specific implementation.
    /// </summary>
    public interface IAudioChannelFactory
    {
        IAudioChannel Create();
    }
}
