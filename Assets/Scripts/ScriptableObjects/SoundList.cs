using System.Collections.Generic;
using UnityEngine;

namespace LyeJam
{
    [CreateAssetMenu(fileName = "SoundList", menuName = "LyeJam/Sound List")]
    public class SoundList : ScriptableObject
    {
        [EnumNamedList(typeof(SoundPlayer.AudioEnum))]
        public List<AudioClip> AudioClips;
        
        [EnumNamedList(typeof(SoundPlayer.MusicEnum))]
        public List<AudioClip> Musics;
    }
}
