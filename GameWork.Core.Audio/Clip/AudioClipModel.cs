using GameWork.Core.Models.Interfaces;

namespace GameWork.Core.Audio.Clip
{
    /// <summary>
    /// An individual Audio Clip used by the <see cref="AudioController"/>.
    /// </summary>
    public class AudioClipModel : IModel
    {
        public string Name { get; set; }

        public float TargetVolume { get; set; }

        public float Duration { get; set; }
    }
}