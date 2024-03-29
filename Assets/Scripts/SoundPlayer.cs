using UnityEngine;

namespace LyeJam
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _musicPlayer;
        [SerializeField] private SoundList _soundList;

        public static SoundPlayer Instance;

        private AudioSource _audioSource;

        public enum AudioEnum
        {
            Madeira,
            Tick,
            TutaVoz,
        }

        public enum MusicEnum
        {
            Menu,
            ingame,
            ingameGlitch,
            vitoria,
            derrota,
            pause,
            endLevel1,
            endLevel2,
            endLevel3,
            endLevel4,
        }
        
        public void InitializeAudioPlayer()
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayAudio(AudioEnum enumValue)
        {
            if(GetAudioClip(enumValue, out AudioClip clip))
            {
                _audioSource.PlayOneShot(clip);
            }
        }

        public bool GetAudioClip(AudioEnum enumValue, out AudioClip clip)
        {
             if((int)enumValue < _soundList.AudioClips.Count)
            {
                clip = _soundList.AudioClips[(int)enumValue];
                if(clip != null)
                return true;
            }

            clip = null;
            return false;
        }

        public bool GetMusic(MusicEnum enumValue, out AudioClip clip)
        {
             if((int)enumValue < _soundList.Musics.Count)
            {
                clip = _soundList.Musics[(int)enumValue];
                if(clip != null)
                return true;
            }

            clip = null;
            return false;
        }

        public void SetMusic(MusicEnum music)
        {
            StopMusic();
            if(GetMusic(music, out AudioClip clip))
            {
                _musicPlayer.clip = clip;
                _musicPlayer.Play();
            }
        }

        public void StopMusic()
        {
            _musicPlayer.Stop();
        }

        private void Awake()
        {
            InitializeAudioPlayer();
        }
    }
}
